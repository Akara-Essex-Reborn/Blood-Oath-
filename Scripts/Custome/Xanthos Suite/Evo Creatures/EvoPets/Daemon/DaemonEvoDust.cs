using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Xanthos.Evo
{
	public class DaemonDust : BaseEvoDust
	{
		[Constructable]
		public DaemonDust() : this( 100 )
		{
		}

		[Constructable]
		public DaemonDust( int amount ) : base( amount )
		{
			Amount = amount;
			Name = "Daemon Dust";
			Hue = Utility.RandomList(1793, 2523, 2534, 1945, 2527, 1176, 1932, 2576, 2529, 2530, 2691, 1171, 1795, 1150, 2975);
		}

		public DaemonDust( Serial serial ) : base ( serial )
		{
		}

		public override BaseEvoDust NewDust()
		{
			return new DaemonDust();
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