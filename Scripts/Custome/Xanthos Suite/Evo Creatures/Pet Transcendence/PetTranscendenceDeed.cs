using System;
using Server;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{

	public class RandomPetTranscendenceDeed: Item
	{

		[Constructable]
        public RandomPetTranscendenceDeed()
            : this(null)
		{
		}

		[Constructable]
		public RandomPetTranscendenceDeed( string name ) : base ( 0x14F0 )
		{
            Name = "Random Pet Transcendence Scroll Deed";
            Hue = 0x490;
		}

		public RandomPetTranscendenceDeed( Serial serial ) : base ( serial )
		{
		}

      		public override void OnDoubleClick( Mobile from ) 
      		{
			if ( !IsChildOf( from.Backpack ) )
			{
                from.SendLocalizedMessage(1042001);
            }
            else
            {
                switch (Utility.Random(88))
                {
                    #region 0.1
                    case 0: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Magery, 0.1)); break;
                    case 1: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.EvalInt, 0.1)); break;
                    case 2: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Meditation, 0.1)); break;
                    case 3: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.MagicResist, 0.1)); break;
                    case 4: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Tactics, 0.1)); break;
                    case 5: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Wrestling, 0.1)); break;
                    case 6: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Anatomy, 0.1)); break;
                    case 7: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Poisoning, 0.1)); break; 
                    #endregion

                    #region 0.2
                    case 8: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Magery, 0.2)); break;
                    case 9: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.EvalInt, 0.2)); break;
                    case 10: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Meditation, 0.2)); break;
                    case 11: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.MagicResist, 0.2)); break;
                    case 12: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Tactics, 0.2)); break;
                    case 13: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Wrestling, 0.2)); break;
                    case 14: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Anatomy, 0.2)); break;
                    case 15: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Poisoning, 0.2)); break;
                    #endregion

                    #region 0.3
                    case 16: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Magery, 0.3)); break;
                    case 17: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.EvalInt, 0.3)); break;
                    case 18: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Meditation, 0.3)); break;
                    case 19: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.MagicResist, 0.3)); break;
                    case 20: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Tactics, 0.3)); break;
                    case 21: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Wrestling, 0.3)); break;
                    case 22: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Anatomy, 0.3)); break;
                    case 23: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Poisoning, 0.3)); break;
                    #endregion

                    #region 0.4
                    case 24: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Magery, 0.4)); break;
                    case 25: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.EvalInt, 0.4)); break;
                    case 26: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Meditation, 0.4)); break;
                    case 27: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.MagicResist, 0.4)); break;
                    case 28: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Tactics, 0.4)); break;
                    case 29: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Wrestling, 0.4)); break;
                    case 30: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Anatomy, 0.4)); break;
                    case 31: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Poisoning, 0.4)); break;
                    #endregion

                    #region 0.5
                    case 32: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Magery, 0.5)); break;
                    case 33: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.EvalInt, 0.5)); break;
                    case 34: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Meditation, 0.5)); break;
                    case 35: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.MagicResist, 0.5)); break;
                    case 36: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Tactics, 0.5)); break;
                    case 37: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Wrestling, 0.5)); break;
                    case 38: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Anatomy, 0.5)); break;
                    case 39: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Poisoning, 0.5)); break;
                    #endregion

                    #region 0.6
                    case 40: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Magery, 0.6)); break;
                    case 41: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.EvalInt, 0.6)); break;
                    case 42: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Meditation, 0.6)); break;
                    case 43: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.MagicResist, 0.6)); break;
                    case 44: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Tactics, 0.6)); break;
                    case 45: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Wrestling, 0.6)); break;
                    case 46: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Anatomy, 0.6)); break;
                    case 47: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Poisoning, 0.6)); break;
                    #endregion

                    #region 0.7
                    case 48: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Magery, 0.7)); break;
                    case 49: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.EvalInt, 0.7)); break;
                    case 50: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Meditation, 0.7)); break;
                    case 51: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.MagicResist, 0.7)); break;
                    case 52: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Tactics, 0.7)); break;
                    case 53: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Wrestling, 0.7)); break;
                    case 54: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Anatomy, 0.7)); break;
                    case 55: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Poisoning, 0.7)); break;
                    #endregion

                    #region 0.8
                    case 56: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Magery, 0.8)); break;
                    case 57: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.EvalInt, 0.8)); break;
                    case 58: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Meditation, 0.8)); break;
                    case 59: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.MagicResist, 0.8)); break;
                    case 60: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Tactics, 0.8)); break;
                    case 61: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Wrestling, 0.8)); break;
                    case 62: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Anatomy, 0.8)); break;
                    case 63: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Poisoning, 0.8)); break;
                    #endregion

                    #region 0.9
                    case 64: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Magery, 0.9)); break;
                    case 65: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.EvalInt, 0.9)); break;
                    case 66: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Meditation, 0.9)); break;
                    case 67: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.MagicResist, 0.9)); break;
                    case 68: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Tactics, 0.9)); break;
                    case 69: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Wrestling, 0.9)); break;
                    case 70: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Anatomy, 0.9)); break;
                    case 71: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Poisoning, 0.9)); break;
                    #endregion

                    #region 1.0
                    case 72: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Magery, 1.0)); break;
                    case 73: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.EvalInt, 1.0)); break;
                    case 74: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Meditation, 1.0)); break;
                    case 75: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.MagicResist, 1.0)); break;
                    case 76: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Tactics, 1.0)); break;
                    case 77: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Wrestling, 1.0)); break;
                    case 78: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Anatomy, 1.0)); break;
                    case 79: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Poisoning, 1.0)); break;
                    #endregion

                    #region 2.0
                    case 80: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Magery, 2.0)); break;
                    case 81: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.EvalInt, 2.0)); break;
                    case 82: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Meditation, 2.0)); break;
                    case 83: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.MagicResist, 2.0)); break;
                    case 84: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Tactics, 2.0)); break;
                    case 85: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Wrestling, 2.0)); break;
                    case 86: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Anatomy, 2.0)); break;
                    case 87: from.AddToBackpack(new ScrollofPetTranscendence(SkillName.Poisoning, 2.0)); break;
                    #endregion
                   
                }
                this.Delete();
			}

		}

		public override void Serialize ( GenericWriter writer)
		{
			base.Serialize ( writer );

			writer.Write ( (int) 0);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize ( reader );

			int version = reader.ReadInt();
		}
	}
}