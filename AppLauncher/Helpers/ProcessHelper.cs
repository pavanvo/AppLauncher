using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AppLauncher.Helpers {
    class ProcessHelper {

        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(HandleRef hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr WindowHandle);
        public const int SW_RESTORE = 9;

        public static async Task<int> RunProcessAsync(string fileName, string args) {
            using (var process = new Process {
                StartInfo = {
                    FileName = fileName, Arguments = args,
                    UseShellExecute = false, CreateNoWindow = true,
                    RedirectStandardOutput = true, RedirectStandardError = true
                },
                EnableRaisingEvents = true
            }) {
                return await RunProcessAsync(process).ConfigureAwait(false);
            }
        }
        private static Task<int> RunProcessAsync(Process process) {
            var tcs = new TaskCompletionSource<int>();

            process.Exited += (s, ea) => tcs.SetResult(process.ExitCode);
            process.OutputDataReceived += (s, ea) => { if (string.IsNullOrWhiteSpace(ea.Data)) Console.WriteLine(ea.Data); };
            process.ErrorDataReceived += (s, ea) => { if (string.IsNullOrWhiteSpace(ea.Data)) Console.WriteLine("ERR: " + ea.Data); };

            bool started = process.Start();
            if (!started) {
                //you may allow for the process to be re-used (started = false) 
                //but I'm not sure about the guarantees of the Exited event in such a case
                throw new InvalidOperationException("Could not start process: " + process);
            }

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            ShowWindowAsync(new HandleRef(null, process.MainWindowHandle), SW_RESTORE);
            SetForegroundWindow(process.MainWindowHandle);

            return tcs.Task;
        }
    }
}
