using System;

namespace Server.Items
{
    public class HouseStepsWestAddon : BaseAddon
    {
        [Constructable]
        public HouseStepsWestAddon()
            : base()
        {
            AddComponent(new LocalizedAddonComponent(1865, 1021953), -2, 0, -5);
                    AddComponent(new LocalizedAddonComponent(1822, 1021953), -1, 0, -5);
        }

        public HouseStepsWestAddon(Serial serial)
            : base(serial)
        {
        }

        public override BaseAddonDeed Deed
        {
            get
            {
                return new HouseStepsWestDeed();
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

    public class HouseStepsWestDeed : BaseAddonDeed
    {
        [Constructable]
        public HouseStepsWestDeed()
            : base()
        {
            this.LootType = LootType.Blessed;
			Name = "House Steps West";
        }

        public HouseStepsWestDeed(Serial serial)
            : base(serial)
        {
        }

        public override BaseAddon Addon
        {
            get
            {
                return new HouseStepsWestAddon();
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