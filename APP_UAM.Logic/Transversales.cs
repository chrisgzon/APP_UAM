using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace APP_UAM.Logic
{
    public class Transversales
    {
        public static string convertirSha256(string text)
        {
			try
			{
                StringBuilder sb = new StringBuilder();
				using (SHA256 hash = SHA256.Create())
				{
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    byte[] result = hash.ComputeHash(Encoding.UTF8.GetBytes(text));
					foreach (byte b in result)
                        sb.AppendFormat("{0:x2}", b);
                }
				return sb.ToString();
			}
			catch (Exception)
			{
				return string.Empty;
			}
        }
    }
}