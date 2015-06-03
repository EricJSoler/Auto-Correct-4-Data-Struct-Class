using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class node
    {
        public node()
        {
            value = null;   // key; string
            level = 0;  // depth of node in tree
            children = new List<node>();    // list of child nodes
            flag = false;   // flag indicating if node is the end of a word
        }

       public string value;
       public int level;
       public List<node> children;
       public bool flag;

    }
}
