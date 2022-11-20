#include <Computer_game.h>

Computer_game::Computer_game(char c1[N], char c2[N], int i1, int i2, int i3, float f, char c3[N], int t)
{
    this->name_of_game = new char[N];
    this->developer = new char[N];
    this->game_mode = new char[N];
    this->release_date_day = new int;
    this->release_date_month = new int;
    this->release_date_year = new int;
    this->critical_evaluation = new float;
    strcpy (this->name_of_game,c1);
    strcpy (this->developer,c2);
    *(this->release_date_day) = i1;
    *(this->release_date_month) = i2;
    *(this->release_date_year) = i3;
    *(this->critical_evaluation)= f;
    strcpy (this->game_mode,c3);
    this->type = t;
}

Computer_game::~Computer_game()
{
    delete []name_of_game;
    delete []developer;
    delete []game_mode;
    delete release_date_day;
    delete release_date_month;
    delete release_date_year;
    delete critical_evaluation;
}

void Computer_game::set_comp_game()
{
    std::string line;
    std::cout << "Введите название игры:" << std::endl;
    std::cin >> line;
    strcpy(this->name_of_game,line.c_str());

    std::cout << "Введите разработчика:" << std::endl;
    std::cin >> line;
    strcpy(this->developer,line.c_str());

    std::cout << "Введите поочерёдно (построчно) день, месяц и год релиза:" << std::endl;
    std::cin >> line;
    *(this->release_date_day) = atoi(line.c_str());

    std::cin >> line;
    *(this->release_date_month) = atoi(line.c_str());

    std::cin >> line;
    *(this->release_date_year) = atoi(line.c_str());

    std::cout << "Введите оценку на Metacritic:" << std::endl;
    std::cin >> line;
    *(this->critical_evaluation) = atof(line.c_str());

    std::cout << "Введите режим игры:" << std::endl;
    std::cin >> line;
    strcpy(this->game_mode,line.c_str());
}

void Computer_game::print_comp_game()
{
    std::cout << " Название игры: " <<  this->name_of_game << std::endl;
    std::cout << "   Разработчик: " <<  this->developer << "." << std::endl;
    std::cout << "   Дата издания: " <<  *(this->release_date_day) << "." <<  *(this->release_date_month) << "." <<  *(this->release_date_year) << std::endl;
    std::cout << "   Оценка на Metacritic: " <<  *(this->critical_evaluation) << "." << std::endl;
    std::cout << "   Режим игры: " <<  this->game_mode << "." << std::endl;
}

void Computer_game::read_comp_game(std::ifstream &fin)
{
    std::string line;
    getline(fin, line, ';');
    strcpy(name_of_game, line.c_str());
    getline(fin, line, ';');
    strcpy(developer, line.c_str());
    getline(fin, line, ';');
    *release_date_day = atoi(line.c_str());
    getline(fin, line, ';');
    *release_date_month = atoi(line.c_str());
    getline(fin, line, ';');
    *release_date_year = atoi(line.c_str());
    getline(fin, line, ';');
    *critical_evaluation = atof(line.c_str());
    getline(fin, line, ';');
    strcpy(game_mode, line.c_str());
}

void Computer_game::record_comp_game(std::ofstream &fout)
{
    fout
            << type << ";" << name_of_game << ";"
            << developer << ";"
            << *release_date_day << ";" << *release_date_month << ";" << *release_date_year << ";"
            << *critical_evaluation << ";"
            << game_mode << ";";
}
