#pragma once
#include "pch.h"

extern "C" __declspec(dllexport) double __cdecl FirstCount(int num, double A[], int n, int i);

extern "C" double __declspec(dllexport) __stdcall SecondCount(int num, double A[], int n, int i);

