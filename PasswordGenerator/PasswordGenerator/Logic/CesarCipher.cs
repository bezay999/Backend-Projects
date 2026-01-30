namespace PasswordGenerator.Logic;

public class CesarCipher
{
    public string Text { get; set; } = string.Empty;

    private readonly char[] alphabet =
    {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
        'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ' ', '.', ','
    };

    public char[] NewText { get; private set; } = Array.Empty<char>();
    public char[] EncryptedText { get; private set; } = Array.Empty<char>();

    public string Encrypt()
    {
        Text = Text.ToLower();
        NewText = Text.ToCharArray();
        EncryptedText = new char[NewText.Length];

        for (int i = 0; i < NewText.Length; i++)
        {
            int index = Array.IndexOf(alphabet, NewText[i]);

            if (index < 23)
            {
                index += 3;
            }
            else if (index >= 23 && index < 26)
            {
                index = index - 23; // find a solution
            }
            else if (index == -1)
            {
                EncryptedText[i] = NewText[i];
                continue;
            }
            else
            {
                // if index >= 26, then index = index
            }

            EncryptedText[i] = alphabet[index];
        }

        return new string(EncryptedText);
    }
}