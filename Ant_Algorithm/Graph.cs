using System.Collections.Generic;
using System.Diagnostics;

namespace Ant_Algorithm;

internal class Graph
{
    // чтение данных о графе

    //словарь для расстояния и ферамона
    public Dictionary<char, Dictionary<char,KeyValuePair<float, float>>> mapDistancesPheromone = new Dictionary<char, Dictionary<char, KeyValuePair<float, float>>>();
}
