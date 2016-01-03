var popUp; 

function OpenCalendar(ctrlName, idSpan, idHiddenField, postBack)
{
	popUp = window.open('/woa/App/popup/Calendar.aspx?formname=' + //document.forms[0].name + 
		'&ctrlName=' + ctrlName +
		'&idSpan=' + idSpan + 
		'&idHiddenField=' + idHiddenField + 
		'&selected=' + // document.forms[0].elements[idname].value + 
		'&postBack=' + postBack, 
		'popupcal', 
		'width=165,height=208,left=200,top=250'); //,scrollbars=yes,resizable=yes
}

function SetDate(formName, ctrlName, idSpan, idHiddenField, newDate, postBack)
{
	//eval('var theform = document.' + formName + ';');
	popUp.close();
	//theform.elements[id].value = newDate;
	//alert( ctrlName+'\n'+idSpan+'\n'+idHiddenField );
	
	lblElem = (ctrlName.length>0)? ctrlName+'_'+idSpan : idSpan;
	hfElem = (ctrlName.length>0)? ctrlName+'_'+idHiddenField : idHiddenField;
	
	lbl = document.getElementById(lblElem).innerHTML.split(' ');
	
	//document.getElementById(ctrlName+'_'+idSpan).innerHTML = lbl[0] + ' ' + newDate;
	if(lbl[0].indexOf('/')>-1)
		document.getElementById(lblElem).innerHTML = newDate;
	else
		document.getElementById(lblElem).innerHTML = lbl[0] + ' ' + newDate;
		
	alert(document.getElementById(lblElem).innerHTML);		
		
	document.getElementById(hfElem).value = newDate;

	if (postBack)
		__doPostBack(id,'');
}		
