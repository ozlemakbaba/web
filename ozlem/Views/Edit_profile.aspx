<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.master" AutoEventWireup="true" CodeFile="Edit_profile.aspx.cs" Inherits="Views_Edit_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<% if (par == null)
   { %>
<form runat="server">
<div class="container">
      <div class="row">
      <div class="col-md-5  toppad  pull-right col-md-offset-3 ">
       <br><% DateTime today = DateTime.Now; %>
<p class=" text-info"><%: today%></p>
      </div>
        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6 col-xs-offset-0 col-sm-offset-0 col-md-offset-3 col-lg-offset-3 toppad" >
   
   
          <div class="panel panel-info">
            <div class="panel-heading">
              <h3 class="panel-title">Profil de : <%: personne.Nom + " " + personne.Prenom %></h3>
            </div>
            <div class="panel-body">
              <div class="row">
              <% img.Src = path; %>
                <div class="col-md-3 col-lg-3 " align="center"> <img alt="User Pic" id="img" runat="server" src="" class="img-circle img-responsive"> </div>
                <!--<div class="col-xs-10 col-sm-10 hidden-md hidden-lg"> <br>
                  <dl>
                    <dt>DEPARTMENT:</dt>
                    <dd>Administrator</dd>
                    <dt>HIRE DATE</dt>
                    <dd>11/12/2013</dd>
                    <dt>DATE OF BIRTH</dt>
                       <dd>11/12/2013</dd>
                    <dt>GENDER</dt>
                    <dd>Male</dd>
                  </dl>
                </div>-->
                <div class=" col-md-9 col-lg-9 "> 
                  <table class="table table-user-information">
                    <tbody>
                      <tr>
                        <td>CIN</td>
                        <td><%: personne.CIN%></td>
                      </tr>
                      <tr>
                        <td>Nom</td>
                        <td><%: personne.Nom%></td>
                      </tr>
                      <tr>
                        <td>Prénom</td>
                        <td><%: personne.Prenom%></td>
                      </tr>
                      <tr>
                        <td>Email</td>
                        <td><%: personne.Email %></td>
                      </tr>
                      <tr>
                        <td>Téléphone</td>
                        <td><%: personne.Telephone%></td>
                      </tr>
                    </tbody>
                  </table>
                  
                  <a href="pref.aspx" class="btn btn-primary">Mes préférences</a>
                  <a href="account.aspx" class="btn btn-primary">Mon compte</a>
                </div>
              </div>
            </div>
                 <div class="panel-footer">
                        <a data-original-title="Broadcast Message" data-toggle="tooltip" type="button" class="btn btn-sm btn-primary"><i class="glyphicon glyphicon-envelope"></i></a>
                        <span class="pull-right">
                            <a data-original-title="Edit this user" data-toggle="tooltip" class="btn btn-sm btn-warning" href="Edit_profile.aspx?b=false";><i class="glyphicon glyphicon-edit"></i></a>
                        </span>
                    </div>
            
          </div>
        </div>
      </div>
    </div>
</form>
    <%}
   else
   { %>
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
              <h3 class="panel-title">Profil de : <%: personne.Nom + " " + personne.Prenom %></h3>
            </div>
            <div class="panel-body">
              <div class="row">
                <% img1.Src = path; %>
                <div class="col-md-3 col-lg-3 " align="center"> <img alt="User Pic" id="img1" runat="server" src="" class="img-circle img-responsive"> </div>
               <div class=" col-md-9 col-lg-9 "> 
                  <table class="table table-user-information">
                    <tbody>
                      <tr>
                        <td>CIN</td>
                         <% cinT.Text = personne.CIN; %>
                        <td><asp:TextBox CssClass="textbox" ID="cinT" runat="server" /></td>
                      </tr>
                      <tr>
                        <td>Nom</td>
                         <% nomT.Text = personne.Nom; %>
                        <td><asp:TextBox CssClass="textbox" ID="nomT" runat="server" /></td>
                      </tr>
                      <tr>
                        <td>Prénom</td>
                         <% prenomT.Text = personne.Prenom; %>
                        <td><asp:TextBox CssClass="textbox" ID="prenomT" runat="server"/></td>
                      </tr>
                      <tr>
                        <td>Téléphone</td>
                        <% date_naissT.Text = personne.Date_naissance; %>
                        <td><asp:TextBox CssClass="textbox" ID="date_naissT" runat="server" /></td>
                      </tr>
                      <tr>
                       <% emailT.Text = personne.Email; %>
                        <td>Email</td>
                        <td><asp:TextBox CssClass="textbox" ID="emailT" runat="server" /></td>
                      </tr>
                      <tr>
                        <td>Téléphone</td>
                        <% telT.Text = personne.Telephone; %>
                        <td><asp:TextBox CssClass="textbox" ID="telT" runat="server" /></td>
                      </tr>
                    </tbody>
                  </table>
                  <div class="buttons">
                  <asp:Button ID="valider" CssClass="btn btn-primary" runat="server" OnClick="update" Text="Valider" />
                  <input class="btn btn-primary" value="Initialier" type="reset" />
                  </div>
                </div>
              </div>
            </div> 
            <div class="panel-footer">
                        <span class="rem-but">
                            <a data-original-title="Edit this user" data-toggle="tooltip" class="btn btn-sm btn-warning" href="Edit_profile.aspx";><i class="glyphicon glyphicon-remove"></i></a>
                        </span>
                    </div>           
          </div>
        </div>
      </div>
          
    </div>

</form>
        <%} %>
</asp:Content>

