﻿namespace Algorithms
{
    public class GraphWithWeights<T> where T : IComparable
    {
        private List<Node<T>> _nodes;
        private List<Edge<T>> _edges;

        public GraphWithWeights()
        {
            _nodes = new List<Node<T>>();
            _edges = new List<Edge<T>>();
        }

        private void CreateNode(Node<T> node)
        {
            _nodes.Add(node);
            _nodes.Sort();
        }

        public void AddLink(T firstElement, T secondelement, int weight = 0)
        {
            Node<T> firtsNode = new Node<T>(_nodes.Count, firstElement);
            if (!_nodes.Contains(firtsNode))
            {
                CreateNode(firtsNode);
            }

            Node<T> secondNode = new Node<T>(_nodes.Count, secondelement);
            if (!_nodes.Contains(secondNode))
            {
                CreateNode(secondNode);
            }

            Edge<T> newEdge = new Edge<T>(firtsNode, secondNode, weight);
            if (!_edges.Contains(newEdge))
            {
                _edges.Add(newEdge);
            }
        }

        public List<T> TopologicalSort()
        {
            Dictionary<T, int> inDegree = new Dictionary<T, int>();
            List<T> linearOrdering = new List<T>();
            foreach (var node in _nodes)
            {
                inDegree.Add(node.Value, 0);
            }
            foreach (var edge in _edges)
            {
                inDegree[edge.FinalNode.Value] += 1;
            }

            Queue<T> next = new Queue<T>();

            foreach (var element in inDegree)
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
                foreach (var edge in _edges)
                {
                    if (edge.StartingNode.Value.CompareTo(node) == 0)
                    {
                        inDegree[edge.FinalNode.Value] -= 1;
                        if (inDegree[edge.FinalNode.Value] == 0)
                        {
                            next.Enqueue(edge.FinalNode.Value);
                        }
                    }
                }
            }

            return linearOrdering;
        }

        private class Edge<N> : IEquatable<Edge<N>> where N : IComparable
        {
            public Node<N> StartingNode => _startingNode;
            public Node<N> FinalNode => _finalNode;
            public int Weight => _weight;

            private Node<N> _startingNode;
            private Node<N> _finalNode;
            private int _weight;

            public Edge(Node<N> startingNode, Node<N> finalNode, int weight = 0)
            {
                _startingNode = startingNode;
                _finalNode = finalNode;
                _weight = weight;
            }

            public bool Equals(GraphWithWeights<T>.Edge<N>? other)
            {
                if (other == null)
                {
                    return false;
                }
                return _startingNode.Equals(other._startingNode) && _finalNode.Equals(other._finalNode);
            }
        }

        private class Node<K> : IEquatable<Node<K>>, IComparable<Node<K>> where K : IComparable
        {
            public K Value => _value;
            private int _id;
            private K _value;

            public Node(int id, K value)
            {
                _id = id;
                _value = value;
            }

            public int CompareTo(Node<K>? other)
            {
                return other == null ? 1 : _value.CompareTo(other.Value);
            }

            public bool Equals(GraphWithWeights<T>.Node<K>? other)
            {
                if (other == null)
                {
                    return false;
                }
                return _value.Equals(other.Value);
            }
        }
    }
}