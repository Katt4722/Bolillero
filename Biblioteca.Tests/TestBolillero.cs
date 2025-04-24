namespace Biblioteca.Tests;
public class TestBolillero
{
    private Bolillero _bolillero;

    public TestBolillero()
    {
        var generadorAleatorio = new Aleatorio();
        _bolillero = new Bolillero(generadorAleatorio);
    }

    [Fact]
    public void SacarBolilla()
    {
        int bolilla = _bolillero.SacarBolilla();
        Assert.NotEqual(-1, bolilla);  // Se espera que la bolilla no sea -1
        Assert.Single(_bolillero.bolillasExtraidas);  // Debe haber una bolilla extraída
        Assert.Equal(9, _bolillero.bolillas.Count);  // Después de sacar una, quedan 9 bolillas
    }

    [Fact]
    public void ReIngresarBolillas()
    {
        int bolilla = _bolillero.SacarBolilla();
        _bolillero.ReIngresarBolillas();

        Assert.Equal(10, _bolillero.bolillas.Count);  // Después de reingresar, deben haber 10 bolillas
        Assert.Empty(_bolillero.bolillasExtraidas);  // Ya no debe haber bolillas extraídas
    }


    [Fact]
    public void JugarGana()
    {
        var jugada = new List<int> { 0, 1, 2, 3 };
        bool gano = _bolillero.Jugar(jugada);
        Assert.False(gano);
    }

    [Fact]
    public void JugarPierde()
    {
        var jugada = new List<int> { 4, 2, 1 };
        bool gano = _bolillero.Jugar(jugada);
        Assert.False(gano);  // Se espera que la jugada no haya ganado
    }

    [Fact]
    public void GanarNVeces()
    {
        var jugada = new List<int> { 0, 1 };
        int veces = 1;
        int aciertos = _bolillero.JugarNVeces(jugada, veces);
        Assert.Equal(1, aciertos);  // Se espera que haya ganado 1 vez. Revisarr
    }
}