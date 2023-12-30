using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Xanthos.Interfaces;

namespace Xanthos.Evo
{
	[CorpseName( "a treefellow corpse" )]
	public class Tree : BaseEvo, IEvoCreature
	{
		public override BaseEvoSpec GetEvoSpec()
		{
			return TreeSpec.Instance;
		}

		public override BaseEvoEgg GetEvoEgg()
		{
			return new TreeSeed();
		}

		public override bool AddPointsOnDamage { get { return true; } }
		public override bool AddPointsOnMelee { get { return true; } }
		public override Type GetEvoDustType() { return typeof( TreeDust ); }

		//public override bool HasBreath{ get{ return false; } }
	

		public Tree( string name ) : base( name, AIType.AI_Mystic, 0.01 )
		{
		}

		public Tree( Serial serial ) : base( serial )
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