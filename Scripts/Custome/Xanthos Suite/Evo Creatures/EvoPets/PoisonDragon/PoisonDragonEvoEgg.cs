using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Xanthos.Interfaces;

namespace Xanthos.Evo
{
	public class PoisonDragonEgg : BaseEvoEgg
	{
		public override IEvoCreature GetEvoCreature()
		{
			return new PoisonDragon( "a poison dragon hatchling" );
		}

		[Constructable]
		public PoisonDragonEgg() : base()
		{
			Name = "a poison dragon egg";
			HatchDuration = 0.01;		// 15 minutes
			Hue = Utility.RandomList(1372, 1267, 1914, 2469, 2470, 2471);
		}

		public PoisonDragonEgg( Serial serial ) : base ( serial )
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