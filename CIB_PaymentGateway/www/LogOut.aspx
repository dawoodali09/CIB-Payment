<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LogOut.aspx.vb" Inherits="www.LogOut" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>MashreqOnline: Sign Out</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" type="text/css">
		<LINK href="../StyleSheet/mol.css" type="text/css" rel="stylesheet">
		<LINK rel="alternate stylesheet" type="text/css"  title="skin2">
		
	</HEAD>
	<body MS_POSITIONING="GridLayout"  leftMargin="0" topmargin="0" rightmargin="0"  >
		<table id="tbl1" runat="server" width="780" cellpadding="0" cellspacing="0" border="0" align="center" dir="ltr">
		
			<tr>
				<td>
					<table width="100%" border="0" align="center" cellspacing="0" cellpadding="0"  >
                    <tr><td><div id="landingheader">
                    <div id="landingheaderwrapper">
                    <img src="images/banner1.jpg" width="100%" height="300" />
                    </div>
                    </div></td></tr>
						<tr>
							<td colspan="2" align="left" valign="top" class="MainHeader"><asp:label id="lblLoggedOut" runat="server"></asp:label></td>
						</tr>
						<tr>
							<td colspan="2" align="left" valign="top" class="MessageBlock" style="padding:12px;">
							<strong><asp:Label ID="lblThanks" Runat="server"></asp:Label> <asp:label id="lblMashreq" runat="server"></asp:label><asp:label id="lblOnline" runat="server"></asp:label></strong><br>
							&raquo;  <a href=Login.aspx>Login</a>
								 <asp:label id="lblPrivacy1" runat="server"></asp:label> <asp:label id="lblPrivacy2" runat="server"></asp:label>
							</td>
						</tr>
						<tr>
						  <td colspan="2" align="left" valign="top">&nbsp;</td>
					  </tr>
					  
					
					  
					 
					  <tr>
						<td colspan="2" align="left" valign="top" style="padding:10px; border-top:2px #cc0000 dotted; border-bottom:2px #cc0000 dotted; font-family:Verdana, Arial, Helvetica, sans-serif; font-size:8pt; color:#666666; background:#FFE3DF;">
						<strong>Important:</strong> Please close the browser for safe browsing.
						<asp:label id="lblIdle1" runat="server"></asp:label>  <asp:label id="lblIdle2" runat="server"></asp:label>
						</td>
					</tr>
					</table>
				</td>
			</tr>
		</table>
		<div style="color:#ffffff; font-size:1px;"><asp:label id="lblTechQ1" runat="server"></asp:label> <asp:label id="lblTechQ2" runat="server"></asp:label> <asp:label id="lblTechQ3" runat="server"></asp:label></div>
	</body>
</HTML>

