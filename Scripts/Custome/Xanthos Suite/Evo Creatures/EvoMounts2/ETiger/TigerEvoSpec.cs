using System;
using Server;

namespace Xanthos.Evo
{
	public sealed class TigerEvoSpec : BaseEvoSpec
	{
		// This class implements a singleton pattern; meaning that no matter how many times the
		// Instance attribute is used, there will only ever be one of these created in the entire system.
		// Copy this template and give it a new name.  Assign all of the data members of the EvoSpec
		// base class in the constructor.  Your subclass must not be abstract.
		// Never call new on this class, use the Instance attribute to get the instance instead.

        TigerEvoSpec()
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


            m_Stages = new BaseEvoStage[] { new TigerStageOne(), new TigerStageTwo(), new TigerStageThree(),
											  new TigerStageFour(), new TigerStageFive() };
		}

		// These next 2 lines facilitate the singleton pattern.  In your subclass only change the
		// BaseEvoSpec class name to your subclass of BaseEvoSpec class name and uncomment both lines.
        public static TigerEvoSpec Instance { get { return Nested.instance; } }
        class Nested { static Nested() { } internal static readonly TigerEvoSpec instance = new TigerEvoSpec();}
	}	

	// Define a subclass of BaseEvoStage for each stage in your creature and place them in the
	// array in your subclass of BaseEvoSpec.  See the example classes for how to do this.
	// Your subclass must not be abstract.

	public class TigerStageOne : BaseEvoStage
	{
        public TigerStageOne()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 25000; EpMinDivisor = 10; EpMaxDivisor = 5; DustMultiplier = 20;
			BaseSoundID = 0x69;
			BodyValue = 0xC9; ControlSlots = 4; MinTameSkill = 99.9; VirtualArmor = 30;

			DamagesTypes = new ResistanceType[1] { ResistanceType.Physical };
			MinDamages = new int[1] { 100 };
			MaxDamages = new int[1] { 100 };

			ResistanceTypes = new ResistanceType[1] { ResistanceType.Physical };
			MinResistances = new int[1] { 15 };
			MaxResistances = new int[1] { 15 };

			DamageMin = 7; DamageMax = 9; HitsMin = 75; HitsMax = 95;
			StrMin = 65; StrMax = 65; DexMin = 65; DexMax = 65; IntMin = 45; IntMax = 45;
		}
	}

	public class TigerStageTwo : BaseEvoStage
	{
        public TigerStageTwo()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 75000; EpMinDivisor = 20; EpMaxDivisor = 10; DustMultiplier = 20;
			BaseSoundID = 0x462;
			BodyValue = 1309; VirtualArmor = 40;
		
			DamagesTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
													ResistanceType.Poison, ResistanceType.Energy };
			MinDamages = new int[5] { 20, 20, 20, 20, 20 };
			MaxDamages = new int[5] { 20, 20, 20, 20, 20 };

			ResistanceTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
														ResistanceType.Poison, ResistanceType.Energy };
			MinResistances = new int[5] { 25, 25, 25, 25, 25 };
			MaxResistances = new int[5] { 25, 25, 25, 25, 25 };

			DamageMin = 1; DamageMax = 1; HitsMin= 25; HitsMax = 35;
			StrMin = 15; StrMax = 25; DexMin = 20; DexMax = 30; IntMin = 10; IntMax = 15;
		}
	}

	public class TigerStageThree : BaseEvoStage
	{
        public TigerStageThree()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 1250000; EpMinDivisor = 30; EpMaxDivisor = 20; DustMultiplier = 20;
			BaseSoundID = 229;
			BodyValue = 1309; VirtualArmor = 50;
		
			DamagesTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
													 ResistanceType.Poison, ResistanceType.Energy };
			MinDamages = new int[5] { 100, 20, 20, 20, 20 };
			MaxDamages = new int[5] { 100, 20, 20, 20, 20 };

			ResistanceTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
														ResistanceType.Poison, ResistanceType.Energy };
			MinResistances = new int[5] { 35, 35, 35, 35, 35 };
			MaxResistances = new int[5] { 35, 35, 35, 35, 35 };

			DamageMin = 1; DamageMax = 1; HitsMin= 35; HitsMax = 55;
			StrMin = 10; StrMax = 15; DexMin = 10; DexMax = 15; IntMin = 5; IntMax = 10;
		}
	}

	public class TigerStageFour : BaseEvoStage
	{
        public TigerStageFour()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 7750000; EpMinDivisor = 50; EpMaxDivisor = 40; DustMultiplier = 20;
			BaseSoundID = 229;
			BodyValue = 1254; ControlSlots = 4; MinTameSkill = 115.0; VirtualArmor = 60;
		
			DamagesTypes = null;
			MinDamages = null;
			MaxDamages = null;

			ResistanceTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
														ResistanceType.Poison, ResistanceType.Energy };
			MinResistances = new int[5] { 40, 40, 40, 40, 40 };
			MaxResistances = new int[5] { 40, 40, 40, 40, 40 };	

			DamageMin = 1; DamageMax = 1; HitsMin= 25; HitsMax = 35;
			StrMin = 10; StrMax = 15; DexMin = 15; DexMax = 20; IntMin = 10; IntMax = 15;
		}
	}

	public class TigerStageFive : BaseEvoStage
	{
        public TigerStageFive()
		{
            Title = "The Ancient Ridable tiger";
            EvolutionMessage = "has evolved to its highest form and is now an Ancient Ridable tiger";
			NextEpThreshold = 0; EpMinDivisor = 160; EpMaxDivisor = 40; DustMultiplier = 20;
			BaseSoundID =229; ControlSlots = 4;
			BodyValue = 1254; VirtualArmor = 100;
		
			ResistanceTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
														ResistanceType.Poison, ResistanceType.Energy };
			MinResistances = new int[5] { 55, 70, 25, 40, 40 };
			MaxResistances = new int[5] { 70, 80, 45, 50, 50 };	

			DamageMin = 7; DamageMax = 7; HitsMin= 300; HitsMax = 300;
			StrMin = 35; StrMax = 35; DexMin = 35; DexMax = 35; IntMin = 35; IntMax = 35;
		}
	}
}