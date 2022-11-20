<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Main.Master" AutoEventWireup="true" CodeBehind="ClientsTableForm.aspx.cs" Inherits="Антикварный_магазин.Pages.Login.Seller.Клиенты.ClientsForm" %>

<asp:Content ID="ClientsContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <h1 class="text-center">Клиенты </h1>
    <br />

    <div class="center-display">
        <asp:Table runat="server" ID="clientsTable" BorderStyle="Solid"
            BorderWidth="2px" ForeColor="Black" GridLines="Both"
            Height="47px" Style="margin-left: 0px; margin-bottom: 14px; text-align: center;" Width="70%">

            <asp:TableFooterRow>
                <asp:TableHeaderCell> ID </asp:TableHeaderCell>
                <asp:TableHeaderCell> ФИО </asp:TableHeaderCell>
                <asp:TableHeaderCell> Страна,город </asp:TableHeaderCell>
                <asp:TableHeaderCell> Номер телефона </asp:TableHeaderCell>
                <asp:TableHeaderCell> Email </asp:TableHeaderCell>
            </asp:TableFooterRow>

        </asp:Table>
    </div>

    <asp:Panel ID="ActionClientsPanel" runat="server" Width="470px" CssClass="center">
        <table style="width: 100%; margin-top: 20px;" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <div class="center-display">
                    Выбор по ID: 
                    <asp:TextBox ID="IdSearchTextBox" runat="server" Width="50%" />
                </div>
            </tr>
            <tr style="margin: 0 auto;">
                <td style="height: 26px; width: 50%;">
                    <div class="center-display">
                        <asp:Button runat="server" ID="RedactButton" OnClick="RedactButton_Click" Text="Изменить" />
                        <asp:Button runat="server" ID="DeleteButton" OnClick="DeleteButton_Click" Text="Удалить" />
                        <asp:Button runat="server" ID="NewElemButton" OnClick="NewElemButton_Click" Text="Добавить новый элемент" />
                    </div>

                    <div class="center-display">
                        <asp:Label runat="server" ID="actionSuccessLabel">  </asp:Label>
                        <asp:Label runat="server" ID="actionErrorLabel">  </asp:Label>
                    </div>

                </td>
            </tr>
        </table>
    </asp:Panel>


</asp:Content>
