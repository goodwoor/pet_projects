"use strict";

var slideIndex_1 = 1;
var slideIndex_2 = 1;

showSlides(slideIndex_1, 1);
showSlides(slideIndex_2, 2);

function plusSlides(n, sliderNum) {
  if(sliderNum == 1)
  {
    showSlides(slideIndex_1 += n, 1);
  }
  else if(sliderNum == 2)
  {
    showSlides(slideIndex_2 += n, 2);
  }
  else{
    return 0;
  }
}

function currentSlide(n, sliderNum) {
  if(sliderNum == 1)
  {
    showSlides(slideIndex_1 = n, 1);
  }
  else if(sliderNum == 2)
  {
    showSlides(slideIndex_2 = n, 2);
  }
  else{
    return 0;
  }
}

function showSlides(n, sliderNum) {
  var slidesName = "";
  var dotsName = "";
  var slideIndex = 0;
  if(sliderNum == 1)
  {
    slidesName = "mySlides";
    dotsName = "dot";
    slideIndex = slideIndex_1;
  }
  else if (sliderNum == 2)
  {
    slidesName = "mySlides-2";
    dotsName = "dot-2";
    slideIndex = slideIndex_2;
  }
  else
  {
    return;
  }
  
    var i;
    var slides = document.getElementsByClassName(slidesName);
    var dots = document.getElementsByClassName(dotsName);

    if (n > slides.length) 
    {
      if(sliderNum == 1)
      {
        slideIndex_1 = 1
      }
      else if(sliderNum == 2)
      {
        slideIndex_2 = 1
      }
    }

    if (n < 1) 
    {
      if(sliderNum == 1)
      {
        slideIndex_1 = slides.length
      }
      else if(sliderNum == 2)
      {
        slideIndex_2 = slides.length
      }
    }

    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }

    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" active", "");
    }

    if(sliderNum == 1)
    {
      slides[slideIndex_1-1].style.display = "block";
      dots[slideIndex_1-1].className += " active";
    }
    if(sliderNum == 2)
    {
      slides[slideIndex_2-1].style.display = "block";
      dots[slideIndex_2-1].className += " active";
    }

}