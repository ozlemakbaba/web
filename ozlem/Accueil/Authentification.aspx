<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Authentification.aspx.cs" Inherits="Accueil_Authentification" %>

<html>
<head runat="server">
    <meta charset="UTF-8">
    <title>Authentification</title>
    
    
    
    
        <link rel="stylesheet" href="css/styl.css">

     <!-- Bootstrap Core CSS -->
        <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet">

        <!-- Font Awesome CSS -->
        <link href="css/font-awesome.min.css" rel="stylesheet">
		
		<!-- Custom CSS -->
        <link href="css/animate.css" rel="stylesheet">

        <!-- Custom CSS -->
        <link href="css/style.css" rel="stylesheet">

        <!-- Custom Fonts -->
        <link href='http://fonts.googleapis.com/css?family=Lobster' rel='stylesheet' type='text/css'>
    
    
  </head>

  <body>

    <div class="wrapper">
	<div class="container">
		<h1>Welcome</h1>
		<form id="Form1" class="form" runat="server">
			<asp:TextBox ID="username" type="text" CssClass="input" placeholder="Username" runat="server" />
			<asp:TextBox ID="password" type="password" CssClass="input" placeholder="Password" runat="server" />
			<asp:Button CssClass="button" OnClick="login" Text="Valider" runat="server" /><br /><br />
            <input type="reset" class="button" value="Initialiser" />
            <asp:Label runat="server" ID="label" ForeColor="Red" Text="" />
		<br>
</form>


<asp:Label ID="label__" runat="server" />
	</div>
	
	<ul class="bg-bubbles">
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
	</ul>
</div>
    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>

        <script src="js/index.js"></script>

    
    
    
  </body>
</html>