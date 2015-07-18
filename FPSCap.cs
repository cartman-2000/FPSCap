using System;
using Rocket.Unturned.Plugins;
using UnityEngine;
using Rocket.Core.Logging;
using System.Collections.Generic;

namespace FPSCap
{
    public class FPSCap : RocketPlugin<FPSCapConfig>
    {
        public static FPSCap Instance;
        protected override void Load()
        {
            Instance = this;
            // Sets the default tps limit for the server to what has been set in the config.
            Application.targetFrameRate = Instance.Configuration.defaultTPS;
            Logger.Log(Translate("tps_set", new object[] { Instance.Configuration.defaultTPS }));
        }

        public override Dictionary<string, string> DefaultTranslations
        {
            get
            {
                return new Dictionary<string, string>
                {
                    {
                        "invalid_arg",
                        "Invalid Arguments."
                    },
                    {
                        "tps_set",
                        "Server TPS has been set to: {0} TPS."
                    },
                    {
                        "ltps_command_help",
                        "<TPS> - Limits the server tps/fps to the value set in the command. 0 disables the TPS cap."
                    }
                };
            }
        }
    }
}
