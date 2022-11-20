<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Main.Master" AutoEventWireup="true" CodeBehind="RedactClientForm.aspx.cs" Inherits="Антикварный_магазин.Pages.Login.Seller.Clients.RedactForm" %>

<asp:Content ID="RedactClientContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <div class="content">
        <h2>Введите данные: </h2>

        <table border="0" style="padding-bottom: 10px;">
            <tr>
                <td style="height: 43px;">ФИО:</td>

                <td style="height: 43px;">
                    <asp:TextBox ID="NameTextBox" runat="server" />
                    <asp:Label runat="server" ID="NameErrorLabel"> </asp:Label>

                </td>
            </tr>
            <tr>
                <td style="height: 43px;">Страна,город:</td>

                <td style="height: 43px;">
                    <asp:TextBox ID="CountryTownTextBox" runat="server" />
                    <asp:Label runat="server" ID="CountryErrorLabel"> </asp:Label>

                </td>
            </tr>
            <tr>
                <td style="height: 43px;">Почта:</td>

                <td style="height: 43px;">
                    <asp:TextBox ID="EmailTextBox" runat="server" TextMode="Email" />
                    <asp:Label runat="server" ID="EmailErrorLabel"> </asp:Label>

                </td>
            </tr>
            <tr>
                <td style="height: 26px;">Номер телефона:</td>
                <td style="height: 26px;">
                    <asp:TextBox ID="PhoneTextBox" runat="server" TextMode="Phone" />
                    <asp:Label runat="server" ID="PhoneErrorLabel"> </asp:Label>

                </td>
            </tr>
        </table>

        <asp:Button runat="server" ID="SaveClientButton" OnClick="SaveClientButton_Click" Text="Сохранить" CssClass="button" />

        <asp:Label runat="server" ID="ErrorSaveClientLabel"> </asp:Label>
        <br />
        <br />
    </div>

</asp:Content>
