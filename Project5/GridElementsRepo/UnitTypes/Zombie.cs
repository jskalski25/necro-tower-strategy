using Project5.GridElementsRepo;

namespace Project5.GridElementsRepo.UnitTypes
{
    class Zombie : ArmyUnit
    {
        public Zombie()
        {
            texture = Content.LoadTexture("zombie.png");
        }
    }
}
