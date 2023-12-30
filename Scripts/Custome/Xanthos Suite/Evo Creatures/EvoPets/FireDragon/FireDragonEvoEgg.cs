using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Xanthos.Interfaces;

namespace Xanthos.Evo
{
	public class FireDragonEgg : BaseEvoEgg
	{
		public override IEvoCreature GetEvoCreature()
		{
			return new FireDragon( "a fire dragon hatchling" );
		}

		[Constructable]
		public FireDragonEgg() : base()
		{
			Name = "a fire dragon egg";
			HatchDuration = 0.01;		// 15 minutes
			Hue = Utility.RandomList(2472, 2445, 2446, 2447, 2117, 1461, 338);
		}

		public FireDragonEgg( Serial serial ) : base ( serial )
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