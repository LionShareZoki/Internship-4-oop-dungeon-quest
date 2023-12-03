using Presentation.Interfaces;

namespace Presentation.Repositories
{
    public class ConsoleHelper : IConsoleHelper
    {
        public int UserInput()
        {
            bool isNumber = false;
            int option;
            do
            {
                isNumber = Int32.TryParse(Console.ReadLine(), out option);
            }
            while (!isNumber);

            return option;
        }

        public void PrintMenu(Dictionary<int, Action> menuOptions, string menuName)
        {
            Console.WriteLine(menuName);
            foreach (var option in menuOptions)
            {
                Console.WriteLine($"{option.Key}");
            }
            int menuSelectedOption = UserInput();
            foreach (var option in menuOptions)
            {
                if (option.Key == menuSelectedOption)
                    option.Value.Invoke();
            }
        }
    }
}
