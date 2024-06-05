List<string> TaskList = new List<string>();

int selectedOption = 0;
do
{
    selectedOption = ShowMenu();
    if (selectedOption == (int)OptionMenu.Add)
    {
        AddTask();
    }
    else if (selectedOption == (int)OptionMenu.Remove)
    {
        RemoveTask();
    }
    else if (selectedOption == (int)OptionMenu.List)
    {
        ShowMenuTaskList();
    }
} while (selectedOption != (int)OptionMenu.Exit);



int ShowMenu()
{
    Console.WriteLine(
        """
        ----------------------------------------
        1. Nueva tarea
        2. Remover tarea
        3. Tareas pendientes
        4. Salir
        """
    );

    string line = Console.ReadLine();
    return Convert.ToInt32(line);
}

void RemoveTask()
{
    try
    {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");

        ListTasks();

        string line = Console.ReadLine();
        
        // Removes 1 to convert position to index
        int indexToRemove = Convert.ToInt32(line) - 1;
        bool indexIsInRange = indexToRemove >= 0 && indexToRemove < TaskList.Count - 1;
        if (!indexIsInRange)
        {
            Console.WriteLine("Número de tarea no válido.");
        }
        else
        {
            string task = TaskList[indexToRemove];
            TaskList.RemoveAt(indexToRemove);
            Console.WriteLine($"Tarea {task} eliminada");
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
    }
}

void AddTask()
{
    Console.WriteLine("Ingrese el nombre de la tarea: ");
    string task = Console.ReadLine();
    TaskList.Add(task);
    Console.WriteLine("Tarea registrada");
}

void ShowMenuTaskList()
{
    if (TaskList.Count == 0)
    {
        Console.WriteLine("No hay tareas por realizar");
        return;
    }

    ListTasks();
}

void ListTasks()
{
    Console.WriteLine("----------------------------------------");

    int index = 0;
    TaskList.ForEach((task) =>
    {
        index++;
        Console.WriteLine($"{index}. {task}");
    });

    Console.WriteLine("----------------------------------------");
}

public enum OptionMenu
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4,
}
