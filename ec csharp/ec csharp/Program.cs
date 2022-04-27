using System.Security.Cryptography;
using System.Text;

public string Decrypt(string Text)
{
    string BOS = "";
    try
    {
        var privateKey = "aE7f03zE"; // secret key 
        var testDate = Encoding.UTF8.GetBytes(Text);
        using (var rsa = new RSACryptoServiceProvider(1024))
        {
            try
            {
                var base64Encrypted = Text;
                rsa.FromXmlString(privateKey);
                var resultBytes = Convert.FromBase64String(base64Encrypted);
                var decryptedBytes = rsa.Decrypt(resultBytes, true);
                var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                return decryptedData.ToString();
            }
            finally
            {
                rsa.PersistKeyInCsp = false;
            }
        }

    }
    catch { return BOS; }
}