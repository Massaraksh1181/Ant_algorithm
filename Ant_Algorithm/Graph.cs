using System.Collections.Generic;
using System.Diagnostics;

namespace Ant_Algorithm;

internal class Graph
{
    // чтение данных о графе

    //словарь для расстояния и ферамона
    public Dictionary<KeyValuePair<char, char>, KeyValuePair<float, float>> mapDistancesPheromone = new Dictionary<KeyValuePair<char, char>, KeyValuePair<float, float>>();

    public void createGraph (char from, char to, float distanse, float pheromone)
    {
        mapDistancesPheromone.Add(new KeyValuePair <char, char>(from, to), new KeyValuePair<float, float>(distanse, pheromone));
    }
}
