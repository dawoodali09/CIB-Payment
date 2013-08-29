<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>CIB Finance Login Screen</title>
<link rel="stylesheet" type="text/css" href="css/main.css"/>
    <script language="javascript" type="text/javascript">
// <![CDATA[

// ]]>
    </script>
</head>

<body>
<form id="form2" runat="server" method="post">
<div id="headerContent">
    <div class="headerWrap">
        <div class="logo"></div>
        <div class="loginNavigation">
        <ul>
        <li><label style="text-align:center; color:White;" for="lbl1">Email Address </label><asp:TextBox id="email" runat="server" class="inputArea"></asp:TextBox></li>
        <li><label style="text-align:center; color:White;" for="lbl1">Password </label><asp:TextBox id="password" runat="server" class="inputArea"></asp:TextBox></li>
        <li><asp:button class="loginButton" id="btnlogin" runat="server" Text="Login"></asp:button></li>
        <li><asp:button class="signupButton" id="btnsignup" runat="server" Text="Signup"></asp:button></li>
        <li><b><asp:label id="lblErrorMessage" Runat="server" style="text-align:center; color:Maroon;" Visible="false"></asp:label></b></li>
        </ul>
        </div>
    </div>
</div>
<div id="menuContent">
	<div class="menuWrap">
    	<table width="100%" height="100%">
        <tr>
        <td class="menuDivision"><a href="#">Home</a></td>
        <td class="menuDivision"><a href="#">Why Us</a></td>
        <td class="menuDivision"><a href="#">How it Works</a></td>
        <td class="menuDivision"><a href="#">Pricing</a></td>
        <td class="menuDivision"><a href="#">Developer</a></td>
        <td class="menuDivision"><a href="#">Login</a></td>
        <td class="menuDivision"><a href="#">Contact Us</a></td>
        </tr>
        </table>
     
    </div>
<div id="bodyContent">
	<div class="bodyWrap">
    <table>
    <tr>
    <td colspan="3"><img src="images/banner1.jpg" width="1000" height="290" /></td>
    </tr>
    <tr height="200" width="100%">
    	<td width="31%">
        	<div class="subcontents">
            	<ul>
                	<li class="subcontentimage"><img src="images/briefcase-icon.png" width="128" height="128" /></li>
                    <li class="subcontenthead">Buy into being safer</li>
                    <li class="subcontentnormal">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. </li>
                    <li class="learnabt"><a href="#">Learn about</a></li>
                </ul>
            </div>
        </td>
        <td width="31%">
            <div class="subcontents">
            <ul>
            <li class="subcontentimage"><img src="images/company-building-icon.png" width="128" height="128" /></li>
            <li class="subcontenthead">Sell in fewer steps</li>
            <li class="subcontentnormal">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. </li>
            <li class="learnabt"><a href="#">Learn about</a></li>
            </ul>
            </div>
        </td>
        <td width="31%">
        	 <div class="subcontents">
            <ul>
            <li class="subcontentimage"><img src="images/pie-chart-icon.png" width="128" height="128" /></li>
            <li class="subcontenthead">Transfer money to friends</li>
            <li class="subcontentnormal">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. </li>
            <li class="learnabt"><a href="#">Learn about</a></li>
            </ul>
            </div>
        </td>
    </tr>
    </table>
	</div>
</div>
<div id="footerContent">
<div id="footerContentwrapper">
	<span class="copyrights">Copyright © 2012-2013 CIB Finance. All rights reserved.</span>
</div>
</div>
</div>
</form>
</body>
</html>

