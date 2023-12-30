using System;

namespace Server.Items
{
    [FlipableAttribute(0x2336, 0x2332)]
    public class HolidayLights : Item
    {
        //public override int LabelNumber { get { return 1123474; } } // Crystal Skull

        [Constructable]
        public HolidayLights()
            : base(0x2332)
        {     
Name = "Christmas Lights";		
        }

        public HolidayLights(Serial serial)
            : base(serial)
        {
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
