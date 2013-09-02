<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="NewPasswordPage.aspx.vb" Inherits="www.NewPasswordPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>Sign UP</title>
        <LINK href="Styles/CIB_Global.css" type="text/css" rel="stylesheet">
        <link rel="stylesheet" type="text/css" href="css/main.css"/>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">

	    <style type="text/css">
            .input
            {}
        </style>

	</HEAD>
	<body class="innerpage" >
		<form id="frmbillpayer" method="post"  runat="server">
        <div id="headerContent">
    <div class="headerWrap">
        <div class="logo"></div>
        
    </div>
</div>
			<table class="BreadCrumbContainer" cellSpacing="0" cellPadding="8" width="100%" border="0">
				<tr>
					<td class="BreadCrumb" vAlign="top" align="left">
                    
                    </td>
				</tr>
			</table>
            <table id="tblMain" dir="ltr" align="center" border="0" cellspacing="0" 
            cellpadding="10" class="MainContainer" runat="server">
		    <tr id="pnl1" runat="server">
			<td align="left">
                    <table class="DetailsSelectionBlock" cellSpacing="0" cellPadding="4" border="0">
                            <TR>
                                <TD class="FormStepsTitle" align="center" colspan="2"><asp:Label id="Label1" text="Enter Your Password:" Runat="server"></asp:Label></TD>
                            </TR>
                          
                            <TR class="putcol">
                                <TD class="FormFileds"><asp:Label id="lblpassword" text="Password" Runat="server"></asp:Label><SPAN class="orange">*</SPAN></TD>
                                <TD class="FormFileds">
                                    <asp:TextBox id="txtpassword" Runat="server" 
                                        CssClass="input" TextMode="Password" ></asp:TextBox></TD>
                            </TR>
                            <TR class="putcol">
                                <TD class="FormFileds"><asp:Label id="lblconfirmpassword" text="Confirm Password" Runat="server"></asp:Label><SPAN class="orange">*</SPAN></TD>
                                <TD class="FormFileds"><asp:TextBox id="txtconfirmpassword" Runat="server" 
                                        CssClass="input" TextMode="Password" ></asp:TextBox></TD>
                            </TR>
                            
                           
                            <TR align="Left">
                            <TD class="dis" colSpan="2"><asp:label id="lblErrorMessage" Height="10px" Runat="server" ForeColor="Red" Visible="false"></asp:label></TD>
                            </TR>                                
                            <TR>
                                <TD class="FormFileds" align="right">
                                    <asp:Button id="btnSubmit" Runat="server" CssClass="InputButton" Text="Submit"></asp:Button>
                                </TD>
                                <td class="FormFileds" align="left">                                
                                    <asp:Button id="btnReset" Runat="server" CssClass="InputButtonCancel" 
                                        Text="Reset" CausesValidation="False"></asp:Button>
                                </td>
                            </TR>
                            <TR>
                            <TD class="FormFileds" colSpan="2">
    
                            </TD>
                            </TR>
                        </TABLE>                        
                    </td>
                    </tr>
                    </table>

			
							
						</form>
	</body>
</HTML>

