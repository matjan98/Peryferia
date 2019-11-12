
#include <iostream>
#include <windows.h>
#include <mmsystem.h>
#include <fstream>
#include <conio.h>
#include "atlbase.h"
#include "atlwin.h"
#include "wmp.h"
using namespace std;




int main(int argc, char* argv[])
{
	PlaySound("C:\\Users\\lab\\Desktop\\beep-09.wav", NULL, SND_ASYNC);
	system("pause");
	return 0;
}
