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

//результат в новом окне
function openNewWindow(result_str)
{
    var newWindow = window.open();
    newWindow.document.write(result_str);
}
