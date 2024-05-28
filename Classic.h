#pragma once
#include "Classic.h"
#include <cstring>
#include <iostream>

class Cd
{
private:
	char performers[50];
	char label[20];
	int selections;			// Количество сборников
	double playtime;		// Время воспроизведения в минутах
public:
	Cd(const char* s1, const char* s2, int n, double x);
	Cd(const Cd& other) = default;
	Cd() = default;
	~Cd() = default;
	void Report() const; // Выводит все данные о CD
	Cd& operator=(const Cd& other);
};

class Classic : public Cd
{
private:
	char mainSong[50];
public:
	Classic() = default;
	Classic(const char* s1, const char* s2, const char* s3, int n, double x);
};

Cd::Cd(const char* s1, const char* s2, int n, double x) : selections(n), playtime(x)
{
	strcpy_s(performers, strlen(performers + 1), s1);
	strcpy_s(label, strlen(label + 1), s2);
}

void Cd::Report() const
{
	std::cout << "Performers: " << performers << "\n" << "Label: " << label << "\n";
	std::cout << "Selections: " << selections << "\n" << "Playtime: " << playtime << "\n" << std::endl;
}

Classic::Classic(const char* s1, const char* s2, const char* s3, int n, double x) : Cd(s2, s3, n, x)
{
	strcpy_s(mainSong, strlen(mainSong + 1), s1);
}

Cd& Cd::operator=(const Cd& other)
{
	strcpy_s(performers, strlen(performers + 1), other.performers);
	strcpy_s(label, strlen(label + 1), other.label);
	return *this;
}
