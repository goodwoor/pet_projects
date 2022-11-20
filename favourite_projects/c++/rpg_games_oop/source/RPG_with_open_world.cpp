#include "RPG_with_open_world.h"


RPG_with_open_world::RPG_with_open_world():RPG("", "", 0, 0, 0, 0, "", 2, "", "")
{
    time_plot = new int;
}

RPG_with_open_world::RPG_with_open_world(char c1[N], char c2[N], int i1, int i2,int i3, float f, char c3[N], int t,
        char c4[N], char c5[N], int i4):RPG(c1, c2, i1, i2, i3, f, c3, 2, c4, c5)
{
    time_plot = new int;
    *time_plot = i4;
}

RPG_with_open_world::~RPG_with_open_world()
{
    delete time_plot;
}

void RPG_with_open_world::print()
{
    print_comp_game();
    print_RPG();

    std::cout << "   Примерное время полного прохождения: " <<  *time_plot << " часов" <<  "." << std::endl;
    std::cout << "\n";
}

void RPG_with_open_world::set_open_world()
{
    std::string line;

    set_comp_game();
    set_RPG();

    std::cout << "Какое примерное время полного прохождения?" << std::endl;
    std::cin >> line;
    *time_plot = atoi(line.c_str());
    line.clear();
}

void RPG_with_open_world::record(std::ofstream &fout)
{
    record_comp_game(fout);
    record_RPG(fout);
    fout
            << ";" << *time_plot << "." << std::endl;
    fout.clear();
}

void RPG_with_open_world::read(std::ifstream &fin)
{
    std::string line;
    read_comp_game(fin);
    read_RPG(fin);

    getline(fin, line, '.');
    *time_plot = atoi(line.c_str());
    getline(fin,line);

    fin.clear();
}

std::ostream& operator <<(std::ostream &out, RPG_with_open_world *new_game)
{
    out << " Название игры: " <<  new_game -> ret_name() << "." << std::endl;
    out << "   Тип игры: RPG with open world." << std::endl;
    out << "   Разработчик: " <<  new_game -> ret_dev() << "." << std::endl;
    out << "   Дата издания: " <<  new_game -> ret_day() << "." <<  new_game -> ret_month() << "." <<  new_game -> ret_year() << std::endl;
    out << "   Оценка на Metacritic: " <<  new_game -> ret_crit() << "." << std::endl;
    out << "   Режим игры: " <<  new_game -> ret_mode() << "." << std::endl;

    out << "   Умения или классы персонажей: " <<  new_game -> ret_specific() << "." << std::endl;
    out << "   Взаимодействие с игрой: " <<  new_game -> ret_basicR() << "." << std::endl;

    out << "   Примерное время полного прохождения: " <<  new_game -> ret_time() << " часов." << std::endl;

    return out;
}

