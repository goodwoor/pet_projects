#ifndef COMPUTER_GAME_H
#define COMPUTER_GAME_H

#include <string>
#include <cstring>
#include <iostream>
#include <stdlib.h>
#include <fstream>

const int N = 100;

class Computer_game
{
public:
    ~Computer_game();
    Computer_game(char c1[N], char c2[N], int i1, int i2, int i3, float f, char c3[N], int t);

    virtual void print() = 0;
    virtual void record(std::ofstream &fout) = 0;

    char* ret_name()
    {
        return name_of_game;
    };
    int ret_type()
    {
        return type;
    };

    char* ret_dev()
    {
        return developer;
    };
    int ret_day()
    {
        return *release_date_day;
    };
    int ret_month()
    {
        return *release_date_month;
    };
    int ret_year()
    {
        return *release_date_year;
    };
    float ret_crit()
    {
        return *critical_evaluation;
    };
    char* ret_mode()
    {
        return game_mode;
    };

    void set_comp_game();
    void print_comp_game();
    void read_comp_game(std::ifstream &fin);
    void record_comp_game(std::ofstream &fout);

private:
    int type;
    char *name_of_game;
    char *developer;
    int *release_date_day, *release_date_month, *release_date_year;
    float *critical_evaluation;
    char *game_mode;
};

#endif
