using System;
using Server;

namespace Xanthos.Evo
{
	public sealed class InsectSpec : BaseEvoSpec
	{
		// This class implements a singleton pattern; meaning that no matter how many times the
		// Instance attribute is used, there will only ever be one of these created in the entire system.
		// Copy this template and give it a new name.  Assign all of the data members of the EvoSpec
		// base class in the constructor.  Your subclass must not be abstract.
		// Never call new on this class, use the Instance attribute to get the instance instead.

		InsectSpec()
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

			m_RandomHues = new int[] { 1157, 1175, 1172, 1171, 1170, 1169, 1168, 1167, 1166, 1165 };

			m_Skills = new SkillName[9] { SkillName.Magery, SkillName.EvalInt, SkillName.Meditation, SkillName.MagicResist,
										  SkillName.Tactics, SkillName.Wrestling, SkillName.Anatomy, SkillName.Parry, SkillName.Poisoning };
			m_MinSkillValues = new int[9] { 50, 50, 50, 15, 19, 19, 19, 19, 19 };
			m_MaxSkillValues = new int[9] { 120, 120, 110, 110, 100, 100, 100, 100, 100 };

			m_Stages = new BaseEvoStage[] { new InsectStageOne(), new InsectStageTwo(),
											  new InsectStageThree(), new InsectStageFour(),
											  new InsectStageFive(), new InsectStageSix(),
											  new InsectStageSeven() };
		}

		// These next 2 lines facilitate the singleton pattern.  In your subclass only change the
		// BaseEvoSpec class name to your subclass of BaseEvoSpec class name and uncomment both lines.
		public static InsectSpec Instance { get { return Nested.instance; } }
		class Nested { static Nested() { } internal static readonly InsectSpec instance = new InsectSpec();}
	}	

	// Define a subclass of BaseEvoStage for each stage in your creature and place them in the
	// array in your subclass of BaseEvoSpec.  See the example classes for how to do this.
	// Your subclass must not be abstract.

	public class InsectStageOne : BaseEvoStage
	{
		public InsectStageOne()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 25000; EpMinDivisor = 10; EpMaxDivisor = 5; DustMultiplier = 20;
			BaseSoundID = 0xDB;
			BodyValue = 732; ControlSlots = 4; MinTameSkill = 99.9; VirtualArmor = 30;
			Hue = Utility.RandomList(1157, 1175, 1172, 1171, 1170, 1169, 1168, 1167, 1166, 1165);

			DamagesTypes = new ResistanceType[1] { ResistanceType.Physical };
			MinDamages = new int[1] { 100 };
			MaxDamages = new int[1] { 100 };

			ResistanceTypes = new ResistanceType[1] { ResistanceType.Physical };
			MinResistances = new int[1] { 15 };
			MaxResistances = new int[1] { 15 };

			DamageMin = 5; DamageMax = 13; HitsMin = 75; HitsMax = 100;
			StrMin = 50; StrMax = 50; DexMin = 50; DexMax = 50; IntMin = 50; IntMax = 50;
		}
	}

	public class InsectStageTwo : BaseEvoStage
	{
		public InsectStageTwo()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 75000; EpMinDivisor = 20; EpMaxDivisor = 10; DustMultiplier = 20;
			BaseSoundID = 0;
			BodyValue = 287; VirtualArmor = 40;
		
			DamagesTypes = new ResistanceType[5] { ResistanceType.Energy, ResistanceType.Fire, ResistanceType.Physical, ResistanceType.Cold,
													ResistanceType.Poison };
			MinDamages = new int[5] { 100, 25, 25, 25, 25 };
			MaxDamages = new int[5] { 100, 25, 25, 25, 25 };

			ResistanceTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
														ResistanceType.Poison, ResistanceType.Energy };
			MinResistances = new int[5] { 20, 20, 20, 20, 20 };
			MaxResistances = new int[5] { 20, 20, 20, 15, 25 };

			DamageMin = 1; DamageMax = 1; HitsMin= 25; HitsMax = 25;
			StrMin = 25; StrMax = 25; DexMin = 25; DexMax = 25; IntMin = 25; IntMax = 25;
		}
	}

	public class InsectStageThree : BaseEvoStage
	{
		public InsectStageThree()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 175000; EpMinDivisor = 30; EpMaxDivisor = 20; DustMultiplier = 20;
			BaseSoundID = 0;
			BodyValue = 791; VirtualArmor = 50;
		
			DamagesTypes = null;
			MinDamages = null;
			MaxDamages = null;

			ResistanceTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
														ResistanceType.Poison, ResistanceType.Energy };
			MinResistances = new int[5] { 40, 40, 40, 35, 45 };
			MaxResistances = new int[5] { 40, 40, 40, 35, 45 };

			DamageMin = 1; DamageMax = 1; HitsMin= 30; HitsMax = 40;
			StrMin = 25; StrMax = 25; DexMin = 25; DexMax = 25; IntMin = 25; IntMax = 25;
		}
	}

	public class InsectStageFour : BaseEvoStage
	{
		public InsectStageFour()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 3750000; EpMinDivisor = 50; EpMaxDivisor = 40; DustMultiplier = 20;
			BaseSoundID = 1006;
			BodyValue = 787; ControlSlots = 4; MinTameSkill = 115.0; VirtualArmor = 60;
		
			DamagesTypes = null;
			MinDamages = null;
			MaxDamages = null;

			ResistanceTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
														ResistanceType.Poison, ResistanceType.Energy };
			MinResistances = new int[5] { 60, 60, 60, 55, 65 };
			MaxResistances = new int[5] { 60, 60, 60, 55, 65 };	

			DamageMin = 1; DamageMax = 5; HitsMin= 100; HitsMax = 100;
			StrMin = 20; StrMax = 20; DexMin = 20; DexMax = 20; IntMin = 20; IntMax = 20;
		}
	}

	public class InsectStageFive : BaseEvoStage
	{
		public InsectStageFive()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 7750000; EpMinDivisor = 160; EpMaxDivisor = 40; DustMultiplier = 20;
			BodyValue = 805; VirtualArmor = 70;
			BaseSoundID = 959;
		
			DamagesTypes = new ResistanceType[5] { ResistanceType.Energy, ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
													 ResistanceType.Poison };
			MinDamages = new int[5] { 100, 50, 50, 50, 50 };
			MaxDamages = new int[5] { 100, 50, 50, 50, 50 };

			ResistanceTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
														ResistanceType.Poison, ResistanceType.Energy };
			MinResistances = new int[5] { 80, 80, 80, 75, 85 };
			MaxResistances = new int[5] { 80, 80, 80, 75, 85 };	

			DamageMin = 3; DamageMax = 5; HitsMin= 45; HitsMax = 55;
			StrMin = 20; StrMax = 20; DexMin = 20; DexMax = 20; IntMin = 20; IntMax = 20;
		}
	}

	public class InsectStageSix : BaseEvoStage
	{
		public InsectStageSix()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 15000000; EpMinDivisor = 540; EpMaxDivisor = 480; DustMultiplier = 20;
			BodyValue = 806; VirtualArmor = 170;
		
			DamagesTypes = null;
			MinDamages = null;
			MaxDamages = null;

			ResistanceTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
														ResistanceType.Poison, ResistanceType.Energy };
			MinResistances = new int[5] { 98, 98, 98, 90, 98 };
			MaxResistances = new int[5] { 98, 98, 98, 90, 98 };	

			DamageMin = 3; DamageMax = 5; HitsMin= 45; HitsMax = 55;
			StrMin = 20; StrMax = 20; DexMin = 20; DexMax = 20; IntMin = 20; IntMax = 20;
		}
	}

	public class InsectStageSeven : BaseEvoStage
	{
		public InsectStageSeven()
		{
			Title = "The Ancient Insect";
			EvolutionMessage = "has evolved to its highest form and is now an Ancient Insect";
			NextEpThreshold = 0; EpMinDivisor = 740; EpMaxDivisor = 660; DustMultiplier = 20;
			BaseSoundID = 959;
			BodyValue = 783; ControlSlots = 4; VirtualArmor = 270;
		
			DamagesTypes = new ResistanceType[5] { ResistanceType.Energy, ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
													 ResistanceType.Poison };
			MinDamages = new int[5] { 100, 75, 75, 75, 75 };
			MaxDamages = new int[5] { 100, 75, 75, 75, 75 };

			ResistanceTypes = null;
			MinResistances = null;
			MaxResistances = null;	

			DamageMin = 10; DamageMax = 15; HitsMin= 350; HitsMax = 400;
			StrMin = 125; StrMax = 125; DexMin = 125; DexMax = 135; IntMin = 125; IntMax = 125;
		}
	}
}