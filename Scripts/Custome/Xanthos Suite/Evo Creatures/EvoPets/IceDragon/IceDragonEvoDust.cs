using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Xanthos.Evo
{
	public class IceDragonDust : BaseEvoDust
	{
		[Constructable]
		public IceDragonDust() : this( 100 )
		{
		}

		[Constructable]
		public IceDragonDust( int amount ) : base( amount )
		{
			Amount = amount;
			Name = "Ice Dragon Dust";
			Hue = Utility.RandomList(1152, 1151, 1173, 1195, 1266, 1927, 2440, 2465, 2499);
		}

		public IceDragonDust( Serial serial ) : base ( serial )
		{
		}

		public override BaseEvoDust NewDust()
		{
			return new IceDragonDust();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}