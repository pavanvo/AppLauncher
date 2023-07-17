
namespace AppLauncher {
    partial class SettingsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.numericColomns = new System.Windows.Forms.NumericUpDown();
            this.listBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.numericPrice = new System.Windows.Forms.NumericUpDown();
            this.buttonSelectExec = new System.Windows.Forms.Button();
            this.textBoxExec = new System.Windows.Forms.TextBox();
            this.buttonSelectPromo = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxPromo = new System.Windows.Forms.TextBox();
            this.comboBoxPromo = new System.Windows.Forms.ComboBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericColomns)).BeginInit();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Колонок на строке";
            // 
            // numericColomns
            // 
            this.numericColomns.Location = new System.Drawing.Point(219, 19);
            this.numericColomns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericColomns.Name = "numericColomns";
            this.numericColomns.Size = new System.Drawing.Size(67, 31);
            this.numericColomns.TabIndex = 1;
            this.numericColomns.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // listBox
            // 
            this.listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 20;
            this.listBox.Location = new System.Drawing.Point(17, 59);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(269, 424);
            this.listBox.TabIndex = 2;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Название";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Цена";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Путь к игре";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.numericPrice);
            this.groupBox.Controls.Add(this.buttonSelectExec);
            this.groupBox.Controls.Add(this.textBoxExec);
            this.groupBox.Controls.Add(this.buttonSelectPromo);
            this.groupBox.Controls.Add(this.textBoxName);
            this.groupBox.Controls.Add(this.textBoxPromo);
            this.groupBox.Controls.Add(this.comboBoxPromo);
            this.groupBox.Controls.Add(this.buttonRemove);
            this.groupBox.Controls.Add(this.buttonEdit);
            this.groupBox.Controls.Add(this.buttonAdd);
            this.groupBox.Controls.Add(this.label6);
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Location = new System.Drawing.Point(306, 19);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(494, 468);
            this.groupBox.TabIndex = 6;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Карточка приложения";
            // 
            // numericPrice
            // 
            this.numericPrice.Location = new System.Drawing.Point(182, 118);
            this.numericPrice.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.numericPrice.Name = "numericPrice";
            this.numericPrice.Size = new System.Drawing.Size(289, 31);
            this.numericPrice.TabIndex = 18;
            // 
            // buttonSelectExec
            // 
            this.buttonSelectExec.Location = new System.Drawing.Point(396, 184);
            this.buttonSelectExec.Name = "buttonSelectExec";
            this.buttonSelectExec.Size = new System.Drawing.Size(75, 31);
            this.buttonSelectExec.TabIndex = 16;
            this.buttonSelectExec.Text = "Файл";
            this.buttonSelectExec.UseVisualStyleBackColor = true;
            this.buttonSelectExec.Click += new System.EventHandler(this.buttonSelectExec_Click);
            // 
            // textBoxExec
            // 
            this.textBoxExec.Location = new System.Drawing.Point(182, 184);
            this.textBoxExec.Name = "textBoxExec";
            this.textBoxExec.ReadOnly = true;
            this.textBoxExec.Size = new System.Drawing.Size(207, 31);
            this.textBoxExec.TabIndex = 15;
            // 
            // buttonSelectPromo
            // 
            this.buttonSelectPromo.Location = new System.Drawing.Point(396, 319);
            this.buttonSelectPromo.Name = "buttonSelectPromo";
            this.buttonSelectPromo.Size = new System.Drawing.Size(75, 31);
            this.buttonSelectPromo.TabIndex = 14;
            this.buttonSelectPromo.Text = "Файл";
            this.buttonSelectPromo.UseVisualStyleBackColor = true;
            this.buttonSelectPromo.Click += new System.EventHandler(this.buttonSelectPromo_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(182, 51);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(289, 31);
            this.textBoxName.TabIndex = 13;
            // 
            // textBoxPromo
            // 
            this.textBoxPromo.Location = new System.Drawing.Point(182, 319);
            this.textBoxPromo.Name = "textBoxPromo";
            this.textBoxPromo.ReadOnly = true;
            this.textBoxPromo.Size = new System.Drawing.Size(207, 31);
            this.textBoxPromo.TabIndex = 12;
            // 
            // comboBoxPromo
            // 
            this.comboBoxPromo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPromo.FormattingEnabled = true;
            this.comboBoxPromo.Location = new System.Drawing.Point(182, 258);
            this.comboBoxPromo.Name = "comboBoxPromo";
            this.comboBoxPromo.Size = new System.Drawing.Size(289, 33);
            this.comboBoxPromo.TabIndex = 11;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(339, 389);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(132, 56);
            this.buttonRemove.TabIndex = 10;
            this.buttonRemove.Text = "Удалить";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(182, 389);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(132, 56);
            this.buttonEdit.TabIndex = 9;
            this.buttonEdit.Text = "Обновить";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(25, 389);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(132, 56);
            this.buttonAdd.TabIndex = 8;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 319);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 25);
            this.label6.TabIndex = 7;
            this.label6.Text = "Промо файл";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Промо тип";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 499);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.numericColomns);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericColomns)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericColomns;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.NumericUpDown numericPrice;
        private System.Windows.Forms.Button buttonSelectExec;
        private System.Windows.Forms.TextBox textBoxExec;
        private System.Windows.Forms.Button buttonSelectPromo;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPromo;
        private System.Windows.Forms.ComboBox comboBoxPromo;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}