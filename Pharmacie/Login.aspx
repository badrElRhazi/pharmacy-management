<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Pharmacie.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Page Connexion"></asp:Label>
&nbsp;:<br />
            <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate">
            </asp:Login>
            <br />
            La Fonction :
            <asp:RadioButton ID="RadPahrma" runat="server" GroupName="radio" Text="Pharmacien" />
            <asp:RadioButton ID="RadMedcin" runat="server" GroupName="radio" Text="Médecin" />
        </div>
    </form>
</body>
</html>
