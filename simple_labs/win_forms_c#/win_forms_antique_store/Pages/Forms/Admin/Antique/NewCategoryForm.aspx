<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Main.Master" AutoEventWireup="true" CodeBehind="NewCategoryForm.aspx.cs" Inherits="Антикварный_магазин.Pages.Forms.Admin.Antique.NewCategoryForm" %>

<asp:Content ID="NewCategoryContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <div class="center-display">

        <asp:Panel runat="server" ID="IzdelPanel">
            <asp:Table runat="server" ID="IzdelTable">

                <asp:TableFooterRow>
                    <asp:TableCell> Материал: </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="IzdelMaterialTextBox" runat="server" />
                    </asp:TableCell>
                </asp:TableFooterRow>

                <asp:TableFooterRow>
                    <asp:TableCell> Вставка: </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="IzdelInsertTextBox" runat="server" />
                    </asp:TableCell>
                </asp:TableFooterRow>

                <asp:TableFooterRow>
                    <asp:TableCell> Вес(граммы): </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="IzdelWeightTextBox" runat="server" />
                        <asp:Label runat="server" ID="IzdelWeightErrorLabel"> </asp:Label>
                    </asp:TableCell>
                </asp:TableFooterRow>

            </asp:Table>
            <asp:Button runat="server" ID="AddIzdeleButton" OnClick="saveJewelry" Text="Добавить" CssClass="button" />
        </asp:Panel>

        <asp:Panel runat="server" ID="WeaponPanel">
            <asp:Table runat="server" ID="WeaponTable">

                <asp:TableFooterRow>
                    <asp:TableCell> Вид оружия: </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="WeaponTypeTextBox" runat="server" />
                    </asp:TableCell>
                </asp:TableFooterRow>

                <asp:TableFooterRow>
                    <asp:TableCell> Страна изготовления: </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="WeaponCountryTextBox" runat="server" />
                    </asp:TableCell>
                </asp:TableFooterRow>

            </asp:Table>
            <asp:Button runat="server" ID="AddWeaponButton" OnClick="saveWeapon" Text="Добавить" CssClass="button" />
        </asp:Panel>

        <asp:Panel runat="server" ID="ProizvedPanel">
            <asp:Table runat="server" ID="ProizvedTable">

                <asp:TableFooterRow>
                    <asp:TableCell> Автор: </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="ProizvedAutorTextBox" runat="server" />
                    </asp:TableCell>
                </asp:TableFooterRow>

                <asp:TableFooterRow>
                    <asp:TableCell> Вид искусства: </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="ProizvedTypeTextBox" runat="server" />
                    </asp:TableCell>
                </asp:TableFooterRow>

            </asp:Table>
            <asp:Button runat="server" ID="AddProizvedButton" OnClick="saveProizved" Text="Добавить" CssClass="button" />
        </asp:Panel>

        <asp:Panel runat="server" ID="BookPanel">
            <asp:Table runat="server" ID="BookTable">

                <asp:TableFooterRow>
                    <asp:TableCell> Автор: </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="BookAutorTextBox" runat="server" />
                    </asp:TableCell>
                </asp:TableFooterRow>

                <asp:TableFooterRow>
                    <asp:TableCell> Количество страниц: </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="BookPagesTextBox" runat="server" />
                        <asp:Label runat="server" ID="BookPagesErrorLabel"> </asp:Label>
                    </asp:TableCell>
                </asp:TableFooterRow>

                <asp:TableFooterRow>
                    <asp:TableCell> Язык: </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="BookLanguageTextBox" runat="server" />
                    </asp:TableCell>
                </asp:TableFooterRow>

            </asp:Table>
            <asp:Button runat="server" ID="AddBookButton" OnClick="saveBook" Text="Добавить" CssClass="button" />
        </asp:Panel>

        <asp:Panel runat="server" ID="ClockPanel">
            <asp:Table runat="server" ID="ClockTable">

                <asp:TableFooterRow>
                    <asp:TableCell> Вид: </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="ClockTypeTextBox" runat="server" />
                    </asp:TableCell>
                </asp:TableFooterRow>

                <asp:TableFooterRow>
                    <asp:TableCell> Основной материал: </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="ClockMaterialTextBox" runat="server" />
                    </asp:TableCell>
                </asp:TableFooterRow>

                <asp:TableFooterRow>
                    <asp:TableCell> Страна изготовления: </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="ClockCountryTextBox" runat="server" />
                    </asp:TableCell>
                </asp:TableFooterRow>

            </asp:Table>
            <asp:Button runat="server" ID="AddClockButton" OnClick="saveClock" Text="Добавить" CssClass="button" />
        </asp:Panel>

        <asp:Label runat="server" ID="ErrorAddLabel"> </asp:Label>
    </div>

</asp:Content>
