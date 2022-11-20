using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Антикварный_магазин.Model;
using Антикварный_магазин.Model.Helpers;
using Антикварный_магазин.Pages.Master;

namespace Антикварный_магазин.Pages.Login.Client
{
    public partial class ClientForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errorSearchFilterLabel.Text = "";
            showAntiques();
        }

        protected void FilterCategoryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorSearchFilterLabel.Text = "";
            using (var context = new AntiqueStore())
            {
                //сначала фильтр по истории
                string historyFilterValue = FilterHistoryEraDropDownList.SelectedItem.Text;
                var notSaleAntiques = context.Database.SqlQuery<Антиквариат>("selectNotSaleAntique");
                Антиквариат[] antiques = notSaleAntiques.ToArray();

                if (historyFilterValue == "первобытное общество" || historyFilterValue == "древний мир" ||
                    historyFilterValue == "средние века" || historyFilterValue == "новое время" ||
                    historyFilterValue == "новейшее время")
                {
                    antiques = antiques.Where(c => c.Историческая_эпоха == historyFilterValue).ToArray<Антиквариат>();
                }

                // фильтр по категории
                if (FilterCategoryDropDownList.SelectedItem.Text == "все категории")
                {
                    TableRow headerRow = antiquesTable.Rows[0];
                    antiquesTable.Rows.Clear();
                    antiquesTable.Rows.Add(headerRow);

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
                        cells[5].Text = BoolStr.Get(item.Наличие_страховки);
                        cells[6].Text = item.Категория;

                        TableRow row = new TableRow();
                        foreach (TableCell cell in cells)
                        {
                            row.Cells.Add(cell);
                        }

                        antiquesTable.Rows.Add(row);
                    }
                    return;
                }

                string filterValue = FilterCategoryDropDownList.SelectedItem.Text;
                bool isCategoryExists = false;
                isCategoryExists = antiques.Any(c => c.Категория == filterValue);
                if (isCategoryExists)
                {
                    Антиквариат[] searchAntiques = antiques.Where(c => c.Категория == filterValue).ToArray<Антиквариат>();

                    TableRow headerRow = antiquesTable.Rows[0]; //сохраняем заголовки таблицы
                    antiquesTable.Rows.Clear();
                    antiquesTable.Rows.Add(headerRow);

                    foreach (Антиквариат item in searchAntiques)
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
                        cells[5].Text = BoolStr.Get(item.Наличие_страховки);
                        cells[6].Text = item.Категория;

                        TableRow row = new TableRow();
                        foreach (TableCell cell in cells)
                        {
                            row.Cells.Add(cell);
                        }

                        antiquesTable.Rows.Add(row);
                    }
                }
                else
                {
                    TableRow headerRow = antiquesTable.Rows[0];
                    antiquesTable.Rows.Clear();
                    antiquesTable.Rows.Add(headerRow);

                    errorSearchFilterLabel.Text = "Элементы с такими характеристиками фильтрации не найдены.";
                }
            }
        }
        protected void FilterHistoryEraDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorSearchFilterLabel.Text = "";


            using (var context = new AntiqueStore())
            {
                //сначала фильтр категории
                string categoryFilterValue = FilterCategoryDropDownList.SelectedItem.Text;
                var notSaleAntiques = context.Database.SqlQuery<Антиквариат>("selectNotSaleAntique");
                Антиквариат[] antiques = notSaleAntiques.ToArray();

                if (categoryFilterValue == "ювелирные изделия" || categoryFilterValue == "оружие" ||
                    categoryFilterValue == "произведения искусства" || categoryFilterValue == "букинистика" ||
                    categoryFilterValue == "часы")
                {
                    antiques = antiques.Where(c => c.Категория == categoryFilterValue).ToArray<Антиквариат>();
                }

                //фильтр историч. эпохи
                if (FilterHistoryEraDropDownList.SelectedItem.Text == "все эпохи")
                {
                    TableRow headerRow = antiquesTable.Rows[0];
                    antiquesTable.Rows.Clear();
                    antiquesTable.Rows.Add(headerRow);

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
                        cells[5].Text = BoolStr.Get(item.Наличие_страховки);
                        cells[6].Text = item.Категория;

                        TableRow row = new TableRow();
                        foreach (TableCell cell in cells)
                        {
                            row.Cells.Add(cell);
                        }

                        antiquesTable.Rows.Add(row);
                    }
                    return;
                }

                string filterValue = FilterHistoryEraDropDownList.SelectedItem.Text;
                bool isHistoryEraExists = false;
                isHistoryEraExists = antiques.Any(c => c.Историческая_эпоха == filterValue);
                if (isHistoryEraExists)
                {
                    Антиквариат[] searchAntiques = antiques.Where(c => c.Историческая_эпоха == filterValue).ToArray<Антиквариат>();

                    TableRow headerRow = antiquesTable.Rows[0];
                    antiquesTable.Rows.Clear();
                    antiquesTable.Rows.Add(headerRow);

                    foreach (Антиквариат item in searchAntiques)
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
                        cells[5].Text = BoolStr.Get(item.Наличие_страховки);
                        cells[6].Text = item.Категория;

                        TableRow row = new TableRow();
                        foreach (TableCell cell in cells)
                        {
                            row.Cells.Add(cell);
                        }

                        antiquesTable.Rows.Add(row);
                    }
                }
                else
                {
                    TableRow headerRow = antiquesTable.Rows[0];
                    antiquesTable.Rows.Clear();
                    antiquesTable.Rows.Add(headerRow);

                    errorSearchFilterLabel.Text = "Элементы с такими характеристиками фильтрации не найдены.";
                }
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            errorSearchFilterLabel.Text = "";
            if (SearchTextBox.Text == "")
            {
                return;
            }

            using (var context = new AntiqueStore())
            {
                string searchName = SearchTextBox.Text;
                bool nameExists = false;
                var notSaleAntiques = context.Database.SqlQuery<Антиквариат>("selectNotSaleAntique");
                Антиквариат[] antiques = notSaleAntiques.ToArray();

                nameExists = antiques.Any(c => c.Наименование == searchName);
                if (nameExists)
                {
                    Антиквариат[] searchAntiques = antiques.Where(c => c.Наименование == searchName).ToArray<Антиквариат>();

                    TableRow headerRow = antiquesTable.Rows[0]; //сохраняем заголовки таблицы
                    antiquesTable.Rows.Clear();
                    antiquesTable.Rows.Add(headerRow);

                    foreach (Антиквариат item in searchAntiques)
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
                        cells[5].Text = BoolStr.Get(item.Наличие_страховки);
                        cells[6].Text = item.Категория;

                        TableRow row = new TableRow();
                        foreach (TableCell cell in cells)
                        {
                            row.Cells.Add(cell);
                        }

                        antiquesTable.Rows.Add(row);
                    }
                }
                else
                {
                    TableRow headerRow = antiquesTable.Rows[0];
                    antiquesTable.Rows.Clear();
                    antiquesTable.Rows.Add(headerRow);

                    errorSearchFilterLabel.Text = "Элементы с таким наименованием не найдены.";
                }
            }
        }

        private void showAntiques()
        {
            TableRow headerRow = antiquesTable.Rows[0];
            antiquesTable.Rows.Clear();
            antiquesTable.Rows.Add(headerRow);

            using (var context = new AntiqueStore())
            {
                var notSaleAntiques = context.Database.SqlQuery<Антиквариат>("selectNotSaleAntique");
                Антиквариат[] antiques = notSaleAntiques.ToArray();

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
                        cells[5].Text = BoolStr.Get(item.Наличие_страховки);
                        cells[6].Text = item.Категория;

                        TableRow row = new TableRow();
                        foreach (TableCell cell in cells)
                        {
                            row.Cells.Add(cell);
                        }

                        antiquesTable.Rows.Add(row);
                    }
                }
                else
                {
                    errorSearchFilterLabel.Text = "Отсутствует антиквариат для продажи.";
                }
            }
        }

        protected void buyButton_Click(object sender, EventArgs e)
        {
            actionErrorLabel.Text = "";
            actionSuccessLabel.Text = "";

            using (var context = new AntiqueStore())
            {
                var notSaleAntiques = context.Database.SqlQuery<Антиквариат>("selectNotSaleAntique");
                Антиквариат[] antiques = notSaleAntiques.ToArray();

                bool idExists = false;
                bool idClientExists = false;
                int idAntique = 0;
                int idClient = 0;
                int idWorker = 0;
                try
                {
                    idAntique = int.Parse(IdSearchTextBox.Text);
                    idClient = int.Parse(IdClientTextBox.Text);

                    idExists = antiques.Any(c => c.Id_антиквариата == idAntique);
                    idClientExists = context.Клиент.Any(c => c.Id_клиента == idClient);
                    idWorker = (context.Сотрудник.FirstOrDefault()).Id_сотрудника;
                }
                catch
                {
                    if(!idClientExists)
                    {
                        actionErrorLabel.Text = "Не удалось совершить покупку. Клиент с указанным ИД не существует." +
                            "Обратитесь в администрацию для регистрации в системе, " +
                            "контакты указаны внизу страницы.";
                    }
                    else
                    {
                        actionErrorLabel.Text = "Не удалось совершить покупку. Проверьте правильность данных.";
                    }
                    return;
                }

                if (idExists && idClientExists)
                {
                    Антиквариат antique = antiques.Where(c => c.Id_антиквариата == idAntique).Single();
                    DateTime now = new DateTime();
                    now = DateTime.Now;
                    Покупка newBuy = new Покупка
                    {
                        Id_антиквариата = antique.Id_антиквариата,
                        Id_клиента = idClient,
                        Id_сотрудника = idWorker,
                        Статус = "обслуживание",
                        Дата = now
                    };

                    try
                    {
                        context.Покупка.Add(newBuy);
                        context.SaveChanges();
                        ShowSimilarAntique(antique.Id_антиквариата,
                            antique.Категория, antique.Историческая_эпоха, antique.Стоимость, antique.Состояние);
                        showAntiques();
                        actionSuccessLabel.Text = "Покупка успешно завершена.";
                    }
                    catch
                    {
                        actionErrorLabel.Text = "Не удалось совершить покупку. Проверьте правильность данных.";
                    }
                }
                else
                {
                    actionErrorLabel.Text = "Не удалось совершить покупку. Проверьте правильность данных.";
                }
            }
        }

        private void ShowSimilarAntique(int antiqueId, string category, string historyEra, decimal cost, string condition)
        {
            using (var context = new AntiqueStore())
            {
                System.Data.SqlClient.SqlParameter paramAntiqueId = new System.Data.SqlClient.SqlParameter("@antiqueId", antiqueId);
                System.Data.SqlClient.SqlParameter paramCategory = new System.Data.SqlClient.SqlParameter("@category", category);
                System.Data.SqlClient.SqlParameter paramEra = new System.Data.SqlClient.SqlParameter("@historyEra", historyEra);
                System.Data.SqlClient.SqlParameter paramCost = new System.Data.SqlClient.SqlParameter("@cost", cost);
                System.Data.SqlClient.SqlParameter paramCondition = new System.Data.SqlClient.SqlParameter("@condition", condition);

                Антиквариат[] similarAntiques = context.Database.SqlQuery<Антиквариат>("SimilarProducts @antiqueId, " +
                    "@category, @historyEra, @cost, @condition",
                    paramAntiqueId, paramCategory, paramEra, paramCost, paramCondition).ToArray();

                if (similarAntiques.Length > 0)
                {
                    similarAntiquePanel.Visible = true;

                    TableRow headerRow = similarAntiquesTable.Rows[0];
                    similarAntiquesTable.Rows.Clear();
                    similarAntiquesTable.Rows.Add(headerRow);

                    foreach (Антиквариат item in similarAntiques)
                    {
                        TableCell[] cells = new TableCell[5];
                        for (int i = 0; i < cells.Length; i++)
                        {
                            cells[i] = new TableCell();
                        }
                        cells[0].Text = item.Id_антиквариата.ToString();
                        cells[1].Text = item.Наименование;
                        cells[2].Text = item.Стоимость.ToString();
                        cells[3].Text = item.Историческая_эпоха;
                        cells[4].Text = item.Категория;

                        TableRow row = new TableRow();
                        foreach (TableCell cell in cells)
                        {
                            row.Cells.Add(cell);
                        }

                        similarAntiquesTable.Rows.Add(row);
                    }
                }
                else
                {
                    similarAntiquePanel.Visible = false;
                }

            }

        }

    }
}