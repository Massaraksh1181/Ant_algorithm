namespace Ant_Algorithm;

internal abstract class Ant
{
    // значение константы Q, отвечающей за количество ферамона
    public int Q;
    // описание муравьев
    public string description;
    // путь пройденный муравьем (путь пройденный на каждой итерации?)
    public Queue<char> route;
}
