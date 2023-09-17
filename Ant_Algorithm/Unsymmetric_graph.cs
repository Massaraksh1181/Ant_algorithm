using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ant_Algorithm;

internal class Unsymmetric_graph : IGraph_symmetry
{
    public void pheromoneDistribution(Dictionary<char, KeyValuePair<float, float>> tempDictionary,
                                      KeyValuePair<List<char>, float> node,
                                      Dictionary<char, Dictionary<char, KeyValuePair<float, float>>> graph,
                                      float Q)
    {
        for (var i = 0; i < (node.Key.Count - 1); i++) // перебор всех пунктов в маршруте
        {
            tempDictionary = graph[node.Key[i]];
            tempDictionary[node.Key[i + 1]] = new KeyValuePair<float, float>(tempDictionary[node.Key[i + 1]].Key, tempDictionary[node.Key[i + 1]].Value + Q / node.Value);
        }
    }
}
