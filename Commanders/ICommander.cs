using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Windows.Forms;
using System.Data;


namespace AgreementOpener.Commanders
{
	public interface ICommander
    {
        string ConnectionString { get; set; }
        SqlConnection Connection { get; set; }
		/// <summary>
		/// Получить информацию о договоре.
		/// </summary>
		/// <param name="snils"></param>
		void Check(string snils);

		/// <summary>
		/// Обновить дату создания договора.
		/// </summary>
		/// <param name="snils"></param>
		void UpdateCreatedDate(string snils);

		/// <summary>
		/// Открыть договор для редактирования, сбросить все статусы.
		/// </summary>
		/// <param name="snils"></param>
		void OpenAgreement(string snils);

		/// <summary>
		/// Сменить НПФ.
		/// </summary>
		/// <param name="snils"></param>
		/// <param name="npfName"></param>
		void ChangeNpf(string snils, string npfName);

	}
}
