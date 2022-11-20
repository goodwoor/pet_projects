#ifndef LIST_GAME_H_INCLUDED
#define LIST_GAME_H_INCLUDED

#include <iostream>
#include <stdlib.h>

#include "Computer_game.h"
#include "RPG.h"
#include "Strategy.h"
#include "RPG_narrative.h"
#include "RPG_with_open_world.h"
#include "Strategy_RTS.h"
#include "Strategy_TBS.h"

template <typename T>
class List;

template <typename T> class Node
{
    friend class List<T>;
private:
    T *data;
    Node *next;
    Node *prev;

public:
    Node(T *d, Node *n = NULL, Node *p = NULL) : data(d), next(), prev(p) {};

    /*Node& operator= (const Node $other)
    {
        data = other.data;
        next = other.next;
        prev = other.prev;
        return *this;
    };*/
};
template <typename T> class List
{
private:
    Node<T> *Head;
    Node<T> *Tail;
    int list_size;
public:
    void Add(T *d);
    void Print();
    void Delete();
    void Search();
    void Output();
    void Print_with_operator();
};

#endif
