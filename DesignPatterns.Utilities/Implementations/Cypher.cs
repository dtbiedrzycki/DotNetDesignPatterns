using System;
using System.Security.Cryptography;
using System.Text;

namespace DesignPatterns.Utilities.Implementations
{
	public class Cypher : ICypher
	{
		// Kudos to http://www.codeproject.com/Articles/14150/Encrypt-and-Decrypt-Data-with-C
		public string Encrypt(string toEncrypt, string key)
		{
			byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

			TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
			//set the secret key for the tripleDES algorithm

			MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
			byte[] keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
			//Always release the resources and flush data
			// of the Cryptographic service provide. Best Practice
			hashmd5.Clear();

			tdes.Key = keyArray;
			tdes.Mode = CipherMode.ECB;
			//padding mode(if any extra byte added)
			tdes.Padding = PaddingMode.PKCS7;

			ICryptoTransform cTransform = tdes.CreateEncryptor();
			//transform the specified region of bytes array to resultArray
			byte[] resultArray =
			  cTransform.TransformFinalBlock(toEncryptArray, 0,
			  toEncryptArray.Length);
			//Release resources held by TripleDes Encryptor
			tdes.Clear();
			//Return the encrypted data into unreadable string format
			return Convert.ToBase64String(resultArray, 0, resultArray.Length);
		}

		public string Decrypt(string cipherString, string key)
		{
			byte[] keyArray;
			//get the byte code of the string

			byte[] toEncryptArray = Convert.FromBase64String(cipherString);

			//Get your key from config file to open the lock!
			MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
			keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
			//Always release the resources and flush data
			// of the Cryptographic service provide. Best Practice
			hashmd5.Clear();


			TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
			//set the secret key for the tripleDES algorithm
			tdes.Key = keyArray;
			tdes.Mode = CipherMode.ECB;
			//padding mode(if any extra byte added)
			tdes.Padding = PaddingMode.PKCS7;

			ICryptoTransform cTransform = tdes.CreateDecryptor();
			byte[] resultArray = cTransform.TransformFinalBlock(
								 toEncryptArray, 0, toEncryptArray.Length);
			//Release resources held by TripleDes Encryptor                
			tdes.Clear();
			//return the Clear decrypted TEXT
			return UTF8Encoding.UTF8.GetString(resultArray);
		}
	}
}