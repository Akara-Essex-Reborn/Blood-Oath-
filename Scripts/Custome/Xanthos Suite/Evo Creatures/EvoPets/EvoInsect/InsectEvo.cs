using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Xanthos.Interfaces;
using System.Collections;
using System.Collections.Generic;


namespace Xanthos.Evo
{
	[CorpseName( "an insect corpse" )]
	public class Insect : BaseEvo, IEvoCreature
	{
		private static readonly Hashtable m_Table = new Hashtable();
		public override BaseEvoSpec GetEvoSpec()
		{
			return InsectSpec.Instance;
		}

		public override BaseEvoEgg GetEvoEgg()
		{
			return new InsectEgg();
		}

		public override bool AddPointsOnDamage { get { return true; } }
		public override bool AddPointsOnMelee { get { return true; } }
		public override Type GetEvoDustType() { return typeof( InsectDust ); }

		//public override bool HasBreath{ get{ return false; } }
		
		public override Poison PoisonImmune  { get { return Poison.Greater; } }
	

		public Insect( string name ) : base( name, AIType.AI_Berserk, 0.01 )
		{
		}

		public Insect( Serial serial ) : base( serial )
		{
		}
		
		 public override void OnGaveMeleeAttack(Mobile defender)
        {
            base.OnGaveMeleeAttack(defender);

            if (0.05 > Utility.RandomDouble())
            {
                /* Rune Corruption
                * Start cliloc: 1070846 "The creature magically corrupts your armor!"
                * Effect: All resistances -70 (lowest 0) for 5 seconds
                * End ASCII: "The corruption of your armor has worn off"
                */
                ExpireTimer timer = (ExpireTimer)m_Table[defender];

                if (timer != null)
                {
                    timer.DoExpire();
                    defender.SendLocalizedMessage(1070845); // The creature continues to corrupt your armor!
                }
                else
                    defender.SendLocalizedMessage(1070846); // The creature magically corrupts your armor!

                List<ResistanceMod> mods = new List<ResistanceMod>();

                if (Core.ML)
                {
                    if (defender.PhysicalResistance > 0)
                        mods.Add(new ResistanceMod(ResistanceType.Physical, -(defender.PhysicalResistance / 2)));

                    if (defender.FireResistance > 0)
                        mods.Add(new ResistanceMod(ResistanceType.Fire, -(defender.FireResistance / 2)));

                    if (defender.ColdResistance > 0)
                        mods.Add(new ResistanceMod(ResistanceType.Cold, -(defender.ColdResistance / 2)));

                    if (defender.PoisonResistance > 0)
                        mods.Add(new ResistanceMod(ResistanceType.Poison, -(defender.PoisonResistance / 2)));

                    if (defender.EnergyResistance > 0)
                        mods.Add(new ResistanceMod(ResistanceType.Energy, -(defender.EnergyResistance / 2)));
                }
                else
                {
                    if (defender.PhysicalResistance > 0)
                        mods.Add(new ResistanceMod(ResistanceType.Physical, (defender.PhysicalResistance > 70) ? -70 : -defender.PhysicalResistance));

                    if (defender.FireResistance > 0)
                        mods.Add(new ResistanceMod(ResistanceType.Fire, (defender.FireResistance > 70) ? -70 : -defender.FireResistance));

                    if (defender.ColdResistance > 0)
                        mods.Add(new ResistanceMod(ResistanceType.Cold, (defender.ColdResistance > 70) ? -70 : -defender.ColdResistance));

                    if (defender.PoisonResistance > 0)
                        mods.Add(new ResistanceMod(ResistanceType.Poison, (defender.PoisonResistance > 70) ? -70 : -defender.PoisonResistance));

                    if (defender.EnergyResistance > 0)
                        mods.Add(new ResistanceMod(ResistanceType.Energy, (defender.EnergyResistance > 70) ? -70 : -defender.EnergyResistance));
                }

                for (int i = 0; i < mods.Count; ++i)
                    defender.AddResistanceMod(mods[i]);

                defender.FixedEffect(0x37B9, 10, 5);

                timer = new ExpireTimer(defender, mods, TimeSpan.FromSeconds(5.0));
                timer.Start();
                m_Table[defender] = timer;
            }
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
			
			 if (version < 1)
            {
                for (int i = 0; i < this.Skills.Length; ++i)
                {
                    this.Skills[i].Cap = Math.Max(100.0, this.Skills[i].Cap * 0.9);

                    if (this.Skills[i].Base > this.Skills[i].Cap)
                    {
                        this.Skills[i].Base = this.Skills[i].Cap;
                    }
                }
            }
		}
		
		private class ExpireTimer : Timer
        {
            private readonly Mobile m_Mobile;
            private readonly List<ResistanceMod> m_Mods;
            public ExpireTimer(Mobile m, List<ResistanceMod> mods, TimeSpan delay)
                : base(delay)
            {
                this.m_Mobile = m;
                this.m_Mods = mods;
                this.Priority = TimerPriority.TwoFiftyMS;
            }

            public void DoExpire()
            {
                for (int i = 0; i < this.m_Mods.Count; ++i)
                    this.m_Mobile.RemoveResistanceMod(this.m_Mods[i]);

                this.Stop();
                m_Table.Remove(this.m_Mobile);
            }

            protected override void OnTick()
            {
                this.m_Mobile.SendMessage("The corruption of your armor has worn off");
                this.DoExpire();
            }
        }
		
	}
}