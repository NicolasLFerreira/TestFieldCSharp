using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFieldCSharp
{
    internal class Graph
    {
        public NodeDirected Initial { get; set; }

        public Graph(NodeDirected initial)
        {
            Initial = initial;
        }

        public void BreadthFirstSearch()
        {
            NodeDirected current = Initial;
            Queue<NodeDirected> queue = new();
            
            while (!current.End)
            {
                foreach (NodeDirected node in current.Next)
                {

                }
            }
        }
    }

    class NodeDirected
    {
        public List<NodeDirected> Next { get; set; }
        public string Name { get; set; }
        public int Data { get; set; }
        public bool End { get => Next == null; }

        public NodeDirected(List<NodeDirected> node, string name, int data)
        {
            Next = node;
            Name = name;
            Data = data;
        }
    }
}
