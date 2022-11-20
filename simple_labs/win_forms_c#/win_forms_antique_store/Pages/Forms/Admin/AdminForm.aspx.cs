using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Антикварный_магазин.Model;

namespace Антикварный_магазин.Pages.Forms.Admin
{
    public partial class AdminForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var context = new AntiqueStore())
            {
                int countClients = context.Клиент.Count();
                int countSellers = context.Сотрудник.Count();
                countClientsLabel.Text = countClients.ToString();
                countSellersLabel.Text = countSellers.ToString();

                var notSaleAntiques = context.Database.SqlQuery<Антиквариат>("selectNotSaleAntique");
                antiquesLabel.Text = notSaleAntiques.Count().ToString();

                int countPerchases = context.Покупка.Count();
                purchasesLabel.Text = countPerchases.ToString();
            }
        }
    }
}