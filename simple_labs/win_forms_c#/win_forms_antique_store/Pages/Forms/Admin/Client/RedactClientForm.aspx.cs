using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Антикварный_магазин.Model;
using Антикварный_магазин.Model.Helpers;

namespace Антикварный_магазин.Pages.Login.Seller.Clients
{
    public partial class RedactForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool redactFlag = bool.Parse(Session["RedactFlagClient"].ToString());
            int idClient = int.Parse(Session["ID_client"].ToString());

            // заполнение полей ввода старыми данными, когда страница грузится в первый раз
            if (redactFlag)
            {
                using (var context = new AntiqueStore())
                {
                    Клиент toRedact = context.Клиент.Where(c => c.Id_клиента == idClient).Single();
                    NameTextBox.Text = toRedact.ФИО;
                    CountryTownTextBox.Text = toRedact.Страна_город;
                    PhoneTextBox.Text = toRedact.Номер_телефона.ToString();
                    EmailTextBox.Text = toRedact.Email;
                }
                // изменяем флаг "первой" загрузки страницы
                Session["RedactFlagClient"] = false;
            }

        }

        protected void SaveClientButton_Click(object sender, EventArgs e)
        {
            // валидация полей ввода
            bool dateIsValid = HelpValidators.IsNotRequried(NameTextBox, NameErrorLabel, "ФИО")
                                && HelpValidators.IsNotRequried(CountryTownTextBox, CountryErrorLabel, "Страна,город")
                                && HelpValidators.IsNotRequried(EmailTextBox, EmailErrorLabel, "Почта")
                                && HelpValidators.IsValidPhone(PhoneTextBox, PhoneErrorLabel);
            if (!dateIsValid)
            {
                return;
            }

            using (var context = new AntiqueStore())
            {
                int idClient = int.Parse(Session["ID_client"].ToString());

                // отбор нужного клиента, редактирование и сохранение данных
                Клиент toRedact = context.Клиент.Where(c => c.Id_клиента == idClient).Single();
                toRedact.ФИО = NameTextBox.Text;
                toRedact.Страна_город = CountryTownTextBox.Text;
                toRedact.Номер_телефона = long.Parse(PhoneTextBox.Text);
                toRedact.Email = EmailTextBox.Text;

                try
                {
                    context.SaveChanges();
                    ErrorSaveClientLabel.Text = "";

                    string redirectUrl = "~/Pages/Forms/Admin/Client/ClientsTableForm.aspx";
                    Response.Redirect(redirectUrl);
                }
                catch
                {
                    ErrorSaveClientLabel.Text = "Не удалось сохранить изменения. Проверьте правильность данных.";
                }

            }
        }
    }
}