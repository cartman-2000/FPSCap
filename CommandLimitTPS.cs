using System;
using System.Collections.Generic;
using UnityEngine;
using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Unturned.Chat;

namespace FPSCap
{
    public class CommandLimitTPS : IRocketCommand
    {
        public bool AllowFromConsole
        {
            get { return true; }
        }

        public string Name
        {
            get { return "limittps"; }
        }

        public string Help
        {
            get { return "Limits the server tps/fps to the value set in the command. 0 disables the TPS cap."; }
        }

        public string Syntax
        {
            get { return "<TPS>"; }
        }

        public List<string> Aliases
        {
            get { return new List<string>() { "ltps" }; }
        }

        public List<string> Permissions
        {
            get { return new List<string> { "fpscap.ltps" }; }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (command.Length == 0)
            {
                UnturnedChat.Say(caller, FPSCap.Instance.Translations.Instance.Translate("ltps_command_help"));
                return;
            }
            int limitTPS;
            if (command.Length == 1 && int.TryParse(command[0], out limitTPS))
            {
                //limit the minimum tps that can be used above a value of 0, but less than 10, to 10.
                if (limitTPS > 0 && limitTPS < 10)
                {
                    limitTPS = 10;
                }
                Application.targetFrameRate = limitTPS;
                if (!(caller is ConsolePlayer))
                {
                    UnturnedChat.Say(caller, FPSCap.Instance.Translations.Instance.Translate("tps_set", limitTPS));
                }
                Logger.Log(FPSCap.Instance.Translations.Instance.Translate("tps_set", limitTPS));
            }
            else
            {
                UnturnedChat.Say(caller, FPSCap.Instance.Translations.Instance.Translate("invalid_arg"));
                return;
            }
        }
    }
}
