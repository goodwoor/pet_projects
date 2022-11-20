using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Антикварный_магазин.Model;
using Антикварный_магазин.Model.Helpers;

namespace Антикварный_магазин.Pages.Login.Seller.Expertise
{
    public partial class NewElemForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddExpertiseButton_Click(object sender, EventArgs e)
        {
            bool dateIsValid = HelpValidators.IsValidCost(CostTextBox, CostErrorLabel, "Оценочная стоимость");
            if (!dateIsValid)
            {
                return;
            }

            ErrorAddExpertiseLabel.Text = "";

            using (var context = new AntiqueStore())
            {
                int idAntiq = 0;
                try
                {
                    idAntiq = int.Parse(IdAntiqueTextBox.Text);
                }
                catch
                {
                    ErrorAddExpertiseLabel.Text = "Не удалось совершить операцию. Антиквариат с указанным ID не существует.";
                    return;
                }

                bool isIDExists = context.Антиквариат.Any(c => c.Id_антиквариата == idAntiq);
                bool isAntiqueHaveExpertise = context.Экспертиза.Any(c => c.Id_антиквариата == idAntiq);

                if (isIDExists && !isAntiqueHaveExpertise)
                {
                    try
                    {
                        Экспертиза newExpertise = new Экспертиза
                        {
                            Id_антиквариата = int.Parse(IdAntiqueTextBox.Text),
                            Оценочная_организация = OrganizationTextBox.Text,
                            Ценность = ValuationDropDownList.SelectedItem.Text,
                            Подтверждение_подлинности = bool.Parse(TruthDropDownList.SelectedItem.Text),
                            Оценочная_стоимость = decimal.Parse(CostTextBox.Text),
                            Примерный_возраст = AgeTextBox.Text == "" ? 0 : int.Parse(AgeTextBox.Text),
                            Авторство = AvtorTextBox.Text == "" ? "не известно" : AvtorTextBox.Text,
                            Место_создания = PlaceOfCreationTextBox.Text == "" ? "не известно" : PlaceOfCreationTextBox.Text
                        };

                        context.Экспертиза.Add(newExpertise);
                        context.SaveChanges();
                        Response.Redirect("~/Pages/Forms/Admin/Expertise/ExpertisesTableForm.aspx");
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException dbExeption)
                    {
                        HelpValidators.CheckExeption(dbExeption, ErrorAddExpertiseLabel);
                    }
                }
                else
                {
                    if (!isIDExists)
                    {
                        ErrorAddExpertiseLabel.Text = "Не удалось совершить операцию. Антиквариат с указанным ID не существует.";
                    }
                    if (isAntiqueHaveExpertise)
                    {
                        ErrorAddExpertiseLabel.Text = "Не удалось совершить операцию. Антиквариат с указанным ID уже прошёл экспертизу.";
                    }
                    
                }

            }
        }
    }
}