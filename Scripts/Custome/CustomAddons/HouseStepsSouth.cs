using System;

namespace Server.Items
{
    public class HouseStepsSouthAddon : BaseAddon
    {
        [Constructable]
        public HouseStepsSouthAddon()
            : base()
        {
            AddComponent(new LocalizedAddonComponent(1823, 1021953), 0, 2, -5);
                    AddComponent(new LocalizedAddonComponent(1822, 1021953), 0, 1, -5);
        }

        public HouseStepsSouthAddon(Serial serial)
            : base(serial)
        {
        }

        public override BaseAddonDeed Deed
        {
            get
            {
                return new HouseStepsSouthDeed();
            }
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();
        }
    }

    public class HouseStepsSouthDeed : BaseAddonDeed
    {
        [Constructable]
        public HouseStepsSouthDeed()
            : base()
        {
            this.LootType = LootType.Blessed;
			Name = "House Steps South";
        }

        public HouseStepsSouthDeed(Serial serial)
            : base(serial)
        {
        }

        public override BaseAddon Addon
        {
            get
            {
                return new HouseStepsSouthAddon();
            }
        }
        public override int LabelNumber
        {
            get
            {
                return 1021953;
            }
        }// Table With A Blue Tablecloth
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();
        }
    }
}