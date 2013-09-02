<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="signupconfirmation.aspx.vb" Inherits="www.signupconfirmation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>Sign UP</title>
        <LINK href="Styles/CIB_Global.css" type="text/css" rel="stylesheet">
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
		<form id="frmbillpayer" method="post" runat="server">
			<table class="BreadCrumbContainer" cellSpacing="0" cellPadding="8" width="100%" border="0">
				<tr>
					<td class="BreadCrumb" vAlign="top" align="left"></td>
				</tr>
			</table>
            <table id="tblMain" dir="ltr" width="50%" align="center" border="0" cellspacing="0" cellpadding="10" class="MainContainer" runat="server">
		    <tr id="pnl1" runat="server">
			<td align="left">
                    <table class="DetailsSelectionBlock" cellSpacing="0" cellPadding="4" width="100%" border="0">
                            <TR>
                                <TD class="FormStepsTitle" colSpan="2" align="center"><asp:Label id="Label1" text="Confirm User Information" Runat="server"></asp:Label></TD>
                            </TR>
                            <TR class="putcol">
                                <TD class="FormFileds"><asp:Label id="lblemailaddress" text="Email Address" Runat="server"></asp:Label><SPAN class="orange">*</SPAN></TD>
                                <TD class="FormFileds"><asp:TextBox id="txtemailaddress" Runat="server" CssClass="input" Width="256px" ReadOnly="true"></asp:TextBox></TD>
                            </TR>
                            <TR class="putcol">
                                <TD class="FormFileds"><asp:Label id="lblpassword" text="Password" Runat="server"></asp:Label><SPAN class="orange"></SPAN></TD>
                                <TD class="FormFileds"><asp:TextBox id="txtpassword" Runat="server" CssClass="input" ReadOnly="true"></asp:TextBox></TD>
                            </TR>
                            <TR class="putcol">
                                <TD class="FormFileds"><asp:Label id="lblconfirmpassword" text="Confirm Password" Runat="server"></asp:Label><SPAN class="orange"></SPAN></TD>
                                <TD class="FormFileds"><asp:TextBox id="txtconfirmpassword" Runat="server" CssClass="input" ReadOnly="true" ></asp:TextBox></TD>
                            </TR>
                            <TR class="putcol">
                                <TD class="FormFileds"><asp:Label id="lblFirstName" text="FirstName" Runat="server"></asp:Label><SPAN class="orange"></SPAN></TD>
                                <TD class="FormFileds"><asp:TextBox id="txtFirstName" Runat="server" CssClass="input" Width="256px" ReadOnly="true"></asp:TextBox></TD>
                            </TR>
                            <TR class="putcol">
                                <TD class="FormFileds"><asp:Label id="lblLastName" text="LastName" Runat="server"></asp:Label></TD>
                                <TD class="FormFileds"><asp:TextBox id="txtLastName" Runat="server" CssClass="forminput" Width="256px" ReadOnly="true"></asp:TextBox></TD>
                            </TR>
                            <TR class="putcol">
                                <TD class="FormFileds"><asp:Label id="lblAddress1" text="Address Line 1" Runat="server"></asp:Label></TD>
                                <TD class="FormFileds"><asp:TextBox id="txtAddress1" Runat="server" CssClass="forminput" Width="256px" ReadOnly="true"></asp:TextBox></TD>
                            </TR>
                            <TR class="putcol">
                                <TD class="FormFileds"><asp:Label id="lblAddress2" text="Address Line 2" Runat="server"></asp:Label>&nbsp;(Optional)</TD>
                                <TD class="FormFileds"><asp:TextBox id="txtAddress2" Runat="server" CssClass="forminput" Width="256px" ReadOnly="true"></asp:TextBox></TD>
                            </TR>
                            <TR class="putcol">
                                <TD class="FormFileds"><asp:Label id="lblPincode" text="Pincode" Runat="server"></asp:Label></TD>
                                <TD class="FormFileds"><asp:TextBox id="txtPincode" Runat="server" CssClass="forminput" ReadOnly="true"></asp:TextBox></TD>
                            </TR>
                            <TR class="putcol">
                                <TD class="FormFileds"><asp:Label id="lblMobileNo" text="Mobile Number" Runat="server"></asp:Label></TD>
                                <TD class="FormFileds"><asp:TextBox id="txtMobileno" Runat="server" CssClass="forminput" ReadOnly="true" ></asp:TextBox></TD>
                            </TR>                             
                            <TR>
                                <TD class="FormFileds" align="right">
                                    <asp:Button id="btnConfirm" Runat="server" CssClass="InputButton" Text="Confirm"></asp:Button>
                                </TD>
                                <td class="FormFileds" align="left">                                
                                    <asp:Button id="btnback" Runat="server" CssClass="InputButtonCancel" Text="Go Back" CausesValidation="False"></asp:Button>
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

