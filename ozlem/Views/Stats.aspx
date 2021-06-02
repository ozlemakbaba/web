<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.master" AutoEventWireup="true" CodeFile="Stats.aspx.cs" Inherits="Views_Stats" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/Style_.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <% if (!b)
       { %>
    <form runat="server" class="form-register">
  <div class="form-register-with-email">
  <h2>Pour mieux choisir vos technologies</h2>
  <div class="form-white-background">
  <div class="form-title-row">
    <label class="desc" id="label1" for="tarif">
      <asp:TextBox CssClass="input" ID="tarif" runat="server" placeholder="Tarif en €" />
    </label>
  </div >
  <div class="form-title-row">
        <label>
        <asp:TextBox CssClass="input" ID="experience" runat="server" placeholder="Expérience professionnelle" />
      </label>
  </div>
  <div class="form-title-row">
    <label class="desc" id="label3" for="duree">
        <asp:TextBox CssClass="input" ID="duree" runat="server" placeholder="Durée en mois" />
    </label>
    </div>
  <div class="form-title-row">
    <fieldset class="form-checkbox">
    
      <legend id="label4" class="desc">
        Choisir un type
      </legend>
      <asp:RadioButtonList CssClass="select" ID="rbtLstRating" runat="server" 
                RepeatDirection="Vertical" RepeatLayout="Table">
                <asp:ListItem Text="Plein Temps" Value="plein" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Demi Temps" Value="demi"></asp:ListItem>
            </asp:RadioButtonList>  
    </fieldset>
  </div>
  <asp:Button runat="server" CssClass="btn" OnClick="evaluer" Text="Valider" />
  <br /><asp:Label runat="server" ID="erreur" ForeColor="Red" Text="" />
  </div>
  </div>
    </form>
    <%}
       else
       { %>
       <img style="padding-left:350px;" alt="victoire" src="../images/victoire.jpg" width="60%" />
    <asp:Label runat="server" CssClass="textRes" ID="res" Text="" />
    <%} %>
</asp:Content>

