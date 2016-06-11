using ScriptHub.Model;
using ScriptHub.Model.Interfaces;
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
            var logsFolder = currentDir + "Logs\\";

            try
            {
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


                ILogger logger = new Logger(logsFolder);

                IConfigFile<Scripts> scriptsConfig = new ConfigFile<Scripts>(scriptsFilePath);
                IScriptStore scriptStore = new ScriptStore(scriptsConfig);

                IConfigFile<Runners> runnersConfig = new ConfigFile<Runners>(runnersFilePath);
                IScriptRunnerFactory scriptRunner = new ScriptRunnerFactory(runnersConfig);

                IScriptHubModel model = new ScriptHubModel(scriptStore, logger, scriptRunner);

                Application.Run(new MainForm(model));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
        }
    }
}
