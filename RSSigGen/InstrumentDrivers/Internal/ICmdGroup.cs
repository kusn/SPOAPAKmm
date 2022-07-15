using System.Collections.Generic;

namespace RSSigGen.InstrumentDrivers.Internal
{
    internal interface ICmdGroup
    {
        //
        // Сводка:
        //     Parent group
        ICmdGroup Parent { get; }

        //
        // Сводка:
        //     Name of the group
        string GroupName { get; }

        //
        // Сводка:
        //     Repeated capability. Null if none is available Contains one repcap definition
        //     - one enum and one value
        RepeatedCapability RepCap { get; set; }

        //
        // Сводка:
        //     Returns true, if the group has a RepCap Returns false for a group with MultiRepCaps
        bool HasRepCap { get; }

        //
        // Сводка:
        //     If the group contains multi-repcaps, this field is filled with comma-separated
        //     values with used repcap types
        string MultiRepCapTypes { get; set; }

        //
        // Сводка:
        //     Returns true, if the group has MultiRepCaps defined Returns false for a group
        //     with single repcaps
        bool HasMultiRepCaps { get; }

        //
        // Сводка:
        //     Adds the child to the parent's list of created children This is used when the
        //     group is cloned
        void AddExistingChild(ICmdGroup child);

        //
        // Сводка:
        //     Get all the descendant groups recursively
        IEnumerable<ICmdGroup> GetDescendantExistingChildren();

        //
        // Сводка:
        //     Returns the owners chain including itself up to the entered point or up to the
        //     root by default
        IEnumerable<ICmdGroup> GetOwnersChain();

        //
        // Сводка:
        //     Returns the owners chain including itself up to the entered point or up to the
        //     root by default
        IEnumerable<ICmdGroup> GetOwnersChain(ICmdGroup stop);
    }
}
