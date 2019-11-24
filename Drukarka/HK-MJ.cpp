#include "pch.h"
#include <iostream>

#include<fstream>
#include<stdio.h>
#include<string>
#include<Windows.h>
#include <fcntl.h>
#define MONTH "\202P\202P\214\216"
#define DAY1 "\202P\202U\223\372"
#define TILDE "\201\140"
#define DAY2 "\202P\202V\223\372"
#define KANJITXT MONTH DAY1 TILDE MONTH DAY2
FILE *prn;

char esc = 27;

using namespace std;


void main() {

	int wybor;
	int odcien = 255;
	int entery = 0;
	string tekst;
	cout << "1. Pogrubione" << endl;
	cout << "2. Kursywa" << endl;
	cout << "3. Normalny tekst" << endl;
	cout << "4. Obrazek" << endl;
	cout << "Wybor: ";
	cin >> wybor;
	if (wybor != 4) {
		cout << "Odcien: ";
		cin >> odcien;
		cout << "Od ktorej lini zaczac drukowac: ";
		cin >> entery;
		cout << "Podaj tekst do wydrukowania: ";
		cin >> tekst;
	}
	fstream out;
	out.open("LPT3", ios::out);
	if (out.is_open())
	{
		cout << "Drukowanie w kolejce" << endl;

		for (int i = 0; i < entery; i++) {
			out << endl;
		}

		if (wybor == 1) 
		{
			out << (char)27 << (char)40 << (char)115 << (char)51 << (char)66 
				<< (char)27 << (char)42 << (char)118 << (char)odcien << (char)odcien << (char)odcien << (char)83
				<< tekst << endl;
		}
		if (wybor == 2) 
		{
			out << (char)27 << (char)40 << (char)115 << (char)49 << (char)83
				<< (char)27 << (char)42 << (char)118 << (char)odcien << (char)odcien << (char)odcien << (char)83
				<< tekst << endl;
		}
		if (wybor == 3) 
		{
			out << (char)27 << (char)42 << (char)118 << (char)odcien << (char)odcien << (char)odcien << (char)83 << tekst << endl;
		}

		if (wybor == 4)
		{
			wchar_t message[8] = L"bit.bmp";
			LPCUWSTR WcharTable = message;
			HANDLE hBitMap = ::LoadImage(0, WcharTable, IMAGE_BITMAP, 0, 0, LR_LOADFROMFILE);
			BITMAP bitmapa;
			GetObject(hBitMap, sizeof(BITMAP), &bitmapa);
			int rozmiar = bitmapa.bmHeight*bitmapa.bmWidthBytes;
			BYTE *lpBits = new BYTE[rozmiar];

			//wpisywanie poszczególnych bajtów do tablicy
			GetBitmapBits((HBITMAP)hBitMap, rozmiar, lpBits);
			// alokacja pamieci
			bool ** tab;
			tab = (bool **)malloc(bitmapa.bmWidth * sizeof(bool*));
			for (int i = 0; i < bitmapa.bmWidth; i++) {
				tab[i] = (bool *)malloc(bitmapa.bmHeight * sizeof(bool));
			}

			//kopiowanie do tymczasowej tablicy
			int licznik = 0;
			for (int y = 0; y < bitmapa.bmHeight; y++) {
				for (int x = 0; x < bitmapa.bmWidth / 8; x++) {
					BYTE bajt = lpBits[licznik];
					for (int tmp = 7; tmp >= 0; tmp--) {
						tab[x * 8 + (7 - tmp)][y] = (bool)(bajt & (1 << tmp));
					}
					licznik++;
				}
				licznik++;
			}
			// obliczanie parametrow drukowania
			int n2 = bitmapa.bmWidth / 256;
			int n1 = bitmapa.bmWidth % 256;
			//druk
			for (int poziom = 0; poziom < bitmapa.bmHeight / 8; poziom++)
			{
				out << esc << "K" << (char)n1 << (char)n2;
				for (int x = 0; x < bitmapa.bmWidth; x++)
					out << (char)~((tab[x][poziom * 8] << 7) |
						(tab[x][poziom * 8 + 1] << 6) |
						(tab[x][poziom * 8 + 2] << 5) | 
						(tab[x][poziom * 8 + 3] << 4) | 
						(tab[x][poziom * 8 + 4] << 3) |
						(tab[x][poziom * 8 + 5] << 2) | 
						(tab[x][poziom * 8 + 6] << 1) |
						(tab[x][poziom * 8 + 7] << 0));
			}
		}

		
	}
	else
	{
		cout << "NIE DZIALA";
	}
	system("pause");
}

