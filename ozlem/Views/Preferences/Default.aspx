<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Views_Preferences_Default" %>

<html>
<head runat="server">
    <title>Choisir Les Préférences.</title>
    <link rel="stylesheet" href="css/style.css">
</head>
<body>
    <form id="form1" runat="server">
    <asp:Label CssClass="label" runat="server" ID="lab" ForeColor="Black" Text="Veuillez choisir les technologies que vous maîtrisez." />
            <br /><br /><table class="table-fill">
                <thead>
                    <tr>
                    <th class="text-left">Technologie</th>
                    <th></th>
                    </tr>
                </thead>
                <tbody class="table-hover">
                    <%foreach (Categorie c in list)
          { %>
            <% if (percatdao.isSelected("cb291085", c.Nom) == null)
               { %>
                    <tr>
                    <td class="text-left"><%: c.Nom %></td>
                    <td class="text-left"><a href="Default.aspx?tech=<%:c.Nom%>" ><img src="select.png" alt="choisir" /></a></td>
                    </tr>
            <%}
          } %>
                </tbody>
            </table>
            
    <!--<a class="button" href="../Default.aspx">
        <span>Terminer</span>
    </a>-->
    <asp:LinkButton CssClass="button" runat="server" OnClick="End">
        <span>Terminer</span>
    </asp:LinkButton>
    <br /><br /><br /><br />
    </form>
</body>
</html>
