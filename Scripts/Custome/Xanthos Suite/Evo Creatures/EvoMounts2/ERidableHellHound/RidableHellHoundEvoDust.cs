using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Xanthos.Evo
{
	public class RidableHellHoundEvoDust : BaseEvoDust
	{
		[Constructable]
		public RidableHellHoundEvoDust() : this( 1 )
		{
		}

		[Constructable]
		public RidableHellHoundEvoDust( int amount ) : base( amount )
		{
			Amount = amount;
			Name = "ridable hell hound dust";
			Hue = 0;
		}

        public RidableHellHoundEvoDust(Serial serial)
            : base(serial)
		{
		}

		public override BaseEvoDust NewDust()
		{
            return new RidableHellHoundEvoDust();
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