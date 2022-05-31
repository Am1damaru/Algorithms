using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Graph<T> where T : IComparable
    {
        private int _countNodes;
        private List<Node<T>> _nodes;

        public Graph()
        {
            _countNodes = 0;
            _nodes = new List<Node<T>>();
        }

        public void AddLink(T firstElement, T secondelement)
        {
            var firstNode = GetOrCreateNode(firstElement);
            var secondNode = GetOrCreateNode(secondelement);
            firstNode.AddLink(secondNode);
        }

        public List<T> TopologicalSort()
        {
            Dictionary<T, int> inDegree= new Dictionary<T, int>();
            List<T> linearOrdering = new List<T>();
            foreach (var node in _nodes)
            {
                inDegree.Add(node.Value, 0);
            }    
            foreach(var node in _nodes)
            {
                foreach(var top in node.Nodes)
                {
                    inDegree[top.Value] += 1;
                }
            }

            Queue<T> next= new Queue<T>();

            foreach(var element in inDegree)
            {
                if (element.Value == 0)
                {
                    next.Enqueue(element.Key);
                }
            }

            while (next.Count > 0)
            {
                T node = next.Dequeue();
                linearOrdering.Add(node);
                foreach(var element in _nodes)
                {
                    if (element.Value.CompareTo(node) == 0)
                    {
                        foreach(var t in element.Nodes)
                        {
                            inDegree[t.Value] -= 1;
                            if (inDegree[t.Value] == 0)
                            {
                                next.Enqueue(t.Value);
                            }
                        }
                    }
                }
            }

            return linearOrdering;
        }

        private Node<T> GetOrCreateNode(T value)
        {
            foreach(var node in _nodes)
            {
                if (node.Value.CompareTo(value) == 0)
                {
                    return node;
                }
            }

            var newNode = new Node<T>(_countNodes++, value);
            _nodes.Add(newNode);

            return newNode;
        }

        private class Node<T>
        {
            public int Id => _id;
            public T Value => _value;

            public List<Node<T>> Nodes => new List<Node<T>>(_nodes);

            private int _id;
            private T _value;
            private List<Node<T>> _nodes;

            public Node(int id, T value)
            {
                _id = id;
                _value = value;
                _nodes = new List<Node<T>>();
            }

            public void AddLink(Node<T> node)
            {
                if (!_nodes.Contains(node))
                    _nodes.Add(node);
            }

            public void DeleteLink(Node<T> node)
            {
                if (_nodes.Contains(node))
                    _nodes.Remove(node);
            }
        }
    }
}
