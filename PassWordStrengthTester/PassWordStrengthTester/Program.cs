string incomingPassword = args[0];

string passwordList = "10-million-password-list-top-1000000.txt";
string DictionaryList = "words.txt";



int passwordScore = 0;


bool isWordFoundList = isWordInList(incomingPassword, passwordList);
bool isWordFoundDictionary = isWordInList(incomingPassword, passwordList);

if (isWordFoundList || isWordFoundDictionary)
{
    passwordScore = -100;
    return passwordScore;
}


int specialCharCount = 0;
int intCount = 0;
int alphaCount = 0;

for (int i = 0; i < incomingPassword.Length; i++)
{
    if (!char.IsLetterOrDigit(incomingPassword[i]))
    {
        specialCharCount++;
    }
    else if (char.IsDigit(incomingPassword[i]))
    {
        intCount++;
    }
    else
    {
        alphaCount++;
    }
}


if (specialCharCount == 0)
{
    passwordScore = passwordScore - 2;
}
else if (specialCharCount == 1)
{
    passwordScore--;
}
else
{
    passwordScore++;
}

if (intCount == 0)
{
    passwordScore -= 2;
}
else if (intCount > 0 && intCount <= 6)
{
    passwordScore --;
}
else
{
    passwordScore ++;
}

if (alphaCount == 0)
{
    passwordScore -= 2;
}
else if (alphaCount > 0 && intCount <= 6)
{
    passwordScore--;
}
else
{
    passwordScore ++;
}

if (incomingPassword.Length <= 5)
{
    passwordScore -= 2;
}
else if(incomingPassword.Length <= 10 && incomingPassword.Length >= 6)
{
    passwordScore --;
}
else if (incomingPassword.Length <= 11 && incomingPassword.Length >= 16)
{
    passwordScore++;
}
else
{
    passwordScore += 2;
}

int consecutiveChar = ConsecutiveChar(incomingPassword);

if (consecutiveChar == 1)
{
    passwordScore += 2;
}
else if (consecutiveChar == 2)
{
    passwordScore++;
}
else if (consecutiveChar == 3)
{
    passwordScore--;
}
else
{
    passwordScore -= 2;
}


Console.WriteLine(passwordScore);

return passwordScore;

bool isWordInList(string incomingPassword, string wordTextFile)
{
    StreamReader reader = new StreamReader(passwordList);

    bool passwordFound = false;

    string line;
    while ((line = reader.ReadLine()) != null)
    {

        if (line == incomingPassword)
        {
            passwordFound = true;
            break;
        }
    }
    reader.Close();

    return passwordFound;
}

int ConsecutiveChar(string passWord)
{
    int highestCharCount = 1;
    int currentCharCount = 1;
    char previousChar = ' ';

    foreach(char c in passWord)
    {
        if (c == previousChar)
        {
            currentCharCount ++;
        }
        else if (c != previousChar && currentCharCount != 0)
        {
            if (currentCharCount > highestCharCount)
            {
                highestCharCount = currentCharCount;
            }
            currentCharCount = 1;
        }
        previousChar = c;
    }
    return highestCharCount;
}
