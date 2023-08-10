using Ant_Algorithm;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        Graph graph = new Graph();
        Ants ants = new SimpleAnt();

        graph.createGraph('a', 'b', 4, 0.2f);
        graph.createGraph('a', 'c', 3, 0.2f);
        graph.createGraph('a', 'd', 2, 0.2f);
        graph.createGraph('b', 'a', 4, 0.2f);
        graph.createGraph('b', 'c', 7, 0.2f);
        graph.createGraph('b', 'd', 3, 0.2f);
        graph.createGraph('c', 'a', 3, 0.2f);
        graph.createGraph('c', 'b', 7, 0.2f);
        graph.createGraph('c', 'd', 9, 0.2f);
        graph.createGraph('d', 'a', 4, 0.2f);
        graph.createGraph('d', 'b', 3, 0.2f);
        graph.createGraph('d', 'c', 9, 0.2f);

        Algorithm algorithm = new Algorithm(ants,graph);
        algorithm.desireСhoice('a').ForEach(Console.WriteLine);




    }
}