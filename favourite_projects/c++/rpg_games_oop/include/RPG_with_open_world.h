#ifndef RPG_WITH_OPEN_WORLD_H
#define RPG_WITH_OPEN_WORLD_H

#include "RPG.h"

class RPG_with_open_world : public RPG
{
public:
    RPG_with_open_world();
    ~RPG_with_open_world();
    RPG_with_open_world(char c1[N], char c2[N], int i1, int i2,int i3, float f, char c3[N], int t,
                        char c4[N], char c5[N], int i4);

    void print();
    void record(std::ofstream &fout);
    void read(std::ifstream &fin);
    void set_open_world();

    int ret_time()
    {
        return *time_plot;
    };

    friend std::ostream& operator<< (std::ostream &out, RPG_with_open_world *new_game);

private:
    int *time_plot;
};

#endif
