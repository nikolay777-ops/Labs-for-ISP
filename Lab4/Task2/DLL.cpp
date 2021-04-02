#include "pch.h"
#include "DLL.h"

extern "C" __declspec(dllexport) double __cdecl FirstCount(int num, double A[], int n, int i)
{
	if (i == -1)
	{
		return 0;
	}
	else
	{
		if (num > A[i])
		{
			return FirstCount(num, A, n, --i) + 1;
		}
		else
		{
			return FirstCount(num, A, n, --i);
		}
	}
}
extern "C" double __declspec(dllexport) __stdcall SecondCount(int num, double A[], int n, int i)
{
	if (i == n)
	{
		return 0;
	}
	else
	{
		if (num > A[i])
		{
			return SecondCount(num, A, n, --i) + 1;
		}
		else
		{
			return SecondCount(num, A, n, --i);
		}
	}
}
