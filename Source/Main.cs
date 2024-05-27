using Brrainz;
using HarmonyLib;
using Verse;

namespace Goosegun
{
	public class Main : Mod
	{
		public Main(ModContentPack content) : base(content)
		{
			var harmony = new Harmony("net.pardeike.goosegun");
			harmony.PatchAll();

			CrossPromotion.Install(76561197973010050);
		}
	}
}
