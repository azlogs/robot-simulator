namespace Helpers{
    class FileHelper {
        public static string[] ReadFile(string path) {
            if (File.Exists(path)){
                return File.ReadAllLines(path);
            }

            throw new ArgumentException($"File \"{path}\" does not exist.");
        }
    }
}