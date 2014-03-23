#include "z.h"

#include <string.h>

int Z(const char *word, const char *str)
{
    int wordlength = strlen(word);
    int n = 0;
    char *pos = (char *)str;
    while( (pos = strstr(pos, (char *)word)) != NULL ) {
        n++;
        pos += wordlength;
    }
    return n;
}

