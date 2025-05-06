namespace Biblioteca.Tests;

public class TestSimulacion
{
    [Fact]
    public void SimularConHilosDevuelveResultadoEsperado()
    {
        var bolillero = new Bolillero(10); // asumiendo que crea bolillas 0 a 9
        var jugada = new List<int> { 1, 3, 5 };
        var simulacion = new Simulacion();

        long resultadoSinHilos = simulacion.SimularSinHilos(bolillero, jugada, 1000);
        long resultadoConHilos = simulacion.SimularConHilos(bolillero, jugada, 1000, 4);

        // No deben ser exactamente iguales, pero parecidos
        double diferenciaRelativa = (double)Math.Abs(resultadoSinHilos - resultadoConHilos) / 1000;
        Assert.True(diferenciaRelativa < 0.1, "Los resultados con y sin hilos deben ser similares");
    }
}