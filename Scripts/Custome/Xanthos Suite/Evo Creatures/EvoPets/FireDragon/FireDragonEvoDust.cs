using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Xanthos.Evo
{
	public class FireDragonDust : BaseEvoDust
	{
		[Constructable]
		public FireDragonDust() : this( 100 )
		{
		}

		[Constructable]
		public FireDragonDust( int amount ) : base( amount )
		{
			Amount = amount;
			Name = "Fire Dragon Dust";
			Hue = Utility.RandomList(2472, 2445, 2446, 2447, 2117, 1461, 338);
		}

		public FireDragonDust( Serial serial ) : base ( serial )
		{
		}

		public override BaseEvoDust NewDust()
		{
			return new FireDragonDust();
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