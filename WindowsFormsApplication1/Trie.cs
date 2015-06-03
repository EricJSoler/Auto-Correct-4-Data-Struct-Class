using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApplication1
{
    public class Trie
    {
        private node root;
        
        public List<string> potentialWord;

        public Trie()
        {
            root = new node();
            //root.value = null;
            root.level = 0;
            //root.children = new List<node>();
            potentialWord = new List<string>();
        }


        public void start(string recieved)
        {
            findMatch(root, recieved);
        }

        public void find(string input)
        {
            findMatch(root, input);
        }

        private void findMatch(node currentNode, string input)
        {
            // search all children of the root node for matches (root is node with level 0)
            if(currentNode.level == 0 && currentNode.children.Count !=0)
            {
                bool matchFound = false;

                for (int i = 0; i < currentNode.children.Count; i++)
                {
                    // if match in root, call findMatch with node
                    if (currentNode.children[i].value[0] == input[0])
                    {
                        findMatch(currentNode.children[i], input);
                        matchFound = true;
                    }
                }
                
                // Note: required to print "no matches" when searching for "blod"
                // but prints "no matches" whenever it gets to the end of a search
                // path. Needs work.
                /*
                if(matchFound == false)
                {
                    Console.WriteLine("No matches found");
                    return;
                }
                 */
            }

            
            // if lengths match and strings match and end of word, print value of node
            else if (currentNode.level == input.Length && currentNode.value == input && currentNode.flag == true)
            {
                Console.WriteLine(currentNode.value);
            }
            

            else if(currentNode.level == input.Length && currentNode.value != input)
            {
                return;
            }

            // partial match found, location isn't end of word;
            // print all nodes below with flag equals true;
            else //if(currentNode.level >= input.Length)
            {
                
                bool matchFound = false;
                
                if(currentNode.level > input.Length && currentNode.value[input.Length] ==  input[input.Length] && currentNode.flag == true)
                {
                    Console.WriteLine(currentNode.value);
                    matchFound = true;
                }

                for (int i = 0; i < currentNode.children.Count; i++)
                {
                    if (currentNode.children[i].value[currentNode.level - 1] != input[currentNode.level - 1])
                        break;
                    
                    if (currentNode.level < input.Length)
                    {
                        findMatch(currentNode.children[i], input);
                    }

                    else
                    {
                        // reached end of input, search everything below and print value of nodes
                        // with flag equals true.
                        matchFound = true;
                        printAllTrue(currentNode);
                        break;
                    }
                }

                
                if(matchFound == false)
                {
                    //Console.WriteLine("No matches found");
                }
            }
        }

        private void printAllTrue(node currentNode)
        {
            bool printed = false;

            for (int i = 0; i < currentNode.children.Count; i++)
            {
                if (currentNode.children.Count > 0)
                {
                    printAllTrue(currentNode.children[i]);
                }
                
                
            }

            if (currentNode.flag == true && printed == false)
            {
                Console.WriteLine(currentNode.value);
                printed = true;
            }
        }

        // the insert function calls the private insertWord function
        public void insert(string w)
        {
            insertWord(root, w);
        }

        // the insertWord steps through each level of the Trie looking
        // for an incremental match to the input string, based on the
        // level of the currentNode. When a match is not found  a new
        // node is created containing a full or partial match to the
        // input string, based on how deep in the Trie the new node is
        private void insertWord(node currentNode, string input)
        {
            // If currentNode is not root & has no value, write value
            if (currentNode.level != 0)
            {
                if (currentNode.value == null)
                {
                    // Write value; length based on level in Trie
                    writePartial(currentNode, input);

                    // If value length equals input length, end of
                    // input string has been reached; adjust flag.
                    if (currentNode.value != null && currentNode.value.Length == input.Length)
                        currentNode.flag = true;
                    else
                        currentNode.flag = false;
                }
                

                // If currentNode level doesn't equal input length check for matches in list of currentNode children
                if (currentNode.level != input.Length)
                {
                    // currentNode has zero children
                    if (currentNode.children.Count() == 0)
                    {
                        // Create a new node and add it to the children of currentNode
                        node newNode = new node();
                        newNode.level = currentNode.level + 1;
                        currentNode.children.Add(newNode);

                        // Call insert with the newly added node
                        insertWord(currentNode.children.Last(), input);
                    }

                    // currentNode has children
                    else
                    {
                        bool matchFound = false;

                        // Check currentNode's list of children for matches
                        for (int i = 0; i < currentNode.children.Count; i++)
                        {
                            // k is index the last char in value of currentNode's children.
                            int k = currentNode.value.Length;

                            // if child's value matches input, call insert with that node
                            if (currentNode.children[i].value[k] == input[k])
                            {
                                insertWord(currentNode.children[i], input);
                                matchFound = true;
                            }
                        }

                        if (matchFound == false)
                        {
                            // Create a new node and add it to the children of currentNode
                            node newNode = new node();
                            newNode.level = currentNode.level + 1;
                            currentNode.children.Add(newNode);

                            // Call insert with the newly added node
                            insertWord(currentNode.children.Last(), input);
                        }
                    }
                }
            }

            // currentNode is root check root for matches
            else
            {
                // if currentNode has zero children
                if (currentNode.children.Count() == 0)
                {
                    // Create a new node and add it to the children of currentNode
                    node newNode = new node();
                    newNode.level = currentNode.level + 1;
                    currentNode.children.Add(newNode);

                    // Call insert with the newly added node
                    insertWord(currentNode.children.Last(), input);
                }

                // else currentNode has children
                else
                {
                    bool matchFound = false;

                    // Check currentNode's list of children for matches
                    for (int i = 0; i < currentNode.children.Count; i++)
                    {
                        // k is index the last char in value of currentNode's children.
                        //int k = currentNode.value.Length;

                        // if child's value matches input, call insert with that node
                        if (currentNode.children[i].value[0] == input[0])
                        {
                            insertWord(currentNode.children[i], input);
                            matchFound = true;
                        }
                    }

                    if (matchFound == false)
                    {
                        // Create a new node and add it to the children of currentNode
                        node newNode = new node();
                        newNode.level = currentNode.level + 1;
                        currentNode.children.Add(newNode);

                        // Call insert with the newly added node
                        insertWord(currentNode.children.Last(), input);
                    }
                }
            }
        }

        void writePartial(node currentNode, string input)
        {
            for (int i = 0; i < currentNode.level; i++)
            {
                currentNode.value = currentNode.value += input[i];
            }
        }

        public void print()
        {
            printTrie(root);
            Console.WriteLine("\n");
        }

        
        private void printTrie(node currentNode)
        {
            if(currentNode.children.Count() != 0)
            {
                for (int i = 0; i < currentNode.children.Count(); i++)
                {
                    Console.WriteLine(currentNode.children[i].value);
                }

                for (int i = 0; i < currentNode.children.Count(); i++)
                {
                printTrie(currentNode.children[i]);
                }
            }
            
        }


    }  
}
