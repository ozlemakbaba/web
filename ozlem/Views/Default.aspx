<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Views_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">

.hd
{
    margin-top : 80px;
}
h2
{
    margin-left: 150px;
}
.image10
{
    margin-left: 460px;
}
.items-collection{
    margin: 120px 0 0 0;
}
.items-collection label.btn-default.active{
    background-color:#007ba7;
    color:#FFF;
}
.items-collection label.btn-default{
    width:90%;
    border:1px solid #305891;
    margin:5px; 
    border-radius: 17px;
    color: #305891;
}
.items-collection label .itemcontent{
    width:100%;
}
.items-collection .btn-group{
    width:100%
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!--<h2>Welcome : <b><%: name %></b></h2>
    <img src="../images/stats.png" alt="statistiques" width="96%" /><br />
    <label style="margin-left: 400px;">Quelques statistiques des différentes missions IT.</label>-->
    <div class="hd">
        <h2>Bienvenue sur notre plateforme <b>Le coin des freelancers</b></h2>
    <img class="image10" alt="logo" src="../images/logo.png" />
    </div>
    
            <div class="items-collection">

                <a href="Offres.aspx">
                <div class="items col-xs-6 col-sm-3 col-md-3 col-lg-3">
                    <div class="info-block block-info clearfix">
                            <label class="btn btn-default">
                                <div class="itemcontent">
                                    <span class="glyphicon glyphicon-list"></span>
                                    <h5>Offres de freelance</h5>
                                </div>
                            </label>
                    </div>
                </div></a>
                <a href="Edit_profile.aspx">
                <div class="items col-xs-6 col-sm-3 col-md-3 col-lg-3">
                    <div class="info-block block-info clearfix">
                            <label class="btn btn-default">
                                <div class="itemcontent">
                                    <span class="glyphicon glyphicon-edit"></span>
                                    <h5>Modifier votre profile</h5>
                                </div>
                            </label>
                    </div>
                </div></a>
                <a href="Messagerie.aspx">
                <div class="items col-xs-6 col-sm-3 col-md-3 col-lg-3">
                    <div class="info-block block-info clearfix">
                            <label class="btn btn-default">
                                <div class="itemcontent">
                                    <span class="glyphicon glyphicon-comment"></span>
                                    <h5>Vos messages</h5>
                                </div>
                            </label>
                    </div>
                </div></a>
                <a href="Stats.aspx">
                <div class="items col-xs-6 col-sm-3 col-md-3 col-lg-3">
                    <div class="info-block block-info clearfix">
                            <label class="btn btn-default">
                                <div class="itemcontent">
                                    <span class="glyphicon glyphicon-usd"></span>
                                    <h5>Suggestions</h5>
                                </div>
                            </label>
                    </div>
                </div></a>                                            

            </div>
</asp:Content>

