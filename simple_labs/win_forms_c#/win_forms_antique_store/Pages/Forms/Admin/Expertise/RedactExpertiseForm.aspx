<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Main.Master" AutoEventWireup="true" CodeBehind="RedactExpertiseForm.aspx.cs" Inherits="Антикварный_магазин.Pages.Login.Seller.Expertise.RedactForm" %>
<asp:Content ID="RedactExpertiseContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

        <div class="content">
        <h2> Введите данные: </h2>
        
        <table border="0" style="padding-bottom:10px;">
            <tr>
                <td style="height: 43px;">Id антиквариата:</td>

                <td style="height: 43px;">
                    <asp:TextBox ID="IdAntiqueTextBox" runat="server" /> 
                </td>
            </tr>
            <tr>
                <td style="height: 43px;">Оценочная организация:</td>

                <td style="height: 43px;">
                    <asp:TextBox ID="OrganizationTextBox" runat="server" /> 

                </td>
            </tr>
            <tr>
                <td style="height: 43px;">Ценность:</td>

                <td style="height: 43px;">
                    <asp:DropDownList ID="ValuationDropDownList"
                        AutoPostBack="True"
                        runat="server">

                        <asp:ListItem>историческая</asp:ListItem>
                        <asp:ListItem>художественная</asp:ListItem>
                        <asp:ListItem>культурная</asp:ListItem>
                        <asp:ListItem>научная</asp:ListItem>
                        <asp:ListItem>этнографическая</asp:ListItem>
                        <asp:ListItem>другая</asp:ListItem>
                        <asp:ListItem>отсутсвует</asp:ListItem>

                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 26px;">Подтверждение подлинности:</td>
                <td style="height: 26px;">
                    
                    <asp:DropDownList ID="TruthDropDownList"
                    AutoPostBack="True"
                    runat="server">
                    
                    <asp:ListItem Value="trueListItem">true</asp:ListItem>
                    <asp:ListItem Value="falseListItem">false</asp:ListItem>

                    </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td style="height: 26px;">Оценочная стоимость:</td>
                <td style="height: 26px;">
                    <asp:TextBox ID="CostTextBox" runat="server"/> 
                    <asp:Label runat="server" ID="CostErrorLabel"> </asp:Label>

                </td>
            </tr>
            <tr>
                <td style="height: 26px;">Примерный возраст:</td>
                <td style="height: 26px;">
                    <asp:TextBox ID="AgeTextBox" runat="server"/> 

                </td>
            </tr>
            <tr>
                <td style="height: 26px;">Авторство:</td>
                <td style="height: 26px;">
                    <asp:TextBox ID="AvtorTextBox" runat="server"/> 

                </td>
            </tr>
            <tr>
                <td style="height: 26px;">Место создания:</td>
                <td style="height: 26px;">
                    <asp:TextBox ID="PlaceOfCreationTextBox" runat="server"/> 

                </td>
            </tr>
        </table>

        <asp:Button runat="server" ID="SaveExpertiseButton" OnClick="SaveExpertiseButton_Click" Text="Сохранить" CssClass="button"/>

        <br />

        <asp:Label runat="server" ID="ErrorSaveExpertiseLabel"> </asp:Label> <br /> <br />
    </div>


</asp:Content>
