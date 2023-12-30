using System;
using Server;

namespace Xanthos.Evo
{
	public sealed class ThunderDragonSpec : BaseEvoSpec
	{
		// This class implements a singleton pattern; meaning that no matter how many times the
		// Instance attribute is used, there will only ever be one of these created in the entire system.
		// Copy this template and give it a new name.  Assign all of the data members of the EvoSpec
		// base class in the constructor.  Your subclass must not be abstract.
		// Never call new on this class, use the Instance attribute to get the instance instead.

		ThunderDragonSpec()
		{
			m_Tamable = true;
			m_MinTamingToHatch = 99.9;
			m_PercentFemaleChance = .04;	// Made small to limit access to eggs.
			m_GuardianEggOrDeedChance = .01;
			m_AlwaysHappy = false;
			m_ProducesYoung = true;
			m_PregnancyTerm = 14.00;
			m_AbsoluteStatValues = false;
			m_MaxEvoResistance = 100;
			m_MaxTrainingStage = 3;
			m_CanAttackPlayers = false;

			m_RandomHues = new int[] { 1276, 1376, 1462, 1929, 2452, 2454, 2467, 2468 };

			m_Skills = new SkillName[7] { SkillName.Magery, SkillName.EvalInt, SkillName.Meditation, SkillName.MagicResist,
										  SkillName.Tactics, SkillName.Wrestling, SkillName.Anatomy };
			m_MinSkillValues = new int[7] { 50, 50, 50, 15, 19, 19, 19 };
			m_MaxSkillValues = new int[7] { 120, 120, 110, 110, 100, 100, 100 };

			m_Stages = new BaseEvoStage[] { new ThunderDragonStageOne(), new ThunderDragonStageTwo(),
											  new ThunderDragonStageThree(), new ThunderDragonStageFour(),
											  new ThunderDragonStageFive(), new ThunderDragonStageSix(),
											  new ThunderDragonStageSeven() };
		}

		// These next 2 lines facilitate the singleton pattern.  In your subclass only change the
		// BaseEvoSpec class name to your subclass of BaseEvoSpec class name and uncomment both lines.
		public static ThunderDragonSpec Instance { get { return Nested.instance; } }
		class Nested { static Nested() { } internal static readonly ThunderDragonSpec instance = new ThunderDragonSpec();}
	}	

	// Define a subclass of BaseEvoStage for each stage in your creature and place them in the
	// array in your subclass of BaseEvoSpec.  See the example classes for how to do this.
	// Your subclass must not be abstract.

	public class ThunderDragonStageOne : BaseEvoStage
	{
		public ThunderDragonStageOne()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 25000; EpMinDivisor = 10; EpMaxDivisor = 5; DustMultiplier = 20;
			BaseSoundID = 0xDB;
			BodyValue = 52; ControlSlots = 4; MinTameSkill = 99.9; VirtualArmor = 30;
			Hue = Evo.Flags.kRandomHueFlag;

			DamagesTypes = new ResistanceType[1] { ResistanceType.Physical };
			MinDamages = new int[1] { 100 };
			MaxDamages = new int[1] { 100 };

			ResistanceTypes = new ResistanceType[1] { ResistanceType.Physical };
			MinResistances = new int[1] { 15 };
			MaxResistances = new int[1] { 15 };

			DamageMin = 11; DamageMax = 13; HitsMin = 178; HitsMax = 195;
			StrMin = 96; StrMax = 125; DexMin = 30; DexMax = 55; IntMin = 50; IntMax = 75;
		}
	}

	public class ThunderDragonStageTwo : BaseEvoStage
	{
		public ThunderDragonStageTwo()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 75000; EpMinDivisor = 20; EpMaxDivisor = 10; DustMultiplier = 20;
			BaseSoundID = 219;
			BodyValue = 89; VirtualArmor = 40;
		
			DamagesTypes = new ResistanceType[5] { ResistanceType.Energy, ResistanceType.Fire, ResistanceType.Physical, ResistanceType.Cold,
													ResistanceType.Poison };
			MinDamages = new int[5] { 100, 25, 25, 25, 25 };
			MaxDamages = new int[5] { 100, 25, 25, 25, 25 };

			ResistanceTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
														ResistanceType.Poison, ResistanceType.Energy };
			MinResistances = new int[5] { 20, 20, 20, 20, 20 };
			MaxResistances = new int[5] { 20, 20, 20, 15, 25 };

			DamageMin = 1; DamageMax = 1; HitsMin= 50; HitsMax = 75;
			StrMin = 10; StrMax = 20; DexMin = 10; DexMax = 20; IntMin = 10; IntMax = 30;
		}
	}

	public class ThunderDragonStageThree : BaseEvoStage
	{
		public ThunderDragonStageThree()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 175000; EpMinDivisor = 30; EpMaxDivisor = 20; DustMultiplier = 20;
			BaseSoundID = 0x5A;
			BodyValue = 0xCE; VirtualArmor = 50;
		
			DamagesTypes = null;
			MinDamages = null;
			MaxDamages = null;

			ResistanceTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
														ResistanceType.Poison, ResistanceType.Energy };
			MinResistances = new int[5] { 40, 40, 40, 35, 45 };
			MaxResistances = new int[5] { 40, 40, 40, 35, 45 };

			DamageMin = 1; DamageMax = 1; HitsMin= 25; HitsMax = 75;
			StrMin = 10; StrMax = 20; DexMin = 10; DexMax = 30; IntMin = 10; IntMax = 30;
		}
	}

	public class ThunderDragonStageFour : BaseEvoStage
	{
		public ThunderDragonStageFour()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 3750000; EpMinDivisor = 50; EpMaxDivisor = 40; DustMultiplier = 20;
			BaseSoundID = 362;
			BodyValue = 60; ControlSlots = 4; MinTameSkill = 115.0; VirtualArmor = 60;
		
			DamagesTypes = null;
			MinDamages = null;
			MaxDamages = null;

			ResistanceTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
														ResistanceType.Poison, ResistanceType.Energy };
			MinResistances = new int[5] { 60, 60, 60, 55, 65 };
			MaxResistances = new int[5] { 60, 60, 60, 55, 65 };	

			DamageMin = 1; DamageMax = 1; HitsMin= 20; HitsMax = 45;
			StrMin = 25; StrMax = 45; DexMin = 10; DexMax = 20; IntMin = 30; IntMax = 50;
		}
	}

	public class ThunderDragonStageFive : BaseEvoStage
	{
		public ThunderDragonStageFive()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 7750000; EpMinDivisor = 160; EpMaxDivisor = 40; DustMultiplier = 20;
			BodyValue = 59; VirtualArmor = 70;
		
			DamagesTypes = new ResistanceType[5] { ResistanceType.Energy, ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
													 ResistanceType.Poison };
			MinDamages = new int[5] { 100, 50, 50, 50, 50 };
			MaxDamages = new int[5] { 100, 50, 50, 50, 50 };

			ResistanceTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
														ResistanceType.Poison, ResistanceType.Energy };
			MinResistances = new int[5] { 80, 80, 80, 75, 85 };
			MaxResistances = new int[5] { 80, 80, 80, 75, 85 };	

			DamageMin = 3; DamageMax = 5; HitsMin= 25; HitsMax = 35;
			StrMin = 10; StrMax = 25; DexMin = 10; DexMax = 10; IntMin = 25; IntMax = 55;
		}
	}

	public class ThunderDragonStageSix : BaseEvoStage
	{
		public ThunderDragonStageSix()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 15000000; EpMinDivisor = 540; EpMaxDivisor = 480; DustMultiplier = 20;
			BodyValue = 46; VirtualArmor = 170;
		
			DamagesTypes = null;
			MinDamages = null;
			MaxDamages = null;

			ResistanceTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
														ResistanceType.Poison, ResistanceType.Energy };
			MinResistances = new int[5] { 98, 98, 98, 90, 98 };
			MaxResistances = new int[5] { 98, 98, 98, 90, 98 };	

			DamageMin = 3; DamageMax = 3; HitsMin= 85; HitsMax = 85;
			StrMin = 30; StrMax = 30; DexMin = 15; DexMax = 15; IntMin = 50; IntMax = 50;
		}
	}

	public class ThunderDragonStageSeven : BaseEvoStage
	{
		public ThunderDragonStageSeven()
		{
			Title = "The Ancient Thunder Dragon";
			EvolutionMessage = "has evolved to its highest form and is now an Ancient Thunder Dragon";
			NextEpThreshold = 0; EpMinDivisor = 740; EpMaxDivisor = 660; DustMultiplier = 20;
			BaseSoundID = 362;
			BodyValue = 172; ControlSlots = 4; VirtualArmor = 270;
		
			DamagesTypes = new ResistanceType[5] { ResistanceType.Energy, ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
													 ResistanceType.Poison };
			MinDamages = new int[5] { 100, 75, 75, 75, 75 };
			MaxDamages = new int[5] { 100, 75, 75, 75, 75 };

			ResistanceTypes = null;
			MinResistances = null;
			MaxResistances = null;	

			DamageMin = 10; DamageMax = 15; HitsMin= 350; HitsMax = 400;
			StrMin = 60; StrMax = 60; DexMin = 60; DexMax = 60; IntMin = 60; IntMax = 60;
		}
	}
}