using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Антикварный_магазин.Model;
using Антикварный_магазин.Model.Helpers;

namespace Антикварный_магазин.Pages.Login.Seller.Клиенты
{
    public partial class ClientsForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // показ таблицы при загрузке страницы
            showClientsTable();
        }

        private void showClientsTable()
        {
            // сохранение заголовков, очистка таблицы
            TableRow headerRow = clientsTable.Rows[0];
            clientsTable.Rows.Clear();
            clientsTable.Rows.Add(headerRow);

            // заполнение ячеек таблицы актуальными данными
            using (var context = new AntiqueStore())
            {
                Клиент[] clients = context.Клиент.Select(s => s).ToArray();

                if (clients.Length > 0)
                {
                    foreach (Клиент item in clients)
                    {
                        TableCell[] cells = new TableCell[5];
                        for (int i = 0; i < cells.Length; i++)
                        {
                            cells[i] = new TableCell();
                        }
                        cells[0].Text = item.Id_клиента.ToString();
                        cells[1].Text = item.ФИО;
                        cells[2].Text = item.Страна_город;
                        cells[3].Text = item.Номер_телефона.ToString();
                        cells[4].Text = item.Email;

                        TableRow row = new TableRow();
                        foreach (TableCell cell in cells)
                        {
                            row.Cells.Add(cell);
                        }

                        clientsTable.Rows.Add(row);
                    }
                }
            }
        }

        protected void RedactButton_Click(object sender, EventArgs e)
        {
            // проверка введённого ИД, перенаправление на страницу редактирования
            if (checkShearch(IdSearchTextBox.Text))
            {
                Session["ID_client"] = int.Parse(IdSearchTextBox.Text);
                Session["RedactFlagClient"] = true;
                string redirectUrl = "~/Pages/Forms/Admin/Client/RedactClientForm.aspx";
                Response.Redirect(redirectUrl);
            }
            else
            {
                return;
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            // проверка введённого ИД, удаление элемента
            if (checkShearch(IdSearchTextBox.Text))
            {
                int idClient = int.Parse(IdSearchTextBox.Text);
                using (var context = new AntiqueStore())
                {
                    Клиент toDelete = context.Клиент.Where(c => c.Id_клиента == idClient).Single();
                    context.Клиент.Remove(toDelete);
                    context.SaveChanges();
                }

                // обновление таблицы
                showClientsTable();
            }
            else
            {
                actionErrorLabel.Text = "Некорректный ID элемента.";
                return;
            }
        }

        protected void NewElemButton_Click(object sender, EventArgs e)
        {
            // перенаправление на страницу редактирования
            string redirectUrl = "~/Pages/Forms/Admin/Client/NewClientForm.aspx";
            Response.Redirect(redirectUrl);
        }

        private bool checkShearch(string strID)
        {
            // проверка ИД на нулевое значение
            if (strID == "")
            {
                actionErrorLabel.Text = "Введите ID элемента.";
                return false;
            }

            try
            {
                // поиск элемента с указанным ИД в таблице
                int idToFind = int.Parse(strID);
                using (var context = new AntiqueStore())
                {
                    if (context.Клиент.Any(s => s.Id_клиента == idToFind))
                    {
                        actionErrorLabel.Text = "";
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                actionErrorLabel.Text = "Некорректный ID элемента.";
                return false;
            }
        }
    }
}