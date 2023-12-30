using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Xanthos.Interfaces;

namespace Xanthos.Evo
{
	[CorpseName( "a kirin corpse" )]
	public class EvoKirin : BaseEvoMount, IEvoCreature
	{
		public override BaseEvoSpec GetEvoSpec()
		{
			return KirinEvoSpec.Instance;
		}

		public override BaseEvoEgg GetEvoEgg()
		{
			return new KirinEvoEgg();
		}

		public override bool AddPointsOnDamage { get { return true; } }
		public override bool AddPointsOnMelee { get { return true; } }
		public override Type GetEvoDustType() { return typeof( KirinEvoDust ); }

		//public override bool HasBreath{ get{ return false; } }

		public EvoKirin( string name ) : base( name, 132, 0x3EAD )
		{
		}

		public EvoKirin( Serial serial ) : base( serial )
		{
		}

		public override WeaponAbility GetWeaponAbility()	
		{
			return WeaponAbility.Dismount;
		} 

		public override bool SubdueBeforeTame{ get{ return false; } } // Must be beaten into submission
		
		public override int GetAngerSound()
		{
			return 0x3C6;
		}

		public override int GetIdleSound()
		{
			return 0x3C7;
		}

		public override int GetAttackSound()
		{
			return 0x3C8;
		}

		public override int GetHurtSound()
		{
			return 0x3C9;
		}

		public override int GetDeathSound()
		{
			return 0x3CA;
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

            if ((this.Rider.Hits - damage) < 30 && this.Rider.Map == attacker.Map && this.Rider.InRange(attacker, 18))	//Range and map checked here instead of other base fuction because of abiliites that don't need to check this
            {
                attacker.BoltEffect(0);
                // 35~100 damage, unresistable, by the Ki-rin.
                attacker.Damage(Utility.RandomMinMax(35, 100), this, false);	//Don't inform mount about this damage, Still unsure wether or not it's flagged as the mount doing damage or the player.  If changed to player, without the extra bool it'd be an infinite loop

                this.Rider.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1042534);	// Your mount calls down the forces of nature on your opponent.
                this.Rider.FixedParticles(0, 0, 0, 0x13A7, EffectLayer.Waist);
                this.Rider.PlaySound(0xA9);	// Ki-rin's whinny.
                return true;
            }

            return false;
        }
		
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write( (int)1 );			
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
			 
			if (version == 0)
                this.AI = AIType.AI_Mage;
		}
	}
}