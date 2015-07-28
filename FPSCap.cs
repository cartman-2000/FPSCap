using System;
using UnityEngine;
using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;

namespace FPSCap
{
    public class FPSCap : RocketPlugin<FPSCapConfig>
    {
        public static FPSCap Instance;

        public static float TPS;
        private float updateInterval = 0.005f;
        private float accum;
        private int frames;
        private float timeleft;
        public static DateTime Started = DateTime.UtcNow;

        protected override void Load()
        {
            Instance = this;
            // Sets the default tps limit for the server to what has been set in the config.
            Application.targetFrameRate = Instance.Configuration.Instance.defaultTPS;
            Logger.Log(Translations.Instance.Translate("tps_set", Instance.Configuration.Instance.defaultTPS));
        }

        public void Update()
        {
            timeleft -= Time.deltaTime;
            accum += Time.timeScale / Time.deltaTime;
            frames++;
            if (timeleft <= 0.0)
            {
                TPS = accum / frames;
                timeleft = updateInterval;
                accum = 0f;
                frames = 0;
            }
        }

        public override TranslationList DefaultTranslations
        {
            get
            {
                return new TranslationList
                {
                    { "invalid_arg", "Invalid Arguments." },
                    { "tps_set", "Server TPS has been set to: {0} TPS." },
                    { "ltps_command_help", "<TPS> - Limits the server tps/fps to the value set in the command. 0 disables the TPS cap." },
                    { "tps_tps", "TPS: {0}" },
                    { "tps_running_since", "Running since: {0} UTC, running for: {1}" },
                };
            }
        }
    }
}
