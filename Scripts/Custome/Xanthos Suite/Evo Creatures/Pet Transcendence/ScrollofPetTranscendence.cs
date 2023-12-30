using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Items
{
    public class ScrollofPetTranscendence : SpecialScroll
    {
        public override int LabelNumber { get { return 1094934; } } // Scroll of Transcendence

        public override int Message { get { return 1094933; } } /*Using a Scroll of Transcendence for a given skill will permanently increase your current
                                                                *level in that skill by the amount of points displayed on the scroll.
                                                                *As you may not gain skills beyond your maximum skill cap, any excess points will be lost.*/

        public override string DefaultTitle { get { return String.Format("<basefont color=#FFFFFF>Scroll of Pet Transcendence ({0} Skill):</basefont>", Value); } }

        public static ScrollofPetTranscendence CreateRandom(int min, int max)
        {
            SkillName skill = (SkillName)Utility.Random(SkillInfo.Table.Length);

            return new ScrollofPetTranscendence(skill, Utility.RandomMinMax(min, max) * 0.1);
        }

        public ScrollofPetTranscendence()
            : this(SkillName.Alchemy, 0.0)
        {
        }

        [Constructable]
        public ScrollofPetTranscendence(SkillName skill, double value)
            : base(skill, value)
        {
            ItemID = 0x14EF;
            Hue = 0x490;
        }
        public override void OnDoubleClick(Mobile from)
        {

            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
            }
            else if (from.InRange(this.GetWorldLocation(), 1))
            {

                this.SendLocalizedMessageTo(from, 1010086);
                from.Target = new TranscendTarget(this);

            }
            else
            {
                from.SendLocalizedMessage(500446); // That is too far away.
            }

        }
        public ScrollofPetTranscendence(Serial serial)
            : base(serial)
        {
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            if (Value == 1)
                list.Add(1076759, "{0}\t{1}.0 Skill Points", GetName(), Value);
            else
                list.Add(1076759, "{0}\t{1} Skill Points", GetName(), Value);
        }

        public override void AddNameProperties(ObjectPropertyList list)
        {
            base.AddNameProperties(list);
            list.Add(1062613, "This Does Not Work on Mercs");
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = (InheritsItem ? 0 : reader.ReadInt()); //Required for SpecialScroll insertion

            LootType = LootType.Cursed;
            Insured = false;

            if (Hue == 0x7E)
                Hue = 0x490;
        }

        private class TranscendTarget : Target
        {
            private Mobile m_Owner;

            private ScrollofPetTranscendence m_Scroll;

            public TranscendTarget(ScrollofPetTranscendence scroll)
                : base(10, false, TargetFlags.None)
            {
                m_Scroll = scroll;
            }

            protected override void OnTarget(Mobile from, object target)
            {

                if (target == from)
                {
                    from.SendMessage("You cant do that.");
                }
                else if (target is BaseCreature)
                {

                    BaseCreature c = (BaseCreature)target;
                    if (c.Controlled == false)
                    {
                        from.SendMessage("That Creature is not tamed.");
                    }
                    /*
					if (c.IsLesserParagon)
                    {
                        from.SendMessage("That can not be done");
                    }
					*/
                    if (c.IsParagon)
                    {
                        from.SendMessage("That can not be done");
                    }
                    if (c.BodyValue == 400 || c.BodyValue == 401 || c.BodyValue == 745 || c.BodyValue == 744)
                    {
                        from.SendMessage("That person gives you a dirty look.");
                    }
                    else if (c.ControlMaster != from)
                    {
                        from.SendMessage("This is not your pet.");
                    }
                    else if (c.Allured)
                    {
                        from.SendMessage("Your hold over this pet is not strong enough to shrink it.");
                    }

                    else if (c.Controlled == true && c.ControlMaster == from)
                    {
                        SkillName skill = m_Scroll.Skill;
                        double val = m_Scroll.Value;
                        c.Skills[skill].Base += val;

                        Effects.SendMovingParticles(new Entity(Serial.Zero, new Point3D(c.X - 6, from.Y - 6, c.Z + 15), c.Map), c, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100);
                        Effects.SendMovingParticles(new Entity(Serial.Zero, new Point3D(c.X - 4, from.Y - 6, c.Z + 15), c.Map), c, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100);
                        Effects.SendMovingParticles(new Entity(Serial.Zero, new Point3D(c.X - 6, from.Y - 4, c.Z + 15), c.Map), c, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100);
                        Effects.SendTargetParticles(c, 0x375A, 35, 90, 0x00, 0x00, 9502, (EffectLayer)255, 0x100);

                        m_Scroll.Delete();

                    }
                }
            }
        }
    }
}