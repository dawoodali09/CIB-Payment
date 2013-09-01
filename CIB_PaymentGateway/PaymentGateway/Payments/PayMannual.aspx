<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PayMannual.aspx.vb" Inherits="Payments_PayMannual" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>Pay Mannual</title>
        <LINK href="../Styles/CIB_Global.css" type="text/css" rel="stylesheet">
        <link rel="stylesheet" type="text/css" href="../css/main.css"/>
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
      


         <h1>
       Manual  payment form
    </h1>
     <div>

     <asp:Panel ID="pnlPayment" runat="server" Visible="true" >
         <table border="0" cellpadding="4" class="DetailsSelectionBlock">
  <tr>
    <td>&nbsp;</td>
    <td>     &nbsp;</td>
    <td>
        <asp:Label ID="lblError" runat="server" Visible="False"></asp:Label>
      </td>
  </tr>
             <tr>
                 <td>
                     &nbsp;</td>
                 <td>
                     <h2>
                         Merchant Info</h2>
                 </td>
                 <td>
                     &nbsp;</td>
             </tr>
  <tr>
    <td>&nbsp;</td>
    <td align="right" valign="top" nowrap>User Name </td>
    <td align="left" valign="top">
        <asp:TextBox ID="txtUserName" runat="server" CssClass="input">HALKBANKAPI</asp:TextBox>
    </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td align="right" valign="top" nowrap>Password</td>
    <td align="left" valign="top">
        <asp:TextBox ID="txtPassword" runat="server" CssClass="input">HALKBANK05</asp:TextBox>
    </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td align="right" valign="top" nowrap>Client ID </td>
    <td align="left" valign="top">
        <asp:TextBox ID="txtClientID" runat="server" CssClass="input">500500000</asp:TextBox>
    </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td align="right" valign="top" nowrap>Payment Type </td>
    <td align="left" valign="top">
        <asp:DropDownList ID="ddPaymentType" runat="server">
            <asp:ListItem Selected="True" Value="Auth" CssClass="input">Auto Deposit</asp:ListItem>
            <asp:ListItem Value="PreAuth" CssClass="input">Authorization</asp:ListItem>
        </asp:DropDownList>
    </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td align="right" valign="top" nowrap>Amount</td>
    <td align="left" valign="top"> 
	<asp:TextBox ID="txtAmount" runat="server" >1.00</asp:TextBox>
        <asp:DropDownList ID="ddCurrency" runat="server">
            <asp:ListItem Selected="True" Value="949">TYR</asp:ListItem>
            <asp:ListItem Value="840">USD</asp:ListItem>
            <asp:ListItem Value="978">EUR</asp:ListItem>
            <asp:ListItem Value="784">AED</asp:ListItem>
        </asp:DropDownList>
    </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td align="right" valign="top" >OrderID</td>
    <td align="left" valign="top">
        <asp:TextBox ID="txtOrderID" runat="server" CssClass="input">1111</asp:TextBox>
    </td>
  </tr>
 
  <tr>
    <td>&nbsp;</td>
    <td><h2>Card Info</h2></td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td align="right" valign="top" nowrap>Number</td>
    <td align="left" valign="top"> <asp:TextBox ID="txtCCNumber" runat="server" CssClass="input" >4920244920244921</asp:TextBox>
    </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td align="right" valign="top" nowrap>Expiry</td>
    <td align="left" valign="top"> <asp:TextBox ID="txtExpDate" runat="server" CssClass="input">12/2017</asp:TextBox>
    </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td align="right" valign="top" nowrap>CVC</td>
    <td align="left" valign="top"> <asp:TextBox ID="txtCVV2" runat="server" CssClass="input">001</asp:TextBox>
    </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>
        <asp:Button ID="cmdSubmit" runat="server" Text="Submit" 
             onclick="cmdSubmit_Click" />
    </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
</table>
    </asp:Panel>
	
    <asp:Panel ID="pnlResult" runat="server" Visible="false" >			
        <h2>Result</h2><br />			
        <center><asp:Label ID="lblMsg" runat="server" ></asp:Label></center>
        <br />
      <asp:ListBox id="lbNodes" runat="server"  Font-Size="XX-Small" Font-Names="Verdana" Enabled="false" Visible="false"  ></asp:ListBox>
        <br />
    <center>  <asp:Button ID="btnBack" runat="server" Text="Back To Payment" CssClass="InputButton"></asp:button></center>
   </asp:Panel> 

   
			
							
						</form>
	</body>
</HTML>
