using System.Collections.Generic;
using System.Linq;
using Castles.Model;
using LanguageExt;
using static LanguageExt.Prelude;

namespace Tests
{
    public static class StateParser
    {
        private static readonly UnitProto[] Prototypes = {UnitProto.Archer, UnitProto.Cleric, UnitProto.Warrior};

        private static readonly Players[] Players = {Castles.Model.Players.P1, Castles.Model.Players.P2};

        public static GameState Parse(string input)
        {
            var trim = input.Trim();
            var stateData = trim.Split('\n');
            var goldInfo = stateData[0];
            var line = stateData[1];
            var health = stateData[2];

            var gold = goldInfo.Split("/");
            return new GameState
            {
                P1 = Money.Of(int.Parse(gold[0])), P2 = Money.Of(int.Parse(gold[1])),
                Line = GetLine(line, health)
            };
        }

        private static Lst<Option<GameUnit>> GetLine(string lineView, string healthView)
        {
            Option<GameUnit> GetCastle(Players player, string healthString) => Some(new GameUnit
                {Hp = Hp.Of(int.Parse(healthString)), Owner = player, Proto = UnitProto.Castle});

            return GetSlots(lineView, healthView)
                .Fold(List(GetCastle(Castles.Model.Players.P1, healthView.Substring(0, 3))),
                    (line, slot) =>
                    {
                        return FilterBlank(slot.view)
                            .Match(
                                Some: view =>
                                    line.Add(GetProto(view)
                                        .Map(proto => new GameUnit
                                        {
                                            Hp = Hp.Of(int.Parse(slot.health)),
                                            Owner = proto.View.Render(Castles.Model.Players.P1) == view
                                                ? Castles.Model.Players.P1
                                                : Castles.Model.Players.P2,
                                            Proto = proto
                                        })),
                                None: line);
                    })
                .Add(GetCastle(Castles.Model.Players.P2, healthView.Substring(healthView.Length - 3, 3)));
        }

        private static IEnumerable<(string view, string health)> GetSlots(string lineView, string healthView) =>
            CropLine(lineView).Zip(CropLine(healthView), ToSlot);

        private static string CropLine(string line) => line.Substring(3, line.Length - 6);

        private static (string view, string health) ToSlot(char c1, char c2) => (c1.ToString(), c2.ToString());

        private static Option<string> FilterBlank(string value) =>
            string.IsNullOrWhiteSpace(value) ? None : Some(value);

        private static Option<UnitProto> GetProto(string view)
        {
            return Prototypes
                .Find(x => Players.Any(p => x.View.Render(p) == view));
        }
    }
}