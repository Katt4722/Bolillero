namespace Biblioteca.Tests;
public class TestBolillero
{
    private Bolillero _bolillero;

    public TestBolillero()
    {
        var secuencia = new List<int> { 0, 0, 0, 0, 0, 0, 0 };
        var generadorAleatorio = new Primero(secuencia);
        _bolillero = new Bolillero(generadorAleatorio);
    }

    [Fact]
    public void SacarBolilla()
    {
        int bolilla = _bolillero.SacarBolilla();
        Assert.NotEqual(-1, bolilla);  
        Assert.Single(_bolillero.bolillasExtraidas);  
        Assert.Equal(9, _bolillero.bolillas.Count);  
    }

    [Fact]
    public void ReIngresarBolillas()
    {
        int bolilla = _bolillero.SacarBolilla();
        _bolillero.ReIngresarBolillas();

        Assert.Equal(10, _bolillero.bolillas.Count);  
        Assert.Empty(_bolillero.bolillasExtraidas);  
    }


    [Fact]
    public void JugarGana()
    {
        var jugada = new List<int> { 0, 1, 2, 3 };
        bool gano = _bolillero.Jugar(jugada);
        Assert.True(gano);
    }

    [Fact]
    public void JugarPierde()
    {
        var jugada = new List<int> { 4, 2, 1 };
        bool gano = _bolillero.Jugar(jugada);
        Assert.False(gano);  
    }

    [Fact]
    public void GanarNVeces()
    {
        var jugada = new List<int> { 0, 1 };
        int veces = 1;
        int aciertos = _bolillero.JugarNVeces(jugada, veces);
        Assert.Equal(1, aciertos); 
    }
}