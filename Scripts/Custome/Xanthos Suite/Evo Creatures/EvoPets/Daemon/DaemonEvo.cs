using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Xanthos.Interfaces;

namespace Xanthos.Evo
{
	[CorpseName( "a daemon corpse" )]
	public class Daemon : BaseEvo, IEvoCreature
	{
		public override BaseEvoSpec GetEvoSpec()
		{
			return DaemonSpec.Instance;
		}

		public override BaseEvoEgg GetEvoEgg()
		{
			return new DaemonEgg();
		}

		public override bool AddPointsOnDamage { get { return true; } }
		public override bool AddPointsOnMelee { get { return true; } }
		public override Type GetEvoDustType() { return typeof( DaemonDust ); }
	
		public override void OnDoubleClickDead(Mobile from)
        {
            if (!from.Alive)
            {
                from.Resurrect();

                from.PlaySound(0x214);
                from.FixedEffect(0x376A, 10, 16);
            }
        }


		public Daemon( string name ) : base( name, AIType.AI_NecroMage, 0.01 )
		{
		}

		public Daemon( Serial serial ) : base( serial )
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