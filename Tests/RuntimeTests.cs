using System.Collections.Generic;
using Castles;
using Castles.Model;
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
        public void WarriorAttack(GameState initial, GameState expected)
        {
            var result = Runtime.Attack(initial.Line);
            Assert.AreEqual(expected.Line, result);
        }

        public static IEnumerable<TestCaseData> WarriorAttackData()
        {
            yield return new TestCaseData(StateParser.Parse(@"
100/80
### . . . . ] [ ###
100         6 5 100
"),
                StateParser.Parse(@"
100/80
### . . . . ] [ ###
100         3 2 100
"));
        }
    }
}