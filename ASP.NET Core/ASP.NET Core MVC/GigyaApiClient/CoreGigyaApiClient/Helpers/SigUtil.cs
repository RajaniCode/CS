using System;
using System.Text;
using Newtonsoft.Json;

namespace Helpers.Gigya.Socialize.SDK
{
    public static class SigUtil
    {
        public static byte[] FromBase64UrlString(this string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException("string is null");
            }

            // Taken from JWT spec
            var output = str;
            output = output.Replace('-', '+'); // 62nd char of encoding
            output = output.Replace('_', '/'); // 63rd char of encoding
            switch (output.Length % 4)
            {
                // Pad with trailing '='s
                case 0:
                    break; // No pad chars in this case
                case 2:
                    output += "==";
                    break; // Two pad chars
                case 3:
                    output += "=";
                    break; // One pad char
                default:
                    throw new FormatException("Illegal base64url string!");
            }
            return Convert.FromBase64String(output); // Standard base64 decoder
        }
        
        public static T Deserialize<T>(string sourceBase64) => JsonConvert.DeserializeObject<T>(sourceBase64.FromBase64UrlString().GetString());
        
        public static string GetString(this byte[] buf, Encoding encoding = null)
        {
            return (encoding ?? Encoding.UTF8).GetString(buf);
        }

        public static T SafeNoException<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch
            {
                return default(T);
            }
        }
        
        public static bool IsTimestampValid(long timestamp, int allowDiffSec)
        {
            var unixTimeStartUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var offset = DateTime.UtcNow - unixTimeStartUtc.AddSeconds(timestamp);
            return Math.Abs(offset.TotalSeconds) < allowDiffSec;
        }
    }
}
