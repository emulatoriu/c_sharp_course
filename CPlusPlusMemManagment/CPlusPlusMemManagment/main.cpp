#include "pch.h"
#include <iostream>

void noSenseFunction()
{
    int *myArr = new int[3];    
    std::cout << "blabla";

    //following line is missing to free the array and make space on the stack
    delete [] myArr;
    *myArr = NULL;
}

int main()
{
    noSenseFunction();
    while (1)
    {

    }
}
