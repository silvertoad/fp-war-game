using System;
using LanguageExt;

namespace Castles.Model
{
    public struct State
    {
        public Lst<Option<GameUnit>> Line;
        public Map<Players, PlayerData> Players;
    }

    public struct GameUnit
    {
        public Hp Hp;
        public Players Owner;
        public UnitProto Proto;
    }

    public struct Hp
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
    }

    public struct Money
    {
        private readonly int _value;

        public Money(int money)
        {
            _value = money;
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

        public string Render(Players owner) => owner switch
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

    public struct PlayerData
    {
        public Some<int> Hp;
        public Some<int> Money;
    }
}