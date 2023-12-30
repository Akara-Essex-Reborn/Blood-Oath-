using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Xanthos.Interfaces;

namespace Xanthos.Evo
{
	public class SwampDragonEvoEgg : BaseEvoEgg
	{
		public override IEvoCreature GetEvoCreature()
		{
            return new EvoSwampDragon("a baby swamp dragon");
		}

		[Constructable]
		public SwampDragonEvoEgg() : base()
		{
			Name = "a swamp dragon egg";
            Hue = Utility.RandomList( 2129, 177, 162, 161, 716, 719, 877, 1271, 1286 );
			HatchDuration = 0.01;		// 15 minutes
		}

        public SwampDragonEvoEgg(Serial serial)
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