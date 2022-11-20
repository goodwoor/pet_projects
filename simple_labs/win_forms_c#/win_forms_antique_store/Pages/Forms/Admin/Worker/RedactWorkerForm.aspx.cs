using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using Антикварный_магазин.Model;
using Антикварный_магазин.Model.Helpers;

namespace Антикварный_магазин.Pages.Login.Seller.Workers
{
    public partial class RedactForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool redactFlag = bool.Parse(Session["RedactFlagWorker"].ToString());
            int idWorker = int.Parse(Session["ID_Worker"].ToString());

            if (redactFlag)
            {
                using (var context = new AntiqueStore())
                {
                    Сотрудник toRedact = context.Сотрудник.Where(c => c.Id_сотрудника == idWorker).Single();

                    NameTextBox.Text = toRedact.ФИО;
                    SalaryTextBox.Text = toRedact.Зарплата.ToString();
                    EmailTextBox.Text = toRedact.Email;
                    PhoneTextBox.Text = toRedact.Номер_телефона.ToString();
                }
                Session["RedactFlagWorker"] = false;
            }
        }

        protected void SaveWorkerButton_Click(object sender, EventArgs e)
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

            using (var context = new AntiqueStore())
            {
                int idToRedact = int.Parse(Session["ID_Worker"].ToString());
                Сотрудник toRedact = context.Сотрудник.Where(c => c.Id_сотрудника == idToRedact).Single();

                toRedact.ФИО = NameTextBox.Text;
                toRedact.Зарплата = decimal.Parse(SalaryTextBox.Text);
                toRedact.Email = EmailTextBox.Text;
                toRedact.Номер_телефона = long.Parse(PhoneTextBox.Text);
    
                try
                {
                    context.SaveChanges();

                    Response.Redirect("~/Pages/Forms/Admin/Worker/WorkersTableForm.aspx");
                }
                catch
                {
                    ErrorSaveWorkerLabel.Text = "Не удалось сохранить изменения. Проверьте правильность данных";
                }
                
            }
        }
    }
}