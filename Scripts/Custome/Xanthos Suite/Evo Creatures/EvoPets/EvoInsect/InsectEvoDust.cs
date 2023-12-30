using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Xanthos.Evo
{
	public class InsectDust : BaseEvoDust
	{
		[Constructable]
		public InsectDust() : this( 100 )
		{
		}

		[Constructable]
		public InsectDust( int amount ) : base( amount )
		{
			Amount = amount;
			Name = "Insect Dust";
			Hue = Utility.RandomList(2484, 2485, 2486, 2487, 2489, 2455, 2456, 2443, 2441, 2467);
		}

		public InsectDust( Serial serial ) : base ( serial )
		{
		}

		public override BaseEvoDust NewDust()
		{
			return new InsectDust();
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