using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using ZJ.Com.Customize.Sdk;

namespace App1
{
    class PrintPicture
    {
        public PrintPicture()
        {
        }
        public static byte[] POS_PrintBMP(Android.Graphics.Bitmap mBitmap, int nWidth, int nMode)
        {
            try
            {
                int width = (nWidth + 7) / 8 * 8;
                int height = mBitmap.Height * width / mBitmap.Width;
                height = (height + 7) / 8 * 8;
                Bitmap rszBitmap = mBitmap;
                if (mBitmap.Width != width)
                {
                    rszBitmap = Other.ResizeImage(mBitmap, width, height);
                }

                Bitmap grayBitmap = Other.ToGrayscale(rszBitmap);
                byte[] dithered = Other.ThresholdToBWPic(grayBitmap);
                byte[] data = Other.EachLinePixToCmd(dithered, width, nMode);
                return data;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static Bitmap resize_bitmap(Android.Graphics.Bitmap mBitmap, int nWidth, int nMode)
        {

            try
            {
                int width = (nWidth + 7) / 8 * 8;
                int height = mBitmap.Height * width / mBitmap.Width;
                height = (height + 7) / 8 * 8;
                Bitmap rszBitmap = mBitmap;
                if (mBitmap.Width != width)
                {
                    rszBitmap = Other.ResizeImage(mBitmap, width, height);
                }

                Bitmap grayBitmap = Other.ToGrayscale(rszBitmap);

                return grayBitmap;
            }
            catch (Exception ex)
            {

                return null;
            }

        }

        public static byte[] Print_1D2A(Bitmap bmp)
        {
            int width = bmp.Width;
            int height = bmp.Height;
            byte[] data = new byte[10240];
            data[0] = 29;
            data[1] = 42;
            data[2] = (byte)((width - 1) / 8 + 1);
            data[3] = (byte)((height - 1) / 8 + 1);
            byte k = 0;
            int position = 4;
            byte temp = 0;

            int i;
            int j;
            for (i = 0; i < width; ++i)
            {
                Console.WriteLine("进来了...I");

                for (j = 0; j < height; ++j)
                {
                    Console.WriteLine("进来了...J");
                    if (bmp.GetPixel(i, j) != -1)
                    {
                        temp = (byte)(temp | 128 >> k);
                    }

                    ++k;
                    if (k == 8)
                    {
                        data[position++] = temp;
                        temp = 0;
                        k = 0;
                    }
                }

                if (k % 8 != 0)
                {
                    data[position++] = temp;
                    temp = 0;
                    k = 0;
                }
            }

            Console.WriteLine("data" + data);
            if (width % 8 != 0)
            {
                i = height / 8;
                if (height % 8 != 0)
                {
                    ++i;
                }

                j = 8 - width % 8;

                for (k = 0; k < i * j; ++k)
                {
                    data[position++] = 0;
                }
            }

            return data;
        }
    }
}