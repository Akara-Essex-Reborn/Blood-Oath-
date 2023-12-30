using System;
using Server;

namespace Xanthos.Evo
{
	public sealed class RidableLlamaEvoSpec : BaseEvoSpec
	{
		// This class implements a singleton pattern; meaning that no matter how many times the
		// Instance attribute is used, there will only ever be one of these created in the entire system.
		// Copy this template and give it a new name.  Assign all of the data members of the EvoSpec
		// base class in the constructor.  Your subclass must not be abstract.
		// Never call new on this class, use the Instance attribute to get the instance instead.

        RidableLlamaEvoSpec()
		{
			m_Tamable = true;
			m_MinTamingToHatch = 0;
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


            m_Stages = new BaseEvoStage[] { new RidableLlamaStageOne(), new RidableLlamaStageTwo(), new RidableLlamaStageThree(),
											  new RidableLlamaStageFour(), new RidableLlamaStageFive() };
		}

		// These next 2 lines facilitate the singleton pattern.  In your subclass only change the
		// BaseEvoSpec class name to your subclass of BaseEvoSpec class name and uncomment both lines.
        public static RidableLlamaEvoSpec Instance { get { return Nested.instance; } }
        class Nested { static Nested() { } internal static readonly RidableLlamaEvoSpec instance = new RidableLlamaEvoSpec();}
	}	

	// Define a subclass of BaseEvoStage for each stage in your creature and place them in the
	// array in your subclass of BaseEvoSpec.  See the example classes for how to do this.
	// Your subclass must not be abstract.

	public class RidableLlamaStageOne : BaseEvoStage
	{
        public RidableLlamaStageOne()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 25000; EpMinDivisor = 10; EpMaxDivisor = 5; DustMultiplier = 20;
			BaseSoundID = 0x3F5;
			BodyValue = 220; ControlSlots = 4; MinTameSkill = 0; VirtualArmor = 30;

			DamagesTypes = new ResistanceType[1] { ResistanceType.Physical };
			MinDamages = new int[1] { 100 };
			MaxDamages = new int[1] { 100 };

			ResistanceTypes = new ResistanceType[1] { ResistanceType.Physical };
			MinResistances = new int[1] { 15 };
			MaxResistances = new int[1] { 15 };

			DamageMin = 5; DamageMax = 5; HitsMin = 75; HitsMax = 95;
			StrMin = 35; StrMax = 35; DexMin = 35; DexMax = 35; IntMin = 35; IntMax = 35;
		}
	}

	public class RidableLlamaStageTwo : BaseEvoStage
	{
        public RidableLlamaStageTwo()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 75000; EpMinDivisor = 20; EpMaxDivisor = 10; DustMultiplier = 20;
			BaseSoundID = 0x3F5;
			BodyValue = 220; VirtualArmor = 40;
		
			DamagesTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
													ResistanceType.Poison, ResistanceType.Energy };
			MinDamages = new int[5] { 20, 20, 20, 20, 20 };
			MaxDamages = new int[5] { 20, 20, 20, 20, 20 };

			ResistanceTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
														ResistanceType.Poison, ResistanceType.Energy };
			MinResistances = new int[5] { 25, 25, 25, 25, 25 };
			MaxResistances = new int[5] { 25, 25, 25, 25, 25 };

			DamageMin = 1; DamageMax = 1; HitsMin= 10; HitsMax = 10;
			StrMin = 10; StrMax = 10; DexMin = 10; DexMax = 10; IntMin = 10; IntMax = 10;
		}
	}

	public class RidableLlamaStageThree : BaseEvoStage
	{
        public RidableLlamaStageThree()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 1250000; EpMinDivisor = 30; EpMaxDivisor = 20; DustMultiplier = 20;
			BaseSoundID = 0x3F5;
			BodyValue = 220; VirtualArmor = 50;
		
			DamagesTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
													 ResistanceType.Poison, ResistanceType.Energy };
			MinDamages = new int[5] { 100, 20, 20, 20, 20 };
			MaxDamages = new int[5] { 100, 20, 20, 20, 20 };

			ResistanceTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
														ResistanceType.Poison, ResistanceType.Energy };
			MinResistances = new int[5] { 35, 35, 35, 35, 35 };
			MaxResistances = new int[5] { 35, 35, 35, 35, 35 };

			DamageMin = 1; DamageMax = 1; HitsMin= 5; HitsMax = 5;
			StrMin = 5; StrMax = 5; DexMin = 5; DexMax = 5; IntMin = 5; IntMax = 5;
		}
	}

	public class RidableLlamaStageFour : BaseEvoStage
	{
        public RidableLlamaStageFour()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 7750000; EpMinDivisor = 50; EpMaxDivisor = 40; DustMultiplier = 20;
			BaseSoundID = 0x3F5;
			BodyValue = 220; ControlSlots = 4; MinTameSkill = 0; VirtualArmor = 60;
		
			DamagesTypes = null;
			MinDamages = null;
			MaxDamages = null;

			ResistanceTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
														ResistanceType.Poison, ResistanceType.Energy };
			MinResistances = new int[5] { 40, 40, 40, 40, 40 };
			MaxResistances = new int[5] { 40, 40, 40, 40, 40 };	

			DamageMin = 1; DamageMax = 1; HitsMin= 10; HitsMax = 10;
			StrMin = 10; StrMax = 10; DexMin = 10; DexMax = 10; IntMin = 10; IntMax = 10;
		}
	}

	public class RidableLlamaStageFive : BaseEvoStage
	{
        public RidableLlamaStageFive()
		{
            Title = "The Ancient Ridable Llama";
            EvolutionMessage = "has evolved to its highest form and is now an Ancient Ridable Llama";
			NextEpThreshold = 0; EpMinDivisor = 160; EpMaxDivisor = 40; DustMultiplier = 20;
			BaseSoundID = 0x3F5; ControlSlots = 4;
			BodyValue = 0xDC; VirtualArmor = 100;
		
			ResistanceTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
														ResistanceType.Poison, ResistanceType.Energy };
			MinResistances = new int[5] { 55, 70, 25, 40, 40 };
			MaxResistances = new int[5] { 70, 80, 45, 50, 50 };	

			DamageMin = 5; DamageMax = 5; HitsMin= 300; HitsMax = 300;
			StrMin = 35; StrMax = 35; DexMin = 35; DexMax = 35; IntMin = 35; IntMax = 35;
		}
	}
}