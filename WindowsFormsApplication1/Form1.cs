using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dict = new Trie();

            /*
            dict.insert("hell");
            //dict.print();

            dict.insert("hello");
            //dict.print();

            
            Console.WriteLine("Matches for input \"hel\"");
            dict.find("hel");
            Console.WriteLine("\n");


            Console.WriteLine("Matches for input \"hele\"");
            dict.find("hele");
            Console.WriteLine("\n");

            Console.WriteLine("Matches for input \"e\"");
            dict.find("e");
            Console.WriteLine("\n");

            dict.insert("help");
            //dict.print();

            dict.insert("hat");
            //dict.print();

            dict.insert("heart");
            //dict.print();

            dict.insert("cat");
            //dict.print();

            dict.insert("cap");
            //dict.print();

            dict.insert("cater");
            //dict.print();

            dict.insert("caters");
            //dict.print();

            dict.insert("cool");
            //dict.print();

             */
            dict.insert("ace");
            dict.insert("brace");
            dict.insert("act");
            dict.insert("acting");
            dict.insert("action");
            dict.insert("blah");
            dict.insert("blood");
            dict.insert("hell");
            dict.insert("help");
            dict.insert("hello");

            dict.insert("eagerest");
            dict.insert("eardrums");
            dict.insert("earmuffs");
            dict.insert("earpiece");
            dict.insert("earstone");
            dict.insert("earthman");
            dict.insert("earthset");
            dict.insert("easiness");
            dict.insert("eatables");
            dict.insert("ebonite");
            dict.insert("ecbolics");
            dict.insert("ecdyson");
            dict.insert("echidnae");
            dict.insert("echogram");
            dict.insert("eclipsed");
            dict.insert("ecliptic");
            dict.insert("eclipsed");
            dict.insert("ecocidal");
            dict.insert("economic");
            dict.insert("ecotones");
            dict.insert("ecraseur");
            dict.insert("ectopias");
            dict.insert("ecumenic");
            dict.insert("edgeways");
            dict.insert("edifiers");
            dict.insert("editress");
            dict.insert("educator");
            dict.insert("eeriness");
            dict.insert("effecter");
            dict.insert("effetely");
            dict.insert("effluent");
            dict.insert("effulges");
            dict.insert("eftsoons");
            dict.insert("egestive");
            dict.insert("eggshell");
            dict.insert("egomania");
            dict.insert("egress");
            dict.insert("eighthly");
            dict.insert("einstein");
            dict.insert("ejective");

            //dict.find("blod");
            //dict.print();
            
            
        }


        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            TextBox tbox = (TextBox)sender;
            String text = tbox.Text;
            if (text.Length >= 1)
            {
                //Console.WriteLine("we here");
                Console.Clear();
                dict.start(text);
                Console.WriteLine("\n");
                //List<string> yourMother = dict.potentialWord;
                //Console.WriteLine("we here");
                //dict.potentialWord.Clear();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        public Trie dict;
    }
}
