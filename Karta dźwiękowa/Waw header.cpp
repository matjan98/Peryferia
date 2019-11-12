#include <iostream>
#include <string>
#include <fstream>
#include <cstdint>

#pragma warning(disable : 4996)

using namespace std;

int main()
{
	//RIFF
	char				RIFF[5];        
	unsigned long       chunkSize;      
	char				WAVE[5];       
	//FMT
	char				FMT[4];        
	unsigned long       subchunk1Size;
	short				audioFormat;    
	short				numChannels;     
	unsigned long       sampleRate;
	unsigned long       byteRate;
	short				blockAlign;     
	short				bitsPerSample;  
	//DATA
	char				dataSubchunk[4]; 
	unsigned long       subchunk2Size;  


	FILE *plik = fopen("bird.wav", "rb");
	if (plik)
	{
		
	}
	else
	{
		cout << "Nie udalo sie otworzyc pliku" << endl;
	}

	fread(RIFF, sizeof(char), 4, plik);
	RIFF[4] = '\0';

	if (!strcmp(RIFF, "RIFF"))
	{
		fread(&chunkSize, sizeof(unsigned long), 1, plik);
		fread(WAVE, sizeof(char), 4, plik);
		WAVE[4] = '\0';

		if (!strcmp(WAVE, "WAVE"))
		{
			fread(FMT, sizeof(char), 4, plik);
			fread(&subchunk1Size, sizeof(unsigned long), 1, plik);
			fread(&audioFormat, sizeof(short), 1, plik);
			fread(&numChannels, sizeof(short), 1, plik);
			fread(&sampleRate, sizeof(unsigned long), 1, plik);
			fread(&byteRate, sizeof(unsigned long), 1, plik);
			fread(&blockAlign, sizeof(short), 1, plik);
			fread(&bitsPerSample, sizeof(short), 1, plik);
			fread(dataSubchunk, sizeof(char), 4, plik);
			fread(&subchunk2Size, sizeof(unsigned long), 1, plik);
		}
		
	}


	cout << "Dane pliku zczytywane w kolejnosci:" << endl << endl;

	cout << "Naglowek RIFF: " << RIFF[0] << RIFF[1] << RIFF[2] << RIFF[3] << endl;
	cout << "Rozmiar danych: " << chunkSize << endl;
	cout << "Format: " << WAVE[0] << WAVE[1] << WAVE[2] << WAVE[3] << endl;
	cout << "Naglowek FMT: " << FMT[0] << FMT[1] << FMT[2] << FMT[3] << endl;
	cout << "Rozmiar FMT: " << subchunk1Size << endl;
	cout << "Format dzwieku: " << audioFormat << endl;
	cout << "Liczba kanalow: " << numChannels << endl;
	cout << "Czestotliwosc probkoawnia: " << sampleRate << endl;
	cout << "Ilosc bajtow: " << byteRate << endl;
	cout << "Blokowanie wyrownania: " << blockAlign << endl;
	cout << "Ilosc bitow na probke: " << bitsPerSample << endl;
	cout << "Naglowek danych: " << dataSubchunk[0] << dataSubchunk[1] << dataSubchunk[2] << dataSubchunk[3] << endl;
	cout << "Rozmiar danych: " << subchunk2Size << endl << endl;
	
	fclose(plik);


	system("pause");
	return 0;
}