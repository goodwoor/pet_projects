"use strict";

//В предложении удалить все слова, состоящие более чем из 5 букв
function work_1(){
    var input_text = document.getElementById("work_1").value;
    
    //разбиваем строку на отдельные слова, на выходе массив слов "words"
    var words = [];
    var current_word = [];
    var str_word = "";
    var count_letters = -1;
    var count_word = 0;
    for(let i = 0; i < input_text.length; i++)
    {
        if(input_text[i] != " ")
        {
            current_word.push(input_text[i]); 
            count_letters += 1;
            str_word += current_word[count_letters];
            words[count_word] = str_word;
        }
        else
        {
            str_word = "";
            current_word = [];
            count_letters = -1;
            count_word += 1;
        }
    }

    //чекаем длину слов, чистим, если > 5
    for(let i = 0; i < words.length; i++)
    {
        if(words[i].length > 5)
        {
            words[i] = "";
        }
    }

    //делаем из массива строку
    var str_words = "";
    for(let i = 0; i < words.length; i++)
    {
        str_words += words[i] + " ";
    }
    openNewWindow(str_words);
}

//В предложении удалить наиболее часто встречающуюся букву
function work_2(){
    var input_text = document.getElementById("work_2").value;

    //массив для хранения пары "буква-количество"
    var words = [];
    words[0] = new Object();
    words[0].letter = input_text[0];
    words[0].count_letters = 0;
    
    //считаем количетсво повторений каждой буквы
    for(let i = 0; i < input_text.length; i++)
    {
        if(input_text[i] != " ")
        {
            let counter = false;
            //ищем соответствия
            for(let j = 0; j < words.length; j++)
            {
                if(words[j].letter == input_text[i])
                {
                    words[j].count_letters += 1;
                    counter = true;
                }
            }
            //если не нашли соответствия добавляем новый элемент
            if (counter == false)
            {
                words.push("");
                words[(words.length - 1)] = new Object();
                words[(words.length - 1)].letter = input_text[i];
                words[(words.length - 1)].count_letters = 1;
            }
        }  
    }

    //наиболее встречающаяся буква
    var max_count = 0;
    var max_letter = "";
    for(let i = 0; i < words.length; i++)
    {
        if(words[i].count_letters > max_count)
        {
            max_count = words[i].count_letters;
            max_letter = words[i].letter;
        }
    }

    //удаляем
    var result_arr =[];
    for(let i = 0; i < input_text.length; i++)
    {
        if (!(input_text[i] == max_letter))
        {
            result_arr.push(input_text[i]);
        }
    }
    
    //делаем из массива строку
    var str_words = "";
    for(let i = 0; i < result_arr.length; i++)
    {
        str_words += result_arr[i];
    }
    openNewWindow(str_words);
}

//проверка строки на цифру
function isStrNum(str){
    if( (str == "0") || (str == "1") ||(str == "2") ||(str == "3") ||(str == "4") ||(str == "5") ||(str == "6") ||(str == "7") || (str == "8") || (str == "9"))
    { 
        return true;
    }
}

//Удалить в предложении все цифры
function work_3(){
    var input_text = document.getElementById("work_3").value;

    var result_text = [];
    for(var i = 0; i < input_text.length; i++)
    {
        if( !(isStrNum(input_text[i])) )
        {
            result_text.push(input_text[i]);
        }
    }

    //делаем из массива строку
    var str_words = "";
    for(var i = 0; i < result_text.length; i++)
    {
        str_words += result_text[i];
    }
    openNewWindow(str_words);
}

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
window.onload = Title_Date();

function calculateForm(){
    var expression = document.forms["calculator"]["input_expression"].value;

    var number_1 = "";
    var number_2 = "";
    var sign = "";
    var sign_find = false;

    for(let i = 0; i < expression.length; i++)
    {
        if( (expression[i] == "+") || (expression[i] == "-") || (expression[i] == "*") || (expression[i] == ":") )
        {
            sign_find = true;
            sign = expression[i];
            continue;
        } 
        if(!sign_find)
        {
            number_1 += expression[i];
        }
        else
        {
            number_2 += expression[i];
        }
    }

    var result = 0;
    var num_1 = +number_1;
    var num_2 = +number_2;
    switch(sign)
    {
        case '+':
            result = num_1 + num_2;
            break;
        case '-':
            result = num_1 - num_2;
            break;
        case '*':
            result = num_1 * num_2;
            break;
        case ':':
            result = num_1 / num_2;
            break;
        default:
    }

    document.getElementById("for_answ").innerHTML = "Answer: " + result;
}

//результат в новом окне
function openNewWindow(result_str)
{
    var newWindow = window.open();
    newWindow.document.write(result_str);
}
