namespace Biblioteca;

public class Bolillero
{
    public List<ListBolillas> Jugada { get; set; }; 
    public List<Bolilla> bolillas;
    public List<Bolilla> bolillasExtraidas;
    private IAleatorio _aleatorio;

    public Bolillero(IAleatorio aleatorio)
    {
        _aleatorio = aleatorio;
        bolillas = new List<int>();
        bolillasExtraidas = new List<int>();

        for (int i = 0; i < 10; i++)
        {
            bolillas.Add(i);
        }
    }

    public int SacarBolilla()
    {
        if (_bolillas.Count == 0) return -1; 

        int index = _aleatorio.SacarAleatorio(bolillas.Count);
        int bolilla = bolillas[index];
        bolillas.RemoveAt(index);
        bolillasExtraidas.Add(bolilla);
        return bolilla;
    }
    public void ReIngresarBolillas()
    {
        bolillas.AddRange(bolillasExtraidas);
        bolillasExtraidas.Clear();
    }
}