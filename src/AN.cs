using System.Runtime.InteropServices;
using System.Text;

namespace AN
{
    public class console
    {
        public static int ConsoleWidth = System.Console.WindowWidth;

        public static void Text(string text)
        {
            System.Console.WriteLine("== " + text);
        }

        public static void Text_1(string text)
        {
            System.Console.WriteLine("= " + text);
        }

        public static void TextHead(string text)
        {
            var str = new StringBuilder();
            int textLength = text.Length + 6; // إضافة مسافات للإطارات
            int spaces = (ConsoleWidth - textLength) / 2; // حساب الفراغات اللازمة لتوسيط النص
            string padding = new string(' ', spaces);

            // تصميم الهيدر
            str.Append(padding);
            for (int i = 0; i < textLength; i++)
            {
                str.Append("=");
            }

            str.Append("\n" + padding);
            str.Append("|= " + text + " =|\n");

            str.Append(padding);
            for (int i = 0; i < textLength; i++)
            {
                str.Append("=");
            }
            str.Append("\n");

            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine(str.ToString());
            System.Console.ResetColor();
        }

        public static void ColoredText(string str, ConsoleColor textColor = ConsoleColor.White, ConsoleColor bgColor = ConsoleColor.Black)
        {
            System.Console.ForegroundColor = textColor;
            System.Console.BackgroundColor = bgColor;
            System.Console.WriteLine(str);
            System.Console.ResetColor();
        }

        public static string? Input(ConsoleColor textColor = ConsoleColor.Yellow)
        {
            System.Console.ForegroundColor = textColor;
            string? input = System.Console.ReadLine();
            System.Console.ResetColor();

            return input;
        }

        public static string GetMultiLines()
        {
            var str = new StringBuilder();
            string line = "";
            int lineNum = 1;
            console.Info("Type '@END' To End Writing.");

            while (true)
            {
                System.Console.ForegroundColor = ConsoleColor.DarkGray;
                System.Console.Write(lineNum);
                System.Console.ResetColor();

                System.Console.Write("> ");
                System.Console.ForegroundColor = ConsoleColor.Yellow;
                line = System.Console.ReadLine() ?? string.Empty;
                System.Console.ResetColor();

                if (line != "@END")
                {
                    str.AppendLine(line);
                    lineNum += 1;
                }
                else break;
            }

            return str.ToString().Trim();
        }

        public static int GetOneOrTwo() // دالة للحصول على خيار من 1 أو 2
        {
            int choosingOption = 0;
            while (true)
            {
                try
                {
                    System.Console.Write("> ");
                    System.Console.ForegroundColor = ConsoleColor.Yellow;
                    choosingOption = int.Parse(System.Console.ReadLine() ?? "0");
                    System.Console.ResetColor();

                    if (choosingOption < 1 || choosingOption > 2)
                    {
                        AN.console.Warning("Invalid Input, please enter '1' or '2' only!");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    AN.console.Warning("Invalid Input, please enter a valid number!");
                }
                catch (Exception e)
                {
                    AN.console.Error(e.ToString());
                }
            }

            return choosingOption;
        }


        public static void Exit(bool exitConsole = true)
        {
            if (exitConsole)
            {
                AN.console.Info("Exiting the application...");
                Environment.Exit(1);
            }
        }


        public static void Error(string errorText)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("\a*= Error: " + errorText);
            System.Console.ResetColor();
        }

        public static void Warning(string warningText)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkYellow;
            System.Console.WriteLine("\a*= Warning: " + warningText);
            System.Console.ResetColor();
        }

        public static void Info(string infoMes)
        {
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("\a*= Information: " + infoMes);
            System.Console.ResetColor();
        }

        public static void SuccessMessage(string successText)
        {
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("== " + successText);
            System.Console.ResetColor();
        }

        // دالة لتوسيط النص، بتتعامل مع نصوص متعددة السطور
        public static string TextCentering(string text)
        {
            var lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            var centeredText = new StringBuilder();

            foreach (var line in lines)
            {
                int spaces = (ConsoleWidth - line.Length) / 2;
                string padding = new string(' ', spaces);
                centeredText.AppendLine(padding + line);
            }
            return centeredText.ToString();
        }

        public static void Wait()
        {
            System.Console.WriteLine("\nPress any key to exit...");
            System.Console.ReadKey();
        }

        public static bool CheckVarType(object var, Type expectedType)
        {
            return expectedType.IsInstanceOfType(var);
        }
    }

    // كلاس لتسجيل الرسائل والأحداث
    public static class logger
    {
        private static readonly string logFilePath = "logs.txt";

        private static string GetTimestamp()
        {
            DateTime now = DateTime.Now;
            string gregDate = now.ToString("dd/MM/yyyy HH:mm:ss");
            return $"[G: {gregDate}]";
        }

        private static void Log(string level, string message)
        {
            string logEntry = $"{GetTimestamp()} [{level}] {message}";
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine(logEntry);
                }
            }
            catch (Exception ex)
            {
                console.Error("Log write error: " + ex.Message);
            }
        }

        public static void LogInfo(string message)
        {
            Log("INFO", message);
            console.Text("INFO: " + message);
        }

        public static void LogWarning(string message)
        {
            Log("WARNING", message);
            console.Warning(message);
        }

        public static void LogError(string message)
        {
            Log("ERROR", message);
            console.Error(message);
        }

        public static void LogDebug(string message)
        {
            Log("DEBUG", message);
            console.Text("DEBUG: " + message);
        }
    }

    public static class exceptionHelper
    {
        public static void HandleException(Exception ex)
        {
            logger.LogError("Exception occurred: " + ex.ToString());
            console.Error("Exception: " + ex.Message);
        }
    }

    public static class SystemInfo
    {
        public static string GetInfo()
        {
            StringBuilder info = new StringBuilder();
            info.AppendLine("Operating System: " + Environment.OSVersion);
            info.AppendLine("Machine Name: " + Environment.MachineName);
            info.AppendLine("User: " + Environment.UserName);
            info.AppendLine("CLR Version: " + Environment.Version);
            return info.ToString();
        }

        public static class OS
        {
            public static OSPlatform Platform()
            {
                var defualtOS = OSPlatform.Windows;

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    return OSPlatform.Windows;
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    return OSPlatform.Linux;
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    return OSPlatform.OSX;
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD))
                {
                    return OSPlatform.FreeBSD;
                }
                else
                {
                    AN.console.Error("Unkown OS!");
                    return defualtOS;
                }
            }
        }
    }

    public static class libraryInfo
    {
        public static string AN_Library_Version() => "Beta 1.2.0";

        public static string AN_Library_Info() =>
            "Dev: Amr Nour," +
            "\n== Phone Number: +201029671620," +
            "\n== Country: Egypt";

        public static bool IsWork() => true;
    }
}