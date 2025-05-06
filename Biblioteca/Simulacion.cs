namespace Biblioteca;
public class Simulacion
{
    public long SimularSinHilos(Bolillero bolillero, List<int> jugada, long cantidadSimulaciones)
    {
        long aciertos = 0;
        for (int i = 0; i < cantidadSimulaciones; i++)
        {
            if (bolillero.Jugar(jugada))
                aciertos++;
        }
        return aciertos;
    }
    public long SimularConHilos(Bolillero bolillero, List<int> jugada, long cantidadSimulaciones, int cantidadHilos)
    {
    var tareas = new List<Task<long>>();
    long simulacionesPorHilo = cantidadSimulaciones / cantidadHilos;

    for (int i = 0; i < cantidadHilos; i++)
    {
        tareas.Add(Task.Run(() =>
        {
            long aciertos = 0;
            var clon = (Bolillero)bolillero.Clone();
            for (int j = 0; j < simulacionesPorHilo; j++)
            {
                if (clon.Jugar(jugada))
                    aciertos++;
            }
            return aciertos;
        }));
    }

    long totalAciertos = 0;
    foreach (var tarea in tareas)
    {
        tarea.Wait(); // Esto espera que termine esa tarea
        totalAciertos += tarea.Result;
    }
    return totalAciertos;
    }
}