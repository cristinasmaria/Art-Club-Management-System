using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace Desktop.Helpers
{
	public static class PasswordCryptor
	{
		private const string EncryptionKey = "37$A?!12#4";

		private static string SecureToUnsecureString(SecureString secureString)
		{
			if (secureString == null)
			{
				return string.Empty;
			}

			var unmanagedString = IntPtr.Zero;

			try
			{
				unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);

				return Marshal.PtrToStringUni(unmanagedString);
			}
			finally
			{
				Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
			}
		}

		public static string EncryptPassword(SecureString securePassword)
		{
			var password = SecureToUnsecureString(securePassword);

			if (string.IsNullOrWhiteSpace(password))
			{
				return null;
			}

			return Encrypt(password, EncryptionKey);
		}

		private static string Decrypt(string password, string encryptionKey)
		{
			var cipherBytes = Convert.FromBase64String(password);

			using (var encryptor = Aes.Create())
			{
				var pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[]
				{
					0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
				});

				encryptor.Key = pdb.GetBytes(32);
				encryptor.IV = pdb.GetBytes(16);

				using (var ms = new MemoryStream())
				{
					using (var cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
					{
						cs.Write(cipherBytes, 0, cipherBytes.Length);
						cs.Close();
					}

					password = Encoding.Unicode.GetString(ms.ToArray());
				}
			}

			return password;
		}

		private static string Encrypt(string password, string encryptionKey)
		{
			var clearBytes = Encoding.Unicode.GetBytes(password);

			using (var encryptor = Aes.Create())
			{
				var pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[]
				{
					0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
				});

				encryptor.Key = pdb.GetBytes(32);
				encryptor.IV = pdb.GetBytes(16);

				using (var ms = new MemoryStream())
				{
					using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
					{
						cs.Write(clearBytes, 0, clearBytes.Length);
						cs.Close();
					}

					password = Convert.ToBase64String(ms.ToArray());
				}
			}

			return password;
		}
	}
}
