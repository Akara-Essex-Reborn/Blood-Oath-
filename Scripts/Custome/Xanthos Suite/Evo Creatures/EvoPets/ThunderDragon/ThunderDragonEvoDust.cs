using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Xanthos.Evo
{
	public class ThunderDragonDust : BaseEvoDust
	{
		[Constructable]
		public ThunderDragonDust() : this( 100 )
		{
		}

		[Constructable]
		public ThunderDragonDust( int amount ) : base( amount )
		{
			Amount = amount;
			Name = "Thunder Dragon Dust";
			Hue = Utility.RandomList(1276, 1376, 1462, 1929, 2452, 2454, 2467, 2468);
		}

		public ThunderDragonDust( Serial serial ) : base ( serial )
		{
		}

		public override BaseEvoDust NewDust()
		{
			return new ThunderDragonDust();
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