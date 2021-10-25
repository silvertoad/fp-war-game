using Castles.Model;
using LanguageExt;
using NUnit.Framework;
using static LanguageExt.Prelude;

namespace Tests
{
    public class StateParserTests
    {
        [Test]
        public void Parse()
        {
            var data = @"
100/80
### . . . . ] { ###
100         6 3 90
";

            var expectedState = new GameState
            {
                Line = new Lst<Option<GameUnit>>(Range(0, 8).Map(_ => Option<GameUnit>.None))
                    .SetItem(0, new GameUnit {Hp = Hp.Of(100), Owner = Players.P1, Proto = UnitProto.Castle})
                    .SetItem(5, new GameUnit {Hp = Hp.Of(6), Owner = Players.P1, Proto = UnitProto.Warrior})
                    .SetItem(6, new GameUnit {Hp = Hp.Of(3), Owner = Players.P2, Proto = UnitProto.Archer})
                    .SetItem(7, new GameUnit {Hp = Hp.Of(90), Owner = Players.P2, Proto = UnitProto.Castle}),
                P1 = Money.Of(100),
                P2 = Money.Of(80)
            };

            var state = StateParser.Parse(data);
            Assert.AreEqual(expectedState, state);
        }
    }
}