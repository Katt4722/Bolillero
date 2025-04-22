namespace Biblioteca;
public class Aleatorio : IAleatorio
{
    private Random _random;
    public Aleatorio()
    {
        _random = new Random();
    }
    public int SacarAleatorio(int max)
    {
        return _random.Next(max);
    }
}