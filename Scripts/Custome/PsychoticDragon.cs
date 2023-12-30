using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a Psychotic dragon corpse")]
    public class PsychoticDragon : BaseCreature

    {
        [Constructable]
        public PsychoticDragon()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.3, 0.5)
        {
            Name = "a Psychotic dragon";
            Body = Utility.RandomList(12, 59);
            BaseSoundID = 362;

            SetStr(5000,6500);
            SetDex(300, 500);
            SetInt(900, 1500);

            SetHits(9000, 10000);
            
            SetDamage(100, 200);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 75, 90);
            SetResistance(ResistanceType.Fire, 75, 100);
            SetResistance(ResistanceType.Cold, 65, 75);
            SetResistance(ResistanceType.Poison, 90, 100);
            SetResistance(ResistanceType.Energy, 75, 90);

            SetSkill(SkillName.Meditation, 0);
            SetSkill(SkillName.EvalInt, 120.0, 140.0);
            SetSkill(SkillName.Magery, 120.0, 140.0);
            SetSkill(SkillName.Poisoning, 95);
            SetSkill(SkillName.Anatomy, 100);
            SetSkill(SkillName.MagicResist, 120.0, 140.0);
            SetSkill(SkillName.Tactics, 120.0, 140.0);
            SetSkill(SkillName.Wrestling, 120.0, 145.0);

            Fame = 22000;
            Karma = -15000;

            VirtualArmor = 100;

            Tamable =false;
            ControlSlots = 5;
            MinTameSkill = 110.0;

            SetWeaponAbility(WeaponAbility.BleedAttack);
            SetSpecialAbility(SpecialAbility.DragonBreath);
        }

        public PsychoticDragon(Serial serial)
            : base(serial)
        {
        }

        public override bool StatLossAfterTame
        {
            get
            {
                return true;
            }
        }
        public override bool ReacquireOnMovement
        {
            get
            {
                return !Controlled;
            }
        }
        public override bool AutoDispel
        {
            get
            {
                return !Controlled;
            }
        }
        public override int TreasureMapLevel
        {
            get
            {
                return 5;
            }
        }
        public override int Meat
        {
            get
            {
                return 19;
            }
        }
        public override int Hides
        {
            get
            {
                return 30;
            }
        }
        public override HideType HideType
        {
            get
            {
                return HideType.Barbed;
            }
        }
        public override int Scales
        {
            get
            {
                return 7;
            }
        }
        public override ScaleType ScaleType
        {
            get
            {
                return (Body == 12 ? ScaleType.Yellow : ScaleType.Red);
            }
        }
        public override FoodType FavoriteFood
        {
            get
            {
                return FoodType.Meat;
            }
        }
        public override bool CanAngerOnTame
        {
            get
            {
                return true;
            }
        }
        public override bool CanFly
        {
            get
            {
                return true;
            }
        }
        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich, 4);
            AddLoot(LootPack.Gems, 8);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
