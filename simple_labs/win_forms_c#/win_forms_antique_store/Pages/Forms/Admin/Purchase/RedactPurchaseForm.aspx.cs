using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Антикварный_магазин.Model;
using Антикварный_магазин.Model.Helpers;

namespace Антикварный_магазин.Pages.Login.Seller.Purchases
{
    public partial class RedactForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool redactFlag = bool.Parse(Session["RedactFlagPurchase"].ToString());
            int purchaseId = int.Parse(Session["ID_Purchase"].ToString());

            if (redactFlag)
            {
                using (var context = new AntiqueStore())
                {
                    Покупка purchaseToRedact = context.Покупка.Where(c => c.Id_покупки == purchaseId).Single();
                    DateTextBox.Text = purchaseToRedact.Дата.ToString();
                    StatusDropDownList.SelectedIndex = purchaseToRedact.Статус == "завершён" ? 0 : 1;
                    IdClientTextBox.Text = purchaseToRedact.Id_клиента.ToString();
                    IdWorkerTextBox.Text = purchaseToRedact.Id_сотрудника.ToString();
                    IdAntiqueTextBox.Text = purchaseToRedact.Id_антиквариата.ToString();
                }
                Session["RedactFlagPurchase"] = false;
            }
        }

        protected void SavePurchaseButton_Click(object sender, EventArgs e)
        {
            bool dateIsValid = HelpValidators.IsValidDate(DateTextBox, DateErrorLabel);
            if (!dateIsValid)
            {
                return;
            }
            ErrorSavePurchaseLabel.Text = "";

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
                    int purchaseId = int.Parse(Session["ID_Purchase"].ToString());
                    Покупка purchaseToRedact = context.Покупка.Find(purchaseId);

                    purchaseToRedact.Дата = DateTime.Parse(DateTextBox.Text);
                    purchaseToRedact.Статус = StatusDropDownList.SelectedIndex == 0 ? "завершён" : "обслуживание";
                    purchaseToRedact.Id_клиента = idClient;
                    purchaseToRedact.Id_сотрудника = idWorker;
                    purchaseToRedact.Id_антиквариата = idAntiq;

                    try
                    {
                        context.SaveChanges();
                        ErrorSavePurchaseLabel.Text = "";

                        Response.Redirect("~/Pages/Forms/Admin/Purchase/PurchasesTableForm.aspx");
                    }
                    catch
                    {
                        ErrorSavePurchaseLabel.Text = "Не удалось сохранить изменения. Проверьте правильность данных.";
                    }
                }

                if (!isIdClientExists)
                {
                    ErrorSavePurchaseLabel.Text = "Не удалось сохранить изменения. Клиент с указанным ID не существует.";
                }
                if (!isIdWorkerExists)
                {
                    ErrorSavePurchaseLabel.Text = "Не удалось сохранить изменения. Сотрудник с указанным ID не существует.";
                }
                if (!isIdAntiqExists)
                {
                    ErrorSavePurchaseLabel.Text = "Не удалось сохранить изменения. Антиквариат с указанным ID не существует.";
                }
            }
        }
    }
}