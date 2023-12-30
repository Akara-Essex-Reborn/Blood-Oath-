using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Xanthos.Interfaces;

namespace Xanthos.Evo
{
	public class InsectEgg : BaseEvoEgg
	{
		public override IEvoCreature GetEvoCreature()
		{
			return new Insect( "an insect larva" );
		}

		[Constructable]
		public InsectEgg() : base()
		{
			Name = "an insect egg";
			HatchDuration = 0.01;		// 15 minutes
			Hue = Utility.RandomList(2484, 2485, 2486, 2487, 2489, 2455, 2456, 2443, 2441, 2467);
		}

		public InsectEgg( Serial serial ) : base ( serial )
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