using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Xanthos.Interfaces;

namespace Xanthos.Evo
{
	[CorpseName( "a poison dragon corpse" )]
	public class PoisonDragon : BaseEvo, IEvoCreature
	{
		public override BaseEvoSpec GetEvoSpec()
		{
			return PoisonDragonSpec.Instance;
		}

		public override BaseEvoEgg GetEvoEgg()
		{
			return new PoisonDragonEgg();
		}

		public override bool AddPointsOnDamage { get { return true; } }
		public override bool AddPointsOnMelee { get { return true; } }
		public override Type GetEvoDustType() { return typeof( PoisonDragonDust ); }

		//public override bool HasBreath{ get{ return true; } }
		

		public PoisonDragon( string name ) : base( name, AIType.AI_Mage, 0.01 )
		{
		}

		public PoisonDragon( Serial serial ) : base( serial )
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