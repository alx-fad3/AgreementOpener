using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AgreementOpener.Commanders
{
    public class WebCommander : ICommander
    {
        public string ConnectionString { get; set; }
        public SqlConnection Connection { get; set; }

        public WebCommander()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["ESP_WEB"].ConnectionString;
        }

		public void Check(string snils)
		{
			const string sqlExpression = @"select
											agr.CreatedOn,
											npf.Name, 
											c.LastName + ' ' + c.FirstName + ' ' + c.MiddleName,
											e1.Name_Last + ' ' + e1.Name_First + ' ' + e1.Name_Middle,
											e.Name_Last + ' ' + e.Name_First + ' ' + e.Name_Middle,
											p.Name,
											s.Name,
											bu.Name
											from Agreements agr 
											left join Npfs npf on npf.id = agr.npfid 
											left join contact c on c.contactid = agr.ContactId
											left join Employees e on e.id = agr.signerid
											left join Employees e1 on e1.id = agr.CreatorId
											left join Partners p on p.id = e1.partnerid
											left join SalesChannels s on s.id = e1.saleschannelid
											left join BusinessUnits bu on bu.id = e1.businessunitid
											where agr.snils = (@snils)";
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
                                    $"WEB:\nСоздан: {reader.GetValue(0)} " +
                                    $"\nНПФ: {reader.GetValue(1)} " +
                                    $"\nКлиент: {reader.GetValue(2)} " +
                                    $"\nАгент: {reader.GetValue(3)} " +
                                    $"\nПодписант: {reader.GetValue(4)} " +
                                    $"\nПартнер: {reader.GetValue(5)} " +
                                    $"\nКанал продаж: {reader.GetValue(6)} " +
                                    $"\nОП: {reader.GetValue(7)}";
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
			const string sqlExpression = @"UPDATE Agreements set CreatedOn = GetDate()
											WHERE snils = (@snils)";

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
			const string sqlExpression = @" UPDATE Agreements SET 
											   Status_Web = 200000001,
											   Partner_Id = null,
											   Partner_Uid = null,
											   PartnerJSON = null,
											   Status_WebDate = getdate()
											WHERE snils = (@snils);";

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
							msg = "Что-то пошло не так..";
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
			const string sqlExpression = @"DECLARE @npfid uniqueIdentifier;
											SET @npfid = (SELECT npfid FROM Npfs where Name = (@npfName));
											
											UPDATE [dbo].[be_agreement] SET 
											   NpfId = @npfid,
											   Status_Web = 200000001,
											   Partner_Id = null, --чистый id 
											   Partner_Uid = null, --чистый uid
											   Status_WebDate = getdate() --дата веб статуса текущая
											WHERE snils = (@snils);";

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

		/// <summary>
		/// Получить отчет по заявкам в "Халве".
		/// </summary>
		/// <param name="d1"></param>
		/// <param name="d2"></param>
		/// <returns></returns>
		public DataTable GetRelatedProducts(DateTime d1, DateTime d2)
		{
			d2 = d2.AddDays(1);

			var data = new DataTable();

			string sqlExpression = "SELECT * " +
                                   "FROM RelatedProductsView " +
                                   $"WHERE createdon BETWEEN '{d1:yyyy-MM-dd}' AND '{d2:yyyy-MM-dd}' " +
                                   "ORDER BY CreatedOn";

			using (Connection = new SqlConnection(ConnectionString))
			{
				try
				{
                    Connection.Open();
					SqlDataAdapter adapter = new SqlDataAdapter(sqlExpression, Connection);
					adapter.Fill(data);

					return data;
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message);
					return null;
				}
			}
		}

		/// <summary>
		/// Получить список сотруников.
		/// </summary>
		/// <param name="lastname"></param> 
		/// <param name="employeesList"></param>
		public void GetEmployee(string lastname, out List<string> employeesList)
		{
			employeesList = new List<string>();

			const string sqlExpression = @"declare @lastname varchar(20);
										  set @lastname = (@lastnameParam);
										  select * from EmployeesWithPasswordTable
										  where lastname like '%' + @lastname + '%'";

			using (Connection = new SqlConnection(ConnectionString))
			{
				try
				{
                    Connection.Open();
					var cmd = new SqlCommand(sqlExpression, Connection);
					var lastnameParam = new SqlParameter("@lastnameParam", lastname);
					cmd.Parameters.Add(lastnameParam);
					try
					{
						var reader = cmd.ExecuteReader();

						if (reader.HasRows)
						{
							while (reader.Read())
							{
								employeesList.Add(reader.GetValue(1).ToString());
								employeesList.Add(reader.GetValue(2).ToString());
								employeesList.Add(reader.GetValue(3).ToString());
								employeesList.Add(reader.GetValue(4).ToString());
								employeesList.Add(reader.GetValue(5).ToString());
							}
							reader.Close();
						}
						else
						{
							MessageBox.Show("Нет таких пользователей");
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
