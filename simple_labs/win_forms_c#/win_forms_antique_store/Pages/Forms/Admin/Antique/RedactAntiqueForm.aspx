<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Main.Master" AutoEventWireup="true" CodeBehind="RedactAntiqueForm.aspx.cs" Inherits="Антикварный_магазин.Pages.Login.Seller.Antique.RedactForm" %>

<asp:Content ID="RedactAntiqueContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">


    <div class="content">
        <h2>Введите данные: </h2>

        <table border="0" style="padding-bottom: 10px;">
            <tr>
                <td style="height: 43px;">Наименование:</td>

                <td style="height: 43px;">
                    <asp:TextBox ID="NameTextBox" runat="server" />
                    <asp:Label runat="server" ID="NameErrorLabel"> </asp:Label>

                </td>
            </tr>

            <tr>
                <td style="height: 26px;">Стоимость:</td>
                <td style="height: 26px;">
                    <asp:TextBox ID="CostTextBox" runat="server" />
                    <asp:Label runat="server" ID="CostErrorLabel"> </asp:Label>

                </td>
            </tr>

            <tr>
                <td style="height: 43px;">Состояние:</td>

                <td style="height: 43px;">
                    <asp:DropDownList ID="ConditionDropDownList"
                        AutoPostBack="True"
                        runat="server">

                        <asp:ListItem>хорошее</asp:ListItem>
                        <asp:ListItem>нормальное</asp:ListItem>
                        <asp:ListItem>ветхое</asp:ListItem>
                        <asp:ListItem>под реставрацию</asp:ListItem>

                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td style="height: 26px;">Историческая эпоха:</td>
                <td style="height: 26px;">

                    <asp:DropDownList ID="HistoryDropDownList"
                        AutoPostBack="True"
                        runat="server">

                        <asp:ListItem>первобытное общество</asp:ListItem>
                        <asp:ListItem>древний мир</asp:ListItem>
                        <asp:ListItem>средние века</asp:ListItem>
                        <asp:ListItem>новое время</asp:ListItem>
                        <asp:ListItem>новейшее время</asp:ListItem>

                    </asp:DropDownList>

                </td>
            </tr>


            <tr>
                <td style="height: 26px;">Наличие страховки:</td>
                <td style="height: 26px;">

                    <asp:DropDownList ID="TruthDropDownList"
                        AutoPostBack="True"
                        runat="server">

                        <asp:ListItem> true </asp:ListItem>
                        <asp:ListItem> false </asp:ListItem>

                    </asp:DropDownList>

                </td>
            </tr>

            <tr>
                <td style="height: 43px;">Категория:</td>

                <td style="height: 43px;">
                    <asp:DropDownList ID="CategoryDropDownList"
                        AutoPostBack="True"
                        runat="server">

                        <asp:ListItem>ювелирные изделия</asp:ListItem>
                        <asp:ListItem>оружие</asp:ListItem>
                        <asp:ListItem>произведения искусства</asp:ListItem>
                        <asp:ListItem>букинистика</asp:ListItem>
                        <asp:ListItem>часы</asp:ListItem>

                    </asp:DropDownList>
                </td>
            </tr>

        </table>

        <asp:Button runat="server" ID="SaveAntiqueButton" OnClick="SaveAntiqueButton_Click" Text="Сохранить" CssClass="button" />

        <br />

        <asp:Label runat="server" ID="ErrorAddAntiqueLabel"> </asp:Label>
        <br />
        <br />
    </div>


</asp:Content>
