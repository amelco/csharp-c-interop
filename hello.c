#include <stdio.h>

#ifdef _WIN32
    #define EXPORT __declspec(dllexport)
#else
    #define EXPORT
#endif

typedef struct {
    char* name;
    int age;
} Person;

EXPORT int soma()
{
    return 2 + 1;
}

EXPORT void hello()
{
    printf("From C => Hello! Soma is %d\n", soma());
}

EXPORT void say_name(char* name)
{
    printf("From C => Name: %s\n", name);
}

EXPORT Person create_person(char* name, int age)
{
    Person p = { name, age };
    return p;
}

EXPORT void print_person(Person* p)
{
    printf("From C => Person is %s and is %d years old.\n", p->name, p->age);
}
