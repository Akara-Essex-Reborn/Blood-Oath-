using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Xanthos.Interfaces;

namespace Xanthos.Evo
{
	[CorpseName( "a swamp dragon corpse" )]
	public class EvoSwampDragon : BaseEvoMount, IEvoCreature
	{
		private bool m_BardingExceptional;
        private Mobile m_BardingCrafter;
        private int m_BardingHP;
        private bool m_HasBarding;
        private CraftResource m_BardingResource;
		public override BaseEvoSpec GetEvoSpec()
		{
			return SwampDragonEvoSpec.Instance;
		}

		public override BaseEvoEgg GetEvoEgg()
		{
			return new SwampDragonEvoEgg();
		}

		public override bool AddPointsOnDamage { get { return true; } }
		public override bool AddPointsOnMelee { get { return true; } }
		public override Type GetEvoDustType() { return typeof( SwampDragonEvoDust ); }

		//public override bool HasBreath{ get{ return false; } }

		public EvoSwampDragon( string name ) : base( name, 0x31A, 0x3EBD )
		{
		}

        public EvoSwampDragon(Serial serial)
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
		
		[CommandProperty(AccessLevel.GameMaster)]
        public Mobile BardingCrafter
        {
            get
            {
                return this.m_BardingCrafter;
            }
            set
            {
                this.m_BardingCrafter = value;
                this.InvalidateProperties();
            }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public bool BardingExceptional
        {
            get
            {
                return this.m_BardingExceptional;
            }
            set
            {
                this.m_BardingExceptional = value;
                this.InvalidateProperties();
            }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int BardingHP
        {
            get
            {
                return this.m_BardingHP;
            }
            set
            {
                this.m_BardingHP = value;
                this.InvalidateProperties();
            }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public bool HasBarding
        {
            get
            {
                return this.m_HasBarding;
            }
            set
            {
                this.m_HasBarding = value;

                if (this.m_HasBarding)
                {
                    this.Hue = CraftResources.GetHue(this.m_BardingResource);
                    this.BodyValue = 0x31F;
                    this.ItemID = 0x3EBE;
                }
                else
                {
                    this.Hue = 0x851;
                    this.BodyValue = 0x31A;
                    this.ItemID = 0x3EBD;
                }

                this.InvalidateProperties();
            }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public CraftResource BardingResource
        {
            get
            {
                return this.m_BardingResource;
            }
            set
            {
                this.m_BardingResource = value;

                if (this.m_HasBarding)
                    this.Hue = CraftResources.GetHue(value);

                this.InvalidateProperties();
            }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int BardingMaxHP
        {
            get
            {
                return this.m_BardingExceptional ? 2500 : 1000;
            }
        }
		
		 public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            if (this.m_HasBarding && this.m_BardingExceptional && this.m_BardingCrafter != null)
                list.Add(1060853, this.m_BardingCrafter.Name); // armor exceptionally crafted by ~1_val~
        }
		
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			
			writer.Write( (int)1 );			
			writer.Write((bool)this.m_BardingExceptional);
            writer.Write((Mobile)this.m_BardingCrafter);
            writer.Write((bool)this.m_HasBarding);
            writer.Write((int)this.m_BardingHP);
            writer.Write((int)this.m_BardingResource);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
			
			switch ( version )
            {
                case 1:
                    {
                        this.m_BardingExceptional = reader.ReadBool();
                        this.m_BardingCrafter = reader.ReadMobile();
                        this.m_HasBarding = reader.ReadBool();
                        this.m_BardingHP = reader.ReadInt();
                        this.m_BardingResource = (CraftResource)reader.ReadInt();
                        break;
                    }
            }

            if (this.Hue == 0 && !this.m_HasBarding)
                this.Hue = 0x851;

            if (this.BaseSoundID == -1)
                this.BaseSoundID = 0x16A;
		}
	}
}