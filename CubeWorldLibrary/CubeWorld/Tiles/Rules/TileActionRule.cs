using System.Collections.Generic;
using CubeWorld.Serialization;

namespace CubeWorld.Tiles.Rules
{
    public class TileActionRule : ISerializable
    {
        public enum ActionType
        {
            CLICKED,
            TOUCHED,
            DESTROYED,
            DAMAGED,
            ONFIRE,
            CREATED,
            TIMEOUT,
            HIT_FLOOR
        }

        public ActionType action;
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
            serializer.SerializeEnum(ref action, "action");
            serializer.Serialize(ref rules, "rules");
        }
    }
}
