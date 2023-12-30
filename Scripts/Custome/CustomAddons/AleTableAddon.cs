using System;
using Server.Gumps;
using Server.Multis;
using Server.Network;

namespace Server.Items
{
    public class AleTableAddon : BaseAddon
    {
        [Constructable]
        public AleTableAddon(DirectionType type)
        {
            switch (type)
            {
                case DirectionType.South:
                    AddComponent(new LocalizedAddonComponent(40795, 1157665), 0, -1, 0);
                    AddComponent(new LocalizedAddonComponent(40793, 1157665), 0, 0, 0);
                    AddComponent(new LocalizedAddonComponent(40792, 1157665), 0, 1, 0);
                    break;
                case DirectionType.East:
                    AddComponent(new LocalizedAddonComponent(40789, 1157665), -1, 0, 0);
                    AddComponent(new LocalizedAddonComponent(40787, 1157665), 0, 0, 0);
                    AddComponent(new LocalizedAddonComponent(40786, 1157665), 1, 0, 0);
                    break;
            }
        }

        public override void OnComponentUsed(AddonComponent c, Mobile from)
        {
            if ((from.InRange(c.Location, 3)))
            {
                BaseHouse house = BaseHouse.FindHouseAt(from);

                if (house != null && (house.IsOwner(from) || (house.LockDowns.ContainsKey(this) && house.LockDowns[this] == from)))
                {
                    Components.ForEach(x =>
                    {
                        switch (x.ItemID)
                        {
                            case 40794:
                                {
                                    x.ItemID = 40795;
                                    break;
                                }
                            case 40795:
                                {
                                    x.ItemID = 40794;
                                    break;
                                }
                            case 40788:
                                {
                                    x.ItemID = 40789;
                                    break;
                                }
                            case 40789:
                                {
                                    x.ItemID = 40788;
                                    break;
                                }
                        }
                    });
                }
                else
                {
                    from.SendLocalizedMessage(502092); // You must be in your house to do this.
                }
            }
            else
            {
                from.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1019045); // I can't reach that.
            }
            
            from.AddToBackpack(new GlassMug(BeverageType.Ale));
            Effects.PlaySound(from.Location, from.Map, 0x240);
        }

        public AleTableAddon(Serial serial)
            : base(serial)
        {
        }

        public override BaseAddonDeed Deed { get { return new AleTableDeed(); } }

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

    public class AleTableDeed : BaseAddonDeed, IRewardOption
    {
        public override int LabelNumber { get { return 1157665; } } // Ale Table

        public override BaseAddon Addon { get { return new AleTableAddon(_Direction); } }

        private DirectionType _Direction;

        [Constructable]
        public AleTableDeed()
            : base()
        {
            LootType = LootType.Blessed;
        }

        public AleTableDeed(Serial serial)
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
