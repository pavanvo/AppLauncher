using AppLauncher.Controls;
using AppLauncher.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppLauncher {
    public partial class MainForm : Form {

        private const string FileName = "Settings.json";

        private readonly int Angle = new Random().Next(0, 180);

        public MainForm() {
            InitializeComponent();

            TopMost = true;
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
        }

        protected override void OnPaintBackground(PaintEventArgs e) {
            base.OnPaintBackground(e);
            // Установка градиента
            e.Graphics.FillRectangle(new LinearGradientBrush(Bounds, Color.FromArgb(64, 176, 255), Color.Black, Angle), Bounds);
        }

        Settings LoadSettings() {
            if (File.Exists(FileName)) {
                var text = File.ReadAllText(FileName);
                var settings = JsonConvert.DeserializeObject<Settings>(text);
                return settings;
            }
            return null;
        }

        private void MainForm_Load(object sender, EventArgs e) {
            var settings = LoadSettings();

            var table = new TableLayoutPanelDoubleBuffered {
                Dock = DockStyle.Fill,
            };
            var rows = Math.Ceiling((double)settings.Apps.Count / settings.Colomns);

            for (int i = 0; i < rows; i++) 
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / settings.Colomns));


            for (int i = 0; i < settings.Apps.Count; i++) {
                var width = Convert.ToInt32((double)Width / settings.Colomns);
                var height = Convert.ToInt32(Height / rows);

                var app = settings.Apps[i];
                var appCard = new AppCard(app, new Size(width, height));

                var colomn = i % settings.Colomns;
                var row = (int)Math.Ceiling((double)(i + 1) / settings.Colomns);
                table.Controls.Add(appCard, colomn, row - 1);
            }

            Controls.Add(table);
        }
    }
}
