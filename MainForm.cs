using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Configuration;
using AgreementOpener.Commanders;
using AgreementOpener.Utils;


namespace AgreementOpener
{
	public partial class MainForm : Form
	{
		private readonly WebCommander _web = new WebCommander();
		private readonly CrmCommander _crm = new CrmCommander();

        // RegExp pattern for snils 000-000-000 00
		private const string SnilsPtrn = @"\d{3}-\d{3}-\d{3}\s\d{2}";

		public MainForm()
		{
			InitializeComponent();
			dateTimePicker1.Value = DateTime.Now;
			dateTimePicker2.Value = DateTime.Now;
		}

		// Close button
		private void Button1Click(object sender, EventArgs e)
		{
			Close();
		}

		// Go button
		private void Update_btnClick(object sender, EventArgs e)
		{
			string snils = snils_tb.Text.Trim();
			
			if(SourceWEBradio.Checked)
			{
				if (snils != "" && Regex.IsMatch(snils, SnilsPtrn))
				{	
					if(DateRadio.Checked)
					{
						_web.UpdateCreatedDate(snils);
					}
					
					if(OpenAgrRadio.Checked)
					{
						_web.OpenAgreement(snils);
					}
					
					if(ChangeNpfRadio.Checked)
					{
						string npfName = NPFBox1.Text;
						
						if(npfName != "")
						{
							_web.ChangeNpf(snils, npfName);
						}
						else
						{
							MessageBox.Show("Не указан НПФ!");
						}
					}
				}
				else
				{
					MessageBox.Show("Неправильный СНИЛС!");
				}
			}
            else if (SourceCRMradio.Checked)
            {
                if (snils != "" && Regex.IsMatch(snils, SnilsPtrn))
                {
                    if (DateRadio.Checked)
                    {
                        _crm.UpdateCreatedDate(snils);
                    }

                    if (OpenAgrRadio.Checked)
                    {
                        _crm.OpenAgreement(snils);
                    }

                    if (!ChangeNpfRadio.Checked) return;
                    string npfName = NPFBox1.Text;

                    if (npfName != "")
                    {
                        _crm.ChangeNpf(snils, npfName);
                    }
                    else
                    {
                        MessageBox.Show("Не указан НПФ!");
                    }
                }
                else
                {
                    MessageBox.Show("Неправильный СНИЛС!");
                }
            }
        }

		//check button
		private void Button2Click(object sender, EventArgs e)
		{
			string snils = snils_tb.Text.Trim();
			if(SourceWEBradio.Checked)
			{
				if(snils != "" && Regex.IsMatch(snils, SnilsPtrn))
				{
					_web.Check(snils);
				}
				else
				{
                    MessageBox.Show("Неправильный СНИЛС!");
				}
			}
            else if (SourceCRMradio.Checked)
            {
                if (snils != "" && Regex.IsMatch(snils, SnilsPtrn))
                {
                    _crm.Check(snils);
                }
                else
                {
                    MessageBox.Show("Неправильный СНИЛС!");
                }
            }
        }

		// Отчет по халве 
		private void ReportButtonClick(object sender, EventArgs e)
		{
			var data = _web.GetRelatedProducts(dateTimePicker1.Value, dateTimePicker2.Value);

            var save = new SaveFileDialog
            {
                DefaultExt = "xlsx",
                InitialDirectory = @"C:\",
                FileName = $"Халва {DateTime.Now:yyyy-MM-dd}"
            };
            save.ShowDialog();

			var excelFormer = new ExcelFormer(data, save.FileName);
			try
            {
                excelFormer.ToExcel();
                MessageBox.Show("Excel file saved!");
                if (checkBox1.Checked)
                {
                    var mailer = new Mailer(
                        ConfigurationManager.AppSettings.Get("smtpServer"),
                        ConfigurationManager.AppSettings.Get("sender"),
                        ConfigurationManager.AppSettings.Get("senderPass"),
                        mailCombo.Text,
                        save.FileName,
                        $"Отчет по Халве {DateTime.Now:yyyy-MM-dd}",
                        $"{DateTime.Now:D}");

                    mailer.SendMail();
                    MessageBox.Show($"Отправлено на {mailCombo.Text}");
                }
            }
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void searchUserButton_Click(object sender, EventArgs e)
		{
			userInfoBox.Clear();
			if (!string.IsNullOrEmpty(searchUserBox.Text))
			{
                _web.GetEmployee(searchUserBox.Text, out var users);

				int counter = 0;
				foreach (var u in users)
                {
                    userInfoBox.AppendText(u + "\n");
                    counter++;
                    if (counter % 5 == 0)
                        userInfoBox.AppendText("------------------------------------\n");
                } 
			}
			else
			{
				MessageBox.Show("Не указано имя пользователя.");
			}
		}
	}
}
