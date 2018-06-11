namespace PracticeQuestionsSharp.Exercises.Bits
{
    //A monochrome screen is stored as a single array of bytes, allowing eight consecutive pixels to be stored in one byte. 
    //The screen has width w, where w is divisible by 8 (that is, no byte will be split across rows). 
    //The height of the screen, of course, can be derived from the length of the array and the width.
    //Implement a function that draws a horizontal line from(xl, y) to(x2, y).
    //Function signiture: drawLine(byte[] screen, int width, int x, int x2, int y)
    public static class DrawLine
    {
        public static void DrawBitLine(byte[] screen, int width, int x, int x2, int y)
        {
            int byte1 = x / 8;
            int byte2 = x2 / 8;
            int bit1 = x % 8;
            int bit2 = x2 % 8;

            for (int i = bit1; i != 8; ++i)
            {
                screen[byte1] = screen[byte1].SetNthBit(i);
            }

            for (int i = bit2; i != 0; --i)
            {
                screen[byte2] = screen[byte2].SetNthBit(i);
            }

            //set bytes between x1 and x2 to 1s
            int byteIndex = byte1 + 1;

            if (byteIndex >= byte2) return;

            while (byteIndex != byte2)
            {
                screen[byteIndex] = 255;
                byteIndex++;
            }
        }

        public static byte SetNthBit(this byte b, int n)
        {
            return (byte)(b | (1 << n));
        }
    }
}
