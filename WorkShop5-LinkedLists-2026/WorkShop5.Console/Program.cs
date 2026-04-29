using DoubleList;

var list = new DoublyLinkedList<string>();
var option = string.Empty;

do
{
    option = Menu();
    switch (option)
    {
        case "1":
            Console.Write("Digit el elemento a adicionar: ");
            var element = Console.ReadLine() ?? string.Empty;
            list.Add(element);
            Console.WriteLine($"Elemento '{element}' adicionado.");
            break;

        case "2":
            try
            {
                Console.Write("Adelante: ");
                list.ShowForward();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;

        case "3":
            try
            {
                Console.Write("Atrás: ");
                list.ShowBackward();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;

        case "4":
            try
            {
                list.SortDescending();
                Console.Write("Lista ordenada descendentemente: ");
                list.ShowForward();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;

        case "5":
            try
            {
                Console.Write("Moda(s): ");
                list.ShowMode();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;

        case "6":
            try
            {
                list.ShowChart();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;

        case "7":
            Console.Write("Digite el elemento a buscar: ");
            var searchElement = Console.ReadLine() ?? string.Empty;
            if (list.Exists(searchElement))
            {
                Console.WriteLine($"El elemento '{searchElement}' SÍ existe en la lista.");
            }
            else
            {
                Console.WriteLine($"El elemento '{searchElement}' NO existe en la lista.");
            }
            break;

        case "8":
            try
            {
                Console.Write("Digite el elemento a eliminar (una ocurrencia): ");
                var deleteOne = Console.ReadLine() ?? string.Empty;
                list.DeleteOne(deleteOne);
                Console.WriteLine($"Una ocurrencia de '{deleteOne}' eliminada.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;

        case "9":
            try
            {
                Console.Write("Digite el elemento a eliminar (todas las ocurrencias): ");
                var deleteAll = Console.ReadLine() ?? string.Empty;
                list.DeleteAll(deleteAll);
                Console.WriteLine($"Todas las ocurrencias de '{deleteAll}' eliminadas.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;

        case "0":
            Console.WriteLine("Saliendo del programa...");
            break;

        default:
            Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
            break;
    }
} while (option != "0");

string Menu()
{
    Console.WriteLine("\n1. Adicionar");
    Console.WriteLine("2. Mostrar hacia adelante");
    Console.WriteLine("3. Mostrar hacia atrás");
    Console.WriteLine("4. Ordenar descendentemente");
    Console.WriteLine("5. Mostrar la(s) moda(s)");
    Console.WriteLine("6. Mostrar gráfico");
    Console.WriteLine("7. Existe");
    Console.WriteLine("8. Eliminar una ocurrencia");
    Console.WriteLine("9. Eliminar todas las ocurrencias");
    Console.WriteLine("0. Salir");
    Console.Write("Digite su opción: ");
    return Console.ReadLine() ?? string.Empty;
}