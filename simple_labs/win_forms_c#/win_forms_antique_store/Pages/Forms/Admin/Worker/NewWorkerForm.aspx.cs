using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Антикварный_магазин.Model;
using Антикварный_магазин.Model.Helpers;

namespace Антикварный_магазин.Pages.Login.Seller.Workers
{
    public partial class NewElemForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddWorkerButton_Click(object sender, EventArgs e)
        {
            bool dateIsValid = HelpValidators.IsNotRequried(NameTextBox, NameErrorLabel, "ФИО")
                                && HelpValidators.IsNotRequried(SalaryTextBox, SalaryErrorLabel, "Зарплата")
                                && HelpValidators.IsNotRequried(EmailTextBox, EmailErrorLabel, "Почта")
                                && HelpValidators.IsNotRequried(PhoneTextBox, PhoneErrorLabel, "Номер телефона")
                                && HelpValidators.IsValidCost(SalaryTextBox, SalaryErrorLabel, "Зарплата")
                                && HelpValidators.IsValidPhone(PhoneTextBox, PhoneErrorLabel);
            if (!dateIsValid)
            {
                return;
            }

            ErrorAddWorkerLabel.Text = "";

            using (var context = new AntiqueStore())
            {
                try
                {
                    Сотрудник newWorker = new Сотрудник
                    {
                        ФИО = NameTextBox.Text,
                        Зарплата = decimal.Parse(SalaryTextBox.Text),
                        Номер_телефона = long.Parse(PhoneTextBox.Text),
                        Email = EmailTextBox.Text
                    };
                    context.Сотрудник.Add(newWorker);
                    context.SaveChanges();
                    Response.Redirect("~/Pages/Forms/Admin/Worker/WorkersTableForm.aspx");

                }
                catch
                {
                    ErrorAddWorkerLabel.Text = "Не удалось совершить операцию. Проверьте правильность данных.";
                }

            }
        }
    }
}