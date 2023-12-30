using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Xanthos.Interfaces;

namespace Xanthos.Evo
{
	public class TigerEvoEgg : BaseEvoEgg
	{
		public override IEvoCreature GetEvoCreature()
		{
            return new EvoTiger("a baby ridable tiger");
		}

		[Constructable]
		public TigerEvoEgg() : base()
		{
			Name = "a ridable tiger egg";
            Hue = Utility.RandomList(0, 2720, 2728, 2037, 2042, 2049, 2059, 1150, 1153);
			HatchDuration = 0.01;		// 15 minutes
		}

        public TigerEvoEgg(Serial serial)
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