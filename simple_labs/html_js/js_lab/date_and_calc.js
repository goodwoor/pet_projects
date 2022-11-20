"use strict";

function setColor(currentColor) {
    document.getElementById('page').style.backgroundColor = currentColor;
}

function showDate() {
    var new_date = new Date();

    var year = new_date.getFullYear();
    var month = new_date.getMonth() + 1;
    var day = new_date.getDate();

    var showing_date = day + "." + month + "." + year;
    
    openNewWindow(showing_date);
}

function Title_Date(){
    var new_date = new Date();

    var hour = new_date.getHours();
    var minutes = new_date.getMinutes();
    var seconds = new_date.getSeconds();

    var showing_date = hour + ":" + minutes + ":" + seconds;
    document.title = showing_date;

    //обновление 1000мс = 1с
    setTimeout(Title_Date, 1000);
}

function calculateForm(){
    var expression = document.forms["calculator"]["input_expression"].value;

    var result = eval(expression);

    document.getElementById("for_answ").innerHTML = "Answer: " + result;
}

//scrolling

setInterval(() => { scrollBy(0, 10) }, 1000)


window.onload = Title_Date();

