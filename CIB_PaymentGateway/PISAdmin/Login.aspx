<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="PISAdmin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>PIS Admin Login</title>
    <script type="text/javascript" src="Scripts/jquery-1.5.2.min.js"></script>
    <link href="style.css" rel="stylesheet" type="text/css"> 
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <meta http-equiv="Imagetoolbar" content="no">
    <style type="text/css">
    /* pushes the page to the full capacity of the viewing area */
    html {height:100%;}
    body {height:100%; margin:0; padding:0;}

    /* prepares the background image to full capacity of the viewing area */
    #bg {position:fixed; top:0; left:0; width:100%; height:100%;}

    /* places the content ontop of the background image */
    #content {position:relative; z-index:1;}
    </style>

    <!--[if IE 6]>
    <style type="text/css">
    /* some css fixes for IE browsers */
    html {overflow-y:hidden;}
    body {overflow-y:auto;}
    #bg {position:absolute; z-index:-1;}
    #content {position:static;}
    </style>
    <![endif]-->
</head>
<body bgcolor="#15325a">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

            <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
	            <tr>
                    <td align="center">
			            <table width="660" height="385" border="0" cellspacing="0" cellpadding="0" align="center" background="../images/loginrequired_background_form.png">
	            			<tr>
                                <td valign="top">
                                    <center>
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />	
                                        <br />	
                                        <br />			
                                            <table cellspacing="2" cellpadding="2" border="0" width="400">
                                    	        <tr>
                                                    <td colspan="2" style="font-weight:bold;font-size:20px;">PIS - Login required<br /><br /><br /></td>
                                                </tr>
                                                <tr>
		                                            <td>
                                                        <table width="300">
                                                            <tr>
                                                                <td width="100">Email:</td>
                                                                <td width="200"><asp:TextBox ID="txtUserName" runat="server" style="width:200px" TabIndex="1"  CssClass="form"></asp:TextBox></td>
                                                            </tr>
                                                        </table>
		                                            </td>
		                                            <td rowspan="2" valign="top">
                                                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="form" 
                                                            style="font-weight:bold;width:75px;height:60px;" TabIndex="3" 
                                                             /></td>
	                                            </tr>
	                                            <tr>
                                                    <td>
                                                        <table width="300">
                                                            <tr>
                                                                <td width="100">Password:</td>
                                                                <td width="200"><asp:TextBox ID="txtPassword" runat="server" TabIndex="2"  style="width:200px" CssClass="form" TextMode="Password"></asp:TextBox></td>
                                                            </tr>
                                                        </table>
		                                            </td>
	                                            </tr>
	                                            <tr>
                                                    <td>
                                                        <table width="300">
                                                            <tr>
                                                                <td width="82"></td>
                                                                <td width="200"><asp:Label ID="lblBadUserPassword" runat="server" Text="Bad email/password" Visible="false" style="color:Red; float:left"></asp:Label></td>
                                                            </tr>
                                                        </table>
		                                            </td>
	                                            </tr>
                                            </table>
                                        </center><br />
					            </td>
                                </tr>
			            </table>
		            </td>
	            </tr>
            </table>
    </ContentTemplate>
    </asp:UpdatePanel>
    <div id="content"></div>
    </form>
</body>
</html>
