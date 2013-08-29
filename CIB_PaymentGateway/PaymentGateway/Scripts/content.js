function opCreativeSetCookieA(n, v, d, e){var de = new Date;de.setTime(de.getTime() + e * 1000);document.cookie = n + "=" + escape(v) + ((e==null) ? "" : ("; expires=" + de.toGMTString())) + "; path=/" + ((d==null) ? "" : (";domain=" + d));}
function opCreativeGetDocumentSLD(){var sld = document.domain;var dp = sld.split(".");var l = dp.length;if (l < 2) sld = null;else if (!isNaN(dp[l-1]) && !isNaN(dp[l-2])) sld = null;else sld = "." + dp[l-2] + "." + dp[l-1];return sld;}
opCreativeSetCookieA("op1643inbusinesshomegum", "a00w01z00o296qv0e036fa296ts0372loc4fc", opCreativeGetDocumentSLD(), 2592000);
opCreativeSetCookieA("op1643inbusinesshomeliid", "a00w01z00o296qv0e036fa296ts0372loc4fc", opCreativeGetDocumentSLD(), 86400);

document.write('<style type="text/css">' +
'.opDefaultContent_inbusinesshome' +
'{display:none;}</style>');

