using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Trie dict = new Trie();//Inserting a couple words into dictionary for now later we will be deserializing a pre created dictionary
            dict.insert("hello");
            dict.insert("okay");

            Console.WriteLine(" 30 your here");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


        }
    }
}
