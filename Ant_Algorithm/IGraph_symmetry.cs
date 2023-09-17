using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ant_Algorithm;

internal interface IGraph_symmetry
{
    public void pheromoneDistribution(Dictionary<char, KeyValuePair<float, float>> tempDictionary,
                                      KeyValuePair <List <char>, float> node,
                                      Dictionary<char, Dictionary<char, KeyValuePair<float, float>>> graph,
                                      float Q);

}
