namespace Presentation.Interfaces
{
    internal interface IConsoleHelper
    {
        public int UserInput();
        void PrintMenu(Dictionary<int, Action> menuOptions, string menuName);
    }
}
