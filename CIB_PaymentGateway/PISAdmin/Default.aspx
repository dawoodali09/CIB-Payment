<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="PISAdmin._Default" %>

<%@ Register src="topmenu.ascx" tagname="topmenu" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head id="Head1" runat="server">
        <title>PIS</title>
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
        <script type="text/javascript">
            $(document).ready(function () {
                $('.aAdvanced').live('click', function () {
                    $(this).closest('div').prev().toggle();
                    if ($(this).text() == 'More search options >>') {
                        $(this).text('<< Less search options');
                    }
                    else {
                        $(this).text('More search options >>');
                    }
                    return true;
                });
            });
        </script>
        <form id="form1" runat="server">
            <div>
                <h3>PIS: Payments</h3>
	            <uc1:topmenu ID="topmenu1" runat="server" />
	            <br />
                <br />
                Start Page.. Later We Will implement this page.<br />
            </div>
	       
 

 


    
    </form>
</body>
</html>