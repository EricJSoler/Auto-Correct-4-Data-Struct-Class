﻿using System;
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
            dict.insert("act");
            dict.insert("ace");
            dict.insert("hello");
            dict.insert("blah");
            
        }


        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            TextBox tbox = (TextBox)sender;
            String text = tbox.Text;
            if (text.Length >= 2)

                       

            Console.WriteLine("we here");
            dict.start(text);
            List<string> yourMother = dict.potentialWord;
            Console.WriteLine("we here");
            dict.potentialWord.Clear();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        public Trie dict;
    }
}