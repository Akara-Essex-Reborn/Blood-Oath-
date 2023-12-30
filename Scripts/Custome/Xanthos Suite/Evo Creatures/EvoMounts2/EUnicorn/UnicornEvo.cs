using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Xanthos.Interfaces;

namespace Xanthos.Evo
{
	[CorpseName( "a unicorn corpse" )]
	public class EvoUnicorn : BaseEvoMount, IEvoCreature
	{
		public override BaseEvoSpec GetEvoSpec()
		{
			return UnicornEvoSpec.Instance;
		}

		public override BaseEvoEgg GetEvoEgg()
		{
			return new UnicornEvoEgg();
		}

		public override bool AddPointsOnDamage { get { return true; } }
		public override bool AddPointsOnMelee { get { return true; } }
		public override Type GetEvoDustType() { return typeof( UnicornEvoDust ); }

		//public override bool HasBreath{ get{ return false; } }

		public EvoUnicorn( string name ) : base( name, 122, 0x3EB4 )
		{
		}

		public EvoUnicorn( Serial serial ) : base( serial )
		{
		}

		public override WeaponAbility GetWeaponAbility()	
		{
			return WeaponAbility.Dismount;
		} 

		public override bool SubdueBeforeTame{ get{ return false; } } // Must be beaten into submission
		
		public override int GetAngerSound()
		{
			return 0x4BD;
		}

		public override int GetIdleSound()
		{
			return 0x4BE;
		}

		public override int GetAttackSound()
		{
			return 0x4BF;
		}

		public override int GetHurtSound()
		{
			return 0x4C0;
		}

		public override int GetDeathSound()
		{
			return 0x4C1;
		}
		public override TimeSpan MountAbilityDelay
        {
            get
            {
                return TimeSpan.FromHours(1.0);
            }
        }
		
		public override bool DoMountAbility(int damage, Mobile attacker)
        {
            if (this.Rider == null || attacker == null)	//sanity
                return false;

            if (this.Rider.Poisoned && ((this.Rider.Hits - damage) < 40))
            {
                Poison p = this.Rider.Poison;

                if (p != null)
                {
                    int chanceToCure = 10000 + (int)(this.Skills[SkillName.Magery].Value * 75) - ((p.RealLevel + 1) * (Core.AOS ? (p.RealLevel < 4 ? 3300 : 3100) : 1750));
                    chanceToCure /= 100;

                    if (chanceToCure > Utility.Random(100))
                    {
                        if (this.Rider.CurePoison(this))	//TODO: Confirm if mount is the one flagged for curing it or the rider is
                        {
                            this.Rider.LocalOverheadMessage(Server.Network.MessageType.Regular, 0x3B2, true, "Your mount senses you are in danger and aids you with magic.");
                            this.Rider.FixedParticles(0x373A, 10, 15, 5012, EffectLayer.Waist);
                            this.Rider.PlaySound(0x1E0);	// Cure spell effect.
                            this.Rider.PlaySound(0xA9);		// Unicorn's whinny.

                            return true;
                        }
                    }
                }
            }

            return false;
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