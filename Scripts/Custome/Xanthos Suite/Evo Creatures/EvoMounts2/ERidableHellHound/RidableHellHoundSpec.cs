using System;
using Server;

namespace Xanthos.Evo
{
	public sealed class RidableHellHoundEvoSpec : BaseEvoSpec
	{
		// This class implements a singleton pattern; meaning that no matter how many times the
		// Instance attribute is used, there will only ever be one of these created in the entire system.
		// Copy this template and give it a new name.  Assign all of the data members of the EvoSpec
		// base class in the constructor.  Your subclass must not be abstract.
		// Never call new on this class, use the Instance attribute to get the instance instead.

        RidableHellHoundEvoSpec()
		{
			m_Tamable = true;
			m_MinTamingToHatch = 99.9;
			m_PercentFemaleChance = .04;
            m_GuardianEggOrDeedChance = .01;
			m_AlwaysHappy = false;
			m_ProducesYoung = true;
			m_PregnancyTerm = 14.00;
			m_AbsoluteStatValues = false;
			m_MaxEvoResistance = 90;
			m_MaxTrainingStage = 3;
			m_MountStage = 4;

			m_Skills = new SkillName[4] { SkillName.MagicResist, SkillName.Tactics, SkillName.Wrestling, SkillName.Anatomy };
			m_MinSkillValues = new int[4] { 50, 50, 50, 15, };
			m_MaxSkillValues = new int[4] { 100, 110, 120, 110 };


            m_Stages = new BaseEvoStage[] { new RidableHellHoundStageOne(), new RidableHellHoundStageTwo(), new RidableHellHoundStageThree(),
											  new RidableHellHoundStageFour(), new RidableHellHoundStageFive() };
		}

		// These next 2 lines facilitate the singleton pattern.  In your subclass only change the
		// BaseEvoSpec class name to your subclass of BaseEvoSpec class name and uncomment both lines.
        public static RidableHellHoundEvoSpec Instance { get { return Nested.instance; } }
        class Nested { static Nested() { } internal static readonly RidableHellHoundEvoSpec instance = new RidableHellHoundEvoSpec();}
	}	

	// Define a subclass of BaseEvoStage for each stage in your creature and place them in the
	// array in your subclass of BaseEvoSpec.  See the example classes for how to do this.
	// Your subclass must not be abstract.

	public class RidableHellHoundStageOne : BaseEvoStage
	{
        public RidableHellHoundStageOne()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 25000; EpMinDivisor = 10; EpMaxDivisor = 5; DustMultiplier = 20;
			BaseSoundID = 0x3F5;
			BodyValue = 217; ControlSlots = 4; MinTameSkill = 99.9; VirtualArmor = 30;

			DamagesTypes = new ResistanceType[1] { ResistanceType.Physical };
			MinDamages = new int[1] { 100 };
			MaxDamages = new int[1] { 100 };

			ResistanceTypes = new ResistanceType[1] { ResistanceType.Physical };
			MinResistances = new int[1] { 15 };
			MaxResistances = new int[1] { 15 };

			DamageMin = 7; DamageMax = 9; HitsMin = 90; HitsMax = 115;
			StrMin = 55; StrMax = 55; DexMin = 55; DexMax = 55; IntMin = 55; IntMax = 55;
		}
	}

	public class RidableHellHoundStageTwo : BaseEvoStage
	{
        public RidableHellHoundStageTwo()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 75000; EpMinDivisor = 20; EpMaxDivisor = 10; DustMultiplier = 20;
			BaseSoundID = 0x3F5;
			BodyValue = 27; VirtualArmor = 40;
		
			DamagesTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
													ResistanceType.Poison, ResistanceType.Energy };
			MinDamages = new int[5] { 20, 20, 20, 20, 20 };
			MaxDamages = new int[5] { 20, 20, 20, 20, 20 };

			ResistanceTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
														ResistanceType.Poison, ResistanceType.Energy };
			MinResistances = new int[5] { 25, 25, 25, 25, 25 };
			MaxResistances = new int[5] { 25, 25, 25, 25, 25 };

			DamageMin = 1; DamageMax = 1; HitsMin= 25; HitsMax = 35;
			StrMin = 11; StrMax = 11; DexMin = 11; DexMax = 11; IntMin = 11; IntMax = 11;
		}
	}

	public class RidableHellHoundStageThree : BaseEvoStage
	{
        public RidableHellHoundStageThree()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 1250000; EpMinDivisor = 30; EpMaxDivisor = 20; DustMultiplier = 20;
			BaseSoundID = 0x3F5;
			BodyValue = 23; VirtualArmor = 50;
		
			DamagesTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
													 ResistanceType.Poison, ResistanceType.Energy };
			MinDamages = new int[5] { 100, 20, 20, 20, 20 };
			MaxDamages = new int[5] { 100, 20, 20, 20, 20 };

			ResistanceTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
														ResistanceType.Poison, ResistanceType.Energy };
			MinResistances = new int[5] { 35, 35, 35, 35, 35 };
			MaxResistances = new int[5] { 35, 35, 35, 35, 35 };

			DamageMin = 1; DamageMax = 1; HitsMin= 55; HitsMax = 75;
			StrMin = 20; StrMax = 20; DexMin = 10; DexMax = 10; IntMin = 20; IntMax = 20;
		}
	}

	public class RidableHellHoundStageFour : BaseEvoStage
	{
        public RidableHellHoundStageFour()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 7750000; EpMinDivisor = 50; EpMaxDivisor = 40; DustMultiplier = 20;
			BaseSoundID = 0x3F5;
			BodyValue = 23; ControlSlots = 4; MinTameSkill = 115.0; VirtualArmor = 60;
		
			DamagesTypes = null;
			MinDamages = null;
			MaxDamages = null;

			ResistanceTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
														ResistanceType.Poison, ResistanceType.Energy };
			MinResistances = new int[5] { 40, 40, 40, 40, 40 };
			MaxResistances = new int[5] { 40, 40, 40, 40, 40 };	

			DamageMin = 1; DamageMax = 1; HitsMin= 25; HitsMax = 45;
			StrMin = 15; StrMax = 25; DexMin = 25; DexMax = 30; IntMin = 25; IntMax = 35;
		}
	}

	public class RidableHellHoundStageFive : BaseEvoStage
	{
        public RidableHellHoundStageFive()
		{
            Title = "The Ancient Ridable Hell Hound";
            EvolutionMessage = "has evolved to its highest form and is now an Ancient Ridable Hell Hound";
			NextEpThreshold = 0; EpMinDivisor = 160; EpMaxDivisor = 40; DustMultiplier = 20;
			BaseSoundID = 0x3F5; ControlSlots = 4;
			BodyValue = 0x42d; VirtualArmor = 100;
		
			ResistanceTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
														ResistanceType.Poison, ResistanceType.Energy };
			MinResistances = new int[5] { 55, 70, 25, 40, 40 };
			MaxResistances = new int[5] { 70, 80, 45, 50, 50 };	

			DamageMin = 10; DamageMax = 10; HitsMin= 300; HitsMax = 300;
			StrMin = 35; StrMax = 35; DexMin = 35; DexMax = 35; IntMin = 35; IntMax = 35;
		}
	}
}