﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FooterPage.aspx.vb" Inherits="landing_FooterPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Footer Content</title>
<link rel="stylesheet" type="text/css" href="../css/main.css"/>
</head>

<body >
<table width="100%" height="100%">
    <tr>
    	<td width="48%" class="userContentLabel">Welcome <span class="nameBold"><asp:Label ID="lblLoginUser" runat="server">Naresh Babu</asp:Label></span></td>
        <td width="48%">
        <table align="right">
        <tr><td class="timeContentLabel">Last Login Time: <span class="nameBold"><asp:Label ID="lblLastLogin" runat="server">19:00</asp:Label></span></td></tr>
        <!--<tr><td class="timeContentLabel">Current login time: <span class="nameBold">00 hrs:26 mins</span></td></tr>-->
        </table>
        
        
        </td>
    </tr>
</table>

</body>
</html>
