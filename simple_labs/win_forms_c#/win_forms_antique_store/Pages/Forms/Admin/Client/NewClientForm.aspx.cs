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
    public partial class NewElemForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void NewClientButton_Click(object sender, EventArgs e)
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
                bool isEmailNew = true;
                bool isPhoneNew = true;

                // проверка почты и телефона на уникальность
                isEmailNew = !(context.Клиент.Any(c => c.Email == EmailTextBox.Text));
                isPhoneNew = !(context.Клиент.Any(c => c.Номер_телефона.ToString() == PhoneTextBox.Text));
                if (isEmailNew && isPhoneNew)
                {
                    // создание нового клиента, сохранение в базе данных
                    Клиент newClient = new Клиент
                    {
                        ФИО = NameTextBox.Text,
                        Страна_город = CountryTownTextBox.Text,
                        Номер_телефона = long.Parse(PhoneTextBox.Text),
                        Email = EmailTextBox.Text
                    };
                    
                    try
                    {
                        context.Клиент.Add(newClient);
                        context.SaveChanges();

                        ErrorNewClientLabel.Text = "";

                        // перенаправление на страницу управления данными клиента
                        string redirectUrl = "~/Pages/Forms/Admin/Client/ClientsTableForm.aspx";
                        Response.Redirect(redirectUrl);
                    }
                    catch
                    {
                        ErrorNewClientLabel.Text = "Не удалось создать нового клиента. Проверьте правильность данных.";
                    }
                }
                else
                {
                    ErrorNewClientLabel.Text = "Пользователь с такими данными уже зарегистрирован.";
                    return;
                }

            }
        }
    }
}