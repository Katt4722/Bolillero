namespace Biblioteca;
public class Primero : IAleatorio
{
    private Queue<int> _secuencia;

    public Primero(List<int> secuencia)
    {
        _secuencia = new Queue<int>(secuencia);
    }

    public int SacarAleatorio(int max)
    {
        return _secuencia.Dequeue();
    }
}