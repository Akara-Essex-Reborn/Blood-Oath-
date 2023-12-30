using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Xanthos.Interfaces;

namespace Xanthos.Evo
{
	[CorpseName( "a tiger corpse" )]
	public class EvoTiger : BaseEvoMount, IEvoCreature
	{
		public override BaseEvoSpec GetEvoSpec()
		{
			return TigerEvoSpec.Instance;
		}

		public override BaseEvoEgg GetEvoEgg()
		{
			return new TigerEvoEgg();
		}

		public override bool AddPointsOnDamage { get { return true; } }
		public override bool AddPointsOnMelee { get { return true; } }
		public override Type GetEvoDustType() { return typeof( TigerEvoDust ); }

		//public override bool HasBreath{ get{ return false; } }

		public EvoTiger( string name ) : base( name, 1255, 0x3EC8 )
		{
		}

        public EvoTiger(Serial serial)
            : base(serial)
		{
		}

		public override WeaponAbility GetWeaponAbility()	
		{
			return WeaponAbility.Dismount;
		} 

		public override bool SubdueBeforeTame{ get{ return false; } } // Must be beaten into submission
		
		public override int GetAngerSound()
		{
			return 0x3F6;
		}

		public override int GetIdleSound()
		{
			return 0x3F4;
		}

		public override int GetAttackSound()
		{
			return 0x3F8;
		}

		public override int GetHurtSound()
		{
			return 0xB8;
		}

		public override int GetDeathSound()
		{
			return 0x4D5;
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