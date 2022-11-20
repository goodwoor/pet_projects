#ifndef RPG_H
#define RPG_H

#include "Computer_game.h"

class RPG : public Computer_game
{
public:
    ~RPG();
    RPG(char c1[N], char c2[N], int i1, int i2,int i3, float f, char c3[N], int t,
        char c4[N], char c5[N]);

    virtual void record(std::ofstream &fout) = 0;
    virtual void print() = 0;

    char* ret_specific()
    {
        return specifications_of_characters;
    };
    char* ret_basicR()
    {
        return basic_of_RPG;
    };

    void set_RPG();
    void print_RPG();
    void read_RPG(std::ifstream &fin);
    void record_RPG(std::ofstream &fout);

private:
    char *specifications_of_characters;
    char *basic_of_RPG; // "применение навыков персонажа"

};

#endif // RPG_H
