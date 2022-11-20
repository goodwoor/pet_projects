using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Антикварный_магазин.Model;
using Антикварный_магазин.Model.Helpers;


namespace Антикварный_магазин.Pages.Login.Seller.Экспертизы
{
    public partial class ExpertiseTableForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            showExpertiseTable();
        }

        private void showExpertiseTable(bool showAfterFilter = false, IEnumerable<Экспертиза> afterFilter = null)
        {
            TableRow headerRow = expertiseTable.Rows[0];
            expertiseTable.Rows.Clear();
            expertiseTable.Rows.Add(headerRow);

            using (var context = new AntiqueStore())
            {
                Экспертиза[] expertises = context.Экспертиза.Select(s => s).ToArray();
                if (showAfterFilter == true)
                {
                    expertises = afterFilter.ToArray();
                }

                if (expertises.Length > 0)
                {
                    foreach (Экспертиза item in expertises)
                    {
                        TableCell[] cells = new TableCell[9];
                        for (int i = 0; i < cells.Length; i++)
                        {
                            cells[i] = new TableCell();
                        }
                        cells[0].Text = item.Номер_договора.ToString();
                        cells[1].Text = item.Id_антиквариата.ToString();
                        cells[2].Text = item.Оценочная_организация;
                        cells[3].Text = item.Ценность;
                        cells[4].Text = item.Подтверждение_подлинности.ToString();
                        cells[5].Text = item.Оценочная_стоимость.ToString();
                        cells[6].Text = item.Примерный_возраст.ToString();
                        cells[7].Text = item.Авторство;
                        cells[8].Text = item.Место_создания;


                        TableRow row = new TableRow();
                        foreach (TableCell cell in cells)
                        {
                            row.Cells.Add(cell);
                        }

                        expertiseTable.Rows.Add(row);
                    }
                }
            }
        }

        protected void RedactButton_Click(object sender, EventArgs e)
        {
            
            if (checkShearch(contractNumberTextBox.Text))
            {
                Session["ID_Expertise"] = int.Parse(contractNumberTextBox.Text);
                Session["RedactFlagExpertise"] = true;
                string redirectUrl = "~/Pages/Forms/Admin/Expertise/RedactExpertiseForm.aspx";
                Response.Redirect(redirectUrl);
            }
            else
            {
                actionErrorLabel.Text = "Некорректный ID элемента.";
                return;
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            if (checkShearch(contractNumberTextBox.Text))
            {
                int NumExpertise = int.Parse(contractNumberTextBox.Text);
                using (var context = new AntiqueStore())
                {
                    Экспертиза toDelete = context.Экспертиза.Where(c => c.Номер_договора == NumExpertise).Single();
                    context.Экспертиза.Remove(toDelete);
                    context.SaveChanges();
                }
                showExpertiseTable();
            }
            else
            {
                actionErrorLabel.Text = "Некорректный ID элемента.";
                return;
            }
        }

        protected void NewElemButton_Click(object sender, EventArgs e)
        {
            string redirectUrl = "~/Pages/Forms/Admin/Expertise/NewExpertiseForm.aspx";
            Response.Redirect(redirectUrl);
        }

        private bool checkShearch(string strContractNumber)
        {
            if (strContractNumber == "")
            {
                actionErrorLabel.Text = "Введите ID элемента.";
                return false;
            }

            try
            {
                int contractNumber = int.Parse(strContractNumber);
                using (var context = new AntiqueStore())
                {
                    if (context.Экспертиза.Any(s => s.Номер_договора == contractNumber))
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

        protected void FilterValuationDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            actionErrorLabel.Text = "";
            using (var context = new AntiqueStore())
            {
                string truthFilterValue = FilterTruthDropDownList.SelectedItem.Text;
                Экспертиза[] expertises = context.Экспертиза.ToArray();

                if (truthFilterValue == "True" || truthFilterValue == "False")
                {
                    expertises = expertises.Where(c => c.Подтверждение_подлинности == bool.Parse(truthFilterValue)).ToArray<Экспертиза>();
                }

                if (FilterValuationDropDownList.SelectedItem.Text == "любая ценность")
                {
                    showExpertiseTable(true, expertises);
                    return;
                }

                string filterValue = FilterValuationDropDownList.SelectedItem.Text;
                bool isValuationExists = false;
                isValuationExists = expertises.Any(c => c.Ценность == filterValue);
                if (isValuationExists)
                {
                    Экспертиза[] filterExpertise = expertises.Where(c => c.Ценность == filterValue).ToArray<Экспертиза>();
                    showExpertiseTable(true, filterExpertise);
                }
                else
                {
                    Экспертиза[] emptyExpertise = new Экспертиза[0];
                    showExpertiseTable(true, emptyExpertise);

                    actionErrorLabel.Text = "Элементы с такими характеристиками фильтрации не найдены.";
                }
            }
        }
        protected void FilterTruthDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            actionErrorLabel.Text = "";
            using (var context = new AntiqueStore())
            {
                string valuationFilterValue = FilterValuationDropDownList.SelectedItem.Text;
                Экспертиза[] expertises = context.Экспертиза.ToArray();

                if (valuationFilterValue == "историческая" || valuationFilterValue == "художественная" ||
                    valuationFilterValue == "культурная" || valuationFilterValue == "научная" ||
                    valuationFilterValue == "этнографическая" || valuationFilterValue == "другая" ||
                    valuationFilterValue == "отсутствует")
                {
                    expertises = expertises.Where(c => c.Ценность == valuationFilterValue).ToArray<Экспертиза>();
                }

                string truthFilterValue = FilterTruthDropDownList.SelectedItem.Text;

                if (truthFilterValue == "любая подлинность")
                {
                    showExpertiseTable(true, expertises);
                    return;
                }

                bool isTruthExists = false;
                isTruthExists = expertises.Any(c => c.Подтверждение_подлинности == bool.Parse(truthFilterValue));
                if (isTruthExists)
                {
                    Экспертиза[] filterExpertise = expertises.Where(c => c.Подтверждение_подлинности == bool.Parse(truthFilterValue)).ToArray<Экспертиза>();
                    showExpertiseTable(true, filterExpertise);
                }
                else
                {
                    Экспертиза[] emptyExpertise = new Экспертиза[0];
                    showExpertiseTable(true, emptyExpertise);

                    actionErrorLabel.Text = "Элементы с такими характеристиками фильтрации не найдены.";
                }
            }
        }
    }
}