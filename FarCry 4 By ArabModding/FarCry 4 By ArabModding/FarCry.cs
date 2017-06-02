using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarCry_4_By_ArabModding
{
    class FarCry
    {
        public static byte[] Nbyte(string str)
        {
            if (str == null || (str.Length % 2) == 1)
                return new byte[0];
            byte[] ret = new byte[str.Length / 2];
            for (int x = 0; x < str.Length; x += 2)
                ret[x / 2] = byte.Parse(sMid(str, x, 2), System.Globalization.NumberStyles.HexNumber);
            return ret;
        }
        public static string sMid(string text, int index, int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException("length", length, "length must be > 0");
            else if (length == 0 || text.Length == 0)
                return "";
            else if (text.Length < (length + index))
                return text;
            else
                return text.Substring(index, length);
        }

        public static void GodMode(bool Ar)
        {
            if (Ar)
            {
                Form1.AR.SetMemory(0x004D21D0, Nbyte("D04300104E8000203F847AE1"));
            }
            else
            {
                Form1.AR.SetMemory(0x004D21D0, Nbyte("480000044E8000203F847AE1"));
            }
        }

        public static void Ammo(bool Ar)
        {
            if (Ar)
            {
                Form1.AR.SetMemory(0x007895C8, Nbyte("7CA42B787C0428004182002C80C30050"));
            }
            else
            {
                Form1.AR.SetMemory(0x007895C8, Nbyte("7C9F28107C0428004182002C80C30050"));
            }
        }
        public static void InfItems(bool Ar)
        {
            if (Ar)
            {
                Form1.AR.SetMemory(0x0068E7DC, Nbyte("6000000038A0000138C000007C8407B4"));
            }
            else
            {
                Form1.AR.SetMemory(0x0068E7DC, Nbyte("7C9F201038A0000138C000007C8407B4"));
            }
        }
        public static void AmmoInReload(bool Ar)
        {
            if (Ar)
            {
                Form1.AR.SetMemory(0x0068D8D8, Nbyte("388003E8909D000038800001989E0021"));
            }
            else
            {
                Form1.AR.SetMemory(0x0068D8D8, Nbyte("7C832810909D000038800001989E0021"));
            }
        }
        public static void MaxSkill(bool Ar)
        {
            if (Ar)
            {
                Form1.AR.SetMemory(0x001AEBF4, Nbyte("38800063"));
            }
            else
            {
                Form1.AR.SetMemory(0x001AEBF4, Nbyte("809F0030"));
            }
        }

        public static void XPMP()
        {
            Form1.AR.SetMemory(0x010A2A54, Nbyte("1FC40064"));
        }
        public static void SetMoney(string stg)
        {
            Form1.AR.SetMemory(0x353350A0, BitConverter.GetBytes(Convert.ToUInt32(stg)));
        }
    }
}
