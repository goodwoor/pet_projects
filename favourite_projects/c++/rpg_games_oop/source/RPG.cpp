#include "RPG.h"

RPG::RPG(char c1[N], char c2[N], int i1, int i2,int i3, float f, char c3[N], int t,
         char c4[N], char c5[N]): Computer_game(c1, c2, i1, i2, i3, f, c3, t)
{
    this->specifications_of_characters = new char[N];
    this->basic_of_RPG = new char [N];
    strcpy (this->specifications_of_characters,c4);
    strcpy (this->basic_of_RPG,c5);
}

RPG:: ~RPG()
{
    delete []specifications_of_characters;
    delete []basic_of_RPG;
}

void RPG::set_RPG()
{
    std::string line;
    std::cout << "Какие классы или умения есть у персонажей?" << std::endl;
    std::cin >> line;
    strcpy(this->specifications_of_characters, line.c_str());

    std::cout << "Какова основа геймлея?(н-р, исследование, квесты, бои, развитие персонажа)" << std::endl;
    std::cin >> line;
    strcpy(this->basic_of_RPG, line.c_str());
}

void RPG::print_RPG()
{
    std::cout << "   Умения или классы персонажей: " <<  this->specifications_of_characters << "." << std::endl;
    std::cout << "   Взаимодействие с игрой: " <<  this->basic_of_RPG << "." << std::endl;
}

void RPG::read_RPG(std::ifstream &fin)
{
    std::string line;
    getline(fin, line, ';');
    strcpy(specifications_of_characters, line.c_str());
    getline(fin, line, ';');
    strcpy(basic_of_RPG, line.c_str());
}

void RPG::record_RPG(std::ofstream &fout)
{
    fout << specifications_of_characters << ";" << basic_of_RPG;
}
