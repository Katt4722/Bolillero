namespace Biblioteca;
public class Aleatorio : IAleatorio
{
    private Random _random;

    public Aleatorio()
    {
        _random = new Random();
    }

    public int SacarAleatorio(int maxValue)
    {
        return _random.Next(0, maxValue);
    }
}