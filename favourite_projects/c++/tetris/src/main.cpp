#include <SFML/Graphics.hpp>	
#include <iostream>
#include <fstream>
#include <time.h>
#include <cmath>
#include <vector>
#include <locale.h>
#include <conio.h>
#include <windows.h>

#include "functions.h"
#include "Tetramino.h"

using namespace sf; // ���������� ������������ ��� sf

const int M = 20; // ������ �������� ���� 
const int N = 10; // ������ �������� ����
short game_box_colour[M][N] = { {0} }; // ������� ����, �������� ������ � ����� � ���������� ������� ���������
const float time_const = 0.3;
float time_down = 0;
int score = 0; // ������� ����

int main()
{
	welcome();

	RenderWindow window(VideoMode(800, 600), "Tetris");

	// находим текущую директорию для подгрузки спрайтов
	char* buffer = new char[MAX_PATH];
	GetCurrentDirectoryA(MAX_PATH, buffer);
	CharToOemA(buffer, buffer);
	std::cout << buffer << std::endl;
	std::string directory(buffer);

	for (int i = 0; i < directory.length(); i++)
	{
		if (directory[i] == '\\')
		{
			//сначала заменяем предыдущий \ на / и добавляем ещё один /
			directory[i] = '/';
			directory.insert(i, "/");
		}

	}

	Texture texture, texture_fon;
	//texture.loadFromFile("N://Dev//projects//sfml//tetris//img//tetramino.png");
	//texture_fon.loadFromFile("N://Dev//projects//sfml//tetris//img//field.png");

	texture.loadFromFile(directory + "//img//tetramino.png");
	texture_fon.loadFromFile(directory + "//img//field.png");

	Tetramino tetr;
	Tetramino tetr_2;
	Clock clock;

	Sprite sprite_box(texture); // ������ ��� �������� ����
	Sprite sprite_tetr(texture); // ������ ��� ���������
	Sprite sprite_tetr_2(texture);

	Sprite sprite_field(texture_fon);
	sprite_field.setTextureRect(IntRect(0, 0, 204, 404));
	sprite_field.setPosition(298, 98);

	Sprite sprite_fon(texture_fon);
	sprite_fon.setTextureRect(IntRect(245, 0, 800, 600));
	sprite_fon.setPosition(0, 0);

	while (window.isOpen())
	{
		std::vector <short> x_prev(tetr.ret_x()); // ������� ���������� 
		std::vector <short> y_prev(tetr.ret_y());

		Event event;
		while (window.pollEvent(event)) // ������������ ������� � ����������
		{
			if (event.type == Event::Closed)
				window.close();

			if (event.type == Event::KeyPressed)
			{
				if (event.key.code == Keyboard::Escape)
				{
					window.close();
				}
				else if (event.key.code == Keyboard::Left)
				{
					x_prev = tetr.ret_x();
					tetr.minus_x();
				}
				else if (event.key.code == Keyboard::Right)
				{
					x_prev = tetr.ret_x();
					tetr.plus_x();
				}
				else if (event.key.code == Keyboard::Down)
				{
					x_prev = tetr.ret_x();
					y_prev = tetr.ret_y();
					tetr.plus_y();

					if (tetr.border(game_box_colour))
					{
						for (int i = 0; i < 4; i++)
						{
							game_box_colour[y_prev[i]][x_prev[i]] = tetr.ret_colour();
						}
						Tetramino tetr_3;// ��������� ���������� � ���� ������ ���������, ���� ��������� �������
						tetr = tetr_2;
						tetr_2 = tetr_3;
					}
				}
				else if (event.key.code == Keyboard::Up)
				{
					x_prev = tetr.ret_x();
					y_prev = tetr.ret_y();
					tetr.rotate();
				}

				if (tetr.border(game_box_colour))
				{
					tetr.set_x(x_prev);
					tetr.set_y(y_prev);
				}
			}

		}

		sprite_tetr.setTextureRect(IntRect(20 * tetr.ret_colour(), 0, 20, 20));
		sprite_tetr_2.setTextureRect(IntRect(20 * tetr_2.ret_colour(), 0, 20, 20));

		// ��������� ��������� �������� � ����������� ��������� ����
		Time begin = clock.getElapsedTime();
		float time_s = begin.asSeconds();
		if (time_s > time_const)
		{
			clock.restart();

			x_prev = tetr.ret_x();
			y_prev = tetr.ret_y();
			tetr.plus_y();

			if (tetr.border(game_box_colour))
			{
				for (int i = 0; i < 4; i++)
				{
					game_box_colour[y_prev[i]][x_prev[i]] = tetr.ret_colour();
				}
				Tetramino tetr_3; // ��������� ���������� � ���� ���������
				tetr = tetr_2;
				tetr_2 = tetr_3;
			}

		}

		for (int i = 0; i < M; i++) // ����� �������� ������ �����
		{
			short count = 0;
			short count_str = 0;

			for (int j = 0; j < N; j++) // ��������, ������� ��������� ������ � �������
			{
				if (game_box_colour[i][j])
					count++;
			}

			if (count == N) // ���� �� N-����, �� ��� ������� ������ ���������� �� ���� ����
			{
				count_str++;
				for (int k = i; k > 0; k--)
				{
					for (int m = 0; m < N; m++)
						game_box_colour[k][m] = game_box_colour[k - 1][m];
				}

				score += (100 * pow(2, count_str));
				std::cout << std::endl << score << std::endl;
			}

		}

		// ������ ��� �������� ����
		window.clear(Color::White);
		window.draw(sprite_fon);
		window.draw(sprite_field);

		// ���������� ���������� ���������
		std::vector <short> x(tetr.ret_x());
		std::vector <short> y(tetr.ret_y());

		std::vector <short> x_2(tetr_2.ret_x());
		std::vector <short> y_2(tetr_2.ret_y());

		// �������� ����� ����
		for (int i = 0; i < 4; i++)
		{
			if (y[i] == 1 && tetr.border(game_box_colour))
			{
				end(score);
				window.close();
			}
		}

		// ������ ��������� ��������� �� �����������
		for (int i = 0; i < 4; i++)
		{
			sprite_tetr_2.setPosition(20 * (x_2[i] + 2), 20 * (y_2[i] + 5));
			window.draw(sprite_tetr_2);
		}

		// ������ ������� ��������� �� �����������
		for (int i = 0; i < 4; i++)
		{
			sprite_tetr.setPosition(20 * (x[i] + 15), 20 * (y[i] + 5)); // +15, + 5 - ��������� ���� � ������ ����
			window.draw(sprite_tetr);
		}

		// ������ ������� ����
		for (int i = 0; i < M; i++)
		{
			for (int j = 0; j < N; j++)
			{
				if (!(game_box_colour[i][j] == 0))
				{
					sprite_box.setTextureRect(IntRect(20 * game_box_colour[i][j], 0, 20, 20));
					sprite_box.setPosition(20 * (j + 15), 20 * (i + 5)); // +14, + 5 - ��������� ���� � ������ ����
					window.draw(sprite_box);
				}
			}
		}

		window.display();
	}

	return 0;
}