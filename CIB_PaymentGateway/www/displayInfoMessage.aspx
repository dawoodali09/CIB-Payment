<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="displayInfoMessage.aspx.vb" Inherits="www.displayInfoMessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
	<head>
		<title>Message</title>
		<LINK href="Styles/CIB_Global.css" type="text/css" rel="stylesheet">
		<META http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="ProgId" content="VisualStudio.HTML">
		<meta name="Originator" content="Microsoft Visual Studio .NET 7.1">
		
	</head>
	<body class="innerpage" MS_POSITIONING="GridLayout" >
		<br>
		<br>
        <form id="frmdispMessade" runat="server">
		<table class="MainContainer" id="tblMain" cellSpacing="0" cellPadding="8"
			align="center" border="0">
			<tr>
				<td>
					<table class="DetailsSelectionBlock" cellSpacing="0" cellPadding="0" border="0"
						ID="Table1">
						<tr>
							<td>
								<table width="100%" align="center" cellSpacing="0" cellPadding="8" border="0" ID="Table2">
									<tr >
										<TD class="AccountStatemnetTitle" align=center>Information/Error</TD>
									</tr>
									<tr>
										<td class="AccountStatemnetTitle" align=center><br>
										<b><asp:Label ID="lblmessage" runat="server"></asp:Label></b> <br>                                          
                                         <asp:LinkButton ID="lnkHome" Text="Login" runat="server" PostBackUrl="~/Login.aspx" Visible=false></asp:LinkButton>
										</td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
        </form>
	</body>
</html>
