<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Accueil_Registration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <title>Inscription</title>
    <link href='http://fonts.googleapis.com/css?family=Titillium+Web:400,300,600' rel='stylesheet' type='text/css'>
    
    <link rel="stylesheet" href="css/normalize.css">

    
        <link rel="stylesheet" href="css/styleregistration.css">

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

    <div class="form">
      
      <ul class="tab-group">
        <li class="tab active"><a href="#signup">Inscription</a></li>
        <li class="tab"><a href="Authentification.aspx">Connexion</a></li>
      </ul>
      
      <div class="tab-content">
        <div id="signup">   
          <h1>Sign Up for Free</h1>
          
          <form runat="server">
          
          <div class="top-row">
            <div class="field-wrap">
              <asp:TextBox runat="server" CssClass="input" required="true" ID="prenom" placeholder="Prénom" autocomplete="off" />
            </div>
        
            <div class="field-wrap">
              <asp:TextBox runat="server" CssClass="input" required="true" ID="nom" placeholder="Nom" autocomplete="off"/>
            </div>
          </div>

          <div class="field-wrap">
            <asp:TextBox runat="server" CssClass="input" type="email" ID="email" required="true" placeholder="Email" autocomplete="off"/>
          </div>

          <div class="field-wrap">
            <h3><asp:Label runat="server" ID="uploadLab" ForeColor="White" Text="Choisir votre image" /></h3>
            <asp:FileUpload ID="upload" runat="server" />
          </div>
          
          <div class="field-wrap">
            <asp:TextBox runat="server" CssClass="input" required="true" ID="cin" placeholder="CIN" autocomplete="off"/>
          </div>

          <div class="field-wrap">
            <asp:TextBox runat="server" CssClass="input" type="Date" ID="birth" required="true" placeholder="Date de naissance" autocomplete="off"/>
          </div>

          <div class="field-wrap">
            <asp:TextBox runat="server" CssClass="input" ID="phone" required="true" placeholder="Téléphone" autocomplete="off"/>
          </div>

          <div class="field-wrap">
            <asp:TextBox runat="server" CssClass="input" ID="pass" type="password" required="true" placeholder="Mot de Passe" autocomplete="off"/>
          </div>

          <div class="field-wrap">
            <asp:TextBox ID="passRep" CssClass="input" runat="server" type="password" required="true" placeholder="Répéter Mot de Passe" autocomplete="off"/>
          </div>
          
          <asp:Button runat="server" OnClick="add" CssClass="button button-block" Text="S'inscrire" /><br>
          <input type="reset" class="button button-block" style="color:#FFFFFF" value="Initialiser" />
          <asp:Label runat="server" Text="" ID="label" ForeColor="Red" />
          </form>

        </div>
        
        <div id="login">   
          <h1>Welcome Back!</h1>
          
          <form action="/" method="post">
          
            <div class="field-wrap">
            <label>
              Email Address<span class="req">*</span>
            </label>
            <input type="email"required autocomplete="off"/>
          </div>
          
          <div class="field-wrap">
            <label>
              Password<span class="req">*</span>
            </label>
            <input type="password"required autocomplete="off"/>
          </div>
          
          <p class="forgot"><a href="#">Forgot Password?</a></p>
          
          <button class="button button-block"/>Log In</button>
          
          </form>

        </div>
        
      </div><!-- tab-content -->
      
</div> <!-- /form -->
    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>

        <script src="js/index.js"></script>

    
    
    
  </body>
</html>

