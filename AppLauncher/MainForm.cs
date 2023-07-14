using AppLauncher.Controls;
using AppLauncher.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppLauncher {
    public partial class MainForm : Form {
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

        Settings fill() {
            var settings = new Settings {
                Colomns = 3,
            };


            var app = new App {
                Name = "Test",
                Promo = new Promo {
                    PromoType = PromoType.Video,
                    FilePath = @"C:\Users\Tester\Desktop\Test\1.MOV"
                },
                Price = 300,
                ExecPath = @"C:\Users\Tester\Downloads\BrainTraining.exe"
            }; 
            
            var app1 = new App {
                Name = "Железная дорога",
                Promo = new Promo {
                    PromoType = PromoType.Image,
                    FilePath = @"C:\Users\Tester\Desktop\Test\Железная дорога.jpg"
                },
                Price = 300,
                ExecPath = @"C:\Users\Tester\Downloads\BrainTraining.exe"
            };        

            settings.Apps.Add(app);
            settings.Apps.Add(app1);
            settings.Apps.Add(app1);
            settings.Apps.Add(app1);

            return settings;
        }

        private void MainForm_Load(object sender, EventArgs e) {
            var settings = fill();

            var table = new TableLayoutPanelDoubleBuffered {
                Dock = DockStyle.Fill,
            };
            var rows = Math.Ceiling((double)settings.Apps.Count / settings.Colomns);

            for (int i = 0; i < rows; i++) 
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / settings.Colomns));


            for (int i = 0; i < settings.Apps.Count; i++) {
                var app = settings.Apps[i];
                var width = Convert.ToInt32((double)Width / settings.Colomns);
                var height = Convert.ToInt32(Height / rows);
                var appCard = new AppCard(app, new Size(width, height));

                var colomn = i % settings.Colomns;
                var row = (int)Math.Ceiling((double)(i + 1) / settings.Colomns);
                table.Controls.Add(appCard, colomn, row - 1);
            }

            Controls.Add(table);
        }
    }
}
