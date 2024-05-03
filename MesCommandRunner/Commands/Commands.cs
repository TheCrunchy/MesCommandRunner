using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox.Game.Multiplayer;
using Sandbox.Game.World;
using Torch.Commands;
using Torch.Commands.Permissions;
using VRage.Game.ModAPI;
using VRageMath;

namespace MesCommandRunner.Commands
{
    public class Commands : CommandModule
    {
        [Command("runmes", "Run an MES command")]
        [Permission(MyPromoteLevel.Admin)]
        public void RunCommand(string command, long playerSteamId = 0l)
        {
            if (playerSteamId == 0l)
            {
                Core.MesAPI.ChatCommand(command, new MatrixD()
                {
                    Translation = Vector3D.Zero,
                    Forward = Vector3D.Zero,
                }, 0, 0);

                Context.Respond("Command executed?");
            }
            else
            {
                var identity = MySession.Static.Players.TryGetIdentityId((ulong)playerSteamId);

                Context.Respond("Command executed?");
                Core.MesAPI.ChatCommand(command, new MatrixD()
                {
                    Translation = Vector3D.Zero,
                    Forward = Vector3D.Zero,
                }, identity, (ulong)playerSteamId);
                return;

            }
        }
    }
}
