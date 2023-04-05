#include "pch.h"

__declspec(dllexport)
void SendKeypress(int key, bool held)
{
    // test export
}

__declspec(dllexport)
void HookKeypress(void* detour)
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