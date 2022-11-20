<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Main.Master" AutoEventWireup="true" CodeBehind="ClientForm.aspx.cs" Inherits="Антикварный_магазин.Pages.Login.Client.ClientForm" %>

<asp:Content ID="ClientContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <div class="catalog-wrapper">
        <div class="catalog">

            <div class="tools center-display">

                <div class="filter">
                    Фильтрация по категории: 
                      <asp:DropDownList ID="FilterCategoryDropDownList"
                          AutoPostBack="True"
                          OnSelectedIndexChanged="FilterCategoryDropDownList_SelectedIndexChanged"
                          runat="server">

                          <asp:ListItem Selected="True">все категории</asp:ListItem>
                          <asp:ListItem>ювелирные изделия</asp:ListItem>
                          <asp:ListItem>оружие</asp:ListItem>
                          <asp:ListItem>произведения искусства</asp:ListItem>
                          <asp:ListItem>букинистика</asp:ListItem>
                          <asp:ListItem>часы</asp:ListItem>

                      </asp:DropDownList>
                </div>

                <div class="filter">
                    Фильтрация по исторической эпохе: 
                      <asp:DropDownList ID="FilterHistoryEraDropDownList"
                          AutoPostBack="True"
                          OnSelectedIndexChanged="FilterHistoryEraDropDownList_SelectedIndexChanged"
                          runat="server">

                          <asp:ListItem Selected="True">все эпохи</asp:ListItem>
                          <asp:ListItem>первобытное общество</asp:ListItem>
                          <asp:ListItem>древний мир</asp:ListItem>
                          <asp:ListItem>средние века</asp:ListItem>
                          <asp:ListItem>новое время</asp:ListItem>
                          <asp:ListItem>новейшее время</asp:ListItem>

                      </asp:DropDownList>
                </div>

            </div>

            <div class="tools center-display">

                <div class="search">
                    Поиск по наименованию:
                      <asp:TextBox runat="server" ID="SearchTextBox"> </asp:TextBox>
                    <asp:Button runat="server" ID="SearchButton" Text="Поиск" OnClick="SearchButton_Click" CssClass="button-search" />
                </div>

            </div>


            <div class="antiques-table">
                <div class="center-display">
                    <asp:Table runat="server" ID="antiquesTable" BorderStyle="Solid"
                        BorderWidth="2px" ForeColor="Black" GridLines="Both"
                        Height="47px" Style="margin-left: 0px; margin-bottom: 14px; text-align: center;" Width="70%">

                        <asp:TableFooterRow ID="headerAntiquesTable">
                            <asp:TableHeaderCell> ID </asp:TableHeaderCell>
                            <asp:TableHeaderCell> Наименование </asp:TableHeaderCell>
                            <asp:TableHeaderCell> Стоимость </asp:TableHeaderCell>
                            <asp:TableHeaderCell> Состояние </asp:TableHeaderCell>
                            <asp:TableHeaderCell> Историческая эпоха </asp:TableHeaderCell>
                            <asp:TableHeaderCell> Наличие страховки </asp:TableHeaderCell>
                            <asp:TableHeaderCell> Категория </asp:TableHeaderCell>
                        </asp:TableFooterRow>

                    </asp:Table>

                    <br />


                </div>

                <div class="center-display">
                    <asp:Label runat="server" ID="errorSearchFilterLabel"></asp:Label>

                </div>
                <br />

                <div>
                    <div class="head-text">
                        <b>Действия</b>
                    </div>
                    <div class="center-display">
                        <asp:Panel ID="ActionClientPanel" runat="server" Width="470px" CssClass="center">
                            <br />

                            <table style="width: 100%; margin-top: 20px;" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 250px;">
                                        <asp:Label runat="server" Width="250px">Выбор антиквариата по ID: </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="IdSearchTextBox" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 250px;">
                                        <asp:Label runat="server" Width="250px">Введите свой ID клиента: </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="IdClientTextBox" runat="server" />
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:Button runat="server" ID="buyButton" OnClick="buyButton_Click" Text="Купить" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="actionErrorLabel">  </asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="actionSuccessLabel">  </asp:Label>
                                    </td>
                                </tr>

                            </table>

                            <br />

                        </asp:Panel>
                    </div>

                    <div class="center-display">
                        <asp:Panel ID="similarAntiquePanel" runat="server" CssClass="center" Visible="false">
                            <div class="head-text">
                                <b>Похожие товары</b>
                            </div>
                            <br />

                            <asp:Table runat="server" ID="similarAntiquesTable" BorderStyle="Solid"
                                BorderWidth="2px" ForeColor="Black" GridLines="Both"
                                Height="47px" Style="margin-left: 0px; margin-bottom: 14px; text-align: center;" Width="70%">
                                <asp:TableFooterRow>
                                    <asp:TableHeaderCell> ID </asp:TableHeaderCell>
                                    <asp:TableHeaderCell> Наименование </asp:TableHeaderCell>
                                    <asp:TableHeaderCell> Стоимость </asp:TableHeaderCell>
                                    <asp:TableHeaderCell> Историческая эпоха </asp:TableHeaderCell>
                                    <asp:TableHeaderCell> Категория </asp:TableHeaderCell>
                                </asp:TableFooterRow>

                            </asp:Table>
                        </asp:Panel>
                    </div>

                </div>
            </div>

        </div>

    </div>

</asp:Content>
