using System.Collections.Generic;
using System.Linq;

namespace Ant_Algorithm;

internal class Algorithm
{
    Ant ant;
    Graph graph;

    public Algorithm(Ant ant, Graph graph)
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
/////

        char nextNode = '+';// следующий выбранный с наибольшей веротяностью узел

        foreach (var node in graph.mapDistancesPheromone[nodeAnt]) // поиск соседей для выбранной вершины
        {
            if (visitedNodes.Contains(node.Key) == false)// если вершина-куда еще не была посещена
                neighbors.Add(node.Key, new KeyValuePair<float, float>(node.Value.Key, node.Value.Value));
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

        if (neighbors.Count != 0)//если еще есть соседи для перехода  //if (nextNode.Equals('+')==false) 
        {
            distance += neighbors[nextNode].Key;

            neighbors.Clear();
            desire.Clear();
            probability.Clear();

            desireСhoice(nextNode);// рекурсивный вызов  
        }
        else // возвращение маршрута в начальную точку
        {
            neighbors = graph.mapDistancesPheromone[nodeAnt];//
            distance += neighbors[visitedNodes[0]].Key; // подсчет дистанции всего маршрута с последнем пунктом
            visitedNodes.Add(visitedNodes[0]);
        }

        KeyValuePair<List<char>, float> oneAntWay = new KeyValuePair<List<char>, float>(visitedNodes, distance);

        return oneAntWay;
    }

    public void clearr()
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
