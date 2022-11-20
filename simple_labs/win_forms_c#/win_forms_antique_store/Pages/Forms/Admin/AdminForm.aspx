<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Main.Master" AutoEventWireup="true" CodeBehind="AdminForm.aspx.cs" Inherits="Антикварный_магазин.Pages.Forms.Admin.AdminForm" %>

<asp:Content ID="AdminContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <div>

        <h1 class="text-center">Информация о магазине
        </h1>
        <br />

        <div class="center-panel">
            <div>
                Количество клиентов:
                <asp:Label runat="server" ID="countClientsLabel"> </asp:Label>
            </div>
            <br />
            <div>
                Количество сотрудников: 
                <asp:Label runat="server" ID="countSellersLabel"> </asp:Label>
            </div>
            <br />
            <div>
                Количество антиквариата на продажу: 
                <asp:Label runat="server" ID="antiquesLabel"> </asp:Label>
            </div>
            <br />
            <div>
                Куплено товаров: 
                <asp:Label runat="server" ID="purchasesLabel"> </asp:Label>
            </div>
        </div>



    </div>

    <br />

    <div>
        <h1 class="text-center">Управление базой данных
        </h1>

        <br />

        <div class="tools center-display">

            <div>
                <asp:Button runat="server" ID="AntiquesButton" Text="Антиквариат" CssClass="button" PostBackUrl="~/Pages/Forms/Admin/Antique/AntiquesTableForm.aspx" />
            </div>

            <div>
                <asp:Button runat="server" ID="ClentsButton2" Text="Клиенты" CssClass="button" PostBackUrl="~/Pages/Forms/Admin/Client/ClientsTableForm.aspx" />
            </div>

            <div>
                <asp:Button runat="server" ID="PurchasesButton4" Text="Покупки" CssClass="button" PostBackUrl="~/Pages/Forms/Admin/Purchase/PurchasesTableForm.aspx" />
            </div>

            <div>
                <asp:Button runat="server" ID="SellersButton" Text="Сотрудники" CssClass="button" PostBackUrl="~/Pages/Forms/Admin/Worker/WorkersTableForm.aspx" />
            </div>

            <div>
                <asp:Button runat="server" ID="ExpertiseButton" Text="Экспертизы" CssClass="button" PostBackUrl="~/Pages/Forms/Admin/Expertise/ExpertisesTableForm.aspx" />
            </div>

        </div>
    </div>

</asp:Content>
