<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="suppp.aspx.cs" Inherits="Pharmacie.suppp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            direction: ltr;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="NumOrdonnance,NumMedicament" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="NumOrdonnance" HeaderText="NumOrdonnance" ReadOnly="True" SortExpression="NumOrdonnance" />
                <asp:BoundField DataField="NumMedicament" HeaderText="NumMedicament" ReadOnly="True" SortExpression="NumMedicament" />
                <asp:BoundField DataField="QttePrescrite" HeaderText="QttePrescrite" SortExpression="QttePrescrite" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PharmacieConnectionString %>" SelectCommand="SELECT * FROM [DetailOrdonnance]"></asp:SqlDataSource>
    </form>
    <p class="auto-style1">
        &nbsp;</p>
</body>
</html>
