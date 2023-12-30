using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Xanthos.Interfaces;


namespace Xanthos.Evo
{
	[CorpseName( "a guardian daemon corpse" )]
	public class GuardianTree : Tree
	{
		public override bool AddPointsOnDamage { get { return false; } }
		public override bool AddPointsOnMelee { get { return false; } }

        [Constructable]
		public GuardianTree() : base( "A Guardian Daemon" )
		{
		

		Name = "Guardian Evo Daemon";
            Body = 149;
			Hue = Utility.RandomList(1793, 2523, 2534, 1945, 2527, 1176, 1932, 2576, 2529, 2530, 2691, 1171, 1795, 1150, 2975);


            SetStr( 1000 );
            SetDex( 200 );
            SetInt( 800 );
                                               
            SetHits( 6000 );
            SetMana( 1000 );
            SetStam( 1000);
                                               
           	SetDamage(  33 );
                                               
            SetDamageType( ResistanceType.Physical, 50 );
            SetDamageType( ResistanceType.Cold, 50 );
            SetDamageType( ResistanceType.Energy, 50 );

            SetResistance( ResistanceType.Physical, 55 );
            SetResistance( ResistanceType.Cold, 81 );
            SetResistance( ResistanceType.Fire, 35 );
            SetResistance( ResistanceType.Energy, 77 );
            SetResistance( ResistanceType.Poison, 44 );
                                               
            SetSkill( SkillName.Anatomy, 70 );
            SetSkill( SkillName.Magery, 70 );
            SetSkill( SkillName.Meditation, 90 );
            SetSkill( SkillName.MagicResist, 85 );
            SetSkill( SkillName.Wrestling, 95 );
            SetSkill( SkillName.Tactics, 95 );
			SetSkill( SkillName.Necromancy, 95 );
            SetSkill( SkillName.SpiritSpeak, 95 );
                                               
            VirtualArmor = 30;

			

				{
				}
			
			Tamable = false;	// Not appropriate as a pet
			
		

		switch ( Utility.Random( 20 ))
            {                                   
            	case 0: AddItem( new DaemonEgg() ); break;
            }	
		
		}
			
          public override void GenerateLoot()
            {
            PackGold( 100 );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5));
             }
			
       public GuardianTree( Serial serial ) : base( serial )
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
