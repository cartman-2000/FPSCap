//Rocket Mod TPS command used as a template for this command.
using System;
using System.Collections.Generic;
using Rocket.API;
using Rocket.Unturned.Chat;
using Steamworks;
using UnityEngine;

namespace FPSCap
{
    public class CommandTPS : IRocketCommand
    {
        public AllowedCaller AllowedCaller
        {
            get { return AllowedCaller.Both; }
        }

        public string Name
        {
            get { return "tps"; }
        }

        public string Help
        {
            get { return "Shows the server's current TPS."; }
        }

        public string Syntax
        {
            get { return ""; }
        }

        public List<string> Aliases
        {
            get { return new List<string>(); }
        }

        public List<string> Permissions
        {
            get { return new List<string>() { "FPSCap.tps" }; }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            int timeLeft = (int)((DateTime.UtcNow - FPSCap.Started).TotalSeconds);
            string runningTimeFormat = "";

            // Format days, hours minutes and seconds since the server was started.
            if (timeLeft >= (60 * 60 * 24))
            {
                runningTimeFormat = ((int)(timeLeft / (60 * 60 * 24))).ToString() + "d ";
            }
            if (timeLeft >= (60 * 60))
            {
                runningTimeFormat += ((int)((timeLeft / (60 * 60)) % 24)).ToString() + "h ";
            }
            if (timeLeft >= 60)
            {
                runningTimeFormat += ((int)((timeLeft / 60) % 60)).ToString() + "m ";
            }
            runningTimeFormat += ((int)(timeLeft % 60)).ToString() + "s";

            UnturnedChat.Say(caller, FPSCap.Instance.Translations.Instance.Translate("tps_tps", FPSCap.TPS));
            UnturnedChat.Say(caller, FPSCap.Instance.Translations.Instance.Translate("tps_running_since", FPSCap.Started.ToString(), runningTimeFormat));
        }
    }
}
