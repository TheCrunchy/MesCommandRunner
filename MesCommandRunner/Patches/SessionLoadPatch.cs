using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MesCommandRunner.Commands;
using Sandbox.Game.SessionComponents;
using Torch.Managers.PatchManager;
using VRage.Game.Components;

namespace MesCommandRunner.Patches
{
  [PatchShim]
    public static class SessionLoadPatch
    {
        public static void Patch(PatchContext ctx)
        {
            ctx.GetPattern(contract).Prefixes.Add(contractPatch);
        }
        internal static readonly MethodInfo contract =
            typeof(MySessionComponentBase).GetMethod("LoadData",
                BindingFlags.Instance | BindingFlags.Public) ??
            throw new Exception("Failed to find patch method contract");

        internal static readonly MethodInfo contractPatch =
            typeof(SessionLoadPatch).GetMethod(nameof(LoadData), BindingFlags.Static | BindingFlags.Public) ??
            throw new Exception("Failed to find patch method");

        public static bool Loaded = false;

        public static void LoadData()
        {
            if (!Loaded)
            {
                Core.MesAPI = new MESApi();

               Loaded = true;
            }
        }

    }
}
