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
    public partial class NewElemForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddAntiqueButton_Click(object sender, EventArgs e)
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
                string Категория = CategoryDropDownList.SelectedItem.Text;
                Антиквариат newAntique = new Антиквариат
                {
                    Наименование = NameTextBox.Text,
                    Стоимость = decimal.Parse(CostTextBox.Text),
                    Состояние = ConditionDropDownList.SelectedItem.Text,
                    Историческая_эпоха = HistoryDropDownList.SelectedItem.Text,
                    Наличие_страховки = bool.Parse(TruthDropDownList.SelectedItem.Text),
                    Категория = CategoryDropDownList.SelectedItem.Text
                };

                try
                {
                    context.Антиквариат.Add(newAntique);
                    context.SaveChanges();
                    saveCategory(newAntique.Категория, newAntique.Id_антиквариата, context);
                    Session["New_category_antique_ID"] = newAntique.Id_антиквариата;
                    Session["New_category_antique_category"] = newAntique.Категория;

                    ErrorAddAntiqueLabel.Text = "";

                    string redirectUrl = "~/Pages/Forms/Admin/Antique/NewCategoryForm.aspx";
                    Response.Redirect(redirectUrl);
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbExeption)
                {
                    HelpValidators.CheckExeption(dbExeption, ErrorAddAntiqueLabel);
                }
            }
        }

        private void saveCategory(string category, int antiqueID, AntiqueStore context)
        {
            switch (category)
            {
                case "ювелирные изделия":
                    Ювелирное_изделие newJewerly = new Ювелирное_изделие
                    {
                        Id_антиквариата = antiqueID,
                        Материал = "не известен",
                        Вставка = "не известна",
                        Вес_граммы_ = 0
                    };
                    context.Ювелирное_изделие.Add(newJewerly);
                    context.SaveChanges();
                    break;
                case "оружие":
                    Оружие newWeapon = new Оружие
                    {
                        Id_антиквариата = antiqueID,
                        Вид_оружия = "не известен",
                        Страна_изготовления = "не известна"

                    };
                    context.Оружие.Add(newWeapon);
                    context.SaveChanges();
                    break;
                case "произведения искусства":
                    Произведение_исскуства newArt = new Произведение_исскуства
                    {
                        Id_антиквариата = antiqueID,
                        Автор = "не известен",
                        Вид_искусства = "не известен"
                    };
                    context.Произведение_исскуства.Add(newArt);
                    context.SaveChanges();
                    break;
                case "букинистика":
                    Букинистика newBook = new Букинистика
                    {
                        Id_антиквариата = antiqueID,
                        Автор = "не известен",
                        Количество_страниц = 0,
                        Язык = "не известен"
                    };
                    context.Букинистика.Add(newBook);
                    context.SaveChanges();
                    break;
                case "часы":
                    Часы newClock = new Часы
                    {
                        Id_антиквариата = antiqueID,
                        Вид = "не известен",
                        Страна_изготовления = "не известна",
                        Основной_материал = "не известен"
                    };
                    context.Часы.Add(newClock);
                    context.SaveChanges();
                    break;
            }


        }
    }
}