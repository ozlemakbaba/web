<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.master" AutoEventWireup="true" CodeFile="account.aspx.cs" Inherits="Views_account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="Form1" runat="server">
<div class="container">
      <div class="row">
      <div class="col-md-5  toppad  pull-right col-md-offset-3 ">
       <br><% DateTime today = DateTime.Now; %>
<p class=" text-info"><%: today%></p>
      </div>
        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6 col-xs-offset-0 col-sm-offset-0 col-md-offset-3 col-lg-offset-3 toppad" >
   
   
          <div class="panel panel-info">
            <div class="panel-heading">
              <h3 class="panel-title">Compte de : <%: personne.Nom + " " + personne.Prenom %></h3>
            </div>
            <div class="panel-body">
              <div class="row">
                <!--<div class="col-md-3 col-lg-3 " align="center"> <img alt="User Pic" src="http://babyinfoforyou.com/wp-content/uploads/2014/10/avatar-300x300.png" class="img-circle img-responsive"> </div>
                --><div class=" col-md-9 col-lg-9 "> 
                  <table class="table table-user-information">
                    <tbody>
                      <tr>
                        <td>Email</td>
                         <% cinT.Text = compte.Username; %>
                        <td><asp:TextBox CssClass="textbox" ID="cinT" runat="server" ReadOnly="true" /></td>
                      </tr>
                      <tr>
                        <td>Ancien mot de passe</td>
                        <td><asp:TextBox type="password" CssClass="textbox" ID="ancmdp" runat="server" /></td>
                      </tr>
                      <tr>
                        <td>Nouveau mot de passe</td>
                        <td><asp:TextBox type="password" CssClass="textbox" ID="nvmdp" runat="server" /></td>
                      </tr>
                      <tr>
                        <td>Répéter le nouveau mot de passe</td>
                        <td><asp:TextBox type="password" CssClass="textbox" ID="nvmdp2" runat="server" /></td>
                      </tr>
                    </tbody>
                  </table>
                  <div class="buttons">
                  <asp:Button ID="valider" CssClass="btn btn-primary" runat="server" OnClick="update" Text="Valider" />
                  <input class="btn btn-primary" value="Initialier" type="reset" />
                  <asp:Label runat="server" ID="err" Text="" ForeColor="Red" />
                  </div>
                </div>
              </div>
            </div> 
            <div class="panel-footer">
                        <span class="rem-but">
                            <a data-original-title="Edit this user" data-toggle="tooltip" class="btn btn-sm btn-warning" href="Edit_profile.aspx?b=false";><i class="glyphicon glyphicon-remove"></i></a>
                        </span>
                    </div>           
          </div>
        </div>
      </div>
          
    </div>

</form>
</asp:Content>

