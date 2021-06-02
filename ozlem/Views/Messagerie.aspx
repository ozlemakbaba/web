<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.master" AutoEventWireup="true" CodeFile="Messagerie.aspx.cs" Inherits="Views_Messagerie" %>

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
    <div class="hd">
        <h2>N'hésitez pas à choisir <b>Le coin que vous voulez</b></h2>
    </div>
    
            <div class="items-collection">

                <a target="_blank" href="Chat/">
                <div class="items col-xs-6 col-sm-3 col-md-3 col-lg-3">
                    <div class="info-block block-info clearfix">
                            <label class="btn btn-default">
                                <div class="itemcontent">
                                    <span class="fa fa-laptop"></span>
                                    <h5>Dévloppement Web</h5>
                                </div>
                            </label>
                    </div>
                </div></a>
                <a href="Edit_profile.aspx">
                <div class="items col-xs-6 col-sm-3 col-md-3 col-lg-3">
                    <div class="info-block block-info clearfix">
                            <label class="btn btn-default">
                                <div class="itemcontent">
                                    <span class="fa fa-mobile"></span>
                                    <h5>Développement Mobile</h5>
                                </div>
                            </label>
                    </div>
                </div></a>
                <a href="Messagerie.aspx">
                <div class="items col-xs-6 col-sm-3 col-md-3 col-lg-3">
                    <div class="info-block block-info clearfix">
                            <label class="btn btn-default">
                                <div class="itemcontent">
                                    <span class="fa fa-signal"></span>
                                    <h5>Réseaux informatique</h5>
                                </div>
                            </label>
                    </div>
                </div></a>
                <a href="Stats.aspx">
                <div class="items col-xs-6 col-sm-3 col-md-3 col-lg-3">
                    <div class="info-block block-info clearfix">
                            <label class="btn btn-default">
                                <div class="itemcontent">
                                    <span class="fa fa-info"></span>
                                    <h5>Data Mining - Big Data</h5>
                                </div>
                            </label>
                    </div>
                </div></a>                                            

            </div>
</asp:Content>

