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

        private readonly int Angle = new Random().Next(0, 180);
        Settings Settings;
        public MainForm(Settings settings) {
            Settings = settings;
            InitializeComponent();

            TopMost = true;
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;       
        }

        protected override void OnPaintBackground(PaintEventArgs e) {
            base.OnPaintBackground(e);
            // Установка градиента
            e.Graphics.FillRectangle(new LinearGradientBrush(Bounds, Color.Black, Color.Black, Angle), Bounds);
        }

        private void MainForm_Load(object sender, EventArgs e) {
            if (Settings == null) return;

            var table = new TableLayoutPanelDoubleBuffered {
                Dock = DockStyle.Fill,
            };
            var rows = Math.Ceiling((double)Settings.Apps.Count / Settings.Colomns);

            for (int i = 0; i < rows; i++)
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / Settings.Colomns));


            for (int i = 0; i < Settings.Apps.Count; i++) {
                var width = Convert.ToInt32((double)Width / Settings.Colomns);
                var height = Convert.ToInt32(Height / rows);

                var app = Settings.Apps[i];
                var appCard = new AppCard(app, new Size(width, height));

                var colomn = i % Settings.Colomns;
                var row = (int)Math.Ceiling((double)(i + 1) / Settings.Colomns);
                table.Controls.Add(appCard, colomn, row - 1);
            }

            Controls.Add(table);
        }
    }
}
