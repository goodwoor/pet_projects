#ifndef STRATEGY_H
#define STRATEGY_H

#include "Computer_game.h"

class Strategy : public Computer_game
{
public:
    ~Strategy();
    Strategy(char c1[N], char c2[N], int i1, int i2,int i3, float f, char c3[N], int t, char c8[N],
             char c9[N]);

    virtual void record(std::ofstream &fout) = 0;
    virtual void print() = 0;

    char* ret_units()
    {
        return units;
    };
    char* ret_races()
    {
        return races;
    };

    void set_Strategy();
    void print_Strategy();
    void read_Strategy(std::ifstream &fin);
    void record_Strategy(std::ofstream &fout);

private:
    char *units;
    char *races;

};
#endif
