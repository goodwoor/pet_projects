"use strict";

/*<img id="sneg" src="img/снежинка.png">*/

function getRandomInt(max) {
    return Math.floor(Math.random() * Math.floor(max));
}

function getRandomArbitrary(min, max) {
    return Math.random() * (max - min) + min;
}

var sneg_count = 1;

function appendSneg() {
    //для рандомной позиции снежинок
    let random_x = getRandomInt(25);
    let position_x = random_x * 4;

    let img = "<img "  + "id=\"" +  //задаём id снежинки через общий счётчик
    sneg_count + "\"" + 
    " src=\"img/снежинка.png\" style=\" " + //остальные css свойства снежинки
    "position: fixed;  width: 60px;  height: 50px;" +
    "z-index: -1;" +
    " bottom: 100%; left: " + position_x +"%;" + //рандомная позиция
    " \" >";  

    $("body").append(img);

    //рандомная траектория движения
    let rand_x = getRandomArbitrary(-10, 10);
    let traektoria = position_x + rand_x;
    let strTraektoria = traektoria + "%";

    //рандомная скорость движения
    let rand_speed = getRandomArbitrary(5000, 10000);

    //уникальный id 
    let str_id = "#" + sneg_count;

        //делаем анимацию
        $(document).ready(
            function(){
            //стандартный случай
            $(str_id).animate({bottom: '-5%' , left: strTraektoria},
                {
                    duration: rand_speed,
                    easign: "swift",
                    specialEasing: {},
                    complete: function(){ 
                        //удалить, когда достигнет низа
                        $(this).remove(); 
                        //запуск новой снежинки
                        appendSneg();
                    },
                }  
            );
            });

    sneg_count += 1;
}

//запуск анимации
function appendSnow(count) {
    for(let i = 0; i < count; i++)
    {
        appendSneg();
    } 
}

document.onload = appendSnow(20);


