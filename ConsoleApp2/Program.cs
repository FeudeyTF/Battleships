string[,] Field =
{
    {" ", " ", " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " ", " "  },
    {" ", " ", " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " ", " "  },
    {" ", " ", " " , "A" , "A" , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " ", " "  },
    {" ", " ", " " , "A" , "A" , "A" , " " , " " , " " , " " , " " , " " , "B" , "B" , "B" , " " , " " , " " , " ", " "  },
    {" ", " ", " " , "A" , "A" , "A" , " " , " " , " " , " " , " " , " " , " " , "B" , "B" , " " , " " , " " , " ", " "  },
    {" ", " ", " " , " " , "A" , "A" , " " , " " , " " , " " , " " , " " , " " , "B" , "B" , " " , " " , " " , " ", " "  },
    {" ", " ", " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " ", " "  },
    {" ", " ", " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , "B" , " " , " " , " ", " "  },
    {" ", " ", " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , "B" , "B" , " " , " ", " "  },
    {" ", " ", " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , "B" , "B" , " ", " "  },
    {" ", " ", "A" , "A" , "A" , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , "B" , " " , " ", " "  },
    {" ", " ", " " , "A" , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " ", " "  },
    {" ", " ", " " , "A" , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " ", " "  },
    {" ", " ", " " , " " , " " , " " , " " , "A" , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " ", " "  },
    {" ", " ", " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , "B" , "B" , "B" , " ", " "  },
    {" ", " ", " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " ", " "  },
    {" ", " ", " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " ", " "  },
    {" ", " ", " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " ", "B"  },
    {" ", " ", " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " ", " "  },
    {" ", " ", " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " " , " ", " "  }
};
WriteText("Обнаружен вражеский сектор! Получение карты...", ConsoleColor.Yellow);
Console.WriteLine();
for (int i = 0; i < 20; i++)
{
    for (int j = 0; j < 20; j++)
    {
        Console.Write(Field[i, j] == " " ? "*" : Field[i,j]);
    }
    Console.WriteLine();
    Thread.Sleep(500);
}

WriteText("Карта загружена в бортовой компьютер.", ConsoleColor.Green);
WriteText("Подсчёт врагов...", ConsoleColor.Yellow);

int count = ShipsControl.GetShipCount((string[,])Field.Clone(), "A");
Thread.Sleep(1000);
WriteText(count == 0 ? "Кораблей не найдено!" : count == 1 ? "Найден 1 корабль" : "Найдено несколько кораблей! Точное кол-во: " + count, ConsoleColor.Red);
WriteText("Наши силы составляют: " + ShipsControl.GetShipCount((string[,])Field.Clone(), "B"), ConsoleColor.Green);
WriteText("Ожидание команды...", ConsoleColor.Yellow);
while (true)
{
    string[] input = Console.ReadLine().Split(' ');
    string command = input[0];
    switch (command)
    {
        case "help":
            Console.WriteLine("attack - Атака на врагов");
            Console.WriteLine("leave - Улететь из сектора");
            break;
        case "attack":
            WriteText("Подготовка пушек кораблей...", ConsoleColor.Yellow);
            Thread.Sleep(1000);
            WriteText("Переход в режим полной боевой готовности...", ConsoleColor.Yellow);
            Thread.Sleep(1000);
            WriteText("Запуск ионных двигателей...", ConsoleColor.Yellow);
            Thread.Sleep(1000);
            WriteText("Налаживание связи между кораблями...", ConsoleColor.Yellow);
            Thread.Sleep(1000);
            WriteText("ФЛОТ ГОТОВ К АТАКЕ. ПРИГТОВИТЬСЯ К УДАРУ", ConsoleColor.Green);
            Field = ShipsControl.CrashShips(Field, "A");
            WriteText("Атака завершена!", ConsoleColor.Green);
            WriteText("Получена новая карта сектора!", ConsoleColor.Green);
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Console.Write(Field[i, j] == " " ? "*" : Field[i, j]);
                }
                Console.WriteLine();
                Thread.Sleep(500);
            }
            break;
        case "leave":
            WriteText("Вы уходите из сектора, увидев примущество врага", ConsoleColor.Red);
            Thread.Sleep(1000);
            WriteText("На последок вы выглядываете из окна и видите...", ConsoleColor.Yellow);
            Thread.Sleep(1000);
            Field = ShipsControl.CrashShips(Field, "B");
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Console.Write(Field[i, j] == " " ? "*" : Field[i, j]);
                }
                Console.WriteLine();
            }
            break;
        case "exit":
            return 0;
        default:
            WriteText("Команда не найдена! Используйте help",ConsoleColor.Red);
            break;
    }
}

void WriteText(string text, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);
    Console.ResetColor();
}
public class ShipsControl
{
    public static int GetShipCount(string[,] field, string type)
    {
        int count = 0;
        for (int i = 0; i < field.GetLength(0); i++)
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (field[i, j] == type)
                {
                    CrashShips(field, i, j, type);
                    count++;
                }
            }
        return count;
    }
    public static string[,] CrashShips(string[,] field, string type)
    {
        for (int i = 0; i < field.GetLength(0); i++)
            for (int j = 0; j < field.GetLength(1); j++)
                if (field[i, j] == type)
                    field = CrashShips(field, i, j, type);
        return field;
    }
    public static string[,] CrashShips(string[,] field, int i, int j, string type)
    {
        if (field[i, j] == type)
        {
            field[i, j] = " ";
            int len1 = field.GetLength(0);
            int len2 = field.GetLength(1);

            if (i - 1 >= 0)
                CrashShips(field, i - 1, j, type);
            if (i + 1 < len1)
                CrashShips(field, i + 1, j, type);
            if (j + 1 < len2)
                CrashShips(field, i, j + 1, type);
            if (j - 1 >= 0)
                CrashShips(field, i, j - 1, type);
            if (i - 1 >= 0 && j - 1 >= 0)
                CrashShips(field, i - 1, j - 1, type);
            if (i + 1 < len1 && j - 1 >= 0)
                CrashShips(field, i + 1, j - 1, type);
            if (i + 1 < len1 && j + 1 < len2)
                CrashShips(field, i + 1, j + 1, type);
            if (i - 1 >= 0 && j + 1 < len2)
                CrashShips(field, i - 1, j + 1, type);
        }
        return field;
    }
}
