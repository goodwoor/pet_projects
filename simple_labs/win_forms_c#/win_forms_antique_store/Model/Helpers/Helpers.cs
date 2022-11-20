using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using Антикварный_магазин.Model;


namespace Антикварный_магазин.Model.Helpers
{
    public static class HelpValidators
    {
        public static bool IsValidPhone(TextBox toValidateTextBox, Label errorMessageLabel)
        {
            long PhoneNum;
            try
            {
                PhoneNum = long.Parse(toValidateTextBox.Text);
            }
            catch
            {
                errorMessageLabel.Text = "Некорректный номер телефона.";
                return false;
            }

            if (PhoneNum < 10000000000)
            {
                errorMessageLabel.Text = "Некорректный номер телефона.";
                return false;
            }
            else if (PhoneNum > 99999999999)
            {
                errorMessageLabel.Text = "Некорректный номер телефона.";
                return false;
            }
            else
            {
                errorMessageLabel.Text = "";
                return true;
            }
        }

        public static bool IsNotRequried(TextBox toValidateTextBox, Label errorMessageLabel, string fieldName)
        {
            if(toValidateTextBox.Text == null || toValidateTextBox.Text == "")
            {
                errorMessageLabel.Text = "Поле \"" + fieldName + "\" не может быть пустым.";
                return false;
            }
            else
            {
                errorMessageLabel.Text = "";
                return true;
            }

        }

        public static bool IsValidCost(TextBox toValidateTextBox, Label errorMessageLabel, string fieldName)
        {
            try
            {
                decimal costValue = decimal.Parse(toValidateTextBox.Text);
                if (costValue <= 0)
                {
                    errorMessageLabel.Text = "Поле \"" + fieldName + "\" может содержать только положительные значения.";
                    return false;
                }
                else
                {
                    errorMessageLabel.Text = "";
                    return true;
                }
            }
            catch
            {
                errorMessageLabel.Text = "Поле \"" + fieldName + "\" выходит за допустимый диапазон.";
                return false;
            }
        }

        public static bool IsValidDate(TextBox toValidateTextBox, Label errorMessageLabel)
        {
            try
            {
                DateTime.Parse(toValidateTextBox.Text);
                errorMessageLabel.Text = "";
                return true;
            }
            catch
            {
                errorMessageLabel.Text = "Не удаётся преобразовать поле \" Дата \" к типу Date.";
                return false;
            }
        }
        public static bool IsValidBookPages(TextBox toValidateTextBox, Label errorMessageLabel)
        {
            if (toValidateTextBox.Text == "")
            {
                return true;
            }

            try
            {
                int bookPages = int.Parse(toValidateTextBox.Text);
                if (bookPages < 0)
                {
                    errorMessageLabel.Text = "Поле \"Количество страниц\" может содержать только положительные значения.";
                    return false;
                }
                else
                {
                    errorMessageLabel.Text = "";
                    return true;
                }
            }
            catch
            {
                errorMessageLabel.Text = "Поле \"Количество страниц\" выходит за допустимый диапазон.";
                return false;
            }
        }

        public static bool IsValidWeight(TextBox toValidateTextBox, Label errorMessageLabel)
        {
            if (toValidateTextBox.Text == "")
            {
                return true;
            }

            try
            {
                float weight = float.Parse(toValidateTextBox.Text);
                if (weight < 0)
                {
                    errorMessageLabel.Text = "Поле \"Вес(граммы)\" может содержать только положительные значения.";
                    return false;
                }
                else
                {
                    errorMessageLabel.Text = "";
                    return true;
                }
            }
            catch
            {
                errorMessageLabel.Text = "Поле \"Вес(граммы)\" выходит за допустимый диапазон.";
                return false;
            }
        }

        public static void CheckExeption(System.Data.Entity.Validation.DbEntityValidationException exeptionToCheck, Label errorMessageLabel)
        {
            string message = "";
            foreach (var validationErrors in exeptionToCheck.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    message += validationError.ErrorMessage;
                }
            }
            errorMessageLabel.Text = "Не удалось совершить операцию. Проверьте правильность данных: " + message;
        }
    }
    
    public static class CategoryCodeComparer
    {
        public static int getCodeGategory(string categoryName)
        {
            switch(categoryName)
            {
                case "ювелирные изделия":
                    return 0;
                case "оружие":
                    return 1;
                case "произведения искусства":
                    return 2;
                case "букинистика":
                    return 3;
                case "часы":
                    return 4;
                default:
                    return -1;
            }
        }

    }

    public static class ValuationCodeComparer
    {
        public static int getCodeValuation(string valuationName)
        {
            switch (valuationName)
            {
                case "историческая":
                    return 0;
                case "художественная":
                    return 1;
                case "культурная":
                    return 2;
                case "научная":
                    return 3;
                case "этнографическая":
                    return 4;
                case "другая":
                    return 5;
                case "отсутствует":
                    return 6;
                default:
                    return 6;

            }
        }
    }

    public static class HistoryEraCodeComparer
    {
        public static int getCodeHistoryEra(string historyEra)
        {
            switch (historyEra)
            {
                case "первобытное общество":
                    return 0;
                case "древний мир":
                    return 1;
                case "средние века":
                    return 2;
                case "новое время":
                    return 3;
                case "новейшее время":
                    return 4;
                default:
                    return -1;

            }
        }
    }
    public static class ConditionCodeComparer
    {
        public static int getCodeCondition(string condition)
        {
            switch (condition)
            {
                case "хорошее":
                    return 0;
                case "нормальное":
                    return 1;
                case "ветхое":
                    return 2;
                case "под реставрацию":
                    return 3;
                default:
                    return -1;

            }
        }
    }

    public static class BoolStr
    {
        public static string Get(bool value)
        {
            if(value == true)
            {
                return "есть";
            }
            else if(value == false)
            {
                return "отсутствует";
            }
            else
            {
                return "";
            }
        }
    }

}