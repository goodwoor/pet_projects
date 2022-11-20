<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Main.Master" AutoEventWireup="true" CodeBehind="AntiquesTableForm.aspx.cs" Inherits="Антикварный_магазин.Pages.Login.Seller.Antique.AntiquesForm" %>


<asp:Content ID="AntiquesContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <h1 class="text-center">Антиквариат </h1>
    <br />

    <div class="center-display">
        <asp:Table runat="server" ID="antiquesTable" BorderStyle="Solid"
            BorderWidth="2px" ForeColor="Black" GridLines="Both"
            Height="47px" Style="margin-left: 0px; margin-bottom: 14px; text-align: center;" Width="70%">

            <asp:TableFooterRow>
                <asp:TableHeaderCell> ID </asp:TableHeaderCell>
                <asp:TableHeaderCell> Наименование </asp:TableHeaderCell>
                <asp:TableHeaderCell> Стоимость </asp:TableHeaderCell>
                <asp:TableHeaderCell> Состояние </asp:TableHeaderCell>
                <asp:TableHeaderCell> Историческая эпоха </asp:TableHeaderCell>
                <asp:TableHeaderCell> Наличие страховки </asp:TableHeaderCell>
                <asp:TableHeaderCell> Категория </asp:TableHeaderCell>
            </asp:TableFooterRow>

        </asp:Table>
    </div>

    <h1 class="text-center">Категории </h1>

    <h2 class="text-center">Ювелирные изделия </h2>
    <div class="center-display">
        <asp:Table runat="server" ID="IzdelTable" BorderStyle="Solid"
            BorderWidth="2px" ForeColor="Black" GridLines="Both"
            Height="47px" Style="margin-left: 0px; margin-bottom: 14px; text-align: center;" Width="70%">

            <asp:TableFooterRow>
                <asp:TableHeaderCell> ID </asp:TableHeaderCell>
                <asp:TableHeaderCell> Материал </asp:TableHeaderCell>
                <asp:TableHeaderCell> Вставка </asp:TableHeaderCell>
                <asp:TableHeaderCell> Вес(граммы) </asp:TableHeaderCell>
            </asp:TableFooterRow>

        </asp:Table>
    </div>

    <h2 class="text-center">Оружие </h2>
    <div class="center-display">
        <asp:Table runat="server" ID="WeaponTable" BorderStyle="Solid"
            BorderWidth="2px" ForeColor="Black" GridLines="Both"
            Height="47px" Style="margin-left: 0px; margin-bottom: 14px; text-align: center;" Width="70%">

            <asp:TableFooterRow>
                <asp:TableHeaderCell> ID </asp:TableHeaderCell>
                <asp:TableHeaderCell> Вид </asp:TableHeaderCell>
                <asp:TableHeaderCell> Страна изготовления </asp:TableHeaderCell>
            </asp:TableFooterRow>

        </asp:Table>
    </div>

    <h2 class="text-center">Произведения искусства </h2>
    <div class="center-display">
        <asp:Table runat="server" ID="ProizvedTable" BorderStyle="Solid"
            BorderWidth="2px" ForeColor="Black" GridLines="Both"
            Height="47px" Style="margin-left: 0px; margin-bottom: 14px; text-align: center;" Width="70%">

            <asp:TableFooterRow>
                <asp:TableHeaderCell> ID </asp:TableHeaderCell>
                <asp:TableHeaderCell> Автор </asp:TableHeaderCell>
                <asp:TableHeaderCell> Вид искусства </asp:TableHeaderCell>
            </asp:TableFooterRow>

        </asp:Table>
    </div>

    <h2 class="text-center">Букинистика </h2>
    <div class="center-display">
        <asp:Table runat="server" ID="BookTable" BorderStyle="Solid"
            BorderWidth="2px" ForeColor="Black" GridLines="Both"
            Height="47px" Style="margin-left: 0px; margin-bottom: 14px; text-align: center;" Width="70%">

            <asp:TableFooterRow>
                <asp:TableHeaderCell> ID </asp:TableHeaderCell>
                <asp:TableHeaderCell> Автор </asp:TableHeaderCell>
                <asp:TableHeaderCell> Количество страниц </asp:TableHeaderCell>
                <asp:TableHeaderCell> Язык </asp:TableHeaderCell>
            </asp:TableFooterRow>

        </asp:Table>
    </div>

    <h2 class="text-center">Часы </h2>
    <div class="center-display">
        <asp:Table runat="server" ID="ClockTable" BorderStyle="Solid"
            BorderWidth="2px" ForeColor="Black" GridLines="Both"
            Height="47px" Style="margin-left: 0px; margin-bottom: 14px; text-align: center;" Width="70%">

            <asp:TableFooterRow>
                <asp:TableHeaderCell> ID </asp:TableHeaderCell>
                <asp:TableHeaderCell> Вид </asp:TableHeaderCell>
                <asp:TableHeaderCell> Основной материал </asp:TableHeaderCell>
                <asp:TableHeaderCell> Страна изготовления </asp:TableHeaderCell>
            </asp:TableFooterRow>

        </asp:Table>
    </div>

    <asp:Panel ID="ActionAntiquesPanel" runat="server" Width="470px" CssClass="center">
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

                    <br />

                </td>
            </tr>
        </table>

    </asp:Panel>
</asp:Content>
