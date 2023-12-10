namespace SOSGame.GUI.Logic {
    public class GameLogger : IGameLogger {
        public async Task Log(string logText) {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\..\Log.txt");
            string sFilePath = Path.GetFullPath(sFile);

            using StreamWriter sw = new StreamWriter(sFilePath, append: true);
            await sw.WriteLineAsync(logText);
            sw.Close();
        }

        public void ResetLog() {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\..\Log.txt");
            string sFilePath = Path.GetFullPath(sFile);

            using StreamWriter sw = new StreamWriter(sFilePath, append: false);
            sw.Write(string.Empty);
            sw.Close();
        }
    }
}

