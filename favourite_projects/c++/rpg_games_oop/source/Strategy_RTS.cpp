#include "Strategy_RTS.h"

Strategy_RTS::Strategy_RTS(): Strategy("", "", 0, 0, 0, 0, "", 4, "", "")
{
    specialization = new char[N];
}

Strategy_RTS::Strategy_RTS(char c1[N], char c2[N], int i1, int i2,int i3, float f, char c3[N], int t, char c8[N],char c9[N],
                           char c12[N]): Strategy(c1, c2, i1, i2, i3, f, c3, 4, c8, c9)
{
    specialization = new char[N];
    strcpy (specialization,c12);
}

Strategy_RTS::~Strategy_RTS()
{
    delete []specialization;
}

void Strategy_RTS::print()
{
    print_comp_game();
    print_Strategy();

    std::cout << "   Специализация RTS: " <<  specialization << "." << std::endl;
    std::cout << "\n";
}

void Strategy_RTS::set_RTS()
{
    std::string line;

    set_comp_game();
    set_Strategy();

    std::cout << "Какая специализация у стратегии(сбор ресурсов,постройка баз,удержание КТ):" << std::endl;
    std::cin >> line;
    strcpy(specialization, line.c_str());
    line.clear();
}

void Strategy_RTS::record(std::ofstream &fout)
{
    record_comp_game(fout);
    record_Strategy(fout);
    fout
            << ";" << specialization << "." << std::endl;
    fout.clear();
}

void Strategy_RTS::read(std::ifstream &fin)
{
    std::string line;
    read_comp_game(fin);
    read_Strategy(fin);

    getline(fin, line, '.');
    strcpy(specialization,line.c_str());
    getline(fin,line);
    fin.clear();
}

std::ostream& operator <<(std::ostream &out, Strategy_RTS *new_game)
{
    out << " Название игры: " <<  new_game -> ret_name() << "." << std::endl;
    out << "   Тип игры: Strategy RTS." << std::endl;
    out << "   Разработчик: " <<  new_game -> ret_dev() << "." << std::endl;
    out << "   Дата издания: " <<  new_game -> ret_day() << "." <<  new_game -> ret_month() << "." <<  new_game -> ret_year() << std::endl;
    out << "   Оценка на Metacritic: " <<  new_game -> ret_crit() << "." << std::endl;
    out << "   Режим игры: " <<  new_game -> ret_mode() << "." << std::endl;

    out << "   Юниты: " <<  new_game -> ret_units()  << "." << std::endl;
    out << "   Рассы: " <<  new_game -> ret_races() << "." << std::endl;

    out << "   Cпециализация: " <<  new_game -> specialization << "." << std::endl;

    return out;
}


