using System;
using System.Collections.Generic;

class Program
{
    static List<Task> tasks = new List<Task>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Criar Tarefa");
            Console.WriteLine("2. Listar Tarefas Pendentes");
            Console.WriteLine("3. Listar Tarefas Concluídas");
            Console.WriteLine("4. Marcar Tarefa como Concluída");
            Console.WriteLine("5. Excluir Tarefa");
            Console.WriteLine("6. Pesquisar Tarefas");
            Console.WriteLine("7. Exibir Estatísticas");
            Console.WriteLine("8. Sair");

            Console.Write("Escolha uma opção: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateTask();
                    break;
                case "2":
                    ListPendingTasks();
                    break;
                case "3":
                    ListCompletedTasks();
                    break;
                case "4":
                    MarkTaskAsCompleted();
                    break;
                case "5":
                    DeleteTask();
                    break;
                case "6":
                    SearchTasks();
                    break;
                case "7":
                    DisplayStatistics();
                    break;
                case "8":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void CreateTask()
    {
        Console.Write("Título da Tarefa: ");
        string title = Console.ReadLine();

        Console.Write("Descrição da Tarefa: ");
        string description = Console.ReadLine();

        Console.Write("Data de Vencimento (yyyy-MM-dd): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime dueDate))
        {
            tasks.Add(new Task(title, description, dueDate));
            Console.WriteLine("Tarefa criada com sucesso!");
        }
        else
        {
            Console.WriteLine("Formato de data inválido. Tarefa não criada.");
        }
    }

    static void ListPendingTasks()
    {
        Console.WriteLine("Tarefas Pendentes:");
        foreach (var task in tasks)
        {
            if (!task.Completed)
            {
                Console.WriteLine(task);
            }
        }
    }

    static void ListCompletedTasks()
    {
        Console.WriteLine("Tarefas Concluídas:");
        foreach (var task in tasks)
        {
            if (task.Completed)
            {
                Console.WriteLine(task);
            }
        }
    }

    static void MarkTaskAsCompleted()
    {
        Console.Write("Digite o número da tarefa a ser marcada como concluída: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber >= 0 && taskNumber < tasks.Count)
        {
            tasks[taskNumber].Completed = true;
            Console.WriteLine("Tarefa marcada como concluída com sucesso!");
        }
        else
        {
            Console.WriteLine("Número de tarefa inválido.");
        }
    }

    static void DeleteTask()
    {
        Console.Write("Digite o número da tarefa a ser excluída: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber >= 0 && taskNumber < tasks.Count)
        {
            tasks.RemoveAt(taskNumber);
            Console.WriteLine("Tarefa excluída com sucesso!");
        }
        else
        {
            Console.WriteLine("Número de tarefa inválido.");
        }
    }

    static void SearchTasks()
    {
        Console.Write("Digite uma palavra-chave para pesquisa: ");
        string keyword = Console.ReadLine().ToLower();

        Console.WriteLine("Resultados da Pesquisa:");
        foreach (var task in tasks)
        {
            if (task.Title.ToLower().Contains(keyword) || task.Description.ToLower().Contains(keyword))
            {
                Console.WriteLine(task);
            }
        }
    }

    static void DisplayStatistics()
    {
        int pendingTasks = 0;
        int completedTasks = 0;

        DateTime oldestTask = DateTime.MaxValue;
        DateTime newestTask = DateTime.MinValue;

        foreach (var task in tasks)
        {
            if (task.Completed)
            {
                completedTasks++;
            }
            else
            {
                pendingTasks++;
            }

            if (task.DueDate < oldestTask)
            {
                oldestTask = task.DueDate;
            }

            if (task.DueDate > newestTask)
            {
                newestTask = task.DueDate;
            }
        }

        Console.WriteLine($"Número de Tarefas Pendentes: {pendingTasks}");
        Console.WriteLine($"Número de Tarefas Concluídas: {completedTasks}");
        Console.WriteLine($"Tarefa Mais Antiga: {oldestTask.ToString("yyyy-MM-dd")}");
        Console.WriteLine($"Tarefa Mais Recente: {newestTask.ToString("yyyy-MM-dd")}");
    }
}

class Task
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool Completed { get; set; }

    public Task(string title, string description, DateTime dueDate)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
        Completed = false;
    }

    public override string ToString()
    {
        return $"Tarefa: {Title}\nDescrição: {Description}\nData de Vencimento: {DueDate.ToString("yyyy-MM-dd")}\nConcluída: {Completed}\n";
    }
}
