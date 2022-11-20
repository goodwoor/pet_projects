<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Main.Master" AutoEventWireup="true" CodeBehind="ExpertisesTableForm.aspx.cs" Inherits="Антикварный_магазин.Pages.Login.Seller.Экспертизы.ExpertiseTableForm" %>

<asp:Content ID="ExpertiseContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">


    <h1 class="text-center">Экспертиза </h1>
    <br />

    <div class="tools center-display">

        <div class="filter">
            Фильтрация по ценности: 
                      <asp:DropDownList ID="FilterValuationDropDownList"
                          AutoPostBack="True"
                          OnSelectedIndexChanged="FilterValuationDropDownList_SelectedIndexChanged"
                          runat="server">

                          <asp:ListItem>историческая</asp:ListItem>
                          <asp:ListItem>художественная</asp:ListItem>
                          <asp:ListItem>культурная</asp:ListItem>
                          <asp:ListItem>научная</asp:ListItem>
                          <asp:ListItem>этнографическая</asp:ListItem>
                          <asp:ListItem>другая</asp:ListItem>
                          <asp:ListItem>отсутсвует</asp:ListItem>
                          <asp:ListItem Selected="True">любая ценность</asp:ListItem>

                      </asp:DropDownList>
        </div>

        <div class="filter">
            Фильтрация по подлинности: 
                      <asp:DropDownList ID="FilterTruthDropDownList"
                          AutoPostBack="True"
                          OnSelectedIndexChanged="FilterTruthDropDownList_SelectedIndexChanged"
                          runat="server">

                          <asp:ListItem>true</asp:ListItem>
                          <asp:ListItem>false</asp:ListItem>
                          <asp:ListItem Selected="True">любая подлинность</asp:ListItem>

                      </asp:DropDownList>
        </div>

    </div>

    <div class="center-display">
        <asp:Table runat="server" ID="expertiseTable" BorderStyle="Solid"
            BorderWidth="2px" ForeColor="Black" GridLines="Both"
            Height="47px" Style="margin-left: 0px; margin-bottom: 14px; text-align: center;" Width="70%">

            <asp:TableFooterRow>
                <asp:TableHeaderCell> Номер договора </asp:TableHeaderCell>
                <asp:TableHeaderCell> Id антиквариата </asp:TableHeaderCell>
                <asp:TableHeaderCell> Оценочная организация </asp:TableHeaderCell>
                <asp:TableHeaderCell> Ценность </asp:TableHeaderCell>
                <asp:TableHeaderCell> Подтверждение подлинности </asp:TableHeaderCell>
                <asp:TableHeaderCell> Оценочная стоимость </asp:TableHeaderCell>
                <asp:TableHeaderCell> Примерный возраст </asp:TableHeaderCell>
                <asp:TableHeaderCell> Авторство </asp:TableHeaderCell>
                <asp:TableHeaderCell> Место создания </asp:TableHeaderCell>
            </asp:TableFooterRow>

        </asp:Table>
    </div>

    <asp:Panel ID="ActionExpertisePanel" runat="server" Width="470px" CssClass="center">
        <table style="width: 100%; margin-top: 20px;" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <div class="center-display">
                    Выбор по номеру договора: 
                    <asp:TextBox ID="contractNumberTextBox" runat="server" Width="50%" />
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
