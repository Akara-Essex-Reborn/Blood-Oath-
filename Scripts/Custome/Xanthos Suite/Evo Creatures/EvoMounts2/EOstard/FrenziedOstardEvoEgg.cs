using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Xanthos.Interfaces;

namespace Xanthos.Evo
{
	public class FrenziedOstardEvoEgg : BaseEvoEgg
	{
		public override IEvoCreature GetEvoCreature()
		{
			return new EvoFrenziedOstard( "a baby frenzied ostard" );
		}

		[Constructable]
		public FrenziedOstardEvoEgg() : base()
		{
			Name = "a frenzied ostard egg";
            Hue = 1173;
			HatchDuration = 0.01;		// 15 minutes
		}

        public FrenziedOstardEvoEgg(Serial serial)
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