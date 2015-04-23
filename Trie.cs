using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace yo
{ 
    class Trie
    {

        public Trie()
        {
            root = new node();
            root.value = '~';
            root.children = new List<node>();
        }

        public struct node
        {
            public char value;
            public List<node> children;
            public bool flag;
        }

        public void insert(string w)
        {
      
           node nextPtr = root;
            for (int i = 0; i < w.Length; i++)
            {
                bool temp = false;
                if (i == w.Length - 1)
                    temp = true;
                char x = w[i];
                nextPtr = insert(ref nextPtr,x, temp);
            }
        }

        private node insert(ref node n, char letter, bool end)
        {
            foreach (node element in n.children)
            {
                if(element.value == letter)
                {
                    return element;
                }
            }

            node newNode = new node();
            newNode.value = letter;
            newNode.flag = end;
            newNode.children = new List<node>();
            n.children.Add(newNode);
            return newNode;
        }

        private node root;

    }
}
