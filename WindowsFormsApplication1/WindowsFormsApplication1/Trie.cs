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
            root = new node();
            root.value = '~';
            root.children = new List<node>();
            potentialWord = new List<string>();
        }




        //public struct node
        //{
        //    public char value;
        //    public List<node> children;
        //    public bool flag;
        //}


        public node start(string recieved)
        {
            
            node nextPtr = root;
            potentialWord.Add(recieved);
            for (int i = 0; i < recieved.Length; i++)
            {
                nextPtr = search(nextPtr, recieved[i]);
            }
            if (nextPtr.value == root.value)
            {
                nextPtr = new node();
                nextPtr.value = '!';
            }
            else
            {
                int start = 0;
                printWordsFromHereOn(nextPtr, start);    
            }


            return nextPtr;

        }

        private void printWordsFromHereOn(node startingLocation, int wordLocation)
        {
            
            for (int i = 0; i < (startingLocation.children.Count - 1);i++ )
            {
                potentialWord.Add(potentialWord[wordLocation]);
            }
            //bool newWord = false;
                for (int i = 0, k= 0; i < startingLocation.children.Count; i++, k++)
                {
                    potentialWord[wordLocation + k] += startingLocation.children[i].value;
                    if (startingLocation.children[i].flag && startingLocation.children[i].children.Count > 0)
                    {
                        potentialWord.Add(potentialWord[wordLocation + k]);
                        //newWord = true;
                        
                        printWordsFromHereOn(startingLocation.children[i], wordLocation + k);
                    }
                    else
                    {
                        wordLocation += k;
                        printWordsFromHereOn(startingLocation.children[i], wordLocation);
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

        private void lookForMore(node t)
        {

        }

        private node search(node n, char letter)
        {
            foreach (node element in n.children)
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

            node nextPtr = root;
            for (int i = 0; i < w.Length; i++)
            {
                bool temp = false;
                if (i == w.Length - 1)
                    temp = true;
                char x = w[i];
                nextPtr = insert(ref nextPtr, x, temp);
            }
        }

        private node insert(ref node n, char letter, bool end)
        {
            for (int i = 0; i < n.children.Count; i++)
            {
                if (n.children[i].value == letter)
                {
                    if (!(n.children[i].flag) && end)//stupid little work around cuz struct stuff in c#
                    {
                        n.children[i].flag = end;
                        //node temp = new node();
                        //temp.children = n.children;
                        //temp.value = n.value;
                        //temp.flag = end;
                        //n.children.RemoveAt(i);
                        //n.children.Add(temp);
                    }
                    return n.children[i];
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
