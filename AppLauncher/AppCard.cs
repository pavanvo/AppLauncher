using AppLauncher.Helpers;
using AppLauncher.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace AppLauncher {
    public partial class AppCard : UserControl {

        private static bool IsRunning = false;

        private static readonly string[] MediaOptions = {
            $"input-repeat={int.MaxValue}", // Loop
            ":avcodec-hw=dxva2", //Should enable GPU acceleration
        };

        private string Executable { get; set; }

        public AppCard(App app, Size size) {
            InitializeComponent();

            Width = size.Width - Margin.Horizontal;
            Height = size.Height - Margin.Vertical;

            labelName.Text = app.Name;
            labelPrice.Text = app.Price + ""; labelPrice.Move2Centr();
            Executable = app.ExecPath;
            switch (app.Promo.PromoType) {
                case PromoType.Video: InitVideo(app.Promo.FilePath); break;
                case PromoType.Image: InitImage(app.Promo.FilePath); break;
            }
        }

        private async void AppCard_Click(object sender, EventArgs e) {

            if (!IsRunning) {
                try {
                    IsRunning = true;
                    this.ParentForm.TopMost = false;
                    var result = await ProcessHelper.RunProcessAsync(Executable, "");
                    this.ParentForm.TopMost = true;
                    IsRunning = false;
                } finally {
                    IsRunning = false;
                }
            }
        }

        private void AppCard_Load(object sender, EventArgs e) {

        }

        private void InitVideo(string media) {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            var libDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));

            vlcControl.BeginInit();
            vlcControl.VlcLibDirectory = libDirectory;
            vlcControl.EndInit();

            vlcControl.Audio.IsMute = true;
            vlcControl.SetMedia(new Uri(media), MediaOptions);
            var vlcMedia = vlcControl.GetCurrentMedia();
            vlcMedia.Parse();

            var track = vlcMedia.Tracks.FirstOrDefault();
            if (track?.Type == MediaTrackTypes.Video) {
                vlcControl.Video.IsMouseInputEnabled = false;
                vlcControl.Video.IsKeyInputEnabled = false;

                var trackInfo = (track.TrackInfo as VideoTrack);
                Resize((int)trackInfo.Width, (int)trackInfo.Height);
            }

            vlcControl.Click += (o, e) => AppCard_Click(o, e);
            vlcControl.Play();
        }

        private void InitImage(string media) {
            Controls.Remove(vlcControl);

            var image = Image.FromFile(media);
            Resize(image.Width, image.Height);

            var pictreBox = new PictureBox {
                Bounds = vlcControl.Bounds,
                BackgroundImage = image,
                BackgroundImageLayout = ImageLayout.Zoom,
                Dock = DockStyle.Bottom,
            };
            pictreBox.Click += (o, e) => AppCard_Click(o, e);

            Controls.Add(pictreBox);
        }

        private new void Resize(int width, int height) {
            var coef = (double)width / Width;

            height = Convert.ToInt32(height / coef);
            var diff = Height - labelName.Height - height;
            Height -= diff;

            var vertical = (diff - Margin.Vertical) / 2;
            var horizontal = Margin.Horizontal / 2;
            Margin = new Padding(horizontal, vertical, horizontal, vertical);
        }
    }
}
