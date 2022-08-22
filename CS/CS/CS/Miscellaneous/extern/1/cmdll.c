// cmdll.c

int __declspec(dllexport) SampleMethod(int i)
{
       return i*10;
}


// >cl /LD cmdll.c

// OR

// >cl /LD /MD cmdll.c // Note: Creates additional file: cmdll.dll.manifest // *Doesn't work
