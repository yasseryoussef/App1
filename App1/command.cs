using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App1
{
    public class command
    {
        private static byte ESC = 27;
        private static byte FS = 28;
        private static byte GS = 29;
        private static byte US = 31;
        private static byte DLE = 16;
        private static byte DC4 = 20;
        private static byte DC1 = 17;
        private static byte SP = 32;
        private static byte NL = 10;
        private static byte FF = 12;
        public static byte PIECE = 1;
        public static byte NUL = 0;

        public static byte[] SELECT_BIT_IMAGE_MODE = { 0x1B, 0x2A, 33, (byte)255, 0 };
        public static byte[] ESC_Init = new byte[] { (byte)27, (byte)64 };
        public static byte[] LF = new byte[] { (byte)10 };
        public static byte[] ESC_J = new byte[] { (byte)27, (byte)74, (byte)0 };
        public static byte[] ESC_d = new byte[] { (byte)27, (byte)100, (byte)0 };
        public static byte[] US_vt_eot = new byte[] { (byte)31, (byte)17, (byte)4 };
        public static byte[] ESC_B_m_n = new byte[] { (byte)27, (byte)66, (byte)0, (byte)0 };
        public static byte[] GS_V_n = new byte[] { (byte)29, (byte)86, (byte)0 };
        public static byte[] GS_V_m_n = new byte[] { (byte)29, (byte)86, (byte)66, (byte)0 };
        public static byte[] GS_i = new byte[] { (byte)27, (byte)105 };
        public static byte[] GS_m = new byte[] { (byte)27, (byte)109 };
        public static byte[] ESC_SP = new byte[] { (byte)27, (byte)32, (byte)0 };
        public static byte[] ESC_ExclamationMark = new byte[] { (byte)27, (byte)33, (byte)0 };
        public static byte[] GS_ExclamationMark = new byte[] { (byte)29, (byte)33, (byte)0 };
        public static byte[] GS_B = new byte[] { (byte)29, (byte)66, (byte)0 };
        public static byte[] ESC_V = new byte[] { (byte)27, (byte)86, (byte)0 };
        public static byte[] ESC_M = new byte[] { (byte)27, (byte)77, (byte)0 };
        public static byte[] ESC_G = new byte[] { (byte)27, (byte)71, (byte)0 };
        public static byte[] ESC_E = new byte[] { (byte)27, (byte)69, (byte)0 };
        public static byte[] ESC_LeftBrace = new byte[] { (byte)27, (byte)123, (byte)0 };
        public static byte[] ESC_Minus = new byte[] { (byte)27, (byte)45, (byte)0 };
        public static byte[] FS_dot = new byte[] { (byte)28, (byte)46 };
        public static byte[] FS_and = new byte[] { (byte)28, (byte)38 };
        public static byte[] FS_ExclamationMark = new byte[] { (byte)28, (byte)33, (byte)0 };
        public static byte[] FS_Minus = new byte[] { (byte)28, (byte)45, (byte)0 };
        public static byte[] FS_S = new byte[] { (byte)28, (byte)83, (byte)0, (byte)0 };
        public static byte[] ESC_t = new byte[] { (byte)27, (byte)116, (byte)0 };
        public static byte[] ESC_Two = new byte[] { (byte)27, (byte)50 };
        public static byte[] ESC_Three = new byte[] { (byte)27, (byte)51, (byte)0 };
        public static byte[] ESC_Align = new byte[] { (byte)27, (byte)97, (byte)0 };
        public static byte[] GS_LeftSp = new byte[] { (byte)29, (byte)76, (byte)0, (byte)0 };
        public static byte[] ESC_Relative = new byte[] { (byte)27, (byte)36, (byte)0, (byte)0 };
        public static byte[] ESC_Absolute = new byte[] { (byte)27, (byte)92, (byte)0, (byte)0 };
        public static byte[] GS_W = new byte[] { (byte)29, (byte)87, (byte)0, (byte)0 };
        public static byte[] DLE_eot = new byte[] { (byte)16, (byte)4, (byte)0 };
        public static byte[] DLE_DC4 = new byte[] { (byte)16, (byte)20, (byte)0, (byte)0, (byte)0 };
        public static byte[] ESC_p = new byte[] { (byte)27, (byte)70, (byte)0, (byte)0, (byte)0 };
        public static byte[] GS_H = new byte[] { (byte)29, (byte)72, (byte)0 };
        public static byte[] GS_h = new byte[] { (byte)29, (byte)104, (byte)94 };
        public static byte[] GS_w = new byte[] { (byte)29, (byte)119, (byte)0 };
        public static byte[] GS_f = new byte[] { (byte)29, (byte)102, (byte)0 };
        public static byte[] GS_x = new byte[] { (byte)29, (byte)120, (byte)0 };
        public static byte[] GS_k = new byte[] { (byte)29, (byte)107, (byte)65, (byte)12 };
        public static byte[] GS_k_m_v_r_nL_nH = new byte[] { (byte)27, (byte)90, (byte)3, (byte)3, (byte)8, (byte)0, (byte)0 };

        public command()
        {
        }
    }
}