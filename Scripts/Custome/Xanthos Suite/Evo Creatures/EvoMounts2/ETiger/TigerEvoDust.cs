using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Xanthos.Evo
{
	public class TigerEvoDust : BaseEvoDust
	{
		[Constructable]
		public TigerEvoDust() : this( 1 )
		{
		}

		[Constructable]
		public TigerEvoDust( int amount ) : base( amount )
		{
			Amount = amount;
			Name = "ridable tiger dust";
			Hue = Utility.RandomList(0, 2720, 2728, 2037, 2042, 2049, 2059, 1150, 1153);
		}

        public TigerEvoDust(Serial serial)
            : base(serial)
		{
		}

		public override BaseEvoDust NewDust()
		{
            return new TigerEvoDust();
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