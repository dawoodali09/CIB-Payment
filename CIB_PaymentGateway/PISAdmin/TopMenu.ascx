<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="TopMenu.ascx.vb" Inherits="PISAdmin.TopMenu" %>

 
<script src="scripts/stuHover.js" type="text/javascript"></script>
<asp:ScriptManager ID="ScriptManager2" runat="server">
</asp:ScriptManager>

<div id="divAdmin" runat="server" visible="false">
    <ul id="nav">
	    <li class="top"><a href="Startpage.aspx" class="top_link"><span>Startpage</span></a></li>
	    <li class="top"><a href="Default.aspx" id="products" class="top_link"><span class="down">Overview</span></a>
		    <ul class="sub">
			    <li><a href="Default.aspx">Subscriptions</a>
			    </li>
			    <li><a href="Payments.aspx">Payments</a>
			    </li>
			    <li><a href="PaymentAttempts.aspx">Paymentattempts</a></li>
                  <li><a href="Emails.aspx">Emails</a></li>
                  <li><a href="PaymentTest.aspx">PaymentTest</a></li>
		    </ul>
	    </li>
	    <li class="top"><a href="Statistik.aspx" id="A1" class="top_link"><span class="down">Statistics</span></a>
            <ul class="sub">
			    <li><a href="Statistik.aspx">Statistics</a></li>
                <li><a href="Cohart.aspx">Cohart</a></li>
                <li><a href="BadCustomers.aspx">Bad customers</a></li>
		    </ul>
        </li>
	    <li class="top"><a href="FraudlogRequest.aspx" id="A2" class="top_link"><span class="down">Fraud</span></a>
            <ul class="sub">
                <li><a href="FraudlogRequest.aspx">Fraud log</a></li>
			    <li><a href="FraudStatistics.aspx">Statistics</a></li>
                <li><a href="#" class="fly">Settings</a>
                    <ul>
                        <li><a href="BlockedIPAddresses.aspx">Blocked IP Addresses</a> </li>
                        <li><a href="BlockedBins.aspx"> Blocked BINs</a>  </li>
                        <li><a href="DisposableDomains.aspx"> Disposable Domains</a>  </li>
                        <li><a href="FraudLogTypes.aspx"> FraudLog Types</a>  </li>
                        <li><a href="CardBlockPolicies.aspx"> Card Block Policies</a>  </li>
                        <li><a href="ExamptedEmails.aspx"> Test Emails</a>  </li>
                    </ul>
                </li>
		    </ul>
        </li>

        <li class="top"><a href="#" class="top_link"><span class="down">Chargeback</span></a>
            <ul class="sub">
                <li><a href="cbDocumentRequests.aspx">Documents-Req</a></li>
                <li><a href="cbProcessedDocs.aspx">Documents-Proc</a></li>
                <li><a href="cbReceivers.aspx">Receivers</a></li>
                <li><a href="cbEventLog.aspx">EventLog</a></li>
                <li><a href="cbFileLog.aspx">FileLog</a></li>
                <li><a href="cbReport.aspx">Report</a></li>                
            </ul>        
        </li>
          <li class="top"><a href="VIPNewSubscriptions.aspx"  id="accounts" class="top_link"><span class="down">Accounting</span></a>
            <ul class="sub">
			    <li><a href="VIPNewSubscriptions.aspx">VIP Statistics</a></li>
                 <li><a href="PointDealTurnoverVIP.aspx">Turnover</a></li>
                 <li><a href="PointDealVIPConversion.aspx">VIPConversion</a></li>
                 <li><a href="PointDealVIPNewSubscriptions.aspx">NewSubscription</a></li>
                 <li><a href="PointDealActiveAndUnsubscribed.aspx">ActiveSubscription</a></li>
            </ul>
          </li>
	    <li class="top"><a href="ListTranslations.aspx" id="A3" class="top_link"><span class="down">Administration</span></a>
            <ul class="sub">
			    <li><a href="ListTranslations.aspx">Translations</a></li>
                <li><a href="ListFAQCategories.aspx">FAQ</a></li>
                <li><a href="AddEditUsers.aspx">User logins</a></li>
                <li><a href="GetSubscriptionDocumentation.aspx">CB/CR</a></li>
		    </ul>
        </li>
	    <li class="top"><a href="Tips.aspx" id="privacy" class="top_link"><span class="down">Help</span></a>
            <ul class="sub">
			    <li><a href="Tips.aspx">Tips</a></li>
                <li><a href="MyLogin.aspx">My login</a></li>
		    </ul>
        </li>
        <li class="top"><a href="Login.aspx?logoff=true" class="top_link"><span>Logoff</span></a></li>
    </ul>
</div>
<div  style="float:left; width:100%; margin-bottom:15px">
<span id="spanStatus" runat="server" style="float:left"></span>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" style="float:left" >
        <ProgressTemplate>
            <strong style="float:left; color:Red; margin-left:10px">Processing your request</strong><img src="images/smallajaxloader.gif" style="float:left; margin-left:5px" />
        </ProgressTemplate>
    </asp:UpdateProgress>
</div>
