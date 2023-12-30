using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Xanthos.Evo
{
	public class PoisonDragonDust : BaseEvoDust
	{
		[Constructable]
		public PoisonDragonDust() : this( 100 )
		{
		}

		[Constructable]
		public PoisonDragonDust( int amount ) : base( amount )
		{
			Amount = amount;
			Name = "Poison Dragon Dust";
			Hue = Utility.RandomList(1372, 1267, 1914, 2469, 2470, 2471);
		}

		public PoisonDragonDust( Serial serial ) : base ( serial )
		{
		}

		public override BaseEvoDust NewDust()
		{
			return new PoisonDragonDust();
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