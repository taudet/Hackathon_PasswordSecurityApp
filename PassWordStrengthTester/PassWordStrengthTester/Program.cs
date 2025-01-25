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

for (int i = 0; i < incomingPassword.Length; i++)
{
    if (!char.IsLetterOrDigit(incomingPassword[i]))
    {
        specialCharCount++;
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

if (incomingPassword.Length <= 5)
{
    passwordScore = passwordScore - 2;
}
else if( incomingPassword.Length <= 10 && incomingPassword.Length >= 6)
{

}