using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApplication1
{
    public class Trie
    {
        public List<string> potentialWord;

        public Trie()
        {
            root = new Node();
            root.value = '~';
            root.children = new List<Node>();
            potentialWord = new List<string>();
        }




        public struct Node
        {
            public char value;
            public List<Node> children;
            public bool flag;
        }


        public Node start(string recieved)
        {
            
            Node nextPtr = root;
            potentialWord.Add(recieved);
            for (int i = 0; i < recieved.Length; i++)
            {
                nextPtr = search(nextPtr, recieved[i]);
            }
            if (nextPtr.value == root.value)
            {
                nextPtr = new Node();
                nextPtr.value = '!';
            }
            else
            {
                printWordsFromHereOn(nextPtr, 0);    
            }


            return nextPtr;

        }

        private void printWordsFromHereOn(Node startingLocation, int wordLocation)
        {
            for (int i = 0; i < (startingLocation.children.Count - 1);i++ )
            {
                potentialWord.Add(potentialWord[wordLocation]);
            }

                for (int i = 0, k= 0; i < startingLocation.children.Count; i++, k++)
                {
                    if (!(startingLocation.flag))
                    {
                        potentialWord[wordLocation + k] += startingLocation.children[i].value;//
                        printWordsFromHereOn(startingLocation.children[i], wordLocation + k);//testing this with ks
                    }
                    else
                    {
                        potentialWord.Add(potentialWord[wordLocation + k]);
                        k++;
                        potentialWord[wordLocation + k] += startingLocation.children[i].value;
                        printWordsFromHereOn(startingLocation.children[i], wordLocation + k);
                        Console.WriteLine("blah");
                    }
                }
            //foreach (node element in startingLocation.children)
            //{
            //    potentialWord[wordLocation] += element.value;
            //    if (element.flag == true && startingLocation.children.Count > 1)
            //    {

            //        potentialWord.Add(potentialWord[wordLocation]);
            //        printWordsFromHereOn(startingLocation.children[i], (wordLocation + 1));
            //    }
            //    else
            //        printWordsFromHereOn(element, wordLocation);
            //    i++;
            //}

        //    return new node;
        }

        private void lookForMore(Node t)
        {

        }

        private Node search(Node n, char letter)
        {
            foreach (Node element in n.children)
            {
                if (element.value == letter)
                {
                    return element;
                }
            }
            return n;
        }

        public void insert(string w)
        {

            Node nextPtr = root;
            for (int i = 0; i < w.Length; i++)
            {
                bool temp = false;
                if (i == w.Length - 1)
                    temp = true;
                char x = w[i];
                nextPtr = insert(ref nextPtr, x, temp);
            }
        }

        private Node insert(ref Node n, char letter, bool end)
        {
            
            for (int i = 0; i < n.children.Count; i++)
            {

                if (n.children[i].value == letter)
                {
                    if (!n.children[i].flag && end)//stupid little work around cuz struct stuff in c#
                    {
                       //n.children[i].flag = end;
                        Node temp = new Node();
                        temp.children = n.children;
                        temp.value = n.value;
                        temp.flag = end;
                        n.children.RemoveAt(i);
                        n.children.Add(temp);

                    }
                   
                    return n.children[i];
                }
            }

            Node newNode = new Node();
            newNode.value = letter;
            newNode.flag = end;
            newNode.children = new List<Node>();
            n.children.Add(newNode);
            return newNode;
        }

        private Node root;

    }
}
