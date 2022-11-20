#include "list_game.h"

template <typename T>
void List<T>::Add(T *d)
{
    Node<T> *new_tail = new Node<T> (d, NULL, NULL);
    Node<T> *old_tail = new Node<T> (NULL, NULL, NULL);
    if (list_size == 0)
    {
        Head = new Node<T> (d, NULL, NULL);
        Tail = new Node<T> (d, NULL, NULL);
        Head = Tail = new_tail;
        list_size++;
    }
    else
    {
        new_tail->prev = Tail;
        Tail->next = new_tail;
        Tail = new_tail;
        list_size++;
    }
}

template <typename T>
void List<T>::Print()
{
    Node<T> *buffer = Head;
    int number = 1;
    std::cout << "" << std::endl;
    std::cout << "Всего элементов:" << list_size << "." << std::endl << std::endl;
    if (list_size == 0)
    {
        std::cout << "Список пуст." << std::endl;
    }
    else
    {
        while (buffer != NULL)
        {
            std::cout << number << ".";
            buffer -> data -> print();
            buffer = buffer -> next;
            number++;
        }
    }
    number = 0;
}

template <typename T>
void List<T>::Delete()
{
    int t;
    std::cout << "Выберите действие (1 или 2):\n";
    std::cout << "1 - удалить элемент по номеру;\n";
    std::cout << "2 - очистить весь список.\n";
    std::cin >> t;
    if ((t != 1)&&(t != 2))
    {
        std::cerr << "Введена некорректная величина!" << std::endl;
    }

    Node<T> *buffer = Head;
    if (t == 1)
    {
        int choise;
        int number = list_size;
        bool poisk = false;

        std::cout << "Введите номер элемента, который хотите удалить: ";
        std::cin >> choise;
        for (int i = 1; i <= number; i++)
        {
            if (i == choise)
            {
                if ((buffer -> next != NULL)&&(buffer -> prev != NULL))
                {
                    buffer -> next -> prev = buffer -> prev;
                    buffer -> prev -> next = buffer -> next;
                }
                if (buffer -> next == NULL)
                {
                    if (list_size == 1)
                    {
                        Tail = NULL;
                        Head = NULL;
                    }
                    if (list_size == 2)
                    {
                        Tail = NULL;
                        Head -> next = NULL;
                    }
                    if (list_size > 2)
                    {
                        Tail = buffer -> prev;
                        buffer -> prev -> prev -> next = Tail;
                        buffer -> prev -> next = NULL;
                    }
                }
                if (buffer -> prev == NULL)
                {
                    if (list_size == 1)
                    {
                        Tail = NULL;
                        Head = NULL;
                    }
                    if (list_size == 2)
                    {
                        Head = Tail;
                        Head -> next = NULL;
                        Tail = NULL;
                    }
                    if (list_size > 2)
                    {
                        Head = buffer -> next;
                        buffer -> next -> next -> prev = Head;
                        buffer -> next -> prev = NULL;
                    }

                }
                delete buffer;
                list_size -=1;
                poisk = true;
                break;
            }
            buffer = buffer -> next;
        }

        if (poisk)
        {
            std::cout << "Элемент под номером " << "<" << choise << ">" << " удалён." << std::endl;
        }
        else
        {
            std::cerr<< "Элемент с таким номером не найден." << std::endl;
        }
    }

    if (t == 2)
    {
        while ( Head != NULL )
        {
            buffer = Head -> next;
            delete Head;
            Head = buffer;
            list_size--;
        }
        std::cout << "Список очищен." << std::endl;
    }
}

template <typename T>
void List<T>::Output()
{
    char nname[10];
    std::string line;
    std::cout << "Введите название файла, в который нужно загрузить список:" << std::endl;
    std::cin >> line;
    strcpy(nname, line.c_str());

    std::ofstream fout(nname);
    if (fout)
    {
        fout << list_size << "." << std::endl;
        fout.clear();

        Node<T> *buffer = Head;
        while (buffer != NULL)
        {
            buffer -> data -> record(fout);
            buffer = buffer -> next;
        }
        if ((list_size == 0))
        {
            std::cout << "Список пуст." << std::endl;
        }
        else
        {
            std::cout << "Список успешно загружен в файл:" << nname << "." << std::endl;
	    fout.close();
        }
    }
    else
    {
        std::cerr << "Ошибка открытия файла." << std::endl;
    }
}

template <typename T>
void List<T>::Search()
{
    char nname[100];
    char name[100];
    int number = 0;
    bool poisk = false;

    std::cout << "Введите название элемента, который хотите найти:";
    std::string choise;
    std::cin >> choise;
    std::cout << "" << std::endl;
    strcpy(nname, choise.c_str());
    Node<T> *buffer = Head;

    while (buffer != NULL)
    {
        strcpy(name, buffer -> data -> ret_name());
        if (strcmp(name,nname) == 0)
        {
            std::cout << "  ";//для отступа от первой строки (название игры)
            buffer -> data -> print();
            poisk = true;
            number += 1;
        }
        buffer = buffer -> next;
    }
    if (poisk == false)
    {
        std::cout << "Элемент не найден." << std::endl;
    }
    if (list_size == 0)
    {
        std::cout << "Список пуст." << std::endl;
    }
    if (number > 1)
    {
        std::cout << "Найдено несколько элементов с именем: " << choise << "\n" << std::endl;
    }
    if (number == 1)
    {
        std::cout << "Элемент " << choise << " найден.\n" << std::endl;
    }
}

template <typename T>
void List<T>::Print_with_operator()
{
    Node<T> *buffer = Head;
    int number = 1;
    std::cout << "" << std::endl;
    std::cout << "Всего элементов:" << list_size << "." << std::endl << std::endl;
    if (list_size == 0)
    {
        std::cout << "Список пуст." << std::endl;
    }
    else
    {
        while (buffer != NULL)
        {
            std::cout << number << ".";
            int type = buffer -> data -> ret_type();
            if (type == 1)
            {
               RPG_narrative *new_game = dynamic_cast<RPG_narrative*>(buffer -> data);
               std::cout << new_game << std::endl;
            }
            if (type == 2)
            {
                RPG_with_open_world *new_game = dynamic_cast<RPG_with_open_world*>(buffer -> data);
                std::cout << new_game << std::endl;
            }
            if (type == 3)
            {
                Strategy_TBS *new_game = dynamic_cast<Strategy_TBS*>(buffer -> data);
                std::cout << new_game << std::endl;
            }
            if (type == 4)
            {
                Strategy_RTS *new_game = dynamic_cast<Strategy_RTS*>(buffer -> data);
                std::cout << new_game << std::endl;
            }
            buffer = buffer -> next;
            number++;
        }
    }
    number = 0;
}
