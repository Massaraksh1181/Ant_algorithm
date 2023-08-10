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
    HashSet<char> nodesFromList = new HashSet<char>();// набор с уникальными точками
    Dictionary<char, float> desire = new Dictionary<char, float>(); // словарь с желанием перехода в соседнюю точку
    Dictionary<char, float> probability = new Dictionary<char, float>(); // словарь с вероятностью перехода в соседнюю точку
    List<char> visitedNodes = new List<char>(); // список посещенных узлов одного муравья в этой итерации

    //желание перехода из i в j-ю вершину
    public List<char> desireСhoice (char nodeAnt) // !!!!!!!!!!!!!!! переменная в параметре - временная мера, та, с которой начинает путь каждый новый муравей
    {
        visitedNodes.Add(nodeAnt);

        neighbors.Clear();
        nodesFromList.Clear();
        desire.Clear();
        probability.Clear();

        char nextNode = '-';// следующий выбранный с наибольшей веротяностью узел

        foreach (var nodesFrom in graph.mapDistancesPheromone)
        {
            nodesFromList.Add(nodesFrom.Key.Key);
        }

        //foreach (char nodeAnt in nodesFromList) // внешний класс, начинает с каждой вершины. олицетворяет муравьев, количество которых равно кол-ву вершин
        //{
            foreach (var node in graph.mapDistancesPheromone) // поиск соседей для выбранной вершины
            {
                if (node.Key.Key == nodeAnt)//если ключ-откуда данного узла совпадает с обрабатываемым сейчас узлом
                    neighbors.Add(node.Key.Value, new KeyValuePair<float, float>(node.Value.Key, node.Value.Value));
            }
            foreach (var node in neighbors)// заполняем словарь с желанием перехода в каждую соседнюю точку
            {
                desire.Add(node.Key, 1 / node.Value.Key * node.Value.Value);// в ключе точка-сосед, в значении формула для расчета желания
            }

            float desireSum = 0;
            foreach (var nodeDesire in desire)// высчитываем сумму всех желаний для соседних точек
            {
                desireSum +=nodeDesire.Value;
            }

            foreach (var nodeDesire in desire)// высчитываем веротяность перехода для соседних точек
            {
                probability.Add(nodeDesire.Key, nodeDesire.Value/desireSum);
            }

            float temp = 0;
            foreach (var nodeProbaboloty in probability) // поиск вершины с наибольшей вероятностью
            {
                if (nodeProbaboloty.Value > temp)// если вероятность перехода в точку больше чем у предыдущей
                {
                    if (visitedNodes.Contains(nodeProbaboloty.Key) == false) // проверка на то, что вершины нет в списке пройденных вершин
                    {
                        temp = nodeProbaboloty.Value;
                        nextNode = nodeProbaboloty.Key;
                    }
                }
            }

        // }
       // visitedNodes.Add(nextNode);// добавление в список пройденных вершин

        if (nextNode.Equals('-')==false) //если еще есть узел для перехода
        desireСhoice(nextNode);// рекурсивный вызов

        return visitedNodes;
    }
 
    //распределение ферамона по граням 

    //добавление ферамона на новой итерации
}
