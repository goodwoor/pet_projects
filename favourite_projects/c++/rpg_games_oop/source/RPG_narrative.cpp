#include "RPG_narrative.h"

RPG_narrative::RPG_narrative():RPG("", "", 0, 0, 0, 0, "", 1, "", "")
{
    this->plot = new char[N];
}

RPG_narrative::RPG_narrative(char c1[N], char c2[N], int i1, int i2,int i3, float f, char c3[N], int t,
                             char c4[N], char c5[N], char c6[N]):RPG(c1, c2, i1, i2, i3, f, c3, 1, c4, c5)
{
    this->plot = new char[N];
    strcpy (this->plot,c6);
}

RPG_narrative::~RPG_narrative()
{
    delete []plot;
}

void RPG_narrative::print()
{
    this->print_comp_game();
    this->print_RPG();

    std::cout << "   Сюжет: " <<  plot << "." << std::endl;
    std::cout << "\n";
}

void RPG_narrative::set_narrative()
{
    std::string line;

    this->set_comp_game();
    this->set_RPG();

    std::cout << "Какой сюжет у игры?(н-р, вариативный, линейный)" << std::endl;
    std::cin >> line;
    strcpy(this->plot, line.c_str());

}

void RPG_narrative::record(std::ofstream &fout)
{
    record_comp_game(fout);
    record_RPG(fout);
    fout
            << ";" << plot << "." << std::endl;
    fout.clear();
}

void RPG_narrative::read(std::ifstream &fin)
{
    std::string line;
    read_comp_game(fin);
    read_RPG(fin);

    getline(fin, line, '.');
    strcpy(plot, line.c_str());
    getline(fin,line);
    fin.clear();
}

std::ostream& operator <<(std::ostream &out, RPG_narrative *new_game)
{
    out << " Название игры: " <<  new_game -> ret_name() << "." << std::endl;
    out << "   Тип игры: RPG narrative." << std::endl;
    out << "   Разработчик: " <<  new_game -> ret_dev() << "." << std::endl;
    out << "   Дата издания: " <<  new_game -> ret_day() << "." <<  new_game -> ret_month() << "." <<  new_game -> ret_year() << std::endl;
    out << "   Оценка на Metacritic: " <<  new_game -> ret_crit() << "." << std::endl;
    out << "   Режим игры: " <<  new_game -> ret_mode() << "." << std::endl;

    out << "   Умения или классы персонажей: " <<  new_game -> ret_specific() << "." << std::endl;
    out << "   Взаимодействие с игрой: " <<  new_game -> ret_basicR() << "." << std::endl;

    out << "   Сюжет: " <<  new_game -> plot << "." << std::endl;

    return out;
}




