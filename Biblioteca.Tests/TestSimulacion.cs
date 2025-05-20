namespace Biblioteca.Tests;

public class TestSimulacion
{
    [Fact]
    public void SimularConHilosDevuelveResultadoEsperado()
    {
        var bolillero = new Bolillero(10); 
        var jugada = new List<int> { 1, 3, 5 };
        var simulacion = new Simulacion();

        long resultadoSinHilos = simulacion.SimularSinHilos(bolillero, jugada, 1000);
        long resultadoConHilos = simulacion.SimularConHilos(bolillero, jugada, 1000, 4);

        double diferenciaRelativa = (double)Math.Abs(resultadoSinHilos - resultadoConHilos) / 1000;
        Assert.True(diferenciaRelativa < 0.1, "Los resultados con y sin hilos deben ser similares");
    }

    [Fact]
    public async Task SimularConHilosAsyncDevuelveResultadoEsperado()
    {
        var bolillero = new Bolillero(10);
        var jugada = new List<int> { 1, 2, 3 };
        var simulacion = new Simulacion();

        long resultado = await simulacion.SimularConHilosAsync(bolillero, jugada, 1000, 4);

        Assert.InRange(resultado, 0, 1000);
    }

}