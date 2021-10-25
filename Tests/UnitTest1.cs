using System;
using System.Collections.Generic;
using System.Linq;
using Castles;
using Castles.Model;
using LanguageExt;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test, TestCaseSource("WarriorAttackData")]
        public void WarriorAttack(Lst<Cell> row)
        {
            Runtime.Attack();
            Assert.Pass();
        }

        public static IEnumerable<TestCaseData> WarriorAttackData()
        {
            
            var line = (new GameUnit{}, 3);
            yield return new TestCaseData(GetLine(()));
        }

        private static Lst<Cell> GetLine(params (GameUnit unit, int index)[] units)
        {
            var list = Enumerable.Range(0, 29).Map((index, _) => new Cell()).ToList();
            foreach (var valueTuple in units)
            {
                list[valueTuple.index] = new Cell {Unit = valueTuple.unit, IsOccupied = true};
            }

            return new Lst<Cell>(list);
        }

        private GameUnit GetUnit(UnitType type)
        {
            switch (type)
            {
                case UnitType.Warrior:
                    return new GameUnit{Hp = };
                case UnitType.Archer:
                    break;
                case UnitType.Cleric:
                    break;
            }
        }
    }
}