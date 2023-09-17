using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ant_Algorithm;

internal class LoopedRoute : ILooped_route
{
    public void returnToStart(Dictionary<char, Dictionary<char, KeyValuePair<float, float>>> mapDistancesPheromone, List<char> visitedNodes, float distance, char nodeAnt)
    {
        foreach (var node in mapDistancesPheromone[nodeAnt]) //  поиск последнего узла                    ///////////////// блок для возврата в последню точку
        {
            if (node.Key.Equals(visitedNodes[0]))// поиск расстояния из последнего узла в начальную точку
                distance += node.Value.Key;
        }
        visitedNodes.Add(visitedNodes[0]); // добавление последнего пункта в список посещенных                  /////////////////
    }
}
