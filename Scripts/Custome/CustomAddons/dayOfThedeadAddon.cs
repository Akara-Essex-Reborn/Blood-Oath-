using System;
using Server.Gumps;
using Server.Multis;
using Server.Network;

namespace Server.Items
{
    public class dayOfThedeadAddon : BaseAddon
    {
        [Constructable]
        public dayOfThedeadAddon(DirectionType type)
        {
            switch (type)
            {
                case DirectionType.South:
                    AddComponent(new LocalizedAddonComponent(41811, 1072983),-1, -1, 0);
                    AddComponent(new LocalizedAddonComponent(41810, 1072983), 0, -1, 0);
                    AddComponent(new LocalizedAddonComponent(41809, 1072983), 1, -1, 0);
                    AddComponent(new LocalizedAddonComponent(41808, 1072983), -1, 0, 0);
                    AddComponent(new LocalizedAddonComponent(41807, 1072983), 0, 0, 0);
                    AddComponent(new LocalizedAddonComponent(41806, 1072983), 1, 0, 0);
                    AddComponent(new LocalizedAddonComponent(41805, 1072983), -1, 1, 0);
                    AddComponent(new LocalizedAddonComponent(41804, 1072983), 0, 1, 0);
                    AddComponent(new LocalizedAddonComponent(41803, 1072983), 1, 1, 0);

                    break;
                case DirectionType.East:
                    AddComponent(new LocalizedAddonComponent(41820, 1072983), -1,-1, 0);
                    AddComponent(new LocalizedAddonComponent(41819, 1072983), -1, 0, 0);
                    AddComponent(new LocalizedAddonComponent(41818, 1072983), -1, 1, 0);
                    AddComponent(new LocalizedAddonComponent(41817, 1072983), 0, -1, 0);
                    AddComponent(new LocalizedAddonComponent(41816, 1072983), 0, 0, 0);
                    AddComponent(new LocalizedAddonComponent(41815, 1072983), 0, 1, 0);
                    AddComponent(new LocalizedAddonComponent(41814, 1072983), 1, -1, 0);
                    AddComponent(new LocalizedAddonComponent(41813, 1072983), 1, 0, 0);
                    AddComponent(new LocalizedAddonComponent(41812, 1072983), 1, 1, 0);
                    break;
            }
        }



        public dayOfThedeadAddon(Serial serial)
            : base(serial)
        {
        }

        public override BaseAddonDeed Deed { get { return new dayOfThedeadAddonDeed(); } }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class dayOfThedeadAddonDeed : BaseAddonDeed, IRewardOption
    {
        public override int LabelNumber { get { return 1072983; } } 

        public override BaseAddon Addon { get { return new dayOfThedeadAddon(_Direction); } }

        private DirectionType _Direction;

        [Constructable]
        public dayOfThedeadAddonDeed()
            : base()
        {
            LootType = LootType.Blessed;
        }

        public dayOfThedeadAddonDeed(Serial serial)
            : base(serial)
        {
        }

        public void GetOptions(RewardOptionList list)
        {
            list.Add((int)DirectionType.South, 1075386); // South
            list.Add((int)DirectionType.East, 1075387); // East
        }

        public void OnOptionSelected(Mobile from, int choice)
        {
            _Direction = (DirectionType)choice;

            if (!Deleted)
                base.OnDoubleClick(from);
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (IsChildOf(from.Backpack))
            {
                from.CloseGump(typeof(AddonOptionGump));
                from.SendGump(new AddonOptionGump(this, 1154194)); // Choose a Facing:
            }
            else
            {
                from.SendLocalizedMessage(1062334); // This item must be in your backpack to be used.
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
