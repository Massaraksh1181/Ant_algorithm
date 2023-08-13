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
        graph.createGraph('a', 'd', 5, 0.2f);
        graph.createGraph('b', 'a', 4, 0.2f);
        graph.createGraph('b', 'c', 7, 0.2f);
        graph.createGraph('b', 'd', 3, 0.2f);
        graph.createGraph('c', 'a', 3, 0.2f);
        graph.createGraph('c', 'b', 7, 0.2f);
        graph.createGraph('c', 'd', 9, 0.2f);
        graph.createGraph('d', 'a', 5, 0.2f);
        graph.createGraph('d', 'b', 3, 0.2f);
        graph.createGraph('d', 'c', 9, 0.2f);

        Algorithm algorithm = new Algorithm(ants,graph);

        KeyValuePair<List<char>, float> oneAntWay = algorithm.desireСhoice('a');
        oneAntWay.Key.ForEach(Console.WriteLine);
        Console.WriteLine(oneAntWay.Value);

        algorithm.clearer();

        KeyValuePair<List<char>, float> twoAntWay = algorithm.desireСhoice('b');
        twoAntWay.Key.ForEach(Console.WriteLine);
        Console.WriteLine(twoAntWay.Value);

        algorithm.clearer();

        KeyValuePair<List<char>, float> threeAntWay = algorithm.desireСhoice('c');
        threeAntWay.Key.ForEach(Console.WriteLine);
        Console.WriteLine(threeAntWay.Value);

        algorithm.clearer();

        KeyValuePair<List<char>, float> fourAntWay = algorithm.desireСhoice('d');
        fourAntWay.Key.ForEach(Console.WriteLine);
        Console.WriteLine(fourAntWay.Value);

    }
}