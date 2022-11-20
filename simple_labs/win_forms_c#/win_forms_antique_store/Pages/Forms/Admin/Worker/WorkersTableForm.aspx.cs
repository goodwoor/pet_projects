using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Антикварный_магазин.Model;
using Антикварный_магазин.Model.Helpers;

namespace Антикварный_магазин.Pages.Login.Seller.Сотрудники
{
    public partial class SellersTableForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            showSellersTable();
        }

        private void showSellersTable()
        {
            TableRow headerRow = sellersTable.Rows[0];
            sellersTable.Rows.Clear();
            sellersTable.Rows.Add(headerRow);

            using (var context = new AntiqueStore())
            {
                Сотрудник[] workers = context.Сотрудник.Select(s => s).ToArray();

                if (workers.Length > 0)
                {
                    foreach (Сотрудник item in workers)
                    {
                        TableCell[] cells = new TableCell[5];
                        for (int i = 0; i < cells.Length; i++)
                        {
                            cells[i] = new TableCell();
                        }
                        cells[0].Text = item.Id_сотрудника.ToString();
                        cells[1].Text = item.ФИО;
                        cells[2].Text = item.Зарплата.ToString();
                        cells[3].Text = item.Номер_телефона.ToString();
                        cells[4].Text = item.Email;


                        TableRow row = new TableRow();
                        foreach (TableCell cell in cells)
                        {
                            row.Cells.Add(cell);
                        }

                        sellersTable.Rows.Add(row);
                    }
                }
            }
        }

        protected void RedactButton_Click(object sender, EventArgs e)
        {
            if(checkShearch(IdSearchTextBox.Text))
            {
                int idWorker = int.Parse(IdSearchTextBox.Text);
                Session["ID_Worker"] = idWorker;
                Session["RedactFlagWorker"] = true;
                Response.Redirect("~/Pages/Forms/Admin/Worker/RedactWorkerForm.aspx");

            }
            else
            {
                return;
            }            
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            if (checkShearch(IdSearchTextBox.Text))
            {
                int idSeller = int.Parse(IdSearchTextBox.Text);
                using (var context = new AntiqueStore())
                {
                    Сотрудник toDelete = context.Сотрудник.Where(c => c.Id_сотрудника == idSeller).Single();
                    context.Сотрудник.Remove(toDelete);
                    context.SaveChanges();
                }

                showSellersTable();
            }
            else
            {
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
                bool idIsFind = context.Сотрудник.Any(s => s.Id_сотрудника == idToFind);
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