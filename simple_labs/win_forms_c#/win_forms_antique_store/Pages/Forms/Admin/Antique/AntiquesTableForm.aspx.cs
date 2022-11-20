using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Антикварный_магазин.Model;
using Антикварный_магазин.Model.Helpers;

namespace Антикварный_магазин.Pages.Login.Seller.Antique
{
    public partial class AntiquesForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            showAntiquesTable();
            showIzdelTable();
            showWeaponTable();
            showProizvedTable();
            showBookTable();
            showClockTable();
        }
        private void showClockTable()
        {
            TableRow headerRow = ClockTable.Rows[0]; //сохраняем заголовки таблицы
            ClockTable.Rows.Clear();
            ClockTable.Rows.Add(headerRow);

            using (var context = new AntiqueStore())
            {
                Часы[] cloks = context.Часы.ToArray();

                if (cloks.Length > 0)
                {
                    foreach (Часы item in cloks)
                    {
                        TableCell[] cells = new TableCell[4];
                        for (int i = 0; i < cells.Length; i++)
                        {
                            cells[i] = new TableCell();
                        }
                        cells[0].Text = item.Id_антиквариата.ToString();
                        cells[1].Text = item.Вид;
                        cells[2].Text = item.Основной_материал;
                        cells[3].Text = item.Страна_изготовления;

                        TableRow row = new TableRow();
                        foreach (TableCell cell in cells)
                        {
                            row.Cells.Add(cell);
                        }

                        ClockTable.Rows.Add(row);
                    }
                }
            }
        }

        private void showIzdelTable()
        {
            TableRow headerRow = IzdelTable.Rows[0]; //сохраняем заголовки таблицы
            IzdelTable.Rows.Clear();
            IzdelTable.Rows.Add(headerRow);

            using (var context = new AntiqueStore())
            {
                Ювелирное_изделие[] izdelia = context.Ювелирное_изделие.ToArray();

                if (izdelia.Length > 0)
                {
                    foreach (Ювелирное_изделие item in izdelia)
                    {
                        TableCell[] cells = new TableCell[4];
                        for (int i = 0; i < cells.Length; i++)
                        {
                            cells[i] = new TableCell();
                        }
                        cells[0].Text = item.Id_антиквариата.ToString();
                        cells[1].Text = item.Материал;
                        cells[2].Text = item.Вставка;
                        cells[3].Text = item.Вес_граммы_.ToString();

                        TableRow row = new TableRow();
                        row.Cells.AddRange(cells);

                        IzdelTable.Rows.Add(row);
                    }
                }
            }
        }
        private void showWeaponTable()
        {
            TableRow headerRow = WeaponTable.Rows[0]; //сохраняем заголовки таблицы
            WeaponTable.Rows.Clear();
            WeaponTable.Rows.Add(headerRow);

            using (var context = new AntiqueStore())
            {
                Оружие[] weapons = context.Оружие.ToArray();

                if (weapons.Length > 0)
                {
                    foreach (Оружие item in weapons)
                    {
                        TableCell[] cells = new TableCell[3];
                        for (int i = 0; i < cells.Length; i++)
                        {
                            cells[i] = new TableCell();
                        }
                        cells[0].Text = item.Id_антиквариата.ToString();
                        cells[1].Text = item.Вид_оружия;
                        cells[2].Text = item.Страна_изготовления;

                        TableRow row = new TableRow();
                        row.Cells.AddRange(cells);

                        WeaponTable.Rows.Add(row);
                    }
                }
            }
        }

        private void showProizvedTable()
        {
            TableRow headerRow = ProizvedTable.Rows[0]; //сохраняем заголовки таблицы
            ProizvedTable.Rows.Clear();
            ProizvedTable.Rows.Add(headerRow);

            using (var context = new AntiqueStore())
            {
                Произведение_исскуства[] proizvedenia = context.Произведение_исскуства.ToArray();

                if (proizvedenia.Length > 0)
                {
                    foreach (Произведение_исскуства item in proizvedenia)
                    {
                        TableCell[] cells = new TableCell[3];
                        for (int i = 0; i < cells.Length; i++)
                        {
                            cells[i] = new TableCell();
                        }
                        cells[0].Text = item.Id_антиквариата.ToString();
                        cells[1].Text = item.Автор;
                        cells[2].Text = item.Вид_искусства;

                        TableRow row = new TableRow();
                        row.Cells.AddRange(cells);
                        ProizvedTable.Rows.Add(row);
                    }
                }
            }
        }

        private void showBookTable()
        {
            TableRow headerRow = BookTable.Rows[0]; //сохраняем заголовки таблицы
            BookTable.Rows.Clear();
            BookTable.Rows.Add(headerRow);

            using (var context = new AntiqueStore())
            {
                Букинистика[] books = context.Букинистика.ToArray();

                if (books.Length > 0)
                {
                    foreach (Букинистика item in books)
                    {
                        TableCell[] cells = new TableCell[4];
                        for (int i = 0; i < cells.Length; i++)
                        {
                            cells[i] = new TableCell();
                        }
                        cells[0].Text = item.Id_антиквариата.ToString();
                        cells[1].Text = item.Автор;
                        cells[2].Text = item.Количество_страниц.ToString();
                        cells[3].Text = item.Язык;

                        TableRow row = new TableRow();
                        row.Cells.AddRange(cells);
                        BookTable.Rows.Add(row);
                    }
                }
            }
        }

        private void showAntiquesTable()
        {
            TableRow headerRow = antiquesTable.Rows[0]; //сохраняем заголовки таблицы
            antiquesTable.Rows.Clear();
            antiquesTable.Rows.Add(headerRow);

            using (var context = new AntiqueStore())
            {
                Антиквариат[] antiques = context.Антиквариат.ToArray();

                if (antiques.Length > 0)
                {
                    foreach (Антиквариат item in antiques)
                    {
                        TableCell[] cells = new TableCell[7];
                        for (int i = 0; i < cells.Length; i++)
                        {
                            cells[i] = new TableCell();
                        }
                        cells[0].Text = item.Id_антиквариата.ToString();
                        cells[1].Text = item.Наименование;
                        cells[2].Text = item.Стоимость.ToString();
                        cells[3].Text = item.Состояние;
                        cells[4].Text = item.Историческая_эпоха;
                        cells[5].Text = item.Наличие_страховки.ToString();
                        cells[6].Text = item.Категория;

                        TableRow row = new TableRow();
                        row.Cells.AddRange(cells);
                        antiquesTable.Rows.Add(row);
                    }
                }
            }
        }

        protected void RedactButton_Click(object sender, EventArgs e)
        {
            if (checkShearch(IdSearchTextBox.Text))
            {
                Session["ID_antique"] = int.Parse(IdSearchTextBox.Text);
                Session["RedactFlagAntique"] = true;
                string redirectUrl = "~/Pages/Forms/Admin/Antique/RedactAntiqueForm.aspx";
                Response.Redirect(redirectUrl);
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
                int idAntique = int.Parse(IdSearchTextBox.Text);
                using (var context = new AntiqueStore())
                {
                    Антиквариат toDelete = context.Антиквариат.Find(idAntique);
                    context.Антиквариат.Remove(toDelete);
                    context.SaveChanges();
                }

                showAntiquesTable();
                showIzdelTable();
                showWeaponTable();
                showProizvedTable();
                showBookTable();
                showClockTable();
            }
            else
            {
                return;
            }
        }

        protected void NewElemButton_Click(object sender, EventArgs e)
        {
            string redirectUrl = "~/Pages/Forms/Admin/Antique/NewAntiqueForm.aspx";
            Response.Redirect(redirectUrl);
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
                bool idIsFind = context.Антиквариат.Any(s => s.Id_антиквариата == idToFind);
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
