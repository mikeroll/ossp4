#include "z.h"

#include <string>

int Z(const char *word, const char *str)
{
    std::string s_word(word), s_str(str); 
    int n = 0;
    std::string::size_type pos = 0;
    while( (pos = s_str.find(s_word, pos )) 
                 != std::string::npos ) {
        n++;
        pos += s_word.size();
    }
    return n;
}

