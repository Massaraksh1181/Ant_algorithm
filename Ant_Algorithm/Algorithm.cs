using System.Linq;

namespace Ant_Algorithm;

internal class Algorithm
{
    Ant ant;
    Graph graph;

    IGraph_symmetry graphSymmetry = new Symmetric_graph(); //по умолчанию алгоритм настроен для симметричного графа
    public void setGraphSymmetry(IGraph_symmetry graphSymmetry) // возможность изменения алгоритма для работы с симметричным/ассимтеричным графом во время выполнения
    {
        graphSymmetry = this.graphSymmetry;
    }

    ILooped_route loopedRoute = new LoopedRoute();//по умолчанию алгоритм настроен для возвращения графа в начальную точку
    public void setGraphLooped(ILooped_route loopedRoute) // возможность изменения алгоритма для возвращения в начальную точку/не возвращения во время выполнения
    {
        loopedRoute = this.loopedRoute;
    }

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

    //построение маршрута для одного муравья
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
            desire.Add(node.Key, MathF.Pow(1 / node.Value.Key, ant.b) * MathF.Pow(node.Value.Value, ant.a));// в ключе точка-сосед, в значении формула для расчета желания
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

       /* float temp = 0;
       foreach (var nodeProbaboloty in probability) // поиск вершины с наибольшей вероятностью
        {
            if (nodeProbaboloty.Value > temp)// если вероятность перехода в точку больше чем у предыдущей
            {
                temp = nodeProbaboloty.Value;
                nextNode = nodeProbaboloty.Key;
            }
        }*/

        nextNode = probabilisticChoice(probability);

        if (neighbors.Count != 0)//если еще есть соседи для перехода  //if (nextNode.Equals('+')==false) 
        {
            distance += neighbors[nextNode].Key;
            oneAntWaySearch(nextNode);// рекурсивный вызов  
        }
        else // если непосещенных соседей не осталось
        {
            loopedRoute.returnToStart(graph.mapDistancesPheromone, visitedNodes, distance, nodeAnt);// возвращение в начальную точку (если алгоритм предусматривает)
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
 
    public void iteration(Dictionary<char, Dictionary<char, KeyValuePair<float, float>>> graph) // выполнение одной итерации алгоритма
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

        foreach (var node in graph.Values) // испарение ферамона
        {
            foreach (var key in node.Keys)
            {
                node[key] = new KeyValuePair<float, float>(node[key].Key, node[key].Value*ant.p);
            }
        }

        foreach (var node in oneIterationWay) // распределение ферамона по одному маршруту (в рамках однйо итерации)
        {
            graphSymmetry.pheromoneDistribution(tempDictionary, node, graph, ant.Q);
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

    public char probabilisticChoice(Dictionary<char, float> probability)
    {
        char nextNode = '+';

        Random r = new Random();
        float range = 0.999f;
        double rDouble = r.NextDouble() * range;

        var sortedProbability = probability.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);// сортировка словаря вероятностей по возрастанию значений

        float tempProbSum = 0f;
        float tempProb;
        foreach (var node in sortedProbability.Keys)// нормализация вероятностей
        {
            tempProb = sortedProbability[node];
            sortedProbability[node] = sortedProbability[node]+tempProbSum;
            tempProbSum = sortedProbability[node];
        }

        foreach (var node in sortedProbability) 
        {
            if (rDouble < node.Value)
                return nextNode= node.Key;
        }

        return nextNode;
    }
}
