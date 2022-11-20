#pragma once

#include <vector>
#include <iostream>

extern const int M; // ������ �������� ���� 
extern const int N; // ������ �������� ����

class Tetramino
{
	std::vector <short> x;
	std::vector <short> y;
	short colour; //  blue = 1, red, green, purple, orange, light_blue, yellow = 7
	short figure;

public:
	Tetramino();
	void minus_x();
	void plus_x();
	void plus_y();
	void set_x(std::vector <short> new_x);
	void set_y(std::vector <short> new_y);
	void rotate();
	short ret_colour();
	std::vector <short> ret_x();
	std::vector <short> ret_y();
	bool border(short game_box_colour[20][10]);
};