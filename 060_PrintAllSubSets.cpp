#include <cstdio>
#include <vector>
#include <algorithm>

using namespace std;


 void subsets(vector<int> &S, int startIndex, vector<int>& v , vector<vector<int> >& results){
        results.push_back(v);
        
        for(int i=startIndex; i<S.size(); i++){
            v.push_back(S[i]);
            subsets(S, i+1, v, results);
            v.pop_back();
        }
    }

    vector<vector<int> > subsets(vector<int> &S) {
        // Start typing your C/C++ solution below
        // DO NOT write int main() function
        sort(S.begin(), S.end());
        vector<vector<int> > results;
        vector<int> v;
        subsets(S, 0 , v, results);
        return results;
    }

void printVector(const vector<int>& v){
	int size=v.size();
	for (int i=0; i<size; i++) {
		printf("%d ", v[i]);
	}
}


vector<vector<int> > subsets(vector<int> &S) {
    sort(S.begin(), S.end());
    vector<vector<int> > v(1);
    for(int i = 0; i < S.size(); ++i) {
        int j = v.size();
		//printf("size of %d\n", j);
        while(j-- > 0) {
			//printVector(v[j]);
			//printf("\n");
			printf("j is %d and i is %d  and v size is %d\n", j, i, v.size());
            v.push_back(v[j]);
			printf("pushed is %d\n", S[i]);
            v.back().push_back(S[i]);
        }
    }
    return v;
}


int main(int argc, char *argv[]) {
	vector<int> v;
	v.push_back(1);
	v.push_back(2);
	v.push_back(3);
	
	vector<vector<int> > s=subsets(v);
	int size=s.size();
	for(int i=0; i<size; i++){
		printVector(s[i]);
		printf("\n");
	}
}