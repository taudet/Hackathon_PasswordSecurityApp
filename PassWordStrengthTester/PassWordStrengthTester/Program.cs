string incomingPassword = args[0];

string passwordList = "10-million-password-list-top-1000000.txt";

StreamReader reader = new StreamReader(passwordList);

bool passwordFound = false;
int passwordScore = 0;

string line;
while ((line = reader.ReadLine()) != null)
{

    if (line == incomingPassword)
    {
        passwordFound = true;
        passwordScore = passwordScore -100;
        break;
    }
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
    passwordScore += 1;
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
    passwordScore += 1;
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

Console.WriteLine(passwordScore);