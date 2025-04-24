namespace Biblioteca;
public class Bolillero
{
    public List<int> Jugada { get; set; }
    public List<int> bolillas;
    public List<int> bolillasExtraidas;
    private IAleatorio _aleatorio;

    public  Bolillero(IAleatorio aleatorio)
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
        if (bolillas.Count == 0) return -1; 

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
    public bool Jugar(List<int> jugada)
        {
            List<int> bolillasSacadas = new List<int>();

            foreach (var bolilla in jugada)
            {
                bolillasSacadas.Add(SacarBolilla());
            }
            return bolillasSacadas.SequenceEqual(jugada);
        }

    public int JugarNVeces(List<int> jugada, int veces)
        {
            int aciertos = 0;
            for (int i = 0; i < veces; i++)
            {
                if (Jugar(jugada))
                {
                    aciertos++;
                }
                ReIngresarBolillas(); 
            }
            return aciertos;
        }
}