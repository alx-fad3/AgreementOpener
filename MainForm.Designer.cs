/*
 * Created by SharpDevelop.
 * User: 1CloudAdmin
 * Date: 10/19/2018
 * Time: 3:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AgreementOpener
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button CloseBtn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox snils_tb;
		private System.Windows.Forms.Button GoBtn;
		private System.Windows.Forms.Button CheckBtn;
		private System.Windows.Forms.ComboBox NPFBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton SourceCRMradio;
		private System.Windows.Forms.RadioButton SourceWEBradio;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton ChangeNpfRadio;
		private System.Windows.Forms.RadioButton OpenAgrRadio;
		private System.Windows.Forms.RadioButton DateRadio;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.CloseBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.snils_tb = new System.Windows.Forms.TextBox();
            this.GoBtn = new System.Windows.Forms.Button();
            this.CheckBtn = new System.Windows.Forms.Button();
            this.NPFBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SourceCRMradio = new System.Windows.Forms.RadioButton();
            this.SourceWEBradio = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DateRadio = new System.Windows.Forms.RadioButton();
            this.ChangeNpfRadio = new System.Windows.Forms.RadioButton();
            this.OpenAgrRadio = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mailCombo = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.reportButton = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.searchUserButton = new System.Windows.Forms.Button();
            this.searchUserBox = new System.Windows.Forms.TextBox();
            this.userInfoBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(587, 383);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseBtn.TabIndex = 0;
            this.CloseBtn.Text = "Закрыть";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.Button1Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "СНИЛС:";
            // 
            // snils_tb
            // 
            this.snils_tb.Location = new System.Drawing.Point(6, 43);
            this.snils_tb.Name = "snils_tb";
            this.snils_tb.Size = new System.Drawing.Size(178, 20);
            this.snils_tb.TabIndex = 2;
            // 
            // GoBtn
            // 
            this.GoBtn.Location = new System.Drawing.Point(6, 156);
            this.GoBtn.Name = "GoBtn";
            this.GoBtn.Size = new System.Drawing.Size(75, 23);
            this.GoBtn.TabIndex = 3;
            this.GoBtn.Text = "Go";
            this.GoBtn.UseVisualStyleBackColor = true;
            this.GoBtn.Click += new System.EventHandler(this.Update_btnClick);
            // 
            // CheckBtn
            // 
            this.CheckBtn.Location = new System.Drawing.Point(190, 41);
            this.CheckBtn.Name = "CheckBtn";
            this.CheckBtn.Size = new System.Drawing.Size(75, 23);
            this.CheckBtn.TabIndex = 6;
            this.CheckBtn.Text = "Проверить";
            this.CheckBtn.UseVisualStyleBackColor = true;
            this.CheckBtn.Click += new System.EventHandler(this.Button2Click);
            // 
            // NPFBox1
            // 
            this.NPFBox1.FormattingEnabled = true;
            this.NPFBox1.Items.AddRange(new object[] {
            "НПФ «Профессиональный»",
            "НПФ «Газфонд»",
            "НПФ «САФМАР»",
            "НПФ «Согласие»",
            "НПФ «ФЕДЕРАЦИЯ»"});
            this.NPFBox1.Location = new System.Drawing.Point(111, 46);
            this.NPFBox1.Name = "NPFBox1";
            this.NPFBox1.Size = new System.Drawing.Size(130, 21);
            this.NPFBox1.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SourceCRMradio);
            this.groupBox1.Controls.Add(this.SourceWEBradio);
            this.groupBox1.Location = new System.Drawing.Point(271, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(84, 70);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "База:";
            // 
            // SourceCRMradio
            // 
            this.SourceCRMradio.Location = new System.Drawing.Point(7, 36);
            this.SourceCRMradio.Name = "SourceCRMradio";
            this.SourceCRMradio.Size = new System.Drawing.Size(61, 24);
            this.SourceCRMradio.TabIndex = 1;
            this.SourceCRMradio.Text = "CRM";
            this.SourceCRMradio.UseVisualStyleBackColor = true;
            // 
            // SourceWEBradio
            // 
            this.SourceWEBradio.Checked = true;
            this.SourceWEBradio.Location = new System.Drawing.Point(7, 15);
            this.SourceWEBradio.Name = "SourceWEBradio";
            this.SourceWEBradio.Size = new System.Drawing.Size(71, 24);
            this.SourceWEBradio.TabIndex = 0;
            this.SourceWEBradio.TabStop = true;
            this.SourceWEBradio.Text = "WEB";
            this.SourceWEBradio.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DateRadio);
            this.groupBox2.Controls.Add(this.ChangeNpfRadio);
            this.groupBox2.Controls.Add(this.OpenAgrRadio);
            this.groupBox2.Controls.Add(this.NPFBox1);
            this.groupBox2.Location = new System.Drawing.Point(6, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 81);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Опции:";
            // 
            // DateRadio
            // 
            this.DateRadio.Location = new System.Drawing.Point(130, 19);
            this.DateRadio.Name = "DateRadio";
            this.DateRadio.Size = new System.Drawing.Size(111, 24);
            this.DateRadio.TabIndex = 11;
            this.DateRadio.Text = "Обновить дату";
            this.DateRadio.UseVisualStyleBackColor = true;
            // 
            // ChangeNpfRadio
            // 
            this.ChangeNpfRadio.Location = new System.Drawing.Point(6, 46);
            this.ChangeNpfRadio.Name = "ChangeNpfRadio";
            this.ChangeNpfRadio.Size = new System.Drawing.Size(104, 24);
            this.ChangeNpfRadio.TabIndex = 10;
            this.ChangeNpfRadio.Text = "Смена НПФ:";
            this.ChangeNpfRadio.UseVisualStyleBackColor = true;
            // 
            // OpenAgrRadio
            // 
            this.OpenAgrRadio.Checked = true;
            this.OpenAgrRadio.Location = new System.Drawing.Point(6, 19);
            this.OpenAgrRadio.Name = "OpenAgrRadio";
            this.OpenAgrRadio.Size = new System.Drawing.Size(118, 24);
            this.OpenAgrRadio.TabIndex = 9;
            this.OpenAgrRadio.TabStop = true;
            this.OpenAgrRadio.Text = "Открыть договор";
            this.OpenAgrRadio.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.snils_tb);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.CheckBtn);
            this.groupBox3.Controls.Add(this.GoBtn);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(363, 193);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Договоры";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox1);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.mailCombo);
            this.groupBox4.Controls.Add(this.dateTimePicker2);
            this.groupBox4.Controls.Add(this.dateTimePicker1);
            this.groupBox4.Controls.Add(this.reportButton);
            this.groupBox4.Location = new System.Drawing.Point(12, 211);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(363, 166);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Халва";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 77);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(125, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Отправить на почту";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "До:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "От:";
            // 
            // mailCombo
            // 
            this.mailCombo.FormattingEnabled = true;
            this.mailCombo.Items.AddRange(new object[] {
            "y.tolstonozhenko@espension.ru",
            "techsupport@espension.ru"});
            this.mailCombo.Location = new System.Drawing.Point(6, 100);
            this.mailCombo.Name = "mailCombo";
            this.mailCombo.Size = new System.Drawing.Size(259, 21);
            this.mailCombo.TabIndex = 8;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(38, 44);
            this.dateTimePicker2.MaxDate = new System.DateTime(2039, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker2.MinDate = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(227, 20);
            this.dateTimePicker2.TabIndex = 1;
            this.dateTimePicker2.Value = new System.DateTime(2020, 1, 17, 18, 14, 5, 0);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(38, 19);
            this.dateTimePicker1.MaxDate = new System.DateTime(2039, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(227, 20);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.Value = new System.DateTime(2020, 1, 17, 18, 14, 5, 0);
            // 
            // reportButton
            // 
            this.reportButton.Location = new System.Drawing.Point(6, 137);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(75, 23);
            this.reportButton.TabIndex = 0;
            this.reportButton.Text = "Отчет";
            this.reportButton.UseVisualStyleBackColor = true;
            this.reportButton.Click += new System.EventHandler(this.ReportButtonClick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.userInfoBox);
            this.groupBox5.Controls.Add(this.searchUserBox);
            this.groupBox5.Controls.Add(this.searchUserButton);
            this.groupBox5.Location = new System.Drawing.Point(382, 13);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(280, 364);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Пользователи";
            // 
            // searchUserButton
            // 
            this.searchUserButton.Location = new System.Drawing.Point(6, 68);
            this.searchUserButton.Name = "searchUserButton";
            this.searchUserButton.Size = new System.Drawing.Size(75, 23);
            this.searchUserButton.TabIndex = 0;
            this.searchUserButton.Text = "Поиск";
            this.searchUserButton.UseVisualStyleBackColor = true;
            this.searchUserButton.Click += new System.EventHandler(this.searchUserButton_Click);
            // 
            // searchUserBox
            // 
            this.searchUserBox.Location = new System.Drawing.Point(6, 42);
            this.searchUserBox.Name = "searchUserBox";
            this.searchUserBox.Size = new System.Drawing.Size(265, 20);
            this.searchUserBox.TabIndex = 1;
            // 
            // userInfoBox
            // 
            this.userInfoBox.Location = new System.Drawing.Point(7, 98);
            this.userInfoBox.Name = "userInfoBox";
            this.userInfoBox.Size = new System.Drawing.Size(264, 260);
            this.userInfoBox.TabIndex = 2;
            this.userInfoBox.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "По фамилии:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(673, 412);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.CloseBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agreement Opener";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

		}

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button reportButton;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox mailCombo;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox userInfoBox;
        private System.Windows.Forms.TextBox searchUserBox;
        private System.Windows.Forms.Button searchUserButton;
        private System.Windows.Forms.Label label4;
    }
}
