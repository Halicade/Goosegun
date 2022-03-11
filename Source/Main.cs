using Brrainz;
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

			CrossPromotion.Install(76561197973010050);
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
}
