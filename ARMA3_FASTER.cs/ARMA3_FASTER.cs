using System;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using WindowsGSM.Functions;
using WindowsGSM.GameServer.Engine;
using WindowsGSM.GameServer.Query;

namespace WindowsGSM.Plugins
{
    public class ARMA3_FASTER //do not use steamcmd, all we need to do is create a dummy severfolder
    {
        // - Plugin Details
        public Plugin Plugin = new Plugin
        {
            name = "WindowsGSM.ARMA3_FASTER", // WindowsGSM.XXXX
            author = "Mildly_Interested",
            description = "🧩 WindowsGSM plugin for supporting FASTER managed Arma 3 Dedicated Server",
            version = "1.0",
            url = "https://github.com/MildlyInterested/WindowsGSM.ARMA3_FASTER", // Github repository link (Best practice)
            color = "#036FBA" // Color Hex
        };


        // - Standard Constructor and properties
        public ARMA3_FASTER(ServerConfig serverData) => _serverData = serverData;
        private readonly ServerConfig _serverData; // Store server start metadata, such as start ip, port, start param, etc
        public string Error, Notice;


        // - Settings properties for SteamCMD installer
        // public override bool loginAnonymous => true; // ARMA3 DOES NOT require to login steam account to install the server, so loginAnonymous = true
        // public override string AppId => "233780"; // Game server appId, ARMA3 is 233780


        // - Game server Fixed variables
        public string StartPath => "arma3server_x64.exe"; // Game server start path, for ARMA3, it is arma3server_x64.exe
        public string FullName = "Arma 3 FASTER Server"; // Game server FullName
        public bool AllowsEmbedConsole = false;  // Does this server support output redirect?
        public int PortIncrements = 10; // This tells WindowsGSM how many ports should skip after installation Arma uses 2302-2306, seperating servers by 10 ports is best practice
        public object QueryMethod = new A2S(); // Query method should be use on current server type. Accepted value: null or new A2S() or new FIVEM() or new UT3()


        // - Game server default values
        public string Port = "2302"; // Default port
        public string QueryPort = "2303"; // Default query port
        public string Defaultmap = "empty"; // Default map name
        public string Maxplayers = "64"; // Default maxplayers
        public string Additional = "-profiles=ArmaHosts -config=server.cfg"; // Additional server start parameter


        // - Create a default cfg for the game server after installation
        public async void CreateServerCFG() { }


        // - Start server function, return its Process to WindowsGSM
        public async Task<Process> Start()
        {
            // Prepare start parameter
            var param = new StringBuilder();
            //param.Append(string.IsNullOrWhiteSpace(_serverData.ServerPort) ? string.Empty : $" -port={_serverData.ServerPort}"); //we do not want to use the GUI port selector but let FASTER handle that
            //param.Append(string.IsNullOrWhiteSpace(_serverData.ServerName) ? string.Empty : $" -name=\"{_serverData.ServerName}\""); //see above, not needed
            param.Append(string.IsNullOrWhiteSpace(_serverData.ServerParam) ? string.Empty : $" {_serverData.ServerParam}"); //this is were the FASTER startup params get pasted into, nothing else is needed
 
            // Prepare Process
            var p = new Process
            {
                StartInfo =
                {
                    WindowStyle = ProcessWindowStyle.Minimized,
                    UseShellExecute = false,
                    WorkingDirectory = ServerPath.GetServersServerFiles(_serverData.ServerID),
                    FileName = ServerPath.GetServersServerFiles(_serverData.ServerID, StartPath),
                    Arguments = param.ToString()
                },
                EnableRaisingEvents = true
            };

            // Start Process
            try
            {
                p.Start();
                return p;
            }
            catch (Exception e)
            {
                return null; // return null if fail to start
            }
        }


        // - Stop server function
        public async Task Stop(Process p) => await Task.Run(() => { p.Kill(); }); // I believe ARMA3 don't have a proper way to stop the server so just kill it

        public async Task<Process> Install()
        {
            return null;
        }
        public async Task<Process> Update()
        {
            return null;
        }
        public bool IsInstallValid()
        {
            return true;
        }
    }

}
