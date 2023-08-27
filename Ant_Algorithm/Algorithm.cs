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

    Dictionary<List<char>, float> oneIterationWay = new Dictionary<List<char>, float>();

    float distance = 0;

    //желание перехода из i в j-ю вершину
    public void oneAntWaySearch(char nodeAnt) 
    {
        visitedNodes.Add(nodeAnt);
        /////
        neighbors.Clear();
        desire.Clear();
        probability.Clear();

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
            oneAntWaySearch(nextNode);// рекурсивный вызов  
        }
        else // возвращение маршрута в начальную точку
        {
            foreach (var node in graph.mapDistancesPheromone[nodeAnt]) //  поиск последнего узла
            {
                if (node.Key.Equals(visitedNodes[0]))// поиск расстояния из последнего узла в начальную точку
                    distance += node.Value.Key;
            }
            visitedNodes.Add(visitedNodes[0]); // добавление последнего пункта в список повещенных
            oneIterationWay.Add(new List<char>(visitedNodes), distance); // добавление списка прйденных пунктов 1-го муровья (и пройденного растояния) в словарь одной итерации
        }

        
    }

    public void clear()
    {
        neighbors.Clear();
        desire.Clear();
        probability.Clear();
        visitedNodes.Clear();
        distance = 0;
    }
 
    public void iteration(Dictionary<char, Dictionary<char, KeyValuePair<float, float>>> graph)
    {       
        foreach (var node in graph)
        {
            oneAntWaySearch(node.Key);
            clear();
        }

        pheromoneDistribution(graph);  
    }

    //распределение ферамона по граням 
    public void pheromoneDistribution(Dictionary<char, Dictionary<char, KeyValuePair<float, float>>> graph)
    {
        Dictionary<char, KeyValuePair<float, float>> tempDictionary = new Dictionary<char, KeyValuePair<float, float>>();

        foreach (var node in oneIterationWay) 
        {
            for (var i = 0; i < (node.Key.Count - 1); i++)
            {
                tempDictionary = graph[node.Key[i]];
                tempDictionary[node.Key[i + 1]] = new KeyValuePair<float, float>(tempDictionary[node.Key[i + 1]].Key,  tempDictionary[node.Key[i + 1]].Value + ant.Q / node.Value);

                ///// заполнение ферамона на промежутке в обратную сторону
                //tempDictionary = graph[node.Key[i+1]];
                //tempDictionary[node.Key[i]] = new KeyValuePair<float, float>(tempDictionary[node.Key[i]].Key, tempDictionary[node.Key[i]].Value + ant.Q / node.Value);
                /////
            }
        }

        //////////////  блок-тест для вывода
        ///
        ///

        foreach (var node in oneIterationWay)
        {
            node.Key.ForEach(Console.Write);
            Console.WriteLine();
            Console.WriteLine(node.Value);
        }
        Console.WriteLine("new iteration");

        /// 
        ///
        //////////////   
        
        oneIterationWay.Clear();
        tempDictionary = null;
    }
}
