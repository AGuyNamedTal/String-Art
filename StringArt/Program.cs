using System;
using System.Windows.Forms;

namespace StringArt
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        public static void Swap<T>(ref T obj1, ref T obj2)
        {
            T tmp = obj1;
            obj1 = obj2;
            obj2 = tmp;
        }
    }
}
