
PAYPAL.widget.PasswordMeter={capsLockEnabled:null,result:'',tmp_result:'',blacklist:false,isAjax:true,keyC:67,keyV:86,keyX:88,isCtrlkey:null,keyflag:null,myKeyCode:0,CTRLKEY:17,rightClickKey:93,weak:false,isRetypefld:0,matchFlag:'',timeOut:null,txt_pwd_msg:'',meterMessages:{'txt_msg_weak':'txtWeak','msg_strong':'Strong','msg_fair':'Fair','msg_weak':'Weak','msg_txtStrong':'txt_StrongTip','msg_txtWeak':'txt_WeakTip','msg_txtFair':'txt_FairTip','errorMsg':'redAlertmsg','MaxLmtErrmsg':'maxLimitErr','pwdErrmsg':'pwdErr','capsLockErrmsg':'capsLockErr','copyErrmsg':'copyErr','defaultMsg':'pwdTips'},config:{email:YUD.get('email'),passwd:YUD.get('password'),retype:YUD.get('retype_password'),meter_tag:YUD.get('meter_tag'),minChars:YUD.get('minChars'),notEmail:YUD.get('notEmail'),noGuess:YUD.get('noGuess'),hardGuess:YUD.get('hardGuess'),mixAll:YUD.get('mixAll'),pwdH:YUD.get('pwdH'),cont:YUD.get('metercontainer'),pwdres2:YUD.get('pwdres2'),pwdres:YUD.get('pwdres'),submitBtn:YUD.get('submitBtn'),blacklist_pwds:new Array(),disableSubmit:false,mtrUpward:YUD.get('txtMeter'),balloonImg:YUD.get('meterknob'),countryCodePsc:YUD.get('intlCountryCode'),languageCodePsc:YUD.get('languageCode'),countryCode:'en_US',min_len:8,max_len:20},init:function(fields){var self=this;var key_press_down;var agt=navigator.userAgent.toLowerCase();if(agt.indexOf("opera")!=-1){key_press_down='keypress';}
else{key_press_down='keydown';}
if(typeof fields!='undefined'){this.config.passwd=YUD.get(fields.passwdFld);if(fields.emailFld){this.config.email=YUD.get(fields.emailFld);}
if(fields.submitBtn){this.config.submitBtn=YUD.get(fields.submitBtn);}
if(fields.retypeFld){this.config.retype=YUD.get(fields.retypeFld);}
if(fields.countryCode){this.config.countryCode=fields.countryCode;}
if(fields.deKey){this.config.deKey=fields.deKey;}
if(fields.keySeq){this.config.keySeq=fields.keySeq;}
this.config.meter_tag.setAttribute('role',"tooltip");this.config.meter_tag.setAttribute('aria-live',"assertive");this.config.passwd.setAttribute('aria-describedby',"meter_tag");this.config.passwd.setAttribute('aria-required',"true");this.config.retype.setAttribute('aria-describedby',"meter_tag");this.config.retype.setAttribute('aria-required',"true");}
this.config.disableSubmit=fields.disableSubmit;YUE.addListener(this.config.passwd,'focus',function(e){self.verifyPass(e);});YUE.addListener(this.config.retype,'focus',function(e){self.test_retypeFld(e);});YUE.addListener([this.config.passwd],'blur',function(e){self.hidemeter(e);});YUE.addListener([this.config.passwd,this.config.retype],'mousedown',function(e){self.rightclickpaste(e);});YUE.addListener(this.config.passwd,'keyup',function(e){self.verifyPass(e);self.test_capsonres(e);self.noctrlcopyres(e);});YUE.addListener(this.config.email,'paste',function(e){if(self.config.passwd.value.length>=self.config.min_len){setTimeout(function(){self.verifyPass(e);},100);}});YUE.addListener([this.config.passwd,this.config.retype],'keypress',function(e){self.test_capson(e);});YUE.addListener([this.config.passwd,this.config.retype],key_press_down,function(e){self.noctrlcopy(e);});YUE.addListener([this.config.passwd,this.config.retype],'keydown',function(e){self.noctrlselect(e);});YUE.addListener([this.config.passwd,this.config.retype],'drop',function(e){if(!self.config.mtrUpward){self.showResult(e);}
self.nodragdroppaste(e);});YUE.addListener([this.config.passwd,this.config.retype],'dragover',function(e){if(!self.config.mtrUpward){self.showResult(e);}
self.nodragdroppaste(e);});YUE.addListener([this.config.passwd,this.config.retype],'paste',function(e){self.showResult(e);self.nodragdroppaste(e);});var myInputArray=document.forms[fields.formName].getElementsByTagName("INPUT");for(var i=0,j=myInputArray.length;i<j;i++){var elem=myInputArray[i];if((elem.type=='text')||(elem.type=='password')||(elem.type=='submit')||(elem.type=='button')||(elem.type=='checkbox')||(elem.type=='radio')){if(this.config.passwd!=elem){YUE.addListener(elem,'keyup',function(e){self.doerror(e)});YUE.addListener(elem,'focus',function(e){self.doerror(e)});YUE.addListener(elem,'blur',function(e){self.hidemeter(e)});}}}
var elemList="A,SELECT,SPAN,BUTTON";var fieldList=elemList.split(',');var myForm=document.forms[fields.formName];for(var i=0,j=fieldList.length;i<j;i++){var fieldListGrp=myForm.getElementsByTagName(fieldList[i]);for(var a=0,b=fieldListGrp.length;a<b;a++){var elemfields=fieldListGrp[a];if(fieldList[i]=='SPAN'&&(elemfields.className=='balloonControl'||elemfields.className=='autoTooltip')){YUE.addListener(elemfields,'focus',function(e){self.doerror(e)});}
else if(fieldList[i]!='SPAN'){YUE.addListener(elemfields,'focus',function(e){self.doerror(e)});}}}
this.add_hiddenvar(fields);},checkPass:function(e)
{this.len=false;this.email=false;this.repeat=false;this.order=false;this.letterupper=false;this.letterlower=false;this.numbers=false;this.specials=false;this.order=false;this.strength=0;var strPasswd=YAHOO.lang.trim(this.config.passwd.value);if(strPasswd.length>0){this.len=this.test_len(strPasswd);var email=this.config.email;if(email&&email.value){this.email=this.test_email(strPasswd,email.value);}
this.repeat=this.test_repeatchar(strPasswd);this.order=this.test_order(strPasswd);this.letterlower=this.test_lower(strPasswd);this.letterupper=this.test_upper(strPasswd);this.numbers=this.test_numbers(strPasswd);this.specials=this.test_special(strPasswd);if(this.letterlower&&this.letterupper){this.strength++;if(this.numbers){this.strength++;}
if(this.specials){this.strength++;}}
else{if(this.letterlower){this.strength++;}
if(this.letterupper){this.strength++;}}
if(this.numbers){this.strength++;}
if(this.specials){this.strength++;}
this.getResult(e);}},test_retypeFld:function(e){var tar=YUE.getTarget(e);if(tar==this.config.retype){this.isRetypefld=1;}
if(tar==this.config.passwd){this.isRetypefld=0;}},verifyPass:function(e){this.test_retypeFld(e);if(YAHOO.lang.trim(this.config.passwd.value).length>0){this.checkPass(e);this.showResult(this.result);this.matchpassword(this.config.passwd.value,this.config.retype.value);}
else{this.showResult('lame');}},getResult:function(e){var result='lame';if(this.weak){var result='weak';}
this.weak=(this.email||this.repeat||this.order);if(this.len){result='lame';this.result=result;}
else if(this.weak||this.strength<2){result='weak';this.result=result;}
else if((!this.weak&&this.strength<3)||(!this.weak&&this.strength>2)){var tar=YUE.getTarget(e);if(tar==this.config.email){var e_emailFld='email';}
var strPasswd=YAHOO.lang.trim(this.config.passwd.value);if((strPasswd.length>=8)&&(this.config.passwd.type=='password')){if(tar==this.config.passwd&&!e.shiftKey&&this.myKeyCode!=this.rightClickKey&&this.keyflag==0){this.test_blacklist(strPasswd,e_emailFld);}}}},blacklist_result:function(ajaxval,e_emailFld){var result="lame";if(this.weak){var result='weak';}
if(YAHOO.lang.trim(ajaxval)=="true"){result='weak';}
else if(!this.weak&&this.strength<3){result='fair';}
else if(!this.weak&&this.strength>2){result='strong';}
this.result=result;this.tmp_result=this.result;this.isAjax=false;if(this.config.passwd.value==''){this.result='lame';}
if(e_emailFld=='email'&&this.email==true){this.showResult(this.result);}
else if(e_emailFld=='email'&&this.email==false){this.hidemeter();}
else{this.showResult(this.result);}},showResult:function(result){if(this.config.mtrUpward){YUD.addClass(this.config.balloonImg,"upwards");this.config.balloonImg.setAttribute("src","/en_US/i/icon/upknob.png");inlinehelp=document.createElement("SPAN");inlinehelp.setAttribute("id","pscHelpTxt");YUD.addClass(inlinehelp,"pscTooltip");helplink=document.createElement("a");helplink.onmouseover=function(e){PAYPAL.widget.PasswordMeter.showmeter();}
helplink.onmouseout=function(e){PAYPAL.widget.PasswordMeter.hidemeter();}
if(YUD.get('password').value==''){PAYPAL.widget.PasswordMeter.hidemeter();}
helplink.setAttribute("href","#");helplink.setAttribute("id","pwd_link");this.password_tips(this.result);}
var pwd_msg=Weak,boxes=0,defaultMsg=pwdTips;var pwdH=this.config.pwdH;var cont=this.config.cont;var passwd=this.config.passwd;var minChars=this.config.minChars;var notEmail=this.config.notEmail;var noGuess=this.config.noGuess;var mixAll=this.config.mixAll;var hardGuess=this.config.hardGuess;if(pwdH.innerHTML!=defaultMsg){pwdH.innerHTML=defaultMsg;}
if(YUD.hasClass(pwdH,'red')){YUD.replaceClass(pwdH,'red','gray');}
switch(result){case'strong':if(this.config.mtrUpward){this.removeclass(this.config.passwd,"pswd_bg");this.removeclass(this.config.retype,"pswd_bg");YUD.get('pwdres2').className='helpstrong show';this.txt_pwd_msg=Strong;}
if(YUD.get('fstatusChk')){if(YUD.get('fstatusChk').checked==true){this.toggleSubmit(false);}}
else{this.toggleSubmit(false);}
pwd_msg=Strong;boxes=3;YUD.batch([minChars,notEmail,noGuess,mixAll],function(el){if(el){el.className='lichkmark';}},YUD,true);if(hardGuess){hardGuess.className='lichkmark';}
break;case'fair':if(this.config.mtrUpward){this.removeclass(this.config.passwd,"pswd_bg");this.removeclass(this.config.retype,"pswd_bg");YUD.get('pwdres2').className='helpfair show';this.txt_pwd_msg=Fair;}
if(YUD.get('fstatusChk')){if(YUD.get('fstatusChk').checked==true){this.toggleSubmit(false);}}
else{this.toggleSubmit(false);}
pwd_msg=Fair;mixAll.className='liimglame';YUD.batch([minChars,notEmail,noGuess],function(el){if(el){el.className='lichkmark';}},YUD,true);if(hardGuess){hardGuess.className='lichkmark';}
boxes=2;break;case'weak':if(this.config.mtrUpward){YUD.addClass(this.config.passwd,"pswd_bg");this.txt_pwd_msg=txtWeak;YUD.get('pwdres2').className='helpweak show';}
if(this.config.disableSubmit){if(YUD.get('fstatusChk')){if(YUD.get('fstatusChk').checked==true){this.toggleSubmit(true);}}
else{this.toggleSubmit(true);}}
boxes=1;if(!this.len){minChars.className='lichkmark';}
if(!this.len&&this.config.mtrUpward&&this.config.passwd.value.length<8){minChars.className='liimglame';}
if(notEmail){if(!this.email){notEmail.className='lichkmark';}
else{notEmail.className='liimglame';}
if(!this.len&&this.config.mtrUpward&&this.config.passwd.value.length<8){notEmail.className='liimglame';}}
YUD.batch([noGuess,mixAll],function(el){if(el){el.className='liimglame';}},YUD,true);if(hardGuess){hardGuess.className='liimglame';}
break;case'lame':if(this.config.mtrUpward){this.removeclass(this.config.passwd,"pswd_bg");this.removeclass(this.config.retype,"pswd_bg");YUD.get('pwdres2').className='help';}
if(YUD.get('fstatusChk')){if(YUD.get('fstatusChk').checked==true){this.toggleSubmit(false);}}
else{this.toggleSubmit(false);}
boxes=3;YUD.batch([minChars,notEmail,noGuess,mixAll],function(el){if(el){el.className='liimglame';}},YUD,true);if(hardGuess){hardGuess.className='liimglame';}
this.replceclass(pwdH,"hide","show");this.replceclass(cont,"show","hide");if(this.config.mtrUpward){YUD.get('pwdres2').className='hide';}
break;}
if(this.config.mtrUpward){this.config.pwdres.innerHTML=pwd_msg;YUD.get('pwdres2').innerHTML=this.txt_pwd_msg;if(YUD.get('pscHelpTxtOnload')&&this.config.passwd.value.length>=8){YUD.get('pscHelpTxtOnload').className="pscOnloadhelp hide";}
if(YUD.get('pscHelpTxtOnload')&&this.config.passwd.value.length<8){YUD.get('pscHelpTxtOnload').className="pscOnloadhelp";YUD.get('pwdres2').className="hide";}
if(!YUD.get('pscHelpTxt')){YUD.get('pwdres2').appendChild(inlinehelp);}}
else{this.config.pwdres.innerHTML=pwd_msg;}
bgclass='meter '+'bg'+result;for(i=1;i<4;i++){var meterDiv=YUD.get('meter'+i);if(meterDiv){if(i>boxes){bgclass='meter bglame';}
meterDiv.className=bgclass;}}
if(result!='lame')
{this.replceclass(pwdH,"show","hide");this.replceclass(cont,"hide","show");if(this.config.mtrUpward&&YUD.hasClass(YUD.get('pscHelpTxtOnload'),'hide')){this.replceclass(this.config.pwdres2,"hide","show");}}
if(result=='weak'&&this.config.mtrUpward&&this.config.passwd.value.length<8){this.replceclass(pwdH,"hide","show");this.replceclass(cont,"show","hide");}
if(!this.config.mtrUpward){this.showmeter();}
this.maxlimit();},hidemeter:function(){var meter_tag=this.config.meter_tag;this.replceclass(meter_tag,"show","hide");YUD.replaceClass('meterknob','show','hide');},showmeter:function(){var meter_tag=this.config.meter_tag;this.replceclass(meter_tag,"hide","show");YUD.replaceClass('meterknob','hide','show');var reg=YUD.getRegion(this.config.passwd);var countryCode=this.config.countryCodePsc.value;if(this.config.mtrUpward){if(this.config.mtrUpward.value=="miniBrowser"){if(countryCode=='C2'||countryCode=='TW'||countryCode=='IN'){YUD.setXY(this.config.meter_tag,[(reg.left+5),(reg.top-116)],true);}else{YUD.setXY(this.config.meter_tag,[(reg.left+5),(reg.top-190)],true);}}
else{if(this.config.countryCodePsc.value=='BR'||this.config.languageCodePsc.value=='pt_BR'){YUD.setXY(this.config.meter_tag,[(reg.left+5),(reg.top-235)],true);}
else if(this.config.countryCodePsc.value=='ID'||this.config.languageCodePsc.value=='id_ID'){YUD.setXY(this.config.meter_tag,[(reg.left+5),(reg.top-220)],true);}
else if(this.config.countryCodePsc.value=='IL'&&this.config.languageCodePsc.value=='he_IL'){if(YUD.get('stdpage')){YUD.setXY(meter_tag,[(reg.left-130),(reg.top-228)],true);}
else{YUD.setXY(meter_tag,[(reg.left-135),(reg.top-228)],true);}}
else{YUD.setXY(this.config.meter_tag,[(reg.left+5),(reg.top-225)],true);}}}
else if(YUD.hasClass(YUD.get('meterknob'),'downwards')){YUD.setXY(meter_tag,[(reg.left),(reg.top+35)],true);}
else{if(this.config.countryCodePsc.value=='IL'&&this.config.languageCodePsc.value=='he_IL'){YUD.setXY(meter_tag,[(reg.left-305),(reg.top-15)],true);}
else{YUD.setXY(meter_tag,[(reg.right+20),(reg.top-15)],true);}}},doerror:function(e){var tar=YUE.getTarget(e);if(this.config.passwd.value==''){this.tmp_result='';this.isAjax=true;}
if(this.isAjax){this.result='';}
var passwd=YAHOO.lang.trim(this.config.passwd);var retype=YAHOO.lang.trim(this.config.retype);if(tar==this.config.email){if(this.isAjax==false&&this.result!='weak'&&passwd.value!=''&&this.config.email.value!=''){this.result='';if(this.tmp_result=='weak'){this.result=this.tmp_result;}}
if(tar==this.config.email&&this.isAjax==false&&this.result=='weak'&&passwd.value!=''&&this.config.email.value!=''){this.result='';if(this.tmp_result=='weak'){this.result=this.tmp_result;}}}
if(this.isAjax==false&&this.result=='weak'&&passwd.value==''){this.result='';}
if(this.result==''){this.result=this.tmp_result;this.checkPass(e);if(this.result!=''){this.showResult(this.result);}}
else{this.checkPass(e);this.showResult(this.result);}
if(this.result=='lame'||this.result=='weak'){this.test_capsonres(e);this.showerrmsg(redAlertmsg);if((passwd.value.length>=this.config.max_len)&&(retype.value.length>=this.config.max_len)&&(tar==passwd||tar==retype)){this.showerrmsg(maxLimitErr);}
this.noctrlcopyres(e);if(!this.config.mtrUpward){this.showmeter();}
else{YUD.addClass(passwd,"pswd_bg");var tar=YUE.getTarget(e);if(tar.id==this.config.retype.id){this.verifyPass(e);if(retype.value.length<this.config.max_len){this.showerrmsg(redAlertmsg);}
this.noctrlcopyres(e);}}
if(this.config.disableSubmit==true){if(YUD.get('fstatusChk')){if(YUD.get('fstatusChk').checked==true){this.toggleSubmit(true);}}
else{this.toggleSubmit(true);}}}
else
{var tar=YUE.getTarget(e);var tmp=0;if(tar.id==this.config.retype.id){this.verifyPass(e);this.test_capsonres(e);this.noctrlcopyres(e);if((passwd.value.length>=this.config.max_len)&&(retype.value=='')&&(this.result=='fair'||this.result=='strong')&&this.myKeyCode!=this.rightClickKey&&this.keyflag==0){this.replceclass(this.config.pwdH,"show","hide");this.replceclass(this.config.cont,"hide","show");}}
else{this.test_capsonres(e);if(((passwd.value.length!=retype.value.length)||((passwd.value.length==retype.value.length)&&(passwd.value!=retype.value)))&&(((passwd.value)&&(retype.value))!='')){tmp=1;if(YUD.get('fstatusChk')){if(YUD.get('fstatusChk').checked==true){this.toggleSubmit(true);}}
else{this.toggleSubmit(true);}
this.showerrmsg(pwdErr);if(!this.config.mtrUpward){this.showmeter();}
if(this.config.mtrUpward){YUD.addClass(this.config.passwd,"pswd_bg");YUD.addClass(this.config.retype,"pswd_bg");}}
else if(passwd.value==retype.value){this.hidemeter();}
else{this.hidemeter();}}
if(tmp!=1){if(YUD.get('fstatusChk')){if(YUD.get('fstatusChk').checked==true){this.toggleSubmit(false);}}
else{this.toggleSubmit(false);}}}
if(((passwd.value)&&(retype.value))!=''){if((passwd.value)!=(retype.value)){this.matchpassword(passwd.value,retype.value);this.noctrlcopyres(e);}}},toggleSubmit:function(flag){this.config.submitBtn.disabled=flag;},rightclickpaste:function(e){this.test_retypeFld(e);var RIGHTCLICK=2;if(e.button==RIGHTCLICK){this.showerrmsg(copyErr);var strPwd=YAHOO.lang.trim(this.config.passwd.value);var strrePwd=YAHOO.lang.trim(this.config.retype.value);PAYPAL.widget.PasswordMeter.timeOut=setTimeout(function(){PAYPAL.widget.PasswordMeter.replace_warningmsg(strPwd,strrePwd);},4000);}
this.config.passwd.oncontextmenu=function(){return false;}
this.config.retype.oncontextmenu=function(){return false;}},noctrlcopy:function(e){this.myKeyCode=YUE.getCharCode(e);if(e.ctrlKey==true&&(this.myKeyCode==this.keyC||this.myKeyCode==this.keyV||this.myKeyCode==this.keyX)){YUE.preventDefault(e);}},noctrlselect:function(e){this.myKeyCode=YUE.getCharCode(e);if(e.keyCode==this.CTRLKEY){this.isCtrlkey=true;}
if((this.myKeyCode==this.keyC||this.myKeyCode==this.keyV||this.myKeyCode==this.keyX)&&this.isCtrlkey){this.keyflag=1;}
else{this.keyflag=0;}},noctrlcopyres:function(e){this.myKeyCode=YUE.getCharCode(e);if(e.keyCode==this.CTRLKEY){this.isCtrlkey=false;}
if(this.myKeyCode==this.rightClickKey||this.keyflag==1){this.showerrmsg(copyErr);}},nodragdroppaste:function(e){this.showerrmsg(copyErr);YUE.preventDefault(e);},maxlimit:function(){var strPwd=YAHOO.lang.trim(this.config.passwd.value);var strrePwd=YAHOO.lang.trim(this.config.retype.value);this.matchpassword(strPwd,strrePwd);clearTimeout(PAYPAL.widget.PasswordMeter.timeOut);if((strPwd.length>=this.config.max_len)&&(((strrePwd=='')&&this.isRetypefld==0)||((strrePwd.length<=this.config.max_len)&&this.isRetypefld==0)||((strrePwd.length>=this.config.max_len)&&this.matchFlag==0&&this.myKeyCode!=this.rightClickKey&&this.keyflag==0))){this.showerrmsg(maxLimitErr);PAYPAL.widget.PasswordMeter.timeOut=setTimeout(function(){PAYPAL.widget.PasswordMeter.replace_warningmsg(strPwd,strrePwd);},4000);}
else if((strPwd=='')&&(strrePwd.length>=this.config.max_len)&&(this.isRetypefld==1)){this.showerrmsg(maxLimitErr);PAYPAL.widget.PasswordMeter.timeOut=setTimeout(function(){PAYPAL.widget.PasswordMeter.replace_passwordhelp(strPwd,strrePwd);},4000);}},replace_warningmsg:function(strPwd,strrePwd){this.replceclass(this.config.pwdH,"show","hide");this.replceclass(this.config.cont,"hide","show");if(this.result=='weak'&&(strrePwd.length>=this.config.max_len)&&this.isRetypefld==1){this.showerrmsg(redAlertmsg);}},replace_passwordhelp:function(strPwd,strrePwd){this.showerrmsg(pwdTips);if(YUD.hasClass(this.config.pwdH,'red')){YUD.replaceClass(this.config.pwdH,'red','gray');}},matchpassword:function(strPwd,strrePwd){if((strPwd&&strrePwd)!=''){if(strPwd!=strrePwd){var a=strPwd.split("");var b=strrePwd.split("");var blen=b.length;for(var i=0;i<blen;i++){this.matchFlag=0;if(a[i]!=b[i]){this.matchFlag=1;if(YUD.get('fstatusChk')){if(YUD.get('fstatusChk').checked==true){this.toggleSubmit(true);}}
else{this.toggleSubmit(true);}
this.showerrmsg(pwdErr);}
if(this.matchFlag==1&&strrePwd!=''){var k=1;}}
if(k==1){if(this.config.mtrUpward){YUD.addClass(this.config.passwd,"pswd_bg");YUD.addClass(this.config.retype,"pswd_bg");}}}
else{if(this.result=='lame'&&this.config.passwd.value.length<=this.config.min_len){if(YUD.get('fstatusChk')){if(YUD.get('fstatusChk').checked==true){this.toggleSubmit(true);}}
else{this.toggleSubmit(true);}}
if(this.result!='weak'){this.removeclass(this.config.passwd,"pswd_bg");this.removeclass(this.config.retype,"pswd_bg");}
else if(this.result=='weak'&&strPwd==strrePwd){this.removeclass(this.config.retype,"pswd_bg");}}}
else if(strrePwd==''){this.removeclass(this.config.retype,"pswd_bg");}},showerrmsg:function(currentErrMsg){var pwdH=this.config.pwdH;pwdH.innerHTML=currentErrMsg;this.replceclass(pwdH,"hide","show");this.replceclass(this.config.cont,"show","hide");this.replceclass(pwdH,"gray","red");},test_capson:function(e){var keycode=YUE.getCharCode(e);if((keycode>=65&&keycode<=90)&&!e.shiftKey){this.capsLockEnabled=true;}
this.test_retypeFld(e);},test_capsonres:function(e){var strPwd=YAHOO.lang.trim(this.config.passwd.value);var strrePwd=YAHOO.lang.trim(this.config.retype.value);var CAPSKEY=20;var tar=YUE.getTarget(e);if((e.keyCode==CAPSKEY)&&(this.capsLockEnabled!==null)){this.capsLockEnabled=!this.capsLockEnabled;}
if(this.capsLockEnabled==true){if(this.config.mtrUpward){if(strPwd.length<8&&strPwd!=''){this.showerrmsg(capsLockErr);}
else if(strrePwd.length<8&&strrePwd!=''){this.showerrmsg(capsLockErr);}}
if(strPwd.length<this.config.min_len&&strPwd!=''){this.showerrmsg(capsLockErr);}
if(strrePwd.length<this.config.min_len&&strrePwd!=''&&tar.id==this.config.retype.id){this.showerrmsg(capsLockErr);}
this.maxlimit();}},test_len:function(str){if(str.length<(this.config.min_len)){this.hidemeter();return true;}
else{this.maxlimit();return false;}},ajaxblacklistchk:function(data,request,exception){if(/^\s*<!DOCTYPE\b/.test(request.responseText)){this.blacklist=" false";}
else{var jsonResponse=eval("("+request.responseText+")");this.blacklist=jsonResponse.isBlacklist;}
this.blacklist_result(this.blacklist,this.argument_email);},test_blacklist:function(str,e_emailFld){var url="webscr?cmd=_forbidden-check&v=1";PAYPAL.util.Connect.send(url,{method:"post",callback:PAYPAL.widget.PasswordMeter.ajaxblacklistchk,scope:this,argument_email:e_emailFld,query:"search_str="+str});},test_email:function(str,email){if(email.indexOf('@')>-1){var arr=email.split('@');var username=arr[0].toLowerCase();if(username.length==0){return false;}
var domainname=arr[1];if((username.indexOf(str.toLowerCase())>-1)||(str.toLowerCase().indexOf(username)>-1)){return true;}}
return false;},test_upper:function(str){if(str.match(/[A-Z].*/)){return true;}
return false;},test_lower:function(str){if(str.match(/[a-z].*/)){return true;}
return false;},test_numbers:function(str){if(str.match(/\d+/)){return true;}
return false;},test_special:function(str){if(str.match(/[~,!,@,#,$,%,^,&,*,(,),+,=]/)){return true;}
return false;},test_repeatchar:function(str){str_chars='abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789~!@#\$%&*\(\)\+=\^';if(this.config.countryCodePsc.value=='DE'){str_chars=str_chars.concat(this.config.deKey);}
for(i=0,k=str_chars.length;i<k;i++){var char=str_chars.substr(i,1);cmd='/["'+char+'"]+/g';cmd=eval(cmd);var matches=str.match(cmd);if(matches){for(j=0,r=matches.length;j<r;j++){newstr=new String(matches[j]);if(newstr.length>3){return true;}}}}
return false;},test_order:function(str){str_chars='012345678909876543210';if(this.inSeq(str,str_chars))return true;if(this.config.countryCodePsc.value=='DE'){str_chars=this.config.deKey;if(this.inSeq(str,str_chars)){return true;}}
str_chars=this.config.keySeq;if(str_chars.indexOf('~')>-1){var arr=str_chars.split('~');var row1=arr[0],row2=arr[1],row3=arr[2];if((this.inSeq(str,row1))||(this.inSeq(str,row2))||(this.inSeq(str,row3))){return true;}
return false;}},inSeq:function(str,str_chars){for(i=0,j=str_chars.length;i<j;i++){var nc=str_chars.substr(i+1,3);if(nc.length==3){cmd='/'+str_chars.substr(i,1)+'(?='+nc+')/i';cmd=eval(cmd);if(str.match(cmd)){return true;}}}
return false;},password_tips:function(pwdstrength){if(pwdstrength=='weak'){helplink.appendChild(document.createTextNode(txt_WeakTip));}
else if(pwdstrength=='fair'){helplink.appendChild(document.createTextNode(txt_FairTip));}
else if(pwdstrength=='strong'){helplink.appendChild(document.createTextNode(txt_StrongTip));}
inlinehelp.appendChild(helplink);},add_hiddenvar:function(fields){var hiddenVar=document.createElement('input');hiddenVar.type="hidden";hiddenVar.name="js_enabled";hiddenVar.value="true";var tmp=document.forms[fields.formName].appendChild(hiddenVar);},addclass:function(whichId,adclass){if(YUD.hasClass(whichId,adclass)){YUD.addClass(whichId,adclass);}},removeclass:function(whichId,rmvclass){if(YUD.hasClass(whichId,rmvclass)){YUD.removeClass(whichId,rmvclass);}},replceclass:function(whichId,chkclass,applycls){if(YUD.hasClass(whichId,chkclass)){YUD.replaceClass(whichId,chkclass,applycls);}},inarray:function(str,arr){var inarr=false;for(i=arr.length-1;i>=0;i--){if(str.toLowerCase().indexOf(arr[i].toLowerCase())>-1){return true;}}
return inarr;},pwdTipsOnload:function(){if(YUD.get('txtMeter')){inlinehelp=document.createElement("SPAN");inlinehelp.setAttribute("id","pscHelpTxtOnload");YUD.addClass(inlinehelp,"pscOnloadhelp");helplink=document.createElement("a");helplink.setAttribute("href","#");helplink.setAttribute("id","pwd_link");helplink.onmouseover=function(e){PAYPAL.widget.PasswordMeter.showmeter();}
helplink.onmouseout=function(e){PAYPAL.widget.PasswordMeter.hidemeter();}
PAYPAL.widget.PasswordMeter.password_tips('fair');inlinehelp.appendChild(helplink);function insertAfter(referenceNode,newNode){referenceNode.parentNode.insertBefore(newNode,referenceNode.nextSibling);}}
YUE.onDOMReady(function(){setTimeout(function(){if(YUD.get('meterknob')&&YUD.get('txtMeter')){YUD.addClass(YUD.get('meterknob'),"upwards");YUD.get('meterknob').setAttribute("src","/en_US/i/icon/upknob.png");}
if(!YUD.get('pscHelpTxtOnload')){if(YUD.get('pwdres2')){insertAfter(YUD.get('pwdres2'),inlinehelp);}}
if(YUD.get('txtMeter')&&YUD.get('stdpage')){var cssId=YUD.get('languageCode').value+'_countryCss';if(!YUD.get(cssId))
{var head=document.getElementsByTagName('head')[0];var link=document.createElement('link');var csslink='css/'+YUD.get('languageCode').value+'/country.css';link.id=cssId;link.rel='stylesheet';link.type='text/css';link.href=csslink;head.appendChild(link);}}},1000);});}};YUE.onDOMReady(PAYPAL.widget.PasswordMeter.pwdTipsOnload);YUE.addListener("country_code",'change',PAYPAL.widget.PasswordMeter.pwdTipsOnload);YUE.addListener("lang_code",'change',PAYPAL.widget.PasswordMeter.pwdTipsOnload);