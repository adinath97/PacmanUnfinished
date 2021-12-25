#include <iostream>
#include <string>
#include <time.h>

using namespace std;

int main() {
    //seed random number generator
    srand(time(NULL));

    string secretWords[5] = {"catatonic", "bazinga", "type", "dramatic", "touchdown"};

    string usedWords[5] = {"unused"};

    char playerGuessChar[10] = {0};

    string secretWord, playerGuess, word;

    const int ARRAY_LENGTH = sizeof(secretWords) / sizeof(secretWords[0]);

    const int TOTAL_TRIES = 5, TOTAL_QUESTIONS = 3;

    int numberCorrect = 0, totalQuestionsCompleted = 0, swapIndex = 0, tempMinIndex = 0, attempts = 0, totalPoints = 0, randomNumber = 0, lengthOfSecretWord = 0, arrayIndex = 0;

    bool foundValidWord = false;

    do {
            foundValidWord = false;
            randomNumber = rand() % ARRAY_LENGTH;
            word = secretWords[randomNumber];
            
            for(int i = 0; i < ARRAY_LENGTH; i++) {
                if(usedWords[i] == word) {
                    break;
                } else if(usedWords[i] != word && i == ARRAY_LENGTH - 1) {
                    //cout << word << endl;
                    foundValidWord = true;
                    usedWords[arrayIndex] = word;
                    arrayIndex++;
                }
            }
        } while(!foundValidWord);

        cout << word << endl;

        for(int i = 0; i < word.length(); i++) {
            if(playerGuessChar[i] == 0) {
                cout << " _ ";
            } else {
                cout << "HELLOOOOOO";
                cout << playerGuessChar[i];
            }
        }

    /*
    do {
        //pick random word that is new
        do {
            foundValidWord = false;
            randomNumber = rand() % ARRAY_LENGTH;
            word = secretWords[randomNumber];
            
            for(int i = 0; i < ARRAY_LENGTH; i++) {
                if(usedWords[i] == word) {
                    break;
                } else if(usedWords[i] != word && i == ARRAY_LENGTH - 1) {
                    //cout << word << endl;
                    foundValidWord = true;
                    usedWords[arrayIndex] = word;
                    arrayIndex++;
                }
            }
        } while(!foundValidWord);

        cout << word << endl;

        //core game loop

        do {
            for(int i = 0; i < word.length(); i++) {
                if(playerGuessChar[i] == 0) {
                    cout << " _ ";
                } else {
                    cout << "HELLOOOOOO";
                    cout << playerGuessChar[i];
                }
            }
        } while(0 == 1 /*attempts < TOTAL_TRIES && playerGuess != secretWord*/);
    } while(0 == 1 /*totalQuestionsCompleted < TOTAL_QUESTIONS*/);
    */

    return 0;
}