using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMockup1.GridElementsRepo.UnitTypes
{
    public class UndeadMeleeUnit: ArmyUnit
    {
        public int OwnerId;

        public UndeadMeleeUnit GetWarriorSample()
        {
            var sample = new UndeadMeleeUnit();

            sample.OwnerId = 1;
            sample.Armor = 10;
            sample.Health = 100;
            sample.Strength = 20;
            sample.FriendlyName = "Skieleton";

            return sample;
        }
    }
}
