#pragma once

#include "Tetramino.h"

#include <time.h>

extern const int M; // ������ �������� ���� 
extern const int N; // ������ �������� ����

Tetramino::Tetramino()
{
	srand(time(0));
	figure = rand() % 7 + 1; // I = 1, S, Z, T, L, J, O = 7
	colour = rand() % 7 + 1;
	if (figure == 1) // I
	{
		x = { 0, 0, 0, 0 };
		y = { 0, 1, 2, 3 };
	}
	if (figure == 2) // S
	{
		x = { 0, 0, 1, 1 };
		y = { 0, 1, 1, 2 };
	}
	if (figure == 3) // Z
	{
		x = { 1, 1, 0, 0 };
		y = { 0, 1, 1, 2 };
	}
	if (figure == 4) // T
	{
		x = { 1, 1, 1, 0 };
		y = { 0, 1, 2, 1 };
	}
	if (figure == 5) // L
	{
		x = { 0, 0, 0, 1 };
		y = { 0, 1, 2, 2 };
	}
	if (figure == 6) // J
	{
		x = { 1, 1, 1, 0 };
		y = { 0, 1, 2, 2 };
	}
	if (figure == 7) // O
	{
		x = { 0, 0, 1, 1 };
		y = { 0, 1, 0, 1 };
	}

	short random_x = rand() % (N - 1);
	for (int i = 0; i < 4; i++)
		x[i] += random_x;
}

void Tetramino::minus_x()
{
	for (int i = 0; i < 4; i++)
		x[i] -= 1;
}

void Tetramino::plus_y()
{
	for (int i = 0; i < 4; i++)
		y[i] += 1;
}

void Tetramino::plus_x()
{
	for (int i = 0; i < 4; i++)
		x[i] += 1;
}

void Tetramino::set_x(std::vector <short> new_x)
{
	x = new_x;
}

void Tetramino::set_y(std::vector <short> new_y)
{
	y = new_y;
}

void Tetramino::rotate()
{
	if (!(figure == 7))
	{
		std::vector <short> old_x = x;
		std::vector <short> old_y = y;

		short x_0 = x[1];
		short y_0 = y[1];

		for (int i = 0; i < 4; i++)
		{
			x[i] = x_0 + y_0 - old_y[i];
			y[i] = -x_0 + y_0 + old_x[i];
		}
	}
}

short Tetramino::ret_colour()
{
	return colour;
}

std::vector <short> Tetramino::ret_x()
{
	return x;
}

std::vector <short> Tetramino::ret_y()
{
	return y;
}

bool Tetramino::border(short cn_game_box_colour[20][10])
{
	for (int i = 0; i < 4; i++)
	{
		if (x[i] < 0 || x[i] >= N || y[i] >= M)
		{
			return 1;
		}

		if (cn_game_box_colour[y[i]][x[i]]) // ���� ������ ������ ���������
		{
			return 1;
		}

	}
	return 0;
}

