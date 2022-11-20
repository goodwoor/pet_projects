#ifndef STRATEGY_RTS_H
#define STRATEGY_RTS_H

#include "Strategy.h"

class Strategy_RTS : public Strategy
{
public:
    Strategy_RTS();
    ~Strategy_RTS();
    Strategy_RTS(char c1[N], char c2[N], int i1, int i2,int i3, float f, char c3[N], int t, char c8[N],char c9[N],
                 char c12[N]);

    void print();
    void record(std::ofstream &fout);
    void read(std::ifstream &fin);
    void set_RTS();

    friend std::ostream& operator<< (std::ostream &out, Strategy_RTS *new_game);

private:
    char *specialization; //"сбор ресурсов, постройка баз, захват и удержание контрольных точек, присылка подкреплений"

};

#endif
