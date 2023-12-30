using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Xanthos.Interfaces;

namespace Xanthos.Evo
{
	public class ThunderDragonEgg : BaseEvoEgg
	{
		public override IEvoCreature GetEvoCreature()
		{
			return new ThunderDragon( "a thunder dragon hatchling" );
		}

		[Constructable]
		public ThunderDragonEgg() : base()
		{
			Name = "a thunder dragon egg";
			HatchDuration = 0.01;		// 15 minutes
			Hue = Utility.RandomList(1276, 1376, 1462, 1929, 2452, 2454, 2467, 2468);
		}

		public ThunderDragonEgg( Serial serial ) : base ( serial )
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