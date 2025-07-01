using RimWorld;
using Verse;

namespace Goosegun
{
    [DefOf]
    public static class GooseCannonDefoF
    {
        public static PawnKindDef Goose;

        static GooseCannonDefoF() {
            DefOfHelper.EnsureInitializedInCtor(typeof(GooseCannonDefoF));
        }
    }

    public class GooseBullet : Bullet
    {
        public override void Impact(Thing hitThing, bool blockedByShield = false) {
            var pawn = PawnGenerator.GeneratePawn(GooseCannonDefoF.Goose);
            IntVec3 cell = Position;
            var map = Map;
            if (!cell.InBounds(map) || !cell.IsValid) {
                Destroy();
                return;
            }

            if (!cell.Standable(map)) {
                cell = GetLastValidCell(origin.ToIntVec3(), cell, map);
            }

            var goose = GenSpawn.Spawn(pawn, cell, Map) as Pawn;
            goose?.health.AddHediff(HediffDefOf.Scaria, null, null, null);
            goose?.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.ManhunterPermanent);

            GenClamor.DoClamor(this, 2.1f, ClamorDefOf.Impact);

            Destroy();
        }

        /// <summary>
        /// Need to get the cell before an impassible cell.
        /// Throws an error if geese try to fly on a cell they shouldn't be at.
        /// </summary>
        private static IntVec3 GetLastValidCell(IntVec3 casterPos, IntVec3 proposedPos, Map map) {
            IntVec3 lastValid = proposedPos;
            foreach (IntVec3 cell in GenSight.PointsOnLineOfSight(proposedPos, casterPos)) {
                if (cell.Standable(map))
                    return cell;
                lastValid = cell;
            }

            return lastValid;
        }
    }
}