namespace DesignPatterns.Utilities
{
	public interface ICypher
	{
		string Encrypt(string toEncrypt, string key);
        string Decrypt(string textToDecrypt, string key);
	}
}