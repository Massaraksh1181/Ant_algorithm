using Ant_Algorithm;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        Graph graph = new Graph();
        Ant ants = new SimpleAnt();

        Algorithm algorithm = new Algorithm(ants,graph);

        /* graph.mapDistancesPheromone['a'] = 
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
                 { 'c', new KeyValuePair<float, float>(9f, 0.2f) } };*/

        graph.mapDistancesPheromone['a'] =
            new Dictionary<char, KeyValuePair<float, float>>() {
                { 'b', new KeyValuePair<float,float> (4f, 0.2f) },
                { 'c', new KeyValuePair<float, float>(3f, 0.2f) },
                { 'd', new KeyValuePair<float, float>(5f, 0.2f) },
                { '1', new KeyValuePair<float, float>(7f, 0.2f) },
                { '2', new KeyValuePair<float, float>(8f, 0.2f) },
                { '3', new KeyValuePair<float, float>(3f, 0.2f) },
                { '4', new KeyValuePair<float, float>(6f, 0.2f) },
                { '5', new KeyValuePair<float, float>(12f, 0.2f) },
                { '6', new KeyValuePair<float, float>(9f, 0.2f) },
                { '7', new KeyValuePair<float, float>(15f, 0.2f) },
                { '8', new KeyValuePair<float, float>(2f, 0.2f) }};
        graph.mapDistancesPheromone['b'] =
            new Dictionary<char, KeyValuePair<float, float>>() {
                { 'a', new KeyValuePair<float, float>(4f, 0.2f) },
                { 'c', new KeyValuePair<float, float>(7f, 0.2f) },
                { 'd', new KeyValuePair<float, float>(3f, 0.2f) },
                { '1', new KeyValuePair<float, float>(8f, 0.2f) },
                { '2', new KeyValuePair<float, float>(12f, 0.2f) },
                { '3', new KeyValuePair<float, float>(9f, 0.2f) },
                { '4', new KeyValuePair<float, float>(14f, 0.2f) },
                { '5', new KeyValuePair<float, float>(3f, 0.2f) },
                { '6', new KeyValuePair<float, float>(2f, 0.2f) },
                { '7', new KeyValuePair<float, float>(3f, 0.2f) },
                { '8', new KeyValuePair<float, float>(6f, 0.2f) }};
        graph.mapDistancesPheromone['c'] =
            new Dictionary<char, KeyValuePair<float, float>>() {
                { 'a', new KeyValuePair<float, float>(3f, 0.2f) },
                { 'b', new KeyValuePair<float, float>(7f, 0.2f) },
                { 'd', new KeyValuePair<float, float>(9f, 0.2f) },
                { '1', new KeyValuePair<float, float>(5f, 0.2f) },
                { '2', new KeyValuePair<float, float>(5f, 0.2f) },
                { '3', new KeyValuePair<float, float>(6f, 0.2f) },
                { '4', new KeyValuePair<float, float>(16f, 0.2f) },
                { '5', new KeyValuePair<float, float>(20f, 0.2f) },
                { '6', new KeyValuePair<float, float>(3f, 0.2f) },
                { '7', new KeyValuePair<float, float>(13f, 0.2f) },
                { '8', new KeyValuePair<float, float>(5f, 0.2f) }};
        graph.mapDistancesPheromone['d'] =
            new Dictionary<char, KeyValuePair<float, float>>() {
                { 'a', new KeyValuePair<float, float>(5f, 0.2f) },
                { 'b', new KeyValuePair<float, float>(3f, 0.2f) },
                { 'c', new KeyValuePair<float, float>(9f, 0.2f) },
                { '1', new KeyValuePair<float, float>(7f, 0.2f) },
                { '2', new KeyValuePair<float, float>(12f, 0.2f) },
                { '3', new KeyValuePair<float, float>(4f, 0.2f) },
                { '4', new KeyValuePair<float, float>(2f, 0.2f) },
                { '5', new KeyValuePair<float, float>(2f, 0.2f) },
                { '6', new KeyValuePair<float, float>(7f, 0.2f) },
                { '7', new KeyValuePair<float, float>(15f, 0.2f) },
                { '8', new KeyValuePair<float, float>(1f, 0.2f) }};
        graph.mapDistancesPheromone['1'] =
            new Dictionary<char, KeyValuePair<float, float>>() {
                { 'a', new KeyValuePair<float, float>(7f, 0.2f) },
                { 'b', new KeyValuePair<float, float>(8f, 0.2f) },
                { 'c', new KeyValuePair<float, float>(5f, 0.2f) },
                { 'd', new KeyValuePair<float, float>(7f, 0.2f) },
                { '2', new KeyValuePair<float, float>(8f, 0.2f) },
                { '3', new KeyValuePair<float, float>(9f, 0.2f) },
                { '4', new KeyValuePair<float, float>(2f, 0.2f) },
                { '5', new KeyValuePair<float, float>(3f, 0.2f) },
                { '6', new KeyValuePair<float, float>(6f, 0.2f) },
                { '7', new KeyValuePair<float, float>(7f, 0.2f) },
                { '8', new KeyValuePair<float, float>(8f, 0.2f) }};
    graph.mapDistancesPheromone['2'] =
            new Dictionary<char, KeyValuePair<float, float>>() {
                { 'a', new KeyValuePair<float, float>(8f, 0.2f) },
                { 'b', new KeyValuePair<float, float>(12f, 0.2f) },
                { 'c', new KeyValuePair<float, float>(5f, 0.2f) },
                { 'd', new KeyValuePair<float, float>(12f, 0.2f) },
                { '1', new KeyValuePair<float, float>(8f, 0.2f) },
                { '3', new KeyValuePair<float, float>(5f, 0.2f) },
                { '4', new KeyValuePair<float, float>(13f, 0.2f) },
                { '5', new KeyValuePair<float, float>(24f, 0.2f) },
                { '6', new KeyValuePair<float, float>(8f, 0.2f) },
                { '7', new KeyValuePair<float, float>(15f, 0.2f) },
                { '8', new KeyValuePair<float, float>(9f, 0.2f) }};
        graph.mapDistancesPheromone['3'] =
            new Dictionary<char, KeyValuePair<float, float>>() {
                { 'a', new KeyValuePair<float, float>(3f, 0.2f) },
                { 'b', new KeyValuePair<float, float>(9f, 0.2f) },
                { 'c', new KeyValuePair<float, float>(6f, 0.2f) },
                { 'd', new KeyValuePair<float, float>(4f, 0.2f) },
                { '1', new KeyValuePair<float, float>(9f, 0.2f) },
                { '2', new KeyValuePair<float, float>(5f, 0.2f) },
                { '4', new KeyValuePair<float, float>(18f, 0.2f) },
                { '5', new KeyValuePair<float, float>(17f, 0.2f) },
                { '6', new KeyValuePair<float, float>(24f, 0.2f) },
                { '7', new KeyValuePair<float, float>(9f, 0.2f) },
                { '8', new KeyValuePair<float, float>(4f, 0.2f) }};
        graph.mapDistancesPheromone['4'] =
            new Dictionary<char, KeyValuePair<float, float>>() {
                { 'a', new KeyValuePair<float, float>(6f, 0.2f) },
                { 'b', new KeyValuePair<float, float>(14f, 0.2f) },
                { 'c', new KeyValuePair<float, float>(16f, 0.2f) },
                { 'd', new KeyValuePair<float, float>(2f, 0.2f) },
                { '1', new KeyValuePair<float, float>(2f, 0.2f) },
                { '2', new KeyValuePair<float, float>(13f, 0.2f) },
                { '3', new KeyValuePair<float, float>(18f, 0.2f) },
                { '5', new KeyValuePair<float, float>(9f, 0.2f) },
                { '6', new KeyValuePair<float, float>(20f, 0.2f) },
                { '7', new KeyValuePair<float, float>(7f, 0.2f) },
                { '8', new KeyValuePair<float, float>(8f, 0.2f) }};
        graph.mapDistancesPheromone['5'] =
            new Dictionary<char, KeyValuePair<float, float>>() {
                { 'a', new KeyValuePair<float, float>(12f, 0.2f) },
                { 'b', new KeyValuePair<float, float>(3f, 0.2f) },
                { 'c', new KeyValuePair<float, float>(20f, 0.2f) },
                { 'd', new KeyValuePair<float, float>(2f, 0.2f) },
                { '1', new KeyValuePair<float, float>(3f, 0.2f) },
                { '2', new KeyValuePair<float, float>(24f, 0.2f) },
                { '3', new KeyValuePair<float, float>(17f, 0.2f) },
                { '4', new KeyValuePair<float, float>(9f, 0.2f) },
                { '6', new KeyValuePair<float, float>(10f, 0.2f) },
                { '7', new KeyValuePair<float, float>(11f, 0.2f) },
                { '8', new KeyValuePair<float, float>(3f, 0.2f) }};
        graph.mapDistancesPheromone['6'] =
            new Dictionary<char, KeyValuePair<float, float>>() {
                { 'a', new KeyValuePair<float, float>(9f, 0.2f) },
                { 'b', new KeyValuePair<float, float>(2f, 0.2f) },
                { 'c', new KeyValuePair<float, float>(3f, 0.2f) },
                { 'd', new KeyValuePair<float, float>(7f, 0.2f) },
                { '1', new KeyValuePair<float, float>(6f, 0.2f) },
                { '2', new KeyValuePair<float, float>(8f, 0.2f) },
                { '3', new KeyValuePair<float, float>(24f, 0.2f) },
                { '4', new KeyValuePair<float, float>(20f, 0.2f) },
                { '5', new KeyValuePair<float, float>(10f, 0.2f) },
                { '7', new KeyValuePair<float, float>(16f, 0.2f) },
                { '8', new KeyValuePair<float, float>(6f, 0.2f) }};
        graph.mapDistancesPheromone['7'] =
            new Dictionary<char, KeyValuePair<float, float>>() {
                { 'a', new KeyValuePair<float, float>(15f, 0.2f) },
                { 'b', new KeyValuePair<float, float>(3f, 0.2f) },
                { 'c', new KeyValuePair<float, float>(13f, 0.2f) },
                { 'd', new KeyValuePair<float, float>(15f, 0.2f) },
                { '1', new KeyValuePair<float, float>(7f, 0.2f) },
                { '2', new KeyValuePair<float, float>(15f, 0.2f) },
                { '3', new KeyValuePair<float, float>(9f, 0.2f) },
                { '4', new KeyValuePair<float, float>(7f, 0.2f) },
                { '5', new KeyValuePair<float, float>(11f, 0.2f) },
                { '6', new KeyValuePair<float, float>(16f, 0.2f) },
                { '8', new KeyValuePair<float, float>(21f, 0.2f) }};
        graph.mapDistancesPheromone['8'] =
            new Dictionary<char, KeyValuePair<float, float>>() {
                { 'a', new KeyValuePair<float, float>(2f, 0.2f) },
                { 'b', new KeyValuePair<float, float>(6f, 0.2f) },
                { 'c', new KeyValuePair<float, float>(5f, 0.2f) },
                { 'd', new KeyValuePair<float, float>(1f, 0.2f) },
                { '1', new KeyValuePair<float, float>(8f, 0.2f) },
                { '2', new KeyValuePair<float, float>(9f, 0.2f) },
                { '3', new KeyValuePair<float, float>(4f, 0.2f) },
                { '4', new KeyValuePair<float, float>(8f, 0.2f) },
                { '5', new KeyValuePair<float, float>(3f, 0.2f) },
                { '6', new KeyValuePair<float, float>(6f, 0.2f) },
                { '7', new KeyValuePair<float, float>(21f, 0.2f) }};

        for (int i=0;i<100;i++)
        algorithm.iteration(graph.mapDistancesPheromone);


    }
}