using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Xanthos.Interfaces;

namespace Xanthos.Evo
{
	public class DaemonEgg : BaseEvoEgg
	{
		public override IEvoCreature GetEvoCreature()
		{
			return new Daemon( "a daemon spawn" );
		}

		[Constructable]
		public DaemonEgg() : base()
		{
			Name = "a daemon egg";
			HatchDuration = 0.01;		// 15 minutes
			Hue = Utility.RandomList(1793, 2523, 2534, 1945, 2527, 1176, 1932, 2576, 2529, 2530, 2691, 1171, 1795, 1150, 2975);
		}

		public DaemonEgg( Serial serial ) : base ( serial )
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