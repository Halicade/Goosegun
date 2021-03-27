using HarmonyLib;
using UnityEngine;
using Verse;

namespace Goosegun
{
	public class Main : Mod
	{
		public Main(ModContentPack content) : base(content)
		{
			var harmony = new Harmony("net.pardeike.goosegun");
			harmony.PatchAll();
		}

		public override void DoSettingsWindowContents(Rect inRect)
		{
			base.DoSettingsWindowContents(inRect);
		}

		public override string SettingsCategory()
		{
			return base.SettingsCategory();
		}

		public override string ToString()
		{
			return base.ToString();
		}

		public override void WriteSettings()
		{
			base.WriteSettings();
		}
	}

	[HarmonyPatch(typeof(Game))]
	[HarmonyPatch("FinalizeInit")]
	static class Game_FinalizeInit_Patch
	{
		public static void Postfix()
		{
			ModCounter.Trigger();
		}
	}
}
