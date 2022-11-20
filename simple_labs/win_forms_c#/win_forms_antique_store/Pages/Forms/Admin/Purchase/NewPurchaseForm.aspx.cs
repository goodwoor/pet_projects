using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Антикварный_магазин.Model;
using Антикварный_магазин.Model.Helpers;

namespace Антикварный_магазин.Pages.Forms.Admin.Purchase
{
    public partial class NewPurchaseForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddPurchaseButton_Click(object sender, EventArgs e)
        {
            bool dateIsValid = HelpValidators.IsValidDate(DateTextBox, DateErrorLabel);
            if (!dateIsValid)
            {
                return;
            }
            ErrorAddPurchaseLabel.Text = "";

            using (var context = new AntiqueStore())
            {
                int idClient = 0;
                int idWorker = 0;
                int idAntiq = 0;

                bool canConvert = false;
                try
                {
                    idClient = int.Parse(IdClientTextBox.Text);
                    idWorker = int.Parse(IdWorkerTextBox.Text);
                    idAntiq = int.Parse(IdAntiqueTextBox.Text);
                    canConvert = true;
                }
                catch
                {
                    canConvert = false;
                }

                bool isIdClientExists = canConvert && context.Клиент.Any(c => c.Id_клиента == idClient);
                bool isIdWorkerExists = canConvert && context.Сотрудник.Any(c => c.Id_сотрудника == idWorker);
                bool isIdAntiqExists = canConvert && context.Антиквариат.Any(c => c.Id_антиквариата == idAntiq);


                if (isIdClientExists && isIdWorkerExists && isIdAntiqExists)
                {
                    Покупка newPurchase = new Покупка
                    {
                        Дата = DateTime.Parse(DateTextBox.Text),
                        Статус = StatusDropDownList.SelectedIndex == 0 ? "завершён" : "обслуживание",
                        Id_клиента = idClient,
                        Id_сотрудника = idWorker,
                        Id_антиквариата = idAntiq
                    };
                    

                    try
                    {
                        context.Покупка.Add(newPurchase);
                        context.SaveChanges();
                        ErrorAddPurchaseLabel.Text = "";

                        Response.Redirect("~/Pages/Forms/Admin/Purchase/PurchasesTableForm.aspx");
                    }
                    catch
                    {
                        ErrorAddPurchaseLabel.Text = "Не удалось сохранить изменения. Проверьте правильность данных.";
                    }
                }

                if (!isIdClientExists)
                {
                    ErrorAddPurchaseLabel.Text = "Не удалось сохранить изменения. Клиент с указанным ID не существует.";
                }
                if (!isIdWorkerExists)
                {
                    ErrorAddPurchaseLabel.Text = "Не удалось сохранить изменения. Сотрудник с указанным ID не существует.";
                }
                if (!isIdAntiqExists)
                {
                    ErrorAddPurchaseLabel.Text = "Не удалось сохранить изменения. Антиквариат с указанным ID не существует.";
                }
            }
        }
    }
}