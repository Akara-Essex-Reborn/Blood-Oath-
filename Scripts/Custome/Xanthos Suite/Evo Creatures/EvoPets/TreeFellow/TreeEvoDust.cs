using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Xanthos.Evo
{
	public class TreeDust : BaseEvoDust
	{
		[Constructable]
		public TreeDust() : this( 100 )
		{
		}

		[Constructable]
		public TreeDust( int amount ) : base( amount )
		{
			Amount = amount;
			Name = "Treefellow Dust";
			Hue = Utility.RandomList(1157, 1175, 1172, 1171, 1170, 1169, 1168, 1167, 1166, 1165);
		}

		public TreeDust( Serial serial ) : base ( serial )
		{
		}

		public override BaseEvoDust NewDust()
		{
			return new TreeDust();
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