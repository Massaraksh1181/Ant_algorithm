namespace Ant_Algorithm;

internal class SimpleAnt : Ants
{
    public SimpleAnt() 
    { 
        Q = 5;
        description = "муравьи как муравьи";
        route = new Queue<char>();
    }
    
}
