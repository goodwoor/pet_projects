#pragma once

#include "functions.h"
#include <iostream>

void welcome()
{
	std::cout << "Hello, friend!" << std::endl << std::endl <<

		"/------------------------------------------------------------------------------------/" << std::endl << std::endl <<

		"It's project was created using c++ (SFML lib) and this tutorial:" << std::endl <<
		"https://ravesli.com/graficheskaya-biblioteka-sfml-sozdanie-tetrisa-chast-1/" << std::endl << std::endl <<

		"/------------------------------------------------------------------------------------/" << std::endl << std::endl <<

		"Use arrows for control" << std::endl <<
		"Your score will show in console." << std::endl << std::endl <<

		"/------------------------------------------------------------------------------------/" << std::endl << std::endl <<

		"Have a nice game!" << std::endl <<
		"Created by GoodWoor." << std::endl << std::endl <<

		"/------------------------------------------------------------------------------------/" << std::endl << std::endl <<

		"Press Enter to start.";
	std::cin.get();
}

void end(int end_score)
{
	std::cout << std::endl << std::endl <<

		"/------------------------------------------------------------------------------------/" << std::endl << std::endl <<

		"You scorred " << end_score << " points." << std::endl;
	if (end_score < 800)
	{
		std::cout << "You got few points :(" << std::endl;
	}
	else
	{
		std::cout << "Cool, you are a good player :)" << std::endl;
	}

}
