using AppLauncher.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppLauncher {
    static class Program {
        private const string FileName = "Settings.json";

        static Settings LoadSettings() {
            if (File.Exists(FileName)) {
                var text = File.ReadAllText(FileName);
                var settings = JsonConvert.DeserializeObject<Settings>(text);
                return settings;
            }
            return null;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            var settings = LoadSettings();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Contains("setup") || settings == null) Application.Run(new SettingsForm(settings)); 
            else Application.Run(new MainForm(settings));
           
        }
    }
}
