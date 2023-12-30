using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Xanthos.Interfaces;

namespace Xanthos.Evo
{
	public class RidableHellHoundEvoEgg : BaseEvoEgg
	{
		public override IEvoCreature GetEvoCreature()
		{
            return new EvoRidableHellHound("a baby ridable hell hound");
		}

		[Constructable]
		public RidableHellHoundEvoEgg() : base()
		{
			Name = "a ridable hell hound egg";
            Hue = 0;
			HatchDuration = 0.01;		// 15 minutes
		}

        public RidableHellHoundEvoEgg(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}