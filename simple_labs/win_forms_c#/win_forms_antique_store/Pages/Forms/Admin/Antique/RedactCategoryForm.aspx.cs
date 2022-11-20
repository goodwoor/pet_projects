using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Антикварный_магазин.Model;
using Антикварный_магазин.Model.Helpers;

namespace Антикварный_магазин.Pages.Forms.Admin.Antique
{
    public partial class RedactCategoryForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool redactFlag = bool.Parse(Session["RedactFlagAntiqueCategory"].ToString());

            if (redactFlag)
            {
                string category = Session["Redact_category_antique_category"].ToString();
                switch (category)
                {
                    case "ювелирные изделия":
                        showContent(0);
                        break;
                    case "оружие":
                        showContent(1);
                        break;
                    case "произведения искусства":
                        showContent(2);
                        break;
                    case "букинистика":
                        showContent(3);
                        break;
                    case "часы":
                        showContent(4);
                        break;
                }
                Session["RedactFlagAntiqueCategory"] = false;
            }


        }

        private void showContent(int categoryCode)
        {
            Panel[] allPanels = new Panel[5] { IzdelPanel, WeaponPanel, ProizvedPanel, BookPanel, ClockPanel };
            Panel visiblePanel = new Panel();
            switch (categoryCode)
            {
                case 0:
                    visiblePanel = IzdelPanel;
                    break;
                case 1:
                    visiblePanel = WeaponPanel;
                    break;
                case 2:
                    visiblePanel = ProizvedPanel;
                    break;
                case 3:
                    visiblePanel = BookPanel;
                    break;
                case 4:
                    visiblePanel = ClockPanel;
                    break;
            }
            foreach (Panel itemPanel in allPanels)
            {
                if (itemPanel != visiblePanel)
                {
                    itemPanel.Visible = false;
                    continue;
                }
                itemPanel.Visible = true;
            }
        }

        protected void saveJewelry(object sender, EventArgs e)
        {
            using (var context = new AntiqueStore())
            {
                bool dateIsValid = HelpValidators.IsValidWeight(IzdelWeightTextBox, IzdelWeightErrorLabel);
                if (!dateIsValid)
                {
                    return;
                }
                ErrorAddLabel.Text = "";

                try
                {
                    int antiqueId = int.Parse(Session["Redact_category_antique_ID"].ToString());

                    Ювелирное_изделие newJewelry = context.Ювелирное_изделие.Find(antiqueId);
                    newJewelry.Материал = IzdelMaterialTextBox.Text == "" ? "не известен" : IzdelMaterialTextBox.Text;
                    newJewelry.Вставка = IzdelInsertTextBox.Text == "" ? "не известна" : IzdelInsertTextBox.Text;
                    newJewelry.Вес_граммы_ = IzdelWeightTextBox.Text == "" ? 0 : double.Parse(IzdelWeightTextBox.Text);

                    context.SaveChanges();

                    ErrorAddLabel.Text = "";

                    string redirectUrl = "~/Pages/Forms/Admin/Antique/AntiquesTableForm.aspx";
                    Response.Redirect(redirectUrl);
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbExeption)
                {
                    HelpValidators.CheckExeption(dbExeption, ErrorAddLabel);
                }
            }
        }

        protected void saveWeapon(object sender, EventArgs e)
        {
            using (var context = new AntiqueStore())
            {
                try
                {
                    int antiqueId = int.Parse(Session["Redact_category_antique_ID"].ToString());

                    Оружие newWeapon = context.Оружие.Find(antiqueId);
                    newWeapon.Вид_оружия = WeaponTypeTextBox.Text == "" ? "не известен" : WeaponTypeTextBox.Text;
                    newWeapon.Страна_изготовления = WeaponCountryTextBox.Text == "" ? "не известна" : WeaponCountryTextBox.Text;
                    context.SaveChanges();

                    ErrorAddLabel.Text = "";

                    string redirectUrl = "~/Pages/Forms/Admin/Antique/AntiquesTableForm.aspx";
                    Response.Redirect(redirectUrl);
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbExeption)
                {
                    HelpValidators.CheckExeption(dbExeption, ErrorAddLabel);
                }
            }
        }

        protected void saveProizved(object sender, EventArgs e)
        {
            using (var context = new AntiqueStore())
            {
                try
                {
                    int antiqueId = int.Parse(Session["Redact_category_antique_ID"].ToString());

                    Произведение_исскуства newArt = context.Произведение_исскуства.Find(antiqueId);

                    newArt.Автор = ProizvedAutorTextBox.Text == "" ? "не известен" : ProizvedAutorTextBox.Text;
                    newArt.Вид_искусства = ProizvedTypeTextBox.Text == "" ? "не известен" : ProizvedTypeTextBox.Text;
                    context.SaveChanges();

                    ErrorAddLabel.Text = "";

                    string redirectUrl = "~/Pages/Forms/Admin/Antique/AntiquesTableForm.aspx";
                    Response.Redirect(redirectUrl);
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbExeption)
                {
                    HelpValidators.CheckExeption(dbExeption, ErrorAddLabel);
                }
            }
        }

        protected void saveBook(object sender, EventArgs e)
        {
            using (var context = new AntiqueStore())
            {
                bool dateIsValid = HelpValidators.IsValidBookPages(BookPagesTextBox, BookPagesErrorLabel);
                if (!dateIsValid)
                {
                    return;
                }
                ErrorAddLabel.Text = "";

                try
                {
                    int antiqueId = int.Parse(Session["Redact_category_antique_ID"].ToString());

                    Букинистика newBook = context.Букинистика.Find(antiqueId);
                    newBook.Автор = BookAutorTextBox.Text == "" ? "не известен" : BookAutorTextBox.Text;
                    newBook.Количество_страниц = BookPagesTextBox.Text == "" ? 0 : int.Parse(BookPagesTextBox.Text);
                    newBook.Язык = BookLanguageTextBox.Text == "" ? "не известен" : BookLanguageTextBox.Text;

                    context.SaveChanges();

                    ErrorAddLabel.Text = "";

                    string redirectUrl = "~/Pages/Forms/Admin/Antique/AntiquesTableForm.aspx";
                    Response.Redirect(redirectUrl);
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbExeption)
                {
                    HelpValidators.CheckExeption(dbExeption, ErrorAddLabel);
                }
            }
        }

        protected void saveClock(object sender, EventArgs e)
        {
            using (var context = new AntiqueStore())
            {
                try
                {
                    int antiqueId = int.Parse(Session["Redact_category_antique_ID"].ToString());

                    Часы newClock = context.Часы.Find(antiqueId);
                    newClock.Вид = ClockTypeTextBox.Text == "" ? "не известен" : ClockTypeTextBox.Text;
                    newClock.Основной_материал = ClockMaterialTextBox.Text == "" ? "не известен" : ClockMaterialTextBox.Text;
                    newClock.Страна_изготовления = ClockCountryTextBox.Text == "" ? "не известна" : ClockCountryTextBox.Text;
                    context.SaveChanges();

                    ErrorAddLabel.Text = "";

                    string redirectUrl = "~/Pages/Forms/Admin/Antique/AntiquesTableForm.aspx";
                    Response.Redirect(redirectUrl);
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbExeption)
                {
                    HelpValidators.CheckExeption(dbExeption, ErrorAddLabel);
                }
            }
        }
    }
}