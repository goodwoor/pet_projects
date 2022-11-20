#include "Strategy_TBS.h"

Strategy_TBS::Strategy_TBS(): Strategy("", "", 0, 0, 0, 0, "", 3, "", "")
{
    moves = new char[N];
}

Strategy_TBS::Strategy_TBS(char c1[N], char c2[N], int i1, int i2,int i3, float f, char c3[N], int t, char c8[N], char c9[N],
                           char c11[N]):Strategy(c1, c2, i1, i2, i3, f, c3, 3, c8, c9)
{
    moves = new char[N];
    strcpy (moves,c11);
}

Strategy_TBS::~Strategy_TBS()
{
    delete []moves;
}

void Strategy_TBS::print()
{
    print_comp_game();
    print_Strategy();

    std::cout << "   Время одного хода: " <<  moves << "." << std::endl;
    std::cout << "\n";
}

void Strategy_TBS::set_TBS()
{
    std::string line;

    set_comp_game();
    set_Strategy();

    std::cout << "Ограничение времени хода:" << std::endl;
    std::cin >> line;
    strcpy(moves, line.c_str());
    line.clear();
}

void Strategy_TBS::record(std::ofstream &fout)
{
    record_comp_game(fout);
    record_Strategy(fout);
    fout
            << ";" << moves << "." << std::endl;
    fout.clear();
}

void Strategy_TBS::read(std::ifstream &fin)
{
    std::string line;
    read_comp_game(fin);
    read_Strategy(fin);

    getline(fin, line, '.');
    strcpy(moves,line.c_str());
    getline(fin,line);
    fin.clear();
}

std::ostream& operator <<(std::ostream &out, Strategy_TBS *new_game)
{
    out << " Название игры: " <<  new_game -> ret_name() << "." << std::endl;
    out << "   Тип игры: Strategy TBS." << std::endl;
    out << "   Разработчик: " <<  new_game -> ret_dev() << "." << std::endl;
    out << "   Дата издания: " <<  new_game -> ret_day() << "." <<  new_game -> ret_month() << "." <<  new_game -> ret_year() << std::endl;
    out << "   Оценка на Metacritic: " <<  new_game -> ret_crit() << "." << std::endl;
    out << "   Режим игры: " <<  new_game -> ret_mode() << "." << std::endl;

    out << "   Юниты: " <<  new_game -> ret_units()  << "." << std::endl;
    out << "   Рассы: " <<  new_game -> ret_races() << "." << std::endl;

    out << "   Ограничение времени хода: " <<  new_game -> moves << "." << std::endl;

    return out;
}
