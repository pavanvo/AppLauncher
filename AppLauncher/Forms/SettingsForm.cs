using AppLauncher.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppLauncher {
    public partial class SettingsForm : Form {

        private const string FileName = "Settings.json";

        public SettingsForm() {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e) {
            comboBoxPromo.DataSource = Enum.GetValues(typeof(PromoType));
            var settings = LoadSettings();
            FillSetting(settings);
        }

        void FillSetting(Settings settings) {
            numericColomns.Value = settings.Colomns;
            listBox.DataSource = null;
            listBox.DataSource = settings.Apps;
        }

        void FillApp(App app) {
            textBoxName.Text = app.Name;
            numericPrice.Value = app.Price;
            comboBoxPromo.SelectedItem = app.Promo.PromoType;
            textBoxPromo.Text = app.Promo.FilePath;
            textBoxExec.Text = app.ExecPath;
        }

        Settings ParseSettings() {
            var settings = new Settings {
                Colomns = Convert.ToInt32(numericColomns.Value),
            };

            settings.Apps = listBox.Items.Cast<App>().ToList();

            return settings;
        }

        App ParseApp() {
            Enum.TryParse(comboBoxPromo.SelectedValue.ToString(), out PromoType promoType);

            var app = new App {
                Name = textBoxName.Text,
                Price = Convert.ToInt32(numericPrice.Value),
                Promo = new Promo {
                    PromoType = promoType,
                    FilePath = textBoxPromo.Text,
                },
                ExecPath = textBoxExec.Text,
            };

            return app;
        }

        void SaveSettings(Settings settings) {
            var text = JsonConvert.SerializeObject(settings);
            File.WriteAllText(FileName, text);
        }

        Settings LoadSettings() {
            if (File.Exists(FileName)) {
                var text = File.ReadAllText(FileName);
                var settings = JsonConvert.DeserializeObject<Settings>(text);
                return settings;
            }
            return null;
        }

        private void buttonAdd_Click(object sender, EventArgs e) {
            var app = ParseApp();
            var settings = ParseSettings();

            settings.Apps.Add(app);
            FillSetting(settings);

            SaveSettings(settings);
        }

        private void buttonEdit_Click(object sender, EventArgs e) {
            if (listBox.SelectedItem is App) {
                var settings = ParseSettings();

                var app = ParseApp();
                settings.Apps[listBox.SelectedIndex] = app;
                FillSetting(settings);

                SaveSettings(settings);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e) {
            if (listBox.SelectedItem is App app) {
                var settings = ParseSettings();

                settings.Apps.Remove(app);
                FillSetting(settings);

                SaveSettings(settings);
            }
        }

        private void buttonSelectExec_Click(object sender, EventArgs e) {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK) {
                textBoxExec.Text = dialog.FileName;
            }
        }

        private void buttonSelectPromo_Click(object sender, EventArgs e) {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK) {
                textBoxPromo.Text = dialog.FileName;
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (listBox.SelectedItem is App app) {
                FillApp(app);
            }
        }
    }
}
