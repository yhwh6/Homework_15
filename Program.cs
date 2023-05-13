namespace Homework_15
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting...\n");

            ConsoleColor[] colors = { ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Blue, ConsoleColor.Magenta };

            for (int i = 0; i < colors.Length; i++)
            {
                int delay = (i + 1) * 1000;
                string text = $"Message {i + 1} from";

                Thread t = new Thread(() =>
                {
                    Console.ForegroundColor = colors[i];

                    Console.WriteLine($"{text} Thread {Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(delay);
                    Console.WriteLine($"{text} Thread {Thread.CurrentThread.ManagedThreadId} finished");

                    Console.ResetColor();
                });
                t.Start();

                await Task.Delay(delay);

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"{text} Main Thread");
                Console.ResetColor();
            }
            Console.WriteLine("\nDone");
        }
    }
}