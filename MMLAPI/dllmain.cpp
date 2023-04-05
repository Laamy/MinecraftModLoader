#include "pch.h"

void InitAPI()
{
    // test export
}

BOOL APIENTRY DllMain(HMODULE module, DWORD reason, LPVOID reserved)
{
    if (reason == DLL_THREAD_ATTACH)
    {

    }
    return TRUE;
}