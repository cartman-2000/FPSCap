using System;
using Rocket.Unturned.Plugins;
using UnityEngine;

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
        }
    }
}
