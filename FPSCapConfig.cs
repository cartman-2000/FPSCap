using System;
using Rocket.API;

namespace FPSCap
{
    public class FPSCapConfig : IRocketPluginConfiguration
    {
        public int defaultTPS;

        public void LoadDefaults()
        {
            defaultTPS = 60;
        }
    }
}
