<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SystemUsers.aspx.vb" Inherits="PISAdmin.SystemUsers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register src="topmenu.ascx" tagname="topmenu" tagprefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PIS Admin -- System Users.</title>
     <meta http-equiv="X-UA-Compatible" content="IE=7" />
        <script language="javascript" type="text/javascript" >
            function popup(theURL, winName, features) {
                window.open(theURL, winName, features);
            }
        </script>
        <script type="text/javascript" src="Scripts/jquery-1.5.2.min.js"></script>
        <link href="style.css" rel="stylesheet" type="text/css" /> 
</head>
<body>
    <form id="form1" runat="server">
   <div>
                <h3>PIS: Payments</h3>
	            <uc1:topmenu ID="topmenu1" runat="server" />
	            <br />
            </div>
            <asp:GridView ID="gv" runat="server">
    </asp:GridView>
            <table  border="0" cellspacing="0" cellpadding="4">
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td align="right" valign="top"><div align="right">Title</div></td>
    <td align="left" valign="top"><div align="left">
        <asp:TextBox ID="txtTitle" runat="server" Width="200px"></asp:TextBox>
        </div></td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td align="right" valign="top"><div align="right">First Name </div></td>
    <td align="left" valign="top"><div align="left">
        <asp:TextBox ID="txtFirstName" runat="server" Width="200px"></asp:TextBox>
        </div></td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td align="right" valign="top"><div align="right">Last Name </div></td>
    <td align="left" valign="top"><div align="left">
        <asp:TextBox ID="txtLastName" runat="server" Width="200px"></asp:TextBox>
        </div></td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td align="right" valign="top"><div align="right">Email Address  </div></td>
    <td align="left" valign="top"><div align="left">
        <asp:TextBox ID="txtEmailAddress" runat="server" Width="200px"></asp:TextBox>
        </div></td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td align="right" valign="top"><div align="right">Password</div></td>
    <td align="left" valign="top"><div align="left">
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
        </div></td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td align="right" valign="top"><div align="right">User Level </div></td>
    <td align="left" valign="top"><div align="left">
        <asp:DropDownList ID="DDLUserLevel" runat="server">
            <asp:ListItem>Manager</asp:ListItem>
            <asp:ListItem>Developer</asp:ListItem>
            <asp:ListItem>Support</asp:ListItem>
            <asp:ListItem>Administrator</asp:ListItem>
        </asp:DropDownList>
        </div></td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td align="right" valign="top"><div align="right">CIB Employee ID </div></td>
    <td align="left" valign="top"><div align="left">
        <asp:TextBox ID="txtCIBEmployeeID" runat="server" Width="200px"></asp:TextBox>
        </div></td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td align="right" valign="top"><div align="right">Signature URL </div></td>
    <td align="left" valign="top"><div align="left">
        <asp:TextBox ID="txtSignatureURL" runat="server" Width="200px"></asp:TextBox>
        </div></td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td align="right" valign="top"><div align="right">Comments</div></td>
    <td align="left" valign="top"><div align="left">
        <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Width="200px"></asp:TextBox>
        </div></td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td align="left" valign="top">
        <asp:Button ID="btnAdd" runat="server" Text="ADD" />
      </td>
    <td>&nbsp;</td>
  </tr>
</table>
    </form>
</body>
</html>
