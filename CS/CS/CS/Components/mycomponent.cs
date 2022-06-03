using System.ComponentModel;

namespace CipherLibrary
{
    public class CipherComponent : Component
    {
        public string Encode(string s)
        {
            string t = "";
            
            for(int i=0; i<s.Length; i++)
                t += (char) (s[i] + 1);

            return t;
        }

        public string Decode(string s)
        {
            string t = "";
            
            for(int i=0; i<s.Length; i++)
                t += (char) (s[i] - 1);

            return t;
        }
    }
}