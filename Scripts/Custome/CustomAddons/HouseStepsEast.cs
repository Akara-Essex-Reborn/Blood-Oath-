using System;

namespace Server.Items
{
    public class HouseStepsEastAddon : BaseAddon
    {
        [Constructable]
        public HouseStepsEastAddon()
            : base()
        {
            AddComponent(new LocalizedAddonComponent(1846, 1021953), 2, 0, -5);
                    AddComponent(new LocalizedAddonComponent(1822, 1021953), 1, 0, -5);
        }

        public HouseStepsEastAddon(Serial serial)
            : base(serial)
        {
        }

        public override BaseAddonDeed Deed
        {
            get
            {
                return new HouseStepsEastDeed();
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

    public class HouseStepsEastDeed : BaseAddonDeed
    {
        [Constructable]
        public HouseStepsEastDeed()
            : base()
        {
            this.LootType = LootType.Blessed;
			Name = "House Steps East";
        }

        public HouseStepsEastDeed(Serial serial)
            : base(serial)
        {
        }

        public override BaseAddon Addon
        {
            get
            {
                return new HouseStepsEastAddon();
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