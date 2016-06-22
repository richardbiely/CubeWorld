using CubeWorld.Tiles.Rules;
using System.Collections.Generic;
using CubeWorld.Serialization;

namespace CubeWorld.Tiles
{
    public class TileActionRules : ISerializable
    {
        public TileActionRule[] actionRules;

        public TileActionRule GetRulesForAction(TileActionRule.ActionType action)
        {
            if (actionRules != null)
            {
                foreach (TileActionRule t in actionRules)
                    if (t.action == action)
                        return t;
            }

            return null;
        }

        public void AddActionRule(TileActionRule actionRule)
        {
            List<TileActionRule> r = new List<TileActionRule>();
            if (actionRules != null)
                r.AddRange(actionRules);
            r.Add(actionRule);
            actionRules = r.ToArray();
        }

        public void Serialize(Serializer serializer)
        {
            serializer.Serialize(ref actionRules, "actionRules");
        }
    }
}