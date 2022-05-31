using Algorithms;

Graph<int> graph= new Graph<int>();
graph.AddLink(5, 2);
graph.AddLink(5, 0);
graph.AddLink(4, 0);
graph.AddLink(4, 1);
graph.AddLink(2, 3);
graph.AddLink(3, 1);

var list = graph.TopologicalSort();
foreach (var item in list)
{
    Console.Write(item + "  ");
}

﻿Console.ReadLine();