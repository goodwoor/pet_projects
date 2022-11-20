using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Антикварный_магазин.Model;
using Антикварный_магазин.Model.Helpers;

namespace Антикварный_магазин.Pages.Login.Seller.Покупки
{
    public partial class PurchasesForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            showPurchasesTable();
        }

        private void showPurchasesTable()
        {
            TableRow headerRow = purchasesTable.Rows[0];
            purchasesTable.Rows.Clear();
            purchasesTable.Rows.Add(headerRow);

            using (var context = new AntiqueStore())
            {
                Покупка[] purchases = context.Покупка.Select(s => s).ToArray();

                if (purchases.Length > 0)
                {
                    foreach (Покупка item in purchases)
                    {
                        TableCell[] cells = new TableCell[6];
                        for (int i = 0; i < cells.Length; i++)
                        {
                            cells[i] = new TableCell();
                        }
                        cells[0].Text = item.Id_покупки.ToString();
                        cells[1].Text = item.Дата.ToShortDateString();
                        cells[2].Text = item.Статус;
                        cells[3].Text = item.Id_клиента.ToString();
                        cells[4].Text = item.Id_сотрудника.ToString();
                        cells[5].Text = item.Id_антиквариата.ToString();

                        TableRow row = new TableRow();
                        foreach (TableCell cell in cells)
                        {
                            row.Cells.Add(cell);
                        }

                        purchasesTable.Rows.Add(row);
                    }
                }
            }
        }

        protected void RedactButton_Click(object sender, EventArgs e)
        {
            if (checkShearch(IdSearchTextBox.Text))
            {
                Session["ID_Purchase"] = int.Parse(IdSearchTextBox.Text);
                Session["RedactFlagPurchase"] = true;
                string redirectUrl = "~/Pages/Forms/Admin/Purchase/RedactPurchaseForm.aspx";
                Response.Redirect(redirectUrl);
            }
            else
            {
                actionErrorLabel.Text = "Некорректный ID элемента.";
                return;
            }
        }
        protected void NewButton_Click(object sender, EventArgs e)
        {
            string redirectUrl = "~/Pages/Forms/Admin/Purchase/NewPurchaseForm.aspx";
            Response.Redirect(redirectUrl);
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            if (checkShearch(IdSearchTextBox.Text))
            {
                int idPurchase = int.Parse(IdSearchTextBox.Text);
                using (var context = new AntiqueStore())
                {
                    Покупка toDelete = context.Покупка.Where(c => c.Id_покупки == idPurchase).Single();
                    context.Покупка.Remove(toDelete);
                    context.SaveChanges();
                }
                showPurchasesTable();
            }
            else
            {
                actionErrorLabel.Text = "Некорректный ID элемента.";
                return;
            }
        }

        private bool checkShearch(string strID)
        {
            if (strID == "")
            {
                actionErrorLabel.Text = "Введите ID элемента.";
                return false;
            }

            using (var context = new AntiqueStore())
            {
                int idToFind = int.Parse(strID);
                bool idIsFind = context.Покупка.Any(s => s.Id_покупки == idToFind);
                if (idIsFind)
                {
                    return true;
                }
                else
                {
                    actionErrorLabel.Text = "Элемент с таким ID не существует.";
                    return false;
                }
            }

        }
    }
}