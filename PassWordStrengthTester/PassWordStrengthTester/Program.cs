

string incomingPassword = args[0];

string passwordList = "C:ProjectFiles\\10-million-password-list-top-10000.txt";

StreamReader reader = new StreamReader(passwordList);

bool passwordFound = false;

while (true)
{
    string line = reader.ReadLine();

    if (line == incomingPassword)
    {
        passwordFound = true;
        break;
    }
}