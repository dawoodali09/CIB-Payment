
(function(){"use strict";var PAYPAL=window.PAYPAL||{};window.PAYPAL=PAYPAL;PAYPAL.analytics={};PAYPAL.analytics.Analytics=function(options){this._init(options);};PAYPAL.analytics.Analytics.prototype={version:'0.1',options:{click:{elements:'*[data-pp-click]',onClick:function(){},request:{keys:{linkUrl:'lu'},values:{eventType:'cl'}}},formAbandonment:{elements:'form',request:{keys:{lastFormFocused:'lf',lastInputFocused:'li'},values:{eventType:'fa'}}},impression:{request:{keys:{cookiesEnabled:'ce',plugins:'pl',jsVersion:'jsv',pageTitle:'pt',referrer:'ru',screenColorDepth:'cd',screenWidth:'sw',screenHeight:'sh',browserWidth:'bw',browserHeight:'bh'},values:{eventType:'im'}}},request:{data:{},unloadDelay:false,keys:{version:'v',timestamp:'t',gmtOffset:'g',eventType:'e'},values:{eventType:'na','true':1,'false':0},keyPrefix:'_',url:'//t.paypal.com/ts',onBeaconCreate:function(){}}},_delayUnloadUntil:null,_lastFormFocused:null,_lastInputFocused:null,_init:function(options){this.setOptions(options);this._enableUnloadDelay();},_mergeOptions:function(options1,options2){if(options1&&options1.data&&typeof options1.data==='string'){options1.data=this.utils.queryStringToObject(options1.data);}
if(options2&&options2.data&&typeof options2.data==='string'){options2.data=this.utils.queryStringToObject(options2.data);}
var options=this.utils.merge(options1,options2);return options;},_enableUnloadDelay:function(){var self=this,delay=function(){var now;if(self._delayUnloadUntil){do{now=new Date();}while(now.getTime()<self._delayUnloadUntil);}};this.utils.addListener(window,'beforeunload',delay);},_recordEvent:function(eventData,options){var key;options=this._mergeOptions(this.options.request,options);options.data=options.data||{};for(key in eventData){options.data[options.keyPrefix+key]=eventData[key];}
this.record(options);},_request:function(options){this._createBeacon(options);},_createBeacon:function(options){var self=this,beacon=new Image();if(options.onBeaconCreate(beacon)!==false){beacon.src=this._generateBeaconUrl(options);if(options.unloadDelay){this.setUnloadDelay(options.unloadDelay);}}},_generateBeaconUrl:function(options){var parts=options.url.split('?'),url=parts[0],optKeys=options.keys,key,perfData,rLogId;if(url.match(/^\/\//)){url=window.location.protocol+url;}
url+='?';if(parts[1]){url+=parts[1]+'&';}
url+=options.keyPrefix+optKeys.version+'='+encodeURIComponent(this.version);if(optKeys.timestamp){url=this._appendQueryStringData(url,options.keyPrefix+optKeys.timestamp,this._getTimestamp());}
if(optKeys.gmtOffset){url=this._appendQueryStringData(url,options.keyPrefix+optKeys.gmtOffset,this._getGmtOffset());}
if(optKeys.eventType){url=this._appendQueryStringData(url,options.keyPrefix+optKeys.eventType,options.values.eventType);}
for(key in options.data){url=this._appendQueryStringData(url,key,options.data[key]);}
perfData=this._buildPerformanceData(options.data);for(key in perfData){url=this._appendQueryStringData(url,key,perfData[key]);}
rLogId=this._getRLogId();if(rLogId){url=this._appendQueryStringData(url,"teal",rLogId);}
return url;},_appendQueryStringData:function(url,key,value){if((key||key===0)&&(value||value===0)){url+='&'+key+'='+encodeURIComponent(value);}
return url;},_getTimestamp:function(){return new Date().getTime();},_buildPerformanceData:function(data){var perf={},pgst=data.pgst||0;if(!PAYPAL.analytics.perf){if(window.performance){var timing=window.performance.timing,secureConTime=timing.secureConnectionStart||timing.connectEnd,loadEventEnd=timing.loadEventEnd||timing.loadEventStart;perf.t1=this._getPerformanceData(timing.requestStart,timing.fetchStart);perf.t1c=this._getPerformanceData(timing.connectEnd,timing.fetchStart);perf.t1d=this._getPerformanceData(timing.domainLookupEnd,timing.domainLookupStart);perf.t1s=this._getPerformanceData(timing.connectEnd,secureConTime);perf.t2=this._getPerformanceData(timing.responseStart,timing.requestStart);perf.t3=this._getPerformanceData(timing.responseEnd,timing.responseStart);perf.t4d=this._getPerformanceData(timing.domComplete,timing.domLoading);perf.t4=this._getPerformanceData(loadEventEnd,timing.domLoading);perf.t4e=this._getPerformanceData(loadEventEnd,timing.loadEventStart);perf.tt=this._getPerformanceData(loadEventEnd,timing.navigationStart);}else if(pgst){perf.told=new Date().getTime()-pgst;}
PAYPAL.analytics.perf=perf;}
return perf;},_getPerformanceData:function(end,start){var diff=0;var max=600000;if(this._validateNumber(start)&&this._validateNumber(end)){if(end>=start){diff=end-start;if(diff>max){diff=0;}}}
return diff;},_validateNumber:function(value){if(!value){return false;}
if(value.length==0){return false;}
var intValue=parseInt(value);if(intValue==Number.NaN){return false;}
if(intValue<0){return false;}
return true;},_getRLogId:function(){var rLogId,commentNode,commentData;if(window.rLogId){rLogId=window.rLogId;}else{try{commentNode=[].slice.call(document.head.childNodes).filter(function(node){return node.nodeType===8;})[0];commentData=commentNode.data;if(commentData&&commentData.length>0){commentData=commentData.trim().split(" : ");if(commentData.length>2){rLogId=commentData[commentData.length-1];}}}catch(e){}}
return rLogId;},_getGmtOffset:function(){return new Date().getTimezoneOffset();},_getPageTitle:function(){return document.title;},_getReferrer:function(){return document.referrer;},_getScreenColorDepth:function(){return window.screen.colorDepth;},_getScreenDimensions:function(){return{width:window.screen.width,height:window.screen.height};},_getBrowserDimensions:function(){var browserWidth,browserHeight,element=document.documentElement;if(window.innerWidth!=='undefined'&&window.innerWidth){browserWidth=window.innerWidth;browserHeight=window.innerHeight;}
else if(element!=='undefined'&&element.clientWidth!=='undefined'&&element.clientWidth!==0){browserWidth=element.clientWidth;browserHeight=element.clientHeight;}
else{element=document.getElementsByTagName('body')[0];browserWidth=element.clientWidth;browserHeight=element.clientHeight;}
return{width:browserWidth,height:browserHeight};},_getJavaEnabled:function(options){options=this._mergeOptions(this.options.request,options);return(navigator.javaEnabled())?options.values['true']:options.values['false'];},_getCookiesEnabled:function(options){options=this._mergeOptions(this.options.request,options);var enabled=0;if(navigator.cookieEnabled==='undefined'){document.cookie='enabledCheck';enabled=(document.cookie.indexOf('enabledCheck')!==-1)?options.values['true']:options.values['false'];}else{enabled=(navigator.cookieEnabled)?options.values['true']:options.values['false'];}
return enabled;},_getFlashVersion:function(){var version=null;if(navigator.plugins&&navigator.plugins.length>0){var type='application/x-shockwave-flash',mimeTypes=navigator.mimeTypes;if(mimeTypes&&mimeTypes[type]&&mimeTypes[type].enabledPlugin&&mimeTypes[type].enabledPlugin.description){version=mimeTypes[type].enabledPlugin.description;}}
return version;},_getPluginData:function(){return{director:'application/x-director',mediaplayer:'application/x-mplayer2',pdf:'application/pdf',quicktime:'video/quicktime',real:'audio/x-pn-realaudio-plugin',silverlight:'application/x-silverlight'};},_getPluginDataIE:function(){var names=["abk","wnt","aol","arb","chs","cht","dht","dhj","dan","dsh","heb","ie5","icw","ibe","iec","ieh","iee","jap","krn","lan","swf","shw","msn","wmp","obp","oex","net","pan","thi","tks","uni","vtc","vnm","mvm","vbs","wfd"],components=["7790769C-0471-11D2-AF11-00C04FA35D02","89820200-ECBD-11CF-8B85-00AA005B4340","47F67D00-9E55-11D1-BAEF-00C04FC2D130","76C19B38-F0C8-11CF-87CC-0020AFEECF20","76C19B34-F0C8-11CF-87CC-0020AFEECF20","76C19B33-F0C8-11CF-87CC-0020AFEECF20","9381D8F2-0288-11D0-9501-00AA00B911A5","4F216970-C90C-11D1-B5C7-0000F8051515","283807B5-2C60-11D0-A31D-00AA00B92C03","44BBA848-CC51-11CF-AAFA-00AA00B6015C","76C19B36-F0C8-11CF-87CC-0020AFEECF20","89820200-ECBD-11CF-8B85-00AA005B4383","5A8D6EE0-3E18-11D0-821E-444553540000","630B1DA0-B465-11D1-9948-00C04F98BBC9","08B0E5C0-4FCB-11CF-AAA5-00401C608555","45EA75A0-A269-11D1-B5BF-0000F8051515","DE5AED00-A4BF-11D1-9948-00C04F98BBC9","76C19B30-F0C8-11CF-87CC-0020AFEECF20","76C19B31-F0C8-11CF-87CC-0020AFEECF20","76C19B50-F0C8-11CF-87CC-0020AFEECF20","D27CDB6E-AE6D-11CF-96B8-444553540000","2A202491-F00D-11CF-87CC-0020AFEECF20","5945C046-LE7D-LLDL-BC44-00C04FD912BE","22D6F312-B0F6-11D0-94AB-0080C74C7E95","3AF36230-A269-11D1-B5BF-0000F8051515","44BBA840-CC51-11CF-AAFA-00AA00B6015C","44BBA842-CC51-11CF-AAFA-00AA00B6015B","76C19B32-F0C8-11CF-87CC-0020AFEECF20","76C19B35-F0C8-11CF-87CC-0020AFEECF20","CC2A9BA0-3BDD-11D0-821E-444553540000","3BF42070-B3B1-11D1-B5C5-0000F8051515","10072CEC-8CC1-11D1-986E-00A0C955B42F","76C19B37-F0C8-11CF-87CC-0020AFEECF20","08B0E5C0-4FCB-11CF-AAA5-00401C608500","4F645220-306D-11D2-995D-00C04F98BBC9","73FA19D0-2D75-11D2-995D-00C04F98BBC9"],plugins={},body=document.body,i,ver;body.addBehavior("#default#clientCaps");for(i=0;i<components.length;i++){ver=body.getComponentVersion("{"+components[i]+"}","componentid");var name=names[i];if(ver){plugins[name]=ver;}}
return plugins;},_getPlugins:function(){var pluginArray=[],name,flash,plugins=this._getPluginData();for(name in plugins){if(this._detectPlugin(plugins[name])){pluginArray.push(name);}}
flash=this._getFlashVersion();if(flash){pluginArray.push(flash);}
if(pluginArray.length===0&&(navigator.appName==='Microsoft Internet Explorer')){plugins=this._getPluginDataIE();for(name in plugins){pluginArray.push(name);}}
return pluginArray.join(',');},_detectPlugin:function(type){var mimeTypes=navigator.mimeTypes,plugin;if(mimeTypes&&mimeTypes.length){plugin=mimeTypes[type];return(plugin&&plugin.enabledPlugin);}},_getLastFormFocusedValue:function(){var value='';if(this._lastFormFocused){value=this._lastFormFocused.getAttribute('name')||this._lastFormFocused.getAttribute('id')||'';}
return value;},_getLastInputFocusedValue:function(){var value='';if(this._lastInputFocused){value=this._lastInputFocused.getAttribute('name')||this._lastInputFocused.getAttribute('id')||'';}
return value;},_getElements:function(arg){var elements=[],i;if(arg){if(typeof arg==='string'){elements=this.utils.getElements(arg);}
else if(typeof arg==='object'){for(i in arg){if(arg.hasOwnProperty(i)&&arg[i].nodeType===1){elements.push(arg[i]);}}}
else if(arg.nodeType===1){elements.push(arg);}}
return elements;},_click:function(element){if(element.getAttribute('href')){window.location.href=element.getAttribute('href');}},setOptions:function(options){this.options=this._mergeOptions(this.options,options);},setRequestData:function(key,value){if(typeof key==='object'){var i;for(i in key){this.options.request.data[i]=key[i];}}else if(typeof key==='string'&&value===undefined){this.setRequestData(this.utils.queryStringToObject(key));}else if(typeof key==='string'&&value!==undefined){this.options.request.data[key]=value;}},getRequestData:function(key){var data=this.options.request.data;if(key){data=data[key];}
return data;},removeRequestData:function(key){var data=this.options.request.data;if(data[key]){delete data[key];}else if(!key){data={};}},setUnloadDelay:function(delay){this._delayUnloadUntil=new Date().getTime()+delay;},recordImpression:function(options){var eventData={},optKeys,screenDimensions,browserDimensions;options=this._mergeOptions(this.options.impression.request,options);optKeys=options.keys;eventData[optKeys.pageTitle]=this._getPageTitle();eventData[optKeys.referrer]=this._getReferrer();eventData[optKeys.screenColorDepth]=this._getScreenColorDepth();screenDimensions=this._getScreenDimensions();eventData[optKeys.screenWidth]=screenDimensions.width;eventData[optKeys.screenHeight]=screenDimensions.height;browserDimensions=this._getBrowserDimensions();eventData[optKeys.browserWidth]=browserDimensions.width;eventData[optKeys.browserHeight]=browserDimensions.height;eventData[optKeys.cookiesEnabled]=this._getCookiesEnabled(options);eventData[optKeys.plugins]=this._getPlugins();this._recordEvent(eventData,options);},recordClick:function(options){var eventData={};options=this._mergeOptions(this.options.click.request,options);this._recordEvent(eventData,options);},recordFormAbandonment:function(options){var eventData={},optKeys;options=this._mergeOptions(this.options.formAbandonment.request,options);optKeys=options.keys;eventData[optKeys.lastFormFocused]=this._getLastFormFocusedValue();eventData[optKeys.lastInputFocused]=this._getLastInputFocusedValue();this._recordEvent(eventData,options);},trackClicks:function(options){var elements,element,i,recordClick,self=this;options=this._mergeOptions(this.options.click,options);options=this._mergeOptions({request:this.options.request},options);elements=this._getElements(options.elements);recordClick=function(ev){var target=ev.currentTarget||ev.srcElement,clickOptions,timeout;if(typeof options.onClick==='function'){clickOptions=options.onClick(ev);}
if(clickOptions!==false){if(typeof clickOptions==='object'){options.request=self._mergeOptions(options.request,clickOptions);}
options.request.data[options.request.keys.linkUrl]=target.getAttribute('href')||'';self.recordClick(options.request);}};for(i=0;i<elements.length;i++){element=elements[i];this.utils.addListener(element,'click',recordClick);}},trackFormAbandonment:function(options){var elements=[],self=this,i,elementsLength;options=this._mergeOptions(this.options.formAbandonment,options);options=this._mergeOptions({request:this.options.request},options);elements=this._getElements(options.elements);elementsLength=elements.length;for(i=0;i<elementsLength;i++){var element=elements[i],forms=(element.tagName.toLowerCase()==='form')?[element]:this.utils.getElements('form',element),formsLength=forms.length,j;for(j=0;j<formsLength;j++){var form=forms[j],inputs,inputsLength,input,k;inputs=this.utils.getElements('input',form);inputsLength=inputs.length;for(k=0;k<inputsLength;k++){input=inputs[k];(function(form,input){self.utils.addListener(input,'focus',function(ev){self._lastFormFocused=form;self._lastInputFocused=input;if(!self._trackingFormAbandonment){self._trackingFormAbandonment=true;self.utils.addListener(window,'beforeunload',function(ev){if(self._lastFormFocused!==null&&self._lastInputFocused!==null){self.recordFormAbandonment(options.request);}});self.utils.addListener(form,'submit',function(ev){self._lastFormFocused=null;self._lastInputFocused=null;});}});})(form,input);}}}},record:function(options){options=this._mergeOptions(this.options.request,options);this._request(options);}};PAYPAL.analytics.Analytics.prototype.utils={clone:function(obj){if(obj===null||obj.constructor!==Object){return obj;}
var clone=obj.constructor(),key;for(key in obj){clone[key]=this.clone(obj[key]);}
return clone;},merge:function(obj1,obj2){obj1=obj1||{};obj2=obj2||{};var clone1=this.clone(obj1),clone2=this.clone(obj2),p;for(p in clone2){try{if(clone2[p].constructor===Object){clone1[p]=this.merge(clone1[p],clone2[p]);}else{clone1[p]=clone2[p];}}catch(e){clone1[p]=clone2[p];}}
return clone1;},queryStringToObject:function(string){var obj={},i,parts,pairs=string.split('&');for(i=0;i<pairs.length;i++){parts=pairs[i].split('=');obj[parts[0]]=decodeURIComponent(parts[1]);}
return obj;},getElements:function(selector,parent){var elements=[],i=0,length,obj,style,nodes,node;parent=parent||document;if(parent.querySelectorAll){obj=parent.querySelectorAll(selector);if((typeof obj==='object'||typeof obj==='function')&&typeof obj.length==='number'){for(i=0;i<obj.length;i++){elements.push(obj[i]);}}else if(typeof obj==='array'){elements=obj;}}else if(document.createStyleSheet){if(document.styleSheets.length){style=document.styleSheets[0];}else{style=document.createStyleSheet();}
var selectors=selector.split(/\s*,\s*/),indexes=[],index;for(i=0;i<selectors.length;i++){index=style.rules.length;indexes.push(index);style.addRule(selectors[i],'aybabtu:pa',index);}
if(parent===document){nodes=parent.all;}else{nodes=parent.childNodes;}
for(i=0,length=nodes.length;i<length;i++){node=nodes[i];if(node.nodeType===1&&node.currentStyle.aybabtu==='pa'){elements.push(node);}}
for(i=indexes.length-1;i>=0;i--){style.removeRule(indexes[i]);}}
return elements;},addListener:function(element,event,callback){if(element.addEventListener){element.addEventListener(event,callback,false);}else if(element.attachEvent){return element.attachEvent('on'+event,callback);}},removeListener:function(event,element,callback){if(element.removeEventListener){element.removeEventListener(event,callback,false);}else if(element.detachEvent){return element.detachEvent('on'+event,callback);}},setCookie:function(key,value,options){var date,expires;options=options||{};if(options.expires){date=new Date();date.setTime(date.getTime()+(options.expires*24*60*60*1000));expires='; expires='+date.toGMTString();}else{expires='';}
document.cookie=key+"="+value+expires+'; path=/';},getCookie:function(key){var segments=document.cookie.split(';'),i;for(i=0;i<segments.length;i++){var segment=segments[i];while(segment.charAt(0)===' '){segment=segment.substring(1,segment.length);}
if(segment.indexOf(key+'=')===0){return segment.substring((key+'=').length,segment.length);}}
return null;},removeCookie:function(key){this.setCookie(key,'',{expires:-1});}};PAYPAL.analytics.setup=function(options){setTimeout(function(){PAYPAL.analytics.setup.init(options);},500);};PAYPAL.analytics.setup.init=function(options){options=options||{};var unloadDelay=500;var analytics=new PAYPAL.analytics.Analytics({request:{data:options.data||{},keys:{version:'v',timestamp:'t',gmtOffset:'g',eventType:'e'},values:{eventType:'na','true':1,'false':0},keyPrefix:'',url:options.url||'//t.paypal.com/ts',onBeaconCreate:function(){},onBeaconDestroy:function(){}}});var impressionOptions={keys:{cookiesEnabled:'ce',plugins:'pl',jsVersion:'jsv',pageTitle:'pt',referrer:'ru',screenColorDepth:'cd',screenWidth:'sw',screenHeight:'sh',browserWidth:'bw',browserHeight:'bh'},values:{eventType:'im'}};var pglk=analytics.utils.getCookie('tcs');analytics.utils.removeCookie('tcs');if(pglk){pglk=unescape(pglk);impressionOptions.data={pglk:pglk};}
var getFirstText=function(element){var nodes=element.childNodes,i,node;for(i=0;i<nodes.length;i++){node=nodes[i];if(node.nodeType===3&&node.nodeValue&&node.nodeValue.match(/\S/)){return node.nodeValue;}else if(node.nodeType===1&&node.childNodes.length){return getFirstText(node);}}};var getTargetAttr=function(target,primaryAttrName){var attr;if(primaryAttrName){attr=target.getAttribute(primaryAttrName);}
if(!attr){attr=target.getAttribute('name')||target.getAttribute('id')||getFirstText(target)||target.getAttribute('href');}
return attr;};analytics.recordImpression(impressionOptions);analytics.trackClicks({elements:'*[data-pa-click]',onClick:function(ev){var target=ev.currentTarget||ev.srcElement,link=getTargetAttr(target,'data-pa-click');return{data:{link:link}};},request:{unloadDelay:unloadDelay,keys:{linkUrl:'lu'},values:{eventType:'cl'}}});analytics.trackClicks({elements:'*[data-pa-exit]',onClick:function(ev){var target=ev.currentTarget||ev.srcElement,link=getTargetAttr(target,'data-pa-exit');return{data:{link:link,exit:analytics.options.request.values['true']}};},request:{unloadDelay:unloadDelay,keys:{linkUrl:'lu'},values:{eventType:'cl'}}});analytics.trackClicks({elements:'*[data-pa-download], *[href*=".zip"], *[href*=".wav"], *[href*=".mov"], *[href*=".mpg"], *[href*=".avi"], *[href*=".wmv"], *[href*=".doc"], *[href*=".docx"], *[href*=".pdf"], *[href*=".xls"], *[href*=".xlsx"], *[href*=".ppt"], *[href*=".pptx"], *[href*=".txt"], *[href*=".csv"], *[href*=".psd"], *[href*=".tar"]',onClick:function(ev){var target=ev.currentTarget||ev.srcElement,link=getTargetAttr(target,'data-pa-download');return{data:{link:link,dwnl:analytics.options.request.values['true']}};},request:{unloadDelay:unloadDelay,keys:{linkUrl:'lu'},values:{eventType:'cl'}}});analytics.trackClicks({elements:'*[class*="scTrack"]',onClick:function(ev){var target=ev.currentTarget||ev.srcElement,link=getTargetAttr(target);var classes=target.className.split(' '),i;for(i=0;i<classes.length;i++){var parts=classes[i].split(':');if(parts[0]==='scTrack'&&parts.length>1){parts.shift();link=parts.join(':');}}
return{data:{link:link}};},request:{unloadDelay:unloadDelay,keys:{linkUrl:'lu'},values:{eventType:'cl'}}});analytics.trackClicks({elements:'*[class*="scExit"]',onClick:function(ev){var target=ev.currentTarget||ev.srcElement,link=getTargetAttr(target);var classes=target.className.split(' '),i;for(i=0;i<classes.length;i++){var parts=classes[i].split(':');if(parts[0]==='scExit'&&parts.length>1){parts.shift();link=parts.join(':');}}
return{data:{link:link,exit:analytics.options.request.values['true']}};},request:{unloadDelay:unloadDelay,keys:{linkUrl:'lu'},values:{eventType:'cl'}}});analytics.trackClicks({elements:'a, button, input[type=submit], input[type=button], input[type=image]',onClick:function(ev){var target=ev.currentTarget||ev.srcElement,link=target.getAttribute('data-pa-click')||target.getAttribute('data-pa-exit')||target.getAttribute('data-pa-download');var pgrp=analytics.getRequestData('pgrp')||'';if(!link){var classes=target.className.split(' '),i;for(i=0;i<classes.length;i++){var parts=classes[i].split(':');if((parts[0]==='scTrack'||parts[0]==='scExit')&&parts.length>1){parts.shift();link=parts.join(':');}}}
if(!link){link=getTargetAttr(target);}
var pglk=escape(pgrp+'|'+link);analytics.utils.setCookie('tcs',pglk);return false;}});analytics.trackFormAbandonment({elements:'form',request:{unloadDelay:unloadDelay,keys:{lastFormFocused:'lf',lastInputFocused:'li'},values:{eventType:'fa'}}});return analytics;};}());