using System;
using System.Text;

public class AWHash
{
    private AWHash()
    {
    }

    public static string Encrypt(int id)
    {
        byte[] sourceConverted;
        ASCIIEncoding sourceEncoder = new ASCIIEncoding();

        try
        {
            sourceConverted = sourceEncoder.GetBytes((id + 731415926).ToString());
            return Convert.ToBase64String(sourceConverted, 0, sourceConverted.Length);
        }
        catch
        {
            return "error";
        }
    }

    public static string EncryptString(string id)
    {
        byte[] sourceConverted;
        ASCIIEncoding sourceEncoder = new ASCIIEncoding();

        try
        {
            sourceConverted = sourceEncoder.GetBytes(id);
            return Convert.ToBase64String(sourceConverted, 0, sourceConverted.Length);
        }
        catch
        {
            return "error";
        }
    }

    public static int Decrypt(string id)
    {
        UTF8Encoding stringDecoder = new UTF8Encoding();
        string decryptedString = "";

        try
        {
            decryptedString = stringDecoder.GetString(Convert.FromBase64String(id));
            return Convert.ToInt32(decryptedString) - 731415926;
        }
        catch
        {
            return 0;
        }
    }

    public static string DecryptString(string id)
    {
        UTF8Encoding stringDecoder = new UTF8Encoding();

        try
        {
            return stringDecoder.GetString(Convert.FromBase64String(id));
        }
        catch
        {
            return "";
        }
    }
}