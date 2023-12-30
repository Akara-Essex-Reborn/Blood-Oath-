using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Xanthos.Evo
{
	public class SwampDragonEvoDust : BaseEvoDust
	{
		[Constructable]
		public SwampDragonEvoDust() : this( 100 )
		{
		}

		[Constructable]
		public SwampDragonEvoDust( int amount ) : base( amount )
		{
			Amount = amount;
			Name = "swamp dragon dust";
			Hue = Utility.RandomList( 2129, 177, 162, 161, 716, 719, 877, 1271, 1286 );
		}

        public SwampDragonEvoDust(Serial serial)
            : base(serial)
		{
		}

		public override BaseEvoDust NewDust()
		{
            return new SwampDragonEvoDust();
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