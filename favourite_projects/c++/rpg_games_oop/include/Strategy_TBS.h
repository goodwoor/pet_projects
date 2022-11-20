#ifndef STRATEGY_TBS_H
#define STRATEGY_TBS_H

#include "Strategy.h"

class Strategy_TBS : public Strategy
{
public:
    Strategy_TBS();
    ~Strategy_TBS();
    Strategy_TBS(char c1[N], char c2[N], int i1, int i2,int i3, float f, char c3[N], int t, char c8[N], char c9[N],
                 char c11[N]);

    void print();
    void record(std::ofstream &fout);
    void read(std::ifstream &fin);
    void set_TBS();

    friend std::ostream& operator<< (std::ostream &out, Strategy_TBS *new_game);

private:
    char *moves; //"время хода - ограничено или нет"

};

#endif
