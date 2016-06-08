using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;


namespace ScriptHub
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var currentDir = Path.GetDirectoryName(Application.ExecutablePath) + "\\";


            var scriptsFilePath = ConfigurationManager.AppSettings["ScriptsConfigFilePath"];
            if (string.IsNullOrEmpty(Path.GetDirectoryName(scriptsFilePath)))
            {
                scriptsFilePath = currentDir + scriptsFilePath;
            }

            var runnersFilePath = ConfigurationManager.AppSettings["RunnersConfigFilePath"];
            if (string.IsNullOrEmpty(Path.GetDirectoryName(runnersFilePath)))
            {
                runnersFilePath = currentDir + runnersFilePath;
            }

            IScriptStore settings = new ScriptStore(scriptsFilePath);
            
            ILogger logger = new Logger(currentDir + "Logs\\");
            IScriptRunnerFactory scriptRunner = new ScriptRunnerFactory(runnersFilePath);

            IScriptHubModel model = new ScriptHubModel(settings, logger, scriptRunner);

            Application.Run(new MainForm(model));
        }
    }
}
