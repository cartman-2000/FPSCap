using System;
using Rocket.API;

namespace FPSCap
{
    public class FPSCapConfig : IRocketPluginConfiguration
    {
        public int defaultTPS;
        public IRocketPluginConfiguration DefaultConfiguration
        {
            get
            {
                return new FPSCapConfig()
                {
                    defaultTPS = 60
                };
            }
        }
    }
}
