using LanguageExt;

namespace Castles.Model
{
    public struct State
    {
        public Lst<Some<Cell>> Line;
        public Map<Players, PlayerData> Players;
    }

    public struct Cell
    {
        public GameUnit Unit;
        public bool IsOccupied;
    }

    public struct GameUnit
    {
        public UnitType Type;
        public int Hp;
        public Players Owner;
    }

    public struct UnitProto
    {
        public UnitType Type;
        public int Hp;
        public int Damage;
    }

    public enum UnitType
    {
        Warrior,
        Archer,
        Cleric
    }

    public enum Players
    {
        P1,
        P2
    }

    public struct PlayerData
    {
        public Some<int> Hp;
        public Some<int> Money;
    }
}