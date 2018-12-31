using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Harmony;
using System.Reflection;

namespace NotPlayingWithTheRealMechCommanders
{
    public class Main
    {
        public static void Init(string _directory, string settings)
        {
            HarmonyInstance.Create("Arcananix.NotPlayingWithTheRealMechCommanders").PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
