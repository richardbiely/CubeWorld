using CubeWorld.Tiles.Rules;
using System.Collections.Generic;
using CubeWorld.Serialization;

namespace CubeWorld.Tiles
{
    public class TileUpdateRules : ISerializable
    {
        public TileRule[] rules;

        public void AddRule(TileRule rule)
        {
            List<TileRule> r = new List<TileRule>();
            if (rules != null)
                r.AddRange(rules);
            r.Add(rule);
            rules = r.ToArray();
        }

        public void Serialize(Serializer serializer)
        {
            serializer.Serialize(ref rules, "rules");
        }
    }
}