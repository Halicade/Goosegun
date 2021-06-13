using RimWorld;
using Verse;

namespace Goosegun
{
	public class GooseBullet : Bullet
	{
		static readonly PawnKindDef gooseDef = PawnKindDef.Named("Goose");

		public override void Impact(Thing hitThing)
		{
			var faction = FactionUtility.DefaultFactionFrom(gooseDef.defaultFactionType);
			var pawn = PawnGenerator.GeneratePawn(gooseDef, faction);
			var goose = GenSpawn.Spawn(pawn, Position, Map, WipeMode.Vanish) as Pawn;
			_ = goose.health.AddHediff(HediffDefOf.Scaria, null, null, null);
			_ = goose.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.ManhunterPermanent, null, false, false, null, false);

			GenClamor.DoClamor(this, 2.1f, ClamorDefOf.Impact);
			Destroy(DestroyMode.Vanish);
		}
	}
}
