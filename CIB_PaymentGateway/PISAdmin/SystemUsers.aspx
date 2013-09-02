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

            <table width="100%" border=" 0" cellspacing="0" cellpadding="5">
  <tr>
    <td align="left" valign="top" nowrap>
        <b><asp:Literal ID="litCaption" runat="server" Text="System Users"></asp:Literal></b>
      </td>
    <td align="center" valign="middle">&nbsp;</td>
    <td align="right" valign="top" nowrap>
        <asp:LinkButton ID="lbtn" runat="server">ADD</asp:LinkButton>
      </td>
  </tr>
  <tr>
    <td colspan="3" align="center">



            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <ItemTemplate>
                            <%# GetName(Eval("ID").ToString()) %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Title" HeaderText="Title">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="EmailAddress" HeaderText="Email">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="UserLevel" HeaderText="User Level">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CIBEmployeeID" HeaderText="EmployeeID">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Edit  Delete">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtEdit" runat="server" Text="edit" CommandName="editrecord" CommandArgument=<%# EVal("ID") %> ></asp:LinkButton>
                            &nbsp;&nbsp;
                            <asp:LinkButton ID="lbtnDelete" runat="server" Text="delete" CommandName="deleterecord" CommandArgument=<%# EVal("ID") %> ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>

    <div id="divAddEdit" runat="server" visible="false" >
           <table  border="0" cellspacing="0" cellpadding="4">
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
    
    </div>
    </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
</table>



     
    </form>
</body>
</html>
