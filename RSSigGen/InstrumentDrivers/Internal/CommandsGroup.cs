using System;
using System.Collections.Generic;
using System.Linq;
using RSSigGen.RS;

namespace RSSigGen.InstrumentDrivers.Internal
{
    internal class CommandsGroup : ICmdGroup
    {
        internal readonly Core Core;

        internal readonly Instrument IO;

        internal readonly List<ICmdGroup> ExistingChildren;

        //
        // Сводка:
        //     Parent group
        public ICmdGroup Parent { get; }

        //
        // Сводка:
        //     Name of the group
        public string GroupName { get; }

        //
        // Сводка:
        //     Repeated capability. Null if none is available Contains one repcap definition
        //     - one enum and one value
        public RepeatedCapability RepCap { get; set; }

        //
        // Сводка:
        //     Returns true, if the group has a RepCap Returns false for a group with MultiRepCaps
        public bool HasRepCap => RepCap != null;

        //
        // Сводка:
        //     If the group contains multi-repcaps, this field is filled with comma-separated
        //     values with used repcap types
        public string MultiRepCapTypes { get; set; }

        //
        // Сводка:
        //     Returns true, if the group has MultiRepCaps defined Returns false for a group
        //     with single repcaps
        public bool HasMultiRepCaps => MultiRepCapTypes != null;

        internal CommandsGroup(string groupName, Core core, ICmdGroup parent)
        {
            GroupName = groupName;
            Core = core;
            IO = core.IO;
            Parent = parent;
            ExistingChildren = new List<ICmdGroup>();
            parent?.AddExistingChild(this);
        }

        //
        // Сводка:
        //     String representation of the Commands Group
        public override string ToString()
        {
            string text = "SCPI Commands Group " + GroupName;
            if (HasRepCap)
            {
                text += $", RepCap {RepCap.Name} = {RepCap.GetEnumValue()}";
            }

            return text;
        }

        //
        // Сводка:
        //     Adds the child to the parent's list of created children This is used when the
        //     group is cloned, where the whole existing tree of groups have to be recreated
        public void AddExistingChild(ICmdGroup child)
        {
            ExistingChildren.Add(child);
        }

        //
        // Сводка:
        //     Sets RepCap value as enum Default is not allowed.
        internal void SetRepCapEnumValue(object enumValue)
        {
            try
            {
                RepCap.SetEnumValue(enumValue);
            }
            catch (ArgumentException)
            {
                throw new RsSmabException(Core.IO.ResourceName, "Commands group Repeated capability '" + RepCap.Name + "' cannot be set to the value 'Default'. You have to select a concrete value");
            }
        }

        //
        // Сводка:
        //     Returns RepCap value as enum
        internal object GetRepCapEnumValue()
        {
            return RepCap.GetEnumValue();
        }

        //
        // Сводка:
        //     Returns the current string of RepCapCmdValue for the entered RepCapEnumName The
        //     RepCapEnumName can be of the current CommandsGroup or any of their parents
        internal string GetRepCapCmdValue(object enumVal)
        {
            if (!RepeatedCapability.IsDefaultValue(enumVal))
            {
                return RepeatedCapability.GetCmdStringValue(enumVal);
            }

            ICmdGroup cmdGroup = this;
            Type rcType = enumVal.GetType();
            while (cmdGroup != null)
            {
                if (cmdGroup.HasRepCap && cmdGroup.RepCap.MatchesType(rcType))
                {
                    return cmdGroup.RepCap.GetCmdStringValue();
                }

                cmdGroup = cmdGroup.Parent;
            }

            for (cmdGroup = this; cmdGroup != null; cmdGroup = cmdGroup.Parent)
            {
                if (cmdGroup.HasMultiRepCaps && cmdGroup.MultiRepCapTypes.Split(',').Any((string x) => x == rcType.Name))
                {
                    throw new RsSmabException(Core.IO.ResourceName, "You can not use the 'Default' with the repeated capability '" + rcType.Name + "', because its real value is not defined in any of the parent command groups. Please select a concrete value.");
                }
            }

            cmdGroup = this;
            List<string> list = new List<string>();
            while (cmdGroup != null)
            {
                if (cmdGroup.HasRepCap)
                {
                    list.Insert(0, cmdGroup.GroupName + "." + cmdGroup.RepCap.Name);
                }
                else
                {
                    list.Insert(0, cmdGroup.GroupName);
                }

                cmdGroup = cmdGroup.Parent;
            }

            string text = string.Join("\n", list);
            throw new RsSmabException(Core.IO.ResourceName, "Replacing Repeated capabilities in the SCPI command error: Repeated Capability '" + rcType.Name + "' not found in the group chain:\n" + text);
        }

        //
        // Сводка:
        //     Clones the existing group repeated capabilities to the new one Because of the
        //     lazy group properties, the group clones are created by accessing the repcaps
        //     in them
        internal void SynchroniseRepCaps(object clone)
        {
            foreach (ICmdGroup item in from x in GetDescendantExistingChildren()
                                       where x.HasRepCap
                                       select x)
            {
                IEnumerable<ICmdGroup> enumerable = item.GetOwnersChain(this).Reverse();
                object obj = clone;
                foreach (ICmdGroup item2 in enumerable)
                {
                    obj = obj.GetType().GetProperty(item2.GroupName)!.GetValue(obj, null);
                }

                object enumValue = item.RepCap.GetEnumValue();
                obj.GetType().GetProperty(item.RepCap.PropertyName)!.SetValue(obj, enumValue);
            }
        }

        //
        // Сводка:
        //     Clones the existing group repeated capabilities to the new one Because of the
        //     lazy group properties, the group clones are created by accessing the repcaps
        //     in them
        internal void RestoreRepCaps()
        {
            foreach (ICmdGroup item in from x in GetDescendantExistingChildren()
                                       where x.HasRepCap
                                       select x)
            {
                item.RepCap.SetToStartValue();
            }
        }

        //
        // Сводка:
        //     Get all the existing descendant groups recursively
        public IEnumerable<ICmdGroup> GetDescendantExistingChildren()
        {
            yield return this;
            foreach (ICmdGroup existingChild in ExistingChildren)
            {
                foreach (ICmdGroup descendantExistingChild in existingChild.GetDescendantExistingChildren())
                {
                    yield return descendantExistingChild;
                }
            }
        }

        //
        // Сводка:
        //     Returns the parent chain up to the root
        public IEnumerable<ICmdGroup> GetOwnersChain()
        {
            return GetOwnersChain(null);
        }

        //
        // Сводка:
        //     Returns the parent chain up to the entered point
        public IEnumerable<ICmdGroup> GetOwnersChain(ICmdGroup stop)
        {
            List<ICmdGroup> list = new List<ICmdGroup>();
            for (ICmdGroup cmdGroup = this; cmdGroup != stop; cmdGroup = cmdGroup.Parent)
            {
                list.Add(cmdGroup);
            }

            return list;
        }
    }
}
