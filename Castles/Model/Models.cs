using LanguageExt;

namespace Castles.Model
{
    public record GameState
    {
        public Lst<Option<GameUnit>> Line;
        public Money P1;
        public Money P2;
    }

    public struct GameUnit
    {
        public Hp Hp;
        public Players Owner;
        public UnitProto Proto;

        public override string ToString()
        {
            return $"{nameof(Hp)}: {Hp}, {nameof(Owner)}: {Owner}, {nameof(Proto)}: {Proto}";
        }
    }

    public record Hp
    {
        private const int MaxValue = 9;

        private readonly int _value;

        public static Hp Of(int value)
        {
            return new Hp(value);
        }

        public Hp(int value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return $"Hp [{_value}]";
        }
    }

    public record Money
    {
        private readonly int _value;

        public Money(int money)
        {
            _value = money;
        }

        public static Money Of(int value)
        {
            return new Money(value);
        }

        public override string ToString()
        {
            return $"Money [{_value}]";
        }
    }

    public struct View
    {
        private readonly string _p1View;
        private readonly string _p2View;

        public View(string p1, string p2)
        {
            _p1View = p1;
            _p2View = p2;
        }

        public readonly string Render(Players owner) => owner switch
        {
            Players.P1 => _p1View,
            _ => _p2View
        };
    }

    public enum UnitType
    {
        Warrior,
        Archer,
        Cleric,
        Castle
    }

    public enum Players
    {
        P1,
        P2
    }
}