using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AgreementOpener.Commanders
{
    public class CrmCommander : ICommander
    {
        public string ConnectionString { get; set; }
        public SqlConnection Connection { get; set; }

        public CrmCommander()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["ESP_CRM"].ConnectionString;

		}
        public void Check(string snils)
		{
			const string sqlExpression = @"select
											agr.CreatedOn,
											npf.be_Name, 
											c.LastName + ' ' + c.FirstName + ' ' + c.MiddleName,
											e1.be_Last_Name + ' ' + e1.be_First_Name + ' ' + e1.be_Middle_Name,
											e.be_Last_Name + ' ' + e.be_First_Name + ' ' + e.be_Middle_Name,
											p.be_name,
											s.be_name,
											bu.be_name
											from be_agreement agr 
											left join be_npf npf on npf.be_npfid = agr.esp_npfid 
											left join contact c on c.contactid = agr.be_client_contactid
											left join be_employee e on e.be_employeeid = agr.be_signerid
											left join be_employee e1 on e1.be_employeeid = agr.be_web_userid
											left join be_partner p on p.be_partnerid = e1.be_partnerid
											left join be_sales_channel s on s.be_sales_channelid = e1.esp_sales_channelid
											left join be_business_unit bu on bu.be_business_unitid = e1.be_business_unitid
											where agr.be_number = (@snils)";
			using (Connection = new SqlConnection(ConnectionString))
			{
				try
				{
                    Connection.Open();
					var cmd = new SqlCommand(sqlExpression, Connection);
					var snilsParam = new SqlParameter("@snils", snils);
					cmd.Parameters.Add(snilsParam);

					try
					{
						var reader = cmd.ExecuteReader();

						if (reader.HasRows)
						{
							while (reader.Read())
							{
								var s =
                                    $"CRM:\nCreated at: {reader.GetValue(0)} " +
                                    $"\nNPF: {reader.GetValue(1)} " +
                                    $"\nClient Name: {reader.GetValue(2)} " +
                                    $"\nAgent Name: {reader.GetValue(3)} " +
                                    $"\nSigner Name: {reader.GetValue(4)} " +
                                    $"\nPartner: {reader.GetValue(5)} " +
                                    $"\nChannel: {reader.GetValue(6)} " +
                                    $"\nOP: {reader.GetValue(7)}";
								MessageBox.Show(s);
							}
							reader.Close();
						}
						else
						{
							MessageBox.Show("Нет договора с указанным СНИЛСом");
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		public void UpdateCreatedDate(string snils)
		{
			const string sqlExpression = @"UPDATE be_agreement set CreatedOn = GetDate()
											WHERE be_number = (@snils)";

			using (Connection = new SqlConnection(ConnectionString))
			{
				try
				{
                    Connection.Open();
					var cmd = new SqlCommand(sqlExpression, Connection);
					var snilsParam = new SqlParameter("@snils", snils);
					cmd.Parameters.Add(snilsParam);
					string msg = "";
					try
					{
						int returned = cmd.ExecuteNonQuery();
						if (returned == 1)
						{
							MessageBox.Show("Дата обновлена!");
						}
						else
						{
							msg = String.Format("Что-то пошло не так..", returned.ToString());
							MessageBox.Show(msg);
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		public void OpenAgreement(string snils)
		{
			const string sqlExpression = @"UPDATE be_agreement SET 
											   be_web_statuscode = 200000001,
											   esp_partner_id = null,
											   esp_partner_uid = null,
											   be_web_status_date = GETDATE()
											WHERE be_snils = (@snils);";

			using (Connection = new SqlConnection(ConnectionString))
			{
				try
				{
                    Connection.Open();
					var cmd = new SqlCommand(sqlExpression, Connection);
					var snilsParam = new SqlParameter("@snils", snils);
					cmd.Parameters.Add(snilsParam);
					string msg = "";
					try
					{
						int returned = cmd.ExecuteNonQuery();
						if (returned == 1)
						{
							MessageBox.Show("Договор открыт!");
						}
						else
						{
							msg = "Что-то пошло не так.. ";
							MessageBox.Show(msg);
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		public void ChangeNpf(string snils, string npfName)
		{
			const string sqlExpression = @" DECLARE @npfid uniqueIdentifier;
                                            SET @npfid = SELECT id FROM be_npfs WHERE be_name = (@npfName);
                                            UPDATE be_agreement SET 
											   esp_npfid = @npfid,
											   be_web_statuscode = 200000001,
											   esp_partner_id = null,
											   esp_partner_uid = null,
											   be_web_status_date = GETDATE()
											WHERE be_agreementid = (@snils);";
			using (Connection = new SqlConnection(ConnectionString))
			{
				try
				{
                    Connection.Open();
					var cmd = new SqlCommand(sqlExpression, Connection);
					var snilsParam = new SqlParameter("@snils", snils);
					var NPF_nameParam = new SqlParameter("@npfName", npfName);
					cmd.Parameters.Add(snilsParam);
					cmd.Parameters.Add(NPF_nameParam);
					string msg = "";
					try
					{
						int returned = cmd.ExecuteNonQuery();
						if (returned == 1)
						{
							MessageBox.Show("НПФ изменен!");
						}
						else
						{
							msg = String.Format("Что-то пошло не так", returned.ToString());
							MessageBox.Show(msg);
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}
	}
}
