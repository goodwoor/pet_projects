<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Main.Master" AutoEventWireup="true" CodeBehind="RedactWorkerForm.aspx.cs" Inherits="Антикварный_магазин.Pages.Login.Seller.Workers.RedactForm" %>

<asp:Content ID="RedactWorkerContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

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
                <td style="height: 43px;">Зарплата:</td>

                <td style="height: 43px;">
                    <asp:TextBox ID="SalaryTextBox" runat="server" />
                    <asp:Label runat="server" ID="SalaryErrorLabel"> </asp:Label>
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

        <asp:Button runat="server" ID="SaveWorkerButton" OnClick="SaveWorkerButton_Click" Text="Сохранить" CssClass="button" />

        <asp:Label runat="server" ID="ErrorSaveWorkerLabel"> </asp:Label>
        <br />
        <br />
    </div>


</asp:Content>
