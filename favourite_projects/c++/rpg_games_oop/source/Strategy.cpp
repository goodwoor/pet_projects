#include "Strategy.h"

Strategy::Strategy(char c1[N], char c2[N], int i1, int i2,int i3, float f, char c3[N], int t, char c8[N],
                   char c9[N]): Computer_game(c1, c2, i1, i2, i3, f, c3, t)
{
    units = new char[N];
    races = new char [N];
    strcpy (units,c8);
    strcpy (races,c9);
}

Strategy:: ~Strategy()
{
    delete []units;
    delete []races;
}

void Strategy::set_Strategy()
{
    std::string line;
    std::cout << "Какие юниты есть в игре?" << std::endl;
    std::cin >> line;
    strcpy(units, line.c_str());

    std::cout << "Какие расы есть в игре?" << std::endl;
    std::cin >> line;
    strcpy(races, line.c_str());
}

void Strategy::print_Strategy()
{
    std::cout << "   Юниты: " <<  units << "." << std::endl;
    std::cout << "   Рассы: " <<  races << "." << std::endl;
}

void Strategy::read_Strategy(std::ifstream &fin)
{
    std::string line;
    getline(fin, line, ';');
    strcpy(units, line.c_str());
    getline(fin, line, ';');
    strcpy(races, line.c_str());
}

void Strategy::record_Strategy(std::ofstream &fout)
{
    fout << units << ";" << races;
}
