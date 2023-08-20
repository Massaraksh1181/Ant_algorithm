namespace Ant_Algorithm;

internal class SimpleAnt : Ant
{
    public SimpleAnt() 
    { 
        Q = 5;
        description = "муравьи как муравьи";
        route = new Queue<char>();
    }
    
}
