//-----------------------------------------------------------------------------------------------------
//FUNCTIONS
//-----------------------------------------------------------------------------------------------------

//SLIDE TOGGLE
var slideToggle = function () {
    $(this).attr('tabindex', 1).focus();
    $(this).toggleClass('active');
    $(this).find('.dropdown-menu').slideToggle(300);
    SubjectArray();
}

//FOCUS OUT
var focusOut = function () {
    $(this).removeClass('active');
    $(this).find('.dropdown-menu').slideUp(300);
}

//UNLOCK DROPDOWN
var unlockDropdown = function () {
    $(this).addEventListener('click', slideToggle);
    $(this).addEventListener('focutout', focusOut);
}

//ADD DYNAMIC LI
var addSubLi = function (subArray) {
    console.log(Array.isArray(subArray));
}

function test(myarray) {
    myarray.forEach(function (entry) {
        console.log(entry);
    });
}

//LI CLICK
var LiClick = function () {

    switch ($(this).parents('.dropdown').attr('id')) {
        case 'semdrop':
            var nextDropdown = $(this).parents('li#preferenceLi').children('div#perdrop');
            break;

        case 'perdrop':
            var nextDropdown = $(this).parents('li#preferenceLi').children('div#subdrop');
            break;

        case 'subdrop':
            var nextDropdown = $(this).parents('li#preferenceLi').children('div#assdrop');
            break;

        default:
            break;
    }

    if ($(nextDropdown).find('i.fa').length == 0) {
        $(nextDropdown).on('click', slideToggle);
        $(nextDropdown).on('focusout', focusOut);
        $(nextDropdown).children('div.select').append(getChevron());
    }

    $(this).parents('.dropdown').find('span').text($(this).text());
    $(this).parents('.dropdown').find('input').attr('value', $(this).attr('id'));


    //console.log($(this).children('ul').find('li'));
    //filterFunction(this, nextDropdown); <=
    //Fill dropdown 
    //console.log(nextDropdown);
    //$(nextDropdown).appendChild(getLi('test'));
}

//FILTERTEST
//var filterFunction = function(currentDropdown, nextDropdown){
//    var input, filter, ul, li, a, i;
//    input = document.
//    console.log(input);
//}



//CREATE Player
var CreatePlayer = function (id, name) {

    var ul = document.getElementById("ulpref");
    var children = ul.children.length + 1;
    var li = document.createElement("li");
    li.id = 'preferenceLi';
    var label = document.createElement("label");

    console.log(semarray + perarray + subarray + assarray);

    //PREFERENCE LABEL
    label.appendChild(document.createTextNode(children));
    label.className = 'preferenceId';
    li.appendChild(label);

    //APPEND ALL DROPDOWNS
    li.appendChild(appendDropdown(true, getSpan('Select Semester', 'semspan'), getChevron(), getSelectDiv(), getInput('Semester'), getUl(), getDropdownDiv(true, 'semdrop'), semarray));
    li.appendChild(appendDropdown(false, getSpan('Select Period', 'perspan'), getChevron(), getSelectDiv(), getInput('Period'), getUl(), getDropdownDiv(false, 'perdrop'), perarray));
    li.appendChild(appendDropdown(false, getSpan('Select Subject', 'subspan'), getChevron(), getSelectDiv(), getInput('Subject'), getUl(), getDropdownDiv(false, 'subdrop'), subarray));
    li.appendChild(appendDropdown(false, getSpan('Select Assignment', 'assspan'), getChevron(), getSelectDiv(), getInput('Assignment'), getUl(), getDropdownDiv(false, 'assdrop'), assarray));
    li.appendChild(getHours());
    li.appendChild(getDeleteButton());
    li.appendChild(document.createElement("hr"));
    ul.appendChild(li);

}

//CREATE LI temp
function getLi(name) {
    var li = document.createElement("li");
    li.id = name.substring(0, 2) + name[name.length - 1];
    li.innerHTML = name;
    li.addEventListener('click', LiClick);

    li.addEventListener('click', function () {
        var input = '<strong>' + $(this).parents('.dropdown').find('input').val() + '</strong>',
            msg = '<span class="msg">Hidden input value: ';
        $('.msg').html(msg + input + '</span>');
    });

    return li;
}

//CREATE RADIO BUTTONS
function getRadioButtons() {
    var span = document.createElement('span');
    span.id = 'radioButtons';
    span.appendChild(getRadioInput('pref1'));
    span.appendChild(getRadioLabel('1'));

    span.appendChild(getRadioInput('pref2'));
    span.appendChild(getRadioLabel('2'));

    span.appendChild(getRadioInput('pref3'));
    span.appendChild(getRadioLabel('3'));

    span.appendChild(getRadioInput('pref4'));
    span.appendChild(getRadioLabel('4'));
    return span;
}

//GET RADIO INPUT
function getRadioInput(value) {
    var input = document.createElement('input');
    var children = document.getElementById("ulpref").children.length + 1;
    input.type = 'radio';
    input.name = 'preferenceIndication' + children;
    input.value = value;
    return input;
}

//GET RADIO LABEL
function getRadioLabel(num) {
    var label = document.createElement('label');
    label.appendChild(document.createTextNode(num))
    return label;
}

//CREATE SPAN
function getSpan(spanText, id) {
    var span = document.createElement('span');
    span.innerHTML = spanText;
    span.id = id;
    return span;
}

//CREATE SELECT DIV  
function getSelectDiv() {
    var div = document.createElement('div');
    div.className = 'select';
    return div;
}

//CREATE UL 
function getUl() {
    var Ul = document.createElement("ul");
    Ul.className = 'dropdown-menu';
    return Ul;
}

//CREATE INPUT 
function getInput(inputname) {
    var Input = document.createElement("input");
    Input.type = 'hidden';
    Input.name = inputname;
    return Input;
}

//CREATE CHEVRON 
function getChevron() {
    var chevron = document.createElement("i");
    chevron.className = 'fa fa-chevron-left';
    return chevron;
}

//CREATE DELETE BUTTON
function getDeleteButton() {
    var button = document.createElement("button");
    button.className = 'preferenceDeleteButton';
    button.appendChild(document.createTextNode('Delete'));

    button.addEventListener("click", function () {
        $(this).parent('li').remove();
    });

    return button;
}

//HOURS LABEL
function getHours() {
    var hours = document.createElement('label');
    hours.className = 'preferenceHours';
    hours.appendChild(document.createTextNode('Not Selected'));

    return hours;
}

//CREATE DROPDOWN DIV 
function getDropdownDiv(bound, id) {
    var div = document.createElement("div");
    div.className = 'dropdown';
    div.id = id;
    div.style = 'margin: 0px 2px;';
    if (bound == true) {
        div.addEventListener('click', slideToggle);
        div.addEventListener("focusout", focusOut);
    }
    return div;
}

//APPEND DROPDOWN 
function appendDropdown(bound, span, chevron, divSelect, input, ul, div, LiArray) {
    LiArray.forEach(function (element) {
        ul.appendChild(getLi(element));
    });

    divSelect.appendChild(span);
    if (bound == true) {
        divSelect.appendChild(chevron);
    }

    div.appendChild(divSelect);
    div.appendChild(input);
    div.appendChild(ul);

    return div;
}



