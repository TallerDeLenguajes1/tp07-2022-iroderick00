namespace Listas
{
    internal class Program
    {
        static void cargarTarea (Tarea tarea, int id)
        {
            tarea.TareaID = id+1;
            Console.WriteLine("Ingrese la descripcion de la tarea: ");
            tarea.descripcion = Console.ReadLine();
            Console.WriteLine("Ingrese la duracion en horas: ");
            tarea.duracion = Convert.ToInt32(Console.ReadLine());
        }
        static void mostrarTarea(Tarea tarea)
        {
            Console.WriteLine("---------------");
            Console.WriteLine($"Tarea Numero: {tarea.TareaID}.");
            Console.WriteLine($"Duracion: {tarea.duracion} horas.");
            Console.WriteLine($"{tarea.descripcion}.");
            Console.WriteLine("---------------");

        }
        static void mostrarLista(List<Tarea> pendientes, List<Tarea> realizadas)
        {
            Console.WriteLine("\n---------------TAREAS PENDIENTES---------------\n");
            foreach (var tarea in pendientes)
            {
                mostrarTarea(tarea);
            }
            Console.WriteLine("\n---------------TAREAS COMPLETADAS---------------\n");
            foreach (var tarea in realizadas)
            {
                mostrarTarea(tarea);
            }
        }
        static void ordenarTareas(List<Tarea> pendientes, List<Tarea> realizadas)
        {
            int indice, end=1;
            do
            {
                Console.Clear();
                mostrarLista(pendientes, realizadas);
                Console.WriteLine("Ingrese el indice de la tarea que desea marcar como realizada: ");
                indice = Convert.ToInt32(Console.ReadLine()) - 1;

                realizadas.Add(pendientes[indice]);
                pendientes.RemoveAt(indice);

                Console.WriteLine("Quiere seguir ordenando las tareas? [0]:NO - [1]:SI");
                end = Convert.ToInt32(Console.ReadLine());
            } while (end == 1);
        }
        static void buscarTarea(List<Tarea> pendientes, List<Tarea> realizadas)
        {
            string palabra;
            Console.WriteLine("Ingrese la palabra para buscar: ");
            palabra = Console.ReadLine();
            foreach (var tarea in pendientes)
            {
                if (tarea.descripcion.Contains(palabra))
                {
                    Console.WriteLine("Tarea encontrada en PENDIENTES");
                    mostrarTarea(tarea);
                }
            }
            foreach (var tarea in realizadas)
            {
                if (tarea.descripcion.Contains(palabra))
                {
                    Console.WriteLine("Tarea encontrada en REALIZADAS");
                    mostrarTarea(tarea);
                }
            }
        }
        static void contarHoras(List<Tarea> realizadas)
        {
            int horasTrabajadas = 0;
            foreach (var tarea in realizadas)
            {
                horasTrabajadas += tarea.duracion;
            }
            Console.WriteLine($"El trabajador completó {horasTrabajadas} horas de trabajo.");
        }
        static void Main(string[] args)
        {
            var tareasSinRealizar = new List<Tarea>();
            var tareasRealizadas = new List<Tarea>();
            Tarea tareaAuxiliar;
            int cantidadDeTareas = new Random().Next(2, 5);

            for (int i = 0; i < cantidadDeTareas; i++)
            {
                tareaAuxiliar = new Tarea();
                cargarTarea(tareaAuxiliar, i);
                tareasSinRealizar.Add(tareaAuxiliar);
            }
            mostrarLista(tareasSinRealizar, tareasRealizadas);
            ordenarTareas(tareasSinRealizar, tareasRealizadas);
            buscarTarea(tareasRealizadas, tareasRealizadas);
        }
    }
}