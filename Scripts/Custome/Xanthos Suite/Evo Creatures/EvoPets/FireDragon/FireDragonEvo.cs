using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Xanthos.Interfaces;

namespace Xanthos.Evo
{
	[CorpseName( "a fire dragon corpse" )]
	public class FireDragon : BaseEvo, IEvoCreature
	{
		public override BaseEvoSpec GetEvoSpec()
		{
			return FireDragonSpec.Instance;
		}

		public override BaseEvoEgg GetEvoEgg()
		{
			return new FireDragonEgg();
		}

		public override bool AddPointsOnDamage { get { return true; } }
		public override bool AddPointsOnMelee { get { return true; } }
		public override Type GetEvoDustType() { return typeof( FireDragonDust ); }

		//public override bool HasBreath{ get{ return true; } }
		

		public FireDragon( string name ) : base( name, AIType.AI_Mage, 0.01 )
		{
		}

		public FireDragon( Serial serial ) : base( serial )
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