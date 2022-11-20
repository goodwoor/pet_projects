#include <iostream>
#include <stdlib.h>
#include <iostream>
#include <fstream>

#include "list_game.h"
#include "list_game.cpp"

#include "Computer_game.h"
#include "RPG.h"
#include "Strategy.h"
#include "RPG_narrative.h"
#include "RPG_with_open_world.h"
#include "Strategy_RTS.h"
#include "Strategy_TBS.h"

void general()
{
    List <Computer_game> *Grand_list;
    Grand_list = new List <Computer_game>;

    char choice;
    while (choice != '7')
    {
        std::cout
                << "Выберите действие (нажмите соответствующую цифру на клавиатуре):\n"
                << "    1 - добавить элемент в список;\n"
                << "    2 - удалить элемент из списка(или весь список);\n"
                << "    3 - загрузить список из файла;\n"
                << "    4 - записать список в файл;\n"
                << "    5 - вывести список на экран;\n"
                << "    6 - найти элемент в списке;\n"
                << "    7 - закончить работу со списком;\n" << std::endl;
        char choice;
        std::cin >> choice;
        if ((choice != '1')&&(choice != '2')&&(choice != '3')&&(choice != '4')&&(choice != '5')&&(choice != '6')&&(choice != '7')&&(choice != '8'))
        {
            std::cerr << "Следуйте инструкции, введено некорректное значение." << std::endl;
        }
        switch(choice)
        {
        case '1':
        {
            std::cout << "--------------------------------------------------------------" << std::endl;
            std::cout << std::endl;
            std::cout << "Вы выбрали: добавить элемент к списку." << std::endl;
            std::cout << "Какую компьютерную игру вы хотите добавить?\n"
                      <<"(нажмите соответствующую букву на клавиатуре)\n"
                      << "   1.Rpg narrative\n"
                      << "   2.Rpg with open world\n"
                      << "   3.TBS strategy\n"
                      << "   4.RTS strategy \n" << std::endl;
            int type;
            bool mistake = true;
            std::cin >> type;
            if (type == 1)
            {
                RPG_narrative *new_game = new RPG_narrative();
                new_game -> set_narrative();
                Grand_list -> Add(new_game);
                mistake = false;
            }

            if (type == 2)
            {
                RPG_with_open_world *new_game = new RPG_with_open_world();
                new_game -> set_open_world();
                Grand_list -> Add(new_game);
                mistake = false;
            }

            if (type == 3)
            {
                Strategy_RTS *new_game = new Strategy_RTS();
                new_game -> set_RTS();
                Grand_list -> Add(new_game);
                mistake = false;
            }

            if (type == 4)
            {
                Strategy_TBS *new_game = new Strategy_TBS();
                new_game -> set_TBS();
                Grand_list -> Add(new_game);
                mistake = false;
            }
            if (mistake)
            {
                std::cerr << "Введена некорректная величина!" << std::endl;
                break;
            }
            std::cout << std::endl;
            std::cout << "--------------------------------------------------------------" << std::endl;
            break;
        }
        case '2':
        {
            std::cout << "--------------------------------------------------------------" << std::endl;
            std::cout << std::endl;
            std::cout << "Вы выбрали: удалить элемент из списка." << std::endl;
            Grand_list -> Delete();
            std::cout << std::endl;
            std::cout << "--------------------------------------------------------------" << std::endl;
            break;
        }
        case '3':
        {
            std::cout << "--------------------------------------------------------------" << std::endl;
            std::cout << std::endl;
            std::cout << "Вы выбрали: загрузить список из файла." << std::endl;
            char file_name[6];
            int type;
            std::string line;
            std::cout << "Введите название файла, из которого нужно загрузить список:"<< std::endl;
            std::cin >> line;
            strcpy(file_name, line.c_str());
            std::ifstream fin(file_name);
            if (fin)
            {
                getline(fin,line, '.');
                const int count_obj = atoi(line.c_str());
                getline(fin,line);
                for (int i = 0; i < count_obj; i++)
                {
                    getline(fin, line, ';');
                    type = atoi(line.c_str());

                    if (type == 1)
                    {
                        RPG_narrative *new_game = new RPG_narrative();
                        new_game -> read(fin);
                        Grand_list -> Add(new_game);
                    }

                    if (type == 2)
                    {
                        RPG_with_open_world *new_game = new RPG_with_open_world();
                        new_game -> read(fin);
                        Grand_list -> Add(new_game);
                    }

                    if (type == 3)
                    {
                        Strategy_TBS *new_game = new Strategy_TBS();
                        new_game -> read(fin);
                        Grand_list -> Add(new_game);
                    }

                    if (type == 4)
                    {
                        Strategy_RTS *new_game = new Strategy_RTS();
                        new_game -> read(fin);
                        Grand_list -> Add(new_game);
                    }
                }
                std::cout << "Список успешно загружен из файла:" << file_name << "." << std::endl;
		        fin.close();
            }
            else
            {
		         std::cerr << "Ошибка открытия файла. Its name:" << file_name << "-end" << std::endl;
            }
            std::cout << std::endl;
            std::cout << "--------------------------------------------------------------" << std::endl;
            break;
        }
        case '4':
        {
            std::cout << "--------------------------------------------------------------" << std::endl;
            std::cout << std::endl;
            std::cout << "Вы выбрали: записать список в файл." << std::endl;
            Grand_list -> Output();
            std::cout << std::endl;
            std::cout << "--------------------------------------------------------------" << std::endl;
            break;
        }
        case '5':
        {
            std::cout << "--------------------------------------------------------------" << std::endl;
            std::cout << std::endl;
            std::cout << "Вы выбрали: вывести список на экран.\n";
            //Grand_list -> Print();
            Grand_list -> Print_with_operator();
            std::cout << std::endl;
            std::cout << "--------------------------------------------------------------" << std::endl;
            break;
        }
        case '6':
        {
            std::cout << "--------------------------------------------------------------" << std::endl;
            std::cout << std::endl;
            std::cout << "Вы выбрали: поиск элемента в списке.\n";
            Grand_list -> Search();
            std::cout << std::endl;
            std::cout << "--------------------------------------------------------------" << std::endl;
            break;

        }
        case '7':
        {
            exit(0);
            break;
        }
        }
    }
}
