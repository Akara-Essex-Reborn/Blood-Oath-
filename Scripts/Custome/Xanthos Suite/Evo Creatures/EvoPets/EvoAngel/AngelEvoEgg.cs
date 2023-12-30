using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Xanthos.Interfaces;

namespace Xanthos.Evo
{
	public class AngelEgg : BaseEvoEgg
	{
		public override IEvoCreature GetEvoCreature()
		{
			return new Angel( "a cherub" );
		}

		[Constructable]
		public AngelEgg() : base()
		{
			Name = "an angel egg";
			HatchDuration = 0.01;		// 15 minutes
			Hue = Utility.RandomList(1157, 1175, 1172, 1171, 1170, 1169, 1168, 1167, 1166, 1165);
		}

		public AngelEgg( Serial serial ) : base ( serial )
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