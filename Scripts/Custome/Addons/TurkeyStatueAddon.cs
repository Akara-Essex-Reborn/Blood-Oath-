// Automatically generated by the
// AddonGenerator script by Arya
// Generator edited 10.Mar.07 by Papler
using System;
using Server;
using Server.Items;
namespace Server.Items
{
	public class TurkeyStatueAddon : BaseAddon {
		public override BaseAddonDeed Deed{get{return new TurkeyStatueAddonDeed();}}
		[ Constructable ]
		public TurkeyStatueAddon()
		{
			AddonComponent ac = null;
			ac = new AddonComponent( 9889 );
			ac.Hue = 1504;
			ac.Name = "turkey";
			AddComponent( ac, 0, 0, 0 );

			ac = new AddonComponent( 9890 );
			ac.Hue = 1504;
			AddComponent( ac, 1, 1, 10 );

			ac = new AddonComponent( 8401 );
			ac.Hue = 546;
			ac.Name = "turkey";
			AddComponent( ac, 1, 1, 6 );

			ac = new AddonComponent( 9890 );
			ac.Hue = 1510;
			ac.Name = "turkey";
			AddComponent( ac, 1, 1, 11 );


		}
		public TurkeyStatueAddon( Serial serial ) : base( serial ){}
		public override void Serialize( GenericWriter writer ){base.Serialize( writer );writer.Write( 0 );}
		public override void Deserialize( GenericReader reader ){base.Deserialize( reader );reader.ReadInt();}
	}

	public class TurkeyStatueAddonDeed : BaseAddonDeed {
		public override BaseAddon Addon{get{return new TurkeyStatueAddon();}}
		[Constructable]
		public TurkeyStatueAddonDeed(){Name = "TurkeyStatue";}
		public TurkeyStatueAddonDeed( Serial serial ) : base( serial ){}
		public override void Serialize( GenericWriter writer ){	base.Serialize( writer );writer.Write( 0 );}
		public override void	Deserialize( GenericReader reader )	{base.Deserialize( reader );reader.ReadInt();}
	}
}