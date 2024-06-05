using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; }

        static void Main(string[] args)
        {
            TaskList = new List<string>();
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
        }

        /// <summary>
        /// Shows the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMenu()
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

            // Read line
            string line = Console.ReadLine();
            return Convert.ToInt32(line);
        }

        public static void RemoveTask()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");

                // Show current tasks
                ListTasks();

                string line = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(line) - 1;
                if (indexToRemove > -1)
                {
                    if (TaskList.Count > 0)
                    {
                        string task = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine("Tarea " + task + " eliminada");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public static void AddTask()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string task = Console.ReadLine();
                TaskList.Add(task);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuTaskList()
        {
            if (TaskList == null || TaskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            }
            else
            {
                ListTasks();
            }
        }

        private static void ListTasks()
        {
            Console.WriteLine("----------------------------------------");

            for (int i = 0; i < TaskList.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + TaskList[i]);
            }

            Console.WriteLine("----------------------------------------");
        }

        public enum OptionMenu
        {
            Add = 1,
            Remove = 2,
            List = 3,
            Exit = 4,
        }
    }
}
