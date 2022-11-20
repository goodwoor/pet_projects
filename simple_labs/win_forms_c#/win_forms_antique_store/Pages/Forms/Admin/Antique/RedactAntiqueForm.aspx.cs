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
    public partial class RedactForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool redactFlag = bool.Parse(Session["RedactFlagAntique"].ToString());
            int idAntique = int.Parse(Session["ID_antique"].ToString());

            if (redactFlag)
            {
                using (var context = new AntiqueStore())
                {
                    Антиквариат toRedact = context.Антиквариат.Find(idAntique);
                    NameTextBox.Text = toRedact.Наименование;
                    CostTextBox.Text = toRedact.Стоимость.ToString();
                    ConditionDropDownList.SelectedIndex = ConditionCodeComparer.getCodeCondition(toRedact.Состояние);
                    HistoryDropDownList.SelectedIndex = HistoryEraCodeComparer.getCodeHistoryEra(toRedact.Историческая_эпоха);
                    TruthDropDownList.SelectedIndex = toRedact.Наличие_страховки == true ? 0 : 1;
                    CategoryDropDownList.SelectedIndex = CategoryCodeComparer.getCodeGategory(toRedact.Категория);
                }
                Session["RedactFlagAntique"] = false;
            }
        }

        protected void SaveAntiqueButton_Click(object sender, EventArgs e)
        {
            bool dateIsValid = HelpValidators.IsNotRequried(NameTextBox, NameErrorLabel, "Наименование")
                                && HelpValidators.IsNotRequried(CostTextBox, CostErrorLabel, "Стоимость")
                                && HelpValidators.IsValidCost(CostTextBox, CostErrorLabel, "Стоимость");
            if (!dateIsValid)
            {
                return;
            }

            using (var context = new AntiqueStore())
            {
                int idAntique = int.Parse(Session["ID_antique"].ToString());
                Антиквариат redactAntique = context.Антиквариат.Find(idAntique);

                redactAntique.Наименование = NameTextBox.Text;
                redactAntique.Стоимость = decimal.Parse(CostTextBox.Text);
                redactAntique.Состояние = ConditionDropDownList.SelectedItem.Text;
                redactAntique.Историческая_эпоха = HistoryDropDownList.SelectedItem.Text;
                redactAntique.Наличие_страховки = bool.Parse(TruthDropDownList.SelectedItem.Text);

                try
                {
                    string oldCategory = redactAntique.Категория;
                    string newCategory = CategoryDropDownList.SelectedItem.Text;

                    if (newCategory != oldCategory)
                    {
                        redactAntique.Категория = newCategory;
                        deleteAntiqueInCategory(oldCategory, idAntique, context);
                        saveNewCategory(newCategory, idAntique, context);
                    }

                    context.SaveChanges();
                    Session["Redact_category_antique_ID"] = redactAntique.Id_антиквариата;
                    Session["Redact_category_antique_category"] = redactAntique.Категория;
                    Session["RedactFlagAntiqueCategory"] = true;

                    ErrorAddAntiqueLabel.Text = "";

                    string redirectUrl = "~/Pages/Forms/Admin/Antique/RedactCategoryForm.aspx";
                    Response.Redirect(redirectUrl);
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbExeption)
                {
                    HelpValidators.CheckExeption(dbExeption, ErrorAddAntiqueLabel);
                }
            }
        }

        private void deleteAntiqueInCategory(string category, int antiqueID, AntiqueStore context)
        {

            switch (category)
            {
                case "ювелирные изделия":
                    Ювелирное_изделие jeleweryToDelete = context.Ювелирное_изделие.Find(antiqueID);
                    context.Ювелирное_изделие.Remove(jeleweryToDelete);
                    break;
                case "оружие":
                    Оружие weaponToDelete = context.Оружие.Find(antiqueID);
                    context.Оружие.Remove(weaponToDelete);
                    break;
                case "произведения искусства":
                    Произведение_исскуства artToDelete = context.Произведение_исскуства.Find(antiqueID);
                    context.Произведение_исскуства.Remove(artToDelete);
                    break;
                case "букинистика":
                    Букинистика bookToDelete = context.Букинистика.Find(antiqueID);
                    context.Букинистика.Remove(bookToDelete);
                    break;
                case "часы":
                    Часы clockToDelete = context.Часы.Find(antiqueID);
                    context.Часы.Remove(clockToDelete);
                    break;
            }
        }

        private void saveNewCategory(string category, int antiqueID, AntiqueStore context)
        {
            switch (category)
            {
                case "ювелирные изделия":
                    Ювелирное_изделие newJewerly = new Ювелирное_изделие
                    {
                        Id_антиквариата = antiqueID
                    };
                    context.Ювелирное_изделие.Add(newJewerly);
                    context.SaveChanges();
                    break;
                case "оружие":
                    Оружие newWeapon = new Оружие
                    {
                        Id_антиквариата = antiqueID
                    };
                    context.Оружие.Add(newWeapon);
                    context.SaveChanges();
                    break;
                case "произведения искусства":
                    Произведение_исскуства newArt = new Произведение_исскуства
                    {
                        Id_антиквариата = antiqueID
                    };
                    context.Произведение_исскуства.Add(newArt);
                    context.SaveChanges();
                    break;
                case "букинистика":
                    Букинистика newBook = new Букинистика
                    {
                        Id_антиквариата = antiqueID
                    };
                    context.Букинистика.Add(newBook);
                    context.SaveChanges();
                    break;
                case "часы":
                    Часы newClock = new Часы
                    {
                        Id_антиквариата = antiqueID
                    };
                    context.Часы.Add(newClock);
                    context.SaveChanges();
                    break;
            }


        }

    }
}