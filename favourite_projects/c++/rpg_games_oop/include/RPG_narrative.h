#ifndef RPG_NARRATIVE_H
#define RPG_NARRATIVE_H

#include "RPG.h"

class RPG_narrative : public RPG
{
public:
    RPG_narrative();
    ~RPG_narrative();
    RPG_narrative(char c1[N], char c2[N], int i1, int i2,int i3, float f, char c3[N], int t,
                  char c4[N], char c5[N], char c6[N]);

    void print();
    void record(std::ofstream &fout);
    void read(std::ifstream &fin);
    void set_narrative();
    friend std::ostream& operator<< (std::ostream &out, RPG_narrative *new_game);

private:
    char *plot;

};


#endif
