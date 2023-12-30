using System;

namespace Server.Items
{
    public class UltimateQuiver: BaseQuiver
	{
		public override bool IsArtifact { get { return true; } }
        [Constructable]
        public UltimateQuiver()
            : base(0x2B02)
        {
            LootType = LootType.Blessed;
            Weight = 8;
            WeightReduction =100 ;
            LowerAmmoCost = 100;
            Attributes.DefendChance = 10;
        }

        public UltimateQuiver(Serial serial)
            : base(serial)
        {
        }

		public override bool CanAlter
		{
			get
			{
				return false;
			}
		}

        public override int LabelNumber
        {
            get
            {
                return 1075201;
            }
        }//UltimateQuiver
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt(2); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();

            if (version < 1 && this.DamageIncrease == 0)
                this.DamageIncrease = 10;

            if (version < 2 && this.Attributes.WeaponDamage == 10)
                this.Attributes.WeaponDamage = 0;
        }
    }
}
