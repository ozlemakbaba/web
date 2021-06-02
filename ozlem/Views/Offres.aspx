<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.master" AutoEventWireup="true" CodeFile="Offres.aspx.cs" Inherits="Views_Offres" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
 .div{
  margin: 20px;
}
 
.ul {
  list-style-type: none;
  width: 600px;
}
 
.h3 {
  font: bold 20px/1.5 Helvetica, Verdana, sans-serif;
}
 
.li .img {
  float: left;
  margin: 0 15px 0 0;
}
 
.li .p {
  font: 200 12px/1.5 Georgia, Times New Roman, serif;
}
 
.li {
  padding: 10px;
  overflow: auto;
}

.img
{
    width: 100px;
    height: 100px;
}
 
.li:hover {
  background: #eee;
  cursor: pointer;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<div class="div">
  <ul class="ul">
  <%foreach(Offre o in list)
    { %>
    <%if (o.Img == "")
        {
            o.Img = "https://www.electiondataservices.com/wp-content/uploads/2014/10/sorry-image-not-available.jpg";
      }%>
    <li class="li">
      <img class="img" src="<%: o.Img %>" alt="<%: o.Img %>" />
      <h3 class="h3"><a href="<%: o.Lien %>"><%: o.Titre %></a></h3>
      <p class="p"><%: o.Description %>&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;Prix : <%: o.Prix %> </p>
    </li>
    <%} %>
  </ul>
</div>
1
2
3
4
5
6
7
8
9
10
</asp:Content>

