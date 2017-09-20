#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
#include <map>

using namespace std;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
int main()
{
    int N; // Number of elements which make up the association table.
    cin >> N; cin.ignore();
    int Q; // Number Q of file names to be analyzed.
    cin >> Q; cin.ignore();
    
    map<string, string> mapMime;
    
    for (int i = 0; i < N; i++) 
    {
        string EXT; // file extension
        string MT; // MIME type.
        cin >> EXT >> MT; cin.ignore();
        // to lower mime type
        transform(EXT.begin(), EXT.end(), EXT.begin(), (int(*)(int))tolower);
        // create map with extension as key and mime type description 
        mapMime.insert(make_pair(EXT, MT));
    }
    
    for (int i = 0; i < Q; i++) 
    {
        string FNAME;
        getline(cin, FNAME);
        
        // find last char in string
        int index = FNAME.find_last_of(".");
        
        // if find the char in string
        if (index != -1)
        {
            // search mime type
            string extSearch = FNAME.substr(index + 1, FNAME.length());
            transform(extSearch.begin(), extSearch.end(), extSearch.begin(), (int(*)(int))tolower);
            
            // search extension in map
            map<string, string>::iterator it = mapMime.find(extSearch);
            
            // check if find extension in map
            if (it != mapMime.end())
                cout << it->second << endl;
            else // found no extansion in map and throw unkown
                cout << "UNKNOWN" << endl;
        }
        else // found no point in string and throw unkown
            cout << "UNKNOWN" << endl;
        
    }
}