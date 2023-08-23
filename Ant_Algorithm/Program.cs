using Ant_Algorithm;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        Graph graph = new Graph();
        Ant ants = new SimpleAnt();

        Algorithm algorithm = new Algorithm(ants,graph);
   
        graph.mapDistancesPheromone['a'] = 
            new Dictionary<char, KeyValuePair<float, float>>() { 
                { 'b', new KeyValuePair<float,float> (4f, 0.2f) }, 
                { 'c', new KeyValuePair<float, float>(3f, 0.2f) }, 
                { 'd', new KeyValuePair<float, float>(5f, 0.2f) } };
        graph.mapDistancesPheromone['b'] = 
            new Dictionary<char, KeyValuePair<float, float>>() { 
                { 'a', new KeyValuePair<float, float>(4f, 0.2f) }, 
                { 'c', new KeyValuePair<float, float>(7f, 0.2f) }, 
                { 'd', new KeyValuePair<float, float>(3f, 0.2f) } };
        graph.mapDistancesPheromone['c'] = 
            new Dictionary<char, KeyValuePair<float, float>>() { 
                { 'a', new KeyValuePair<float, float>(3f, 0.2f) }, 
                { 'b', new KeyValuePair<float, float>(7f, 0.2f) }, 
                { 'd', new KeyValuePair<float, float>(9f, 0.2f) } };
        graph.mapDistancesPheromone['d'] = 
            new Dictionary<char, KeyValuePair<float, float>>() { 
                { 'a', new KeyValuePair<float, float>(5f, 0.2f) }, 
                { 'b', new KeyValuePair<float, float>(3f, 0.2f) }, 
                { 'c', new KeyValuePair<float, float>(9f, 0.2f) } };

        KeyValuePair<List<char>, float> AntWay1 = algorithm.desireСhoice('a');
        AntWay1.Key.ForEach(Console.WriteLine);
        Console.WriteLine(AntWay1.Value);
        algorithm.clearr();

        KeyValuePair<List<char>, float> AntWay2 = algorithm.desireСhoice('b');
        AntWay2.Key.ForEach(Console.WriteLine);
        Console.WriteLine(AntWay2.Value);
        algorithm.clearr();

        KeyValuePair<List<char>, float> AntWay3 = algorithm.desireСhoice('c');
        AntWay3.Key.ForEach(Console.WriteLine);
        Console.WriteLine(AntWay3.Value);
        algorithm.clearr();

        KeyValuePair<List<char>, float> AntWay4 = algorithm.desireСhoice('d');
        AntWay4.Key.ForEach(Console.WriteLine);
        Console.WriteLine(AntWay4.Value);
        algorithm.clearr();
    }
}