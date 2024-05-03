using Sandbox.Game.Entities.Cube;
using Sandbox.Game.GameSystems;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MesCommandRunner.Commands;
using Torch;
using Torch.API;
using Torch.API.Managers;
using Torch.API.Plugins;
using Torch.API.Session;
using Torch.Managers;
using Torch.Managers.PatchManager;
using Torch.Session;

namespace MesCommandRunner
{
    public class Core : TorchPluginBase
    {
        public TorchSessionState TorchState;
        public static MESApi MesAPI;
        public override void Init(ITorchBase torch)
        {
            base.Init(torch);

            var sessionManager = Torch.Managers.GetManager<TorchSessionManager>();

            if (sessionManager != null)
            {
                sessionManager.SessionStateChanged += SessionChanged;
            }

            SetupConfig();

        }

        public override void Update()
        {
        }

        private void SetupConfig()
        {
          //no config file but me lazy so keeping it here if i need one
        }

        private void SessionChanged(ITorchSession session, TorchSessionState newState)
        {
            TorchState = newState;
            if (newState is TorchSessionState.Loaded)
            {
                //example stuff
            }
        }
    }
}

