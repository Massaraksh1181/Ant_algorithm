using System.Collections.Generic;
using System.Linq;

namespace Ant_Algorithm;

internal class Algorithm
{
    Ants ant;
    Graph graph;

    public Algorithm(Ants ant, Graph graph)
    {
        this.ant = ant;
        this.graph = graph;
    }

    Dictionary<char, KeyValuePair<float, float>> neighbors = new Dictionary<char, KeyValuePair<float, float>>();// словарь хрянящий соседей точки
    Dictionary<char, float> desire = new Dictionary<char, float>(); // словарь с желанием перехода в соседнюю точку
    Dictionary<char, float> probability = new Dictionary<char, float>(); // словарь с вероятностью перехода в соседнюю точку
    List<char> visitedNodes = new List<char>(); // список посещенных узлов одного муравья в этой итерации
    float distance = 0;

    //желание перехода из i в j-ю вершину
    public KeyValuePair<List<char>, float> desireСhoice(char nodeAnt) 
    {
        visitedNodes.Add(nodeAnt);

        neighbors.Clear();
        desire.Clear();
        probability.Clear();

        char nextNode = '+';// следующий выбранный с наибольшей веротяностью узел

        foreach (var node in graph.mapDistancesPheromone) // поиск соседей для выбранной вершины
        {
            if ((node.Key.Key == nodeAnt) && (visitedNodes.Contains(node.Key.Value) == false))//если ключ-откуда данного узла совпадает с обрабатываемым сейчас узлом И не был посещен
                neighbors.Add(node.Key.Value, new KeyValuePair<float, float>(node.Value.Key, node.Value.Value));
        }

        foreach (var node in neighbors)// заполняем словарь с желанием перехода в каждую соседнюю точку
        {
            desire.Add(node.Key, 1 / node.Value.Key * node.Value.Value);// в ключе точка-сосед, в значении формула для расчета желания
        }

        float desireSum = 0;
        foreach (var nodeDesire in desire)// высчитываем сумму всех желаний для соседних точек
        {
            desireSum += nodeDesire.Value;
        }

        foreach (var nodeDesire in desire)// высчитываем веротяность перехода для соседних точек
        {
            probability.Add(nodeDesire.Key, nodeDesire.Value / desireSum);
        }

        float temp = 0;
        foreach (var nodeProbaboloty in probability) // поиск вершины с наибольшей вероятностью
        {
            if (nodeProbaboloty.Value > temp)// если вероятность перехода в точку больше чем у предыдущей
            {
                temp = nodeProbaboloty.Value;
                nextNode = nodeProbaboloty.Key;
            }
        }

        KeyValuePair<char, char> distanceNode = new KeyValuePair<char, char>(nodeAnt, nextNode);

        if (neighbors.Count != 0)//если еще есть соседи для перехода  //if (nextNode.Equals('+')==false) 
        {
            distance += graph.mapDistancesPheromone[distanceNode].Key; // подсчет дистанции всего маршрута
            desireСhoice(nextNode);// рекурсивный вызов  
        }
        else // возвращение маршрута в начальную точку
        { 
            KeyValuePair<char, char> toStart = new KeyValuePair<char, char>(nodeAnt, visitedNodes[0]);
            visitedNodes.Add(visitedNodes[0]);
            distance += graph.mapDistancesPheromone[toStart].Key; // подсчет дистанции всего маршрута с последнем пунктом          
        }

        KeyValuePair<List<char>, float> oneAntWay = new KeyValuePair<List<char>, float>(visitedNodes, distance);

        return oneAntWay;
    }

    public void clearer()
    {
        neighbors.Clear();
        desire.Clear();
        probability.Clear();
        visitedNodes.Clear();
        distance = 0;
    }
 
    //распределение ферамона по граням 

    //добавление ферамона на новой итерации
}
