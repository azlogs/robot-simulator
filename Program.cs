using Helpers;

namespace Toy
{
    class Program
    {
        const string INPUT_FILE = "command.txt";

        public static void Main()
        {
            // read files
            string[] inputCommands = new string[]{};
            try
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                string COMMAND_FILE_PATH = $"{currentDirectory}/{INPUT_FILE}";
                inputCommands = FileHelper.ReadFile(COMMAND_FILE_PATH);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Read file issue{ex}");
            }


            GamePlay.StartGame(inputCommands);
        }
    }

}