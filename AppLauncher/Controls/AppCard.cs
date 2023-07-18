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

        private readonly Timer Timer = new Timer();
        const int SECONDS_2_EXIT = 10;
        int Seconds2Exit = SECONDS_2_EXIT;

        private static bool IsRunning = false;

        private static readonly string[] MediaOptions = {
            $"input-repeat={int.MaxValue}", // Loop
            ":avcodec-hw=dxva2", //Should enable GPU acceleration
        };

        private string Executable { get; set; }

        private void TransparentPanel_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                Timer.Start();
            }
        }

        private void TransparentPanel_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                Timer.Stop();
                Seconds2Exit = SECONDS_2_EXIT;
            }
        }

        public AppCard(App app, Size size) {
            InitializeComponent();

            Timer.Interval = 1000;
            Timer.Tick += (o, e) => { Seconds2Exit--; if (Seconds2Exit < 0) Application.Exit(); Console.WriteLine(Seconds2Exit); };

            Width = size.Width - Margin.Horizontal;
            Height = size.Height - Margin.Vertical;

            labelName.Text = app.Name; labelName.Width = Width; labelName.Move2HCentr();

            labelPrice.Text = app.Price + ""; labelPrice.Move2HCentr();

            vlcControl.Width = Width - Margin.Horizontal; vlcControl.Move2HCentr();

            Executable = app.ExecPath;

            switch (app.Promo.PromoType) {
                case PromoType.Video: InitVideo(app.Promo.FilePath); break;
                case PromoType.Image: InitImage(app.Promo.FilePath); break;
            }

            var TransparentPanel = new Controls.TransparentPanel();
            TransparentPanel.Click += (o, e) => AppCard_Click(o, e);
            TransparentPanel.MouseDown += TransparentPanel_MouseDown;
            TransparentPanel.MouseUp += TransparentPanel_MouseUp;
            TransparentPanel.SetBounds(0, 0, Width, Height);
            Controls.Add(TransparentPanel);
            TransparentPanel.BringToFront();
        }

        protected override void OnPaint(PaintEventArgs e) {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.White, ButtonBorderStyle.Solid);
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
                var trackInfo = (track.TrackInfo as VideoTrack);
                Resize((int)trackInfo.Width, (int)trackInfo.Height);
            }

            vlcControl.Play();
        }

        private void InitImage(string media) {
            var image = Image.FromFile(media);
            Resize(image.Width, image.Height);

            var pictreBox = new PictureBox {
                Anchor = vlcControl.Anchor,
                Bounds = vlcControl.Bounds,
                BackgroundImage = image,
                BackgroundImageLayout = ImageLayout.Zoom,
            };
            Controls.Remove(vlcControl);
            Controls.Add(pictreBox);
        }

        private new void Resize(int width, int height) {
            var coef = (double)width / Width;

            var heightNew = Convert.ToInt32(height / coef);
            var diff = Height - labelName.Height - heightNew;
            Height -= diff;

            var vertical = (diff - Margin.Vertical) / 2;
            var horizontal = Margin.Horizontal / 2;
            Margin = new Padding(horizontal, vertical, horizontal, vertical);

            vlcControl.Width = Width - vlcControl.Margin.Horizontal;
            coef = (double)width / vlcControl.Width;
            heightNew = Convert.ToInt32(height / coef);
            vlcControl.Top = vlcControl.Top - (heightNew - vlcControl.Height);
            vlcControl.Height = heightNew;
        }
    }
}
