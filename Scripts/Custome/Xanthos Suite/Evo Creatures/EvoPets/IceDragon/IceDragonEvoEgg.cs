using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Xanthos.Interfaces;

namespace Xanthos.Evo
{
	public class IceDragonEgg : BaseEvoEgg
	{
		public override IEvoCreature GetEvoCreature()
		{
			return new IceDragon( "an ice dragon hatchling" );
		}

		[Constructable]
		public IceDragonEgg() : base()
		{
			Name = "an ice dragon egg";
			HatchDuration = 0.01;		// 15 minutes
			Hue = Utility.RandomList(1152, 1151, 1173, 1195, 1266, 1927, 2440, 2465, 2499);
		}

		public IceDragonEgg( Serial serial ) : base ( serial )
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