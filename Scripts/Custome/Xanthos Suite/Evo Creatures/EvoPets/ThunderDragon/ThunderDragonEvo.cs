using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Xanthos.Interfaces;

namespace Xanthos.Evo
{
	[CorpseName( "a thunder dragon corpse" )]
	public class ThunderDragon : BaseEvo, IEvoCreature
	{
		public override BaseEvoSpec GetEvoSpec()
		{
			return ThunderDragonSpec.Instance;
		}

		public override BaseEvoEgg GetEvoEgg()
		{
			return new ThunderDragonEgg();
		}

		public override bool AddPointsOnDamage { get { return true; } }
		public override bool AddPointsOnMelee { get { return true; } }
		public override Type GetEvoDustType() { return typeof( ThunderDragonDust ); }

		//public override bool HasBreath{ get{ return true; } }


		public ThunderDragon( string name ) : base( name, AIType.AI_Mage, 0.01 )
		{
		}

		public ThunderDragon( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write( (int)0 );			
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}