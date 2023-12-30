using System;

namespace Server.Items
{
    public class HouseStepsNorthAddon : BaseAddon
    {
        [Constructable]
        public HouseStepsNorthAddon()
            : base()
        {
            AddComponent(new LocalizedAddonComponent(1847, 1021953), 0, -2, -5);
                    AddComponent(new LocalizedAddonComponent(1822, 1021953), 0, -1, -5);
        }

        public HouseStepsNorthAddon(Serial serial)
            : base(serial)
        {
        }

        public override BaseAddonDeed Deed
        {
            get
            {
                return new HouseStepsNorthDeed();
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

    public class HouseStepsNorthDeed : BaseAddonDeed
    {
        [Constructable]
        public HouseStepsNorthDeed()
            : base()
        {
            this.LootType = LootType.Blessed;
			Name = "House Steps North";
        }

        public HouseStepsNorthDeed(Serial serial)
            : base(serial)
        {
        }

        public override BaseAddon Addon
        {
            get
            {
                return new HouseStepsNorthAddon();
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