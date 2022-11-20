<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Main.Master" AutoEventWireup="true" CodeBehind="RedactPurchaseForm.aspx.cs" Inherits="Антикварный_магазин.Pages.Login.Seller.Purchases.RedactForm" %>

<asp:Content ID="redactPurchaseContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <div class="content">
        <h2>Введите данные: </h2>

        <table border="0" style="padding-bottom: 10px;">
            <tr>
                <td style="height: 43px;">Дата:</td>

                <td style="height: 43px;">
                    <asp:TextBox ID="DateTextBox" runat="server" />
                    <asp:Label runat="server" ID="DateErrorLabel"> </asp:Label>

                </td>
            </tr>
            <tr>
                <td style="height: 43px;">Статус:</td>

                <td style="height: 43px;">
                    <asp:DropDownList ID="StatusDropDownList"
                        AutoPostBack="True"
                        runat="server">

                        <asp:ListItem Value="completeListItem">завершён</asp:ListItem>
                        <asp:ListItem Value="serviceListItem">обслуживание</asp:ListItem>

                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 26px;">Id клиента:</td>
                <td style="height: 26px;">

                    <asp:TextBox ID="IdClientTextBox" runat="server" />

                </td>
            </tr>
            <tr>
                <td style="height: 26px;">Id сотрудника:</td>
                <td style="height: 26px;">
                    <asp:TextBox ID="IdWorkerTextBox" runat="server" />

                </td>
            </tr>
            <tr>
                <td style="height: 26px;">Id антиквариата:</td>
                <td style="height: 26px;">
                    <asp:TextBox ID="IdAntiqueTextBox" runat="server" />

                </td>
            </tr>

        </table>

        <asp:Button runat="server" ID="SavePurchaseButton" OnClick="SavePurchaseButton_Click" Text="Сохранить" CssClass="button" />

        <br />

        <asp:Label runat="server" ID="ErrorSavePurchaseLabel"> </asp:Label>
        <br />
        <br />
    </div>


</asp:Content>
