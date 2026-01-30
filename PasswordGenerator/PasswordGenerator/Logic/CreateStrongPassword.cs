using System.Security.Cryptography;

namespace PasswordGenerator.Logic;

public class CreateStrongPassword
{
    private const string Upper = "ABCDEFGHIGKLMNOPQRSTUVWXYZ";
    private const string Lower = "abcdefghijklmnopqrstuvwxyz";
    private const string Number = "0123456789";
    private const string Symbol = "!@#$%^&*+-=:;()";
    private const string All = Upper + Lower + Number + Symbol;

    public string Generate(int size)
    {
        if (size < 4) size = 14;

        char[] password = new char[size];
        
        password[0] = Upper[RandomNumberGenerator.GetInt32(Upper.Length)];
        password[1] = Lower[RandomNumberGenerator.GetInt32(Lower.Length)];
        password[2] = Number[RandomNumberGenerator.GetInt32(Number.Length)];
        password[3] = Symbol[RandomNumberGenerator.GetInt32(Symbol.Length)];
        
        for (int i = 4; i < size; i++)
        {
            password[i] = All[RandomNumberGenerator.GetInt32(All.Length)];
        }
        
        for (int i = password.Length - 1; i > 0; i--)
        {
            int j = RandomNumberGenerator.GetInt32(i + 1);
            (password[i], password[j]) = (password[j], password[i]);
        }

        return new string(password);
    }
}