namespace Castles.Model
{
    public struct UnitProto
    {
        public readonly UnitType Type;
        public readonly Hp Hp;
        public readonly Hp Damage;
        public readonly Money Cost;
        public readonly View View;

        public UnitProto(UnitType type, Hp hp, Hp damage, Money cost, View view)
        {
            Type = type;
            Hp = hp;
            Damage = damage;
            Cost = cost;
            View = view;
        }

        public static readonly UnitProto Warrior =
            new UnitProto(UnitType.Warrior, new Hp(9), new Hp(3), new Money(15), new View("]", "["));

        public static readonly UnitProto Archer =
            new UnitProto(UnitType.Archer, new Hp(5), new Hp(2), new Money(20), new View("}", "{"));

        public static readonly UnitProto Cleric =
            new UnitProto(UnitType.Cleric, new Hp(3), new Hp(1), new Money(30), new View(")", "("));

        public static readonly UnitProto Castle =
            new UnitProto(UnitType.Castle, new Hp(100), new Hp(0), new Money(0), new View("###", "###"));
    }
}