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
    "position: absolute;  width: 60px;  height: 50px;" +
    "z-index: -1;" +
    " bottom: 100%; left: " + position_x +"%;" + //рандомная позиция
    " \" >";  

    $("body").append(img);

    //рандомная траектория движения
    let rand_x = getRandomArbitrary(-10, 10);
    let traektoria = position_x + rand_x;
    let strTraektoria = traektoria + "%";

    //рандомная скорость движения
    let rand_speed = getRandomArbitrary(1000, 5000);

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

                    //при наведении курсора
                    step: function(){
                        $(this).on("mouseenter", function(){

                            if(sneg_count % 2 == 0){
                                //меняем свойства текущей снежинки
                                rand_x = getRandomArbitrary(-10, 10);
                                traektoria = position_x + rand_x;
                                strTraektoria = traektoria + "%";
                                rand_speed = getRandomArbitrary(1000, 5000);

                                $(this).stop().animate({bottom: '-5%' , left: strTraektoria}, rand_speed, function(){ 
                                    //удалить, когда достигнет низа
                                    $(this).remove(); 
                                    //запуск новой снежинки
                                    appendSneg();
                            });
                            }
                            else{
                                //запускаем четыре новых снежинки
                                for(let i = 0; i < 5; i++)
                                {
                                    appendSneg_second( $(this).css("bottom"),  $(this).css("left"));
                                } 
                                //очищаем очередь анимаций
                                $(this).stop(true, true);
                            }
                            
                        })
                        }   
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

//перегрузка функции
function appendSneg_second(x ,y) {
    //позиция не рандомная
    //значения в пикселях
    
    let img = "<img "  + "id=\"" +  
    sneg_count + "\"" + 
    " src=\"img/снежинка.png\" style=\" " + 
    "position: absolute;  width: 60px;  height: 50px;" +
    " bottom: " + x + "; " + " left: " + y +";" + 
    " \" >";  

    $("body").append(img);

    let rand_x = getRandomArbitrary(-100, 100);

    let index = x.indexOf("p");
    let intX = x.substring(0, index);
    let traektoria = (+intX) + rand_x;
    let strTraektoria = traektoria + "px";

    let rand_speed = getRandomArbitrary(1000, 5000);

    let str_id = "#" + sneg_count;

    $(str_id).animate({bottom: '-5%' , left: strTraektoria},
        rand_speed, "swing",function(){ 
        //удалить, когда достигнет низа
        $(str_id ).remove(); 
    });

    sneg_count += 1;
}