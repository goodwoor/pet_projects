using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Антикварный_магазин.Model.Helpers;
using Антикварный_магазин.Model;

namespace Антикварный_магазин.Pages.Login.Seller.Expertise
{
    public partial class RedactForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool redactFlag = bool.Parse(Session["RedactFlagExpertise"].ToString());
            int expertiseNum = int.Parse(Session["ID_Expertise"].ToString());

            if (redactFlag)
            {
                using (var context = new AntiqueStore())
                {
                    Экспертиза toRedact = context.Экспертиза.Where(c => c.Номер_договора == expertiseNum).Single();
                    IdAntiqueTextBox.Text = toRedact.Id_антиквариата.ToString();
                    OrganizationTextBox.Text = toRedact.Оценочная_организация;
                    ValuationDropDownList.SelectedIndex = ValuationCodeComparer.getCodeValuation(toRedact.Ценность);
                    TruthDropDownList.SelectedIndex = toRedact.Подтверждение_подлинности.ToString() == "true" ? 0 : 1; ;
                    CostTextBox.Text = toRedact.Оценочная_стоимость.ToString();
                    AgeTextBox.Text = toRedact.Примерный_возраст.ToString();
                    AvtorTextBox.Text = toRedact.Авторство;
                    PlaceOfCreationTextBox.Text = toRedact.Место_создания;

                }
                Session["RedactFlagExpertise"] = false;
            }
            
        }

        protected void SaveExpertiseButton_Click(object sender, EventArgs e)
        {
            bool dateIsValid = HelpValidators.IsValidCost(CostTextBox, CostErrorLabel, "Оценочная стоимость");
            if (!dateIsValid)
            {
                return;
            }

            ErrorSaveExpertiseLabel.Text = "";

            using (var context = new AntiqueStore())
            {
                int idAntiq = 0;
                try
                {
                    idAntiq = int.Parse(IdAntiqueTextBox.Text);
                }
                catch
                {
                    ErrorSaveExpertiseLabel.Text = "Не удалось совершить операцию. Антиквариат с указанным ID не существует.";
                    return;
                }
                bool isIDExists = context.Антиквариат.Any(c => c.Id_антиквариата == idAntiq);

                if (isIDExists)
                {
                    int expertiseNum = int.Parse(Session["ID_Expertise"].ToString());
                    Экспертиза expToRedact = context.Экспертиза.Where(c => c.Номер_договора == expertiseNum).Single();
                    expToRedact.Id_антиквариата = idAntiq;
                    expToRedact.Оценочная_организация = OrganizationTextBox.Text;
                    expToRedact.Ценность = ValuationDropDownList.SelectedItem.Text;
                    expToRedact.Подтверждение_подлинности = bool.Parse(TruthDropDownList.SelectedItem.Text);
                    expToRedact.Примерный_возраст = AgeTextBox.Text == "" ? 0 : int.Parse(AgeTextBox.Text);
                    expToRedact.Авторство = AvtorTextBox.Text == "" ? "не известно" : AvtorTextBox.Text;
                    expToRedact.Место_создания = PlaceOfCreationTextBox.Text == "" ? "не известно" : PlaceOfCreationTextBox.Text;

                    try
                    {
                        context.SaveChanges();
                        ErrorSaveExpertiseLabel.Text = "";

                        Response.Redirect("~/Pages/Forms/Admin/Expertise/ExpertisesTableForm.aspx");
                    }
                    catch
                    {
                        ErrorSaveExpertiseLabel.Text = "Не удалось сохранить изменения. Проверьте правильность данных.";
                    }
                }
                else
                {
                    ErrorSaveExpertiseLabel.Text = "Не удалось сохранить изменения. Антиквариат с указанным ID не существует.";
                }
            }
        }
    }
}