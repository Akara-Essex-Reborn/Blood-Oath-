using Server.Mobiles;
using Server.Targeting;
using Server.Engines.XmlSpawner2;

namespace Server.Items
{
	public class PetMaxStatsDeed : Item
	{
		[Constructable]
		public PetMaxStatsDeed() : base(0x14F0)
		{
			Weight = 1.0;
			Movable = true;
			Name = "A Pet Max Stats Deed";
			LootType = LootType.Blessed;
		}

		public PetMaxStatsDeed(Serial serial) : base(serial)
		{
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (!IsChildOf(from.Backpack))
			{
				from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
			}
			else if (from.InRange(this.GetWorldLocation(), 1))
			{
				from.SendMessage("Which pet would you like to use this on?");
				from.Target = new PetMaxStatsDeedTarget(this);
			}
			else
			{
				from.SendLocalizedMessage(500446); // That is too far away. 
			}
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			list.Add("<BASEFONT COLOR=#7FCAE7>Increase pets max hits<BASEFONT COLOR=#FFFFFF>");
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

		private class PetMaxStatsDeedTarget : Target
		{
			private Item m_Deed;
			private int DeedsUsed;

			public PetMaxStatsDeedTarget(Item deed) : base(10, false, TargetFlags.None)
			{
				m_Deed = deed;
			}

			protected override void OnTarget(Mobile from, object target)
			{
				if (target == from)
					from.SendMessage("You cannot change your stats points!");
				else if (target is PlayerMobile)
					from.SendMessage("You cannot change their stats points!");
				else if (target is BaseCreature)
				{
					BaseCreature bc = (BaseCreature)target;

					if (bc.Controlled && from == bc.ControlMaster)
					{
						var a = (XmlValue)XmlAttach.FindAttachment(bc, typeof(XmlValue), "PetMaxStatDeedsUsed");

						if (a != null)
						{
							DeedsUsed = a.Value;
						}
						else
						{
							XmlAttach.AttachTo(bc, new XmlValue("PetMaxStatDeedsUsed", 1));
							DeedsUsed = 0;
						}

						if (DeedsUsed >= 5) //Increase this number to allow more than 5 deeds to be used
						{
							from.SendMessage("This pet has already used the maximum number of Pet Stat Deeds!");
						}
						else
						{
							DeedsUsed += 1;
							XmlAttach.AttachTo(bc, new XmlValue("PetMaxStatDeedsUsed", DeedsUsed));
							try
							{
								bc.SetHits ((bc.HitsMax + (Utility.RandomMinMax (25, 25)))); //The numbers here can have a minimum, maximum
                                bc.SetStam ((bc.StamMax + (Utility.RandomMinMax (25, 25)))); //In case you want to randomize it some
                                bc.SetMana ((bc.ManaMax + (Utility.RandomMinMax (25, 25))));
								from.SendMessage("Your pets stats have increased!");
								m_Deed.Delete();
							}
							catch
							{
								from.SendMessage("There was an error please contact a Game Master.");
							}
						}
					}
					else
					{
						from.SendMessage("You can only change your own pet.");
					}
				}
				else
				{
					from.SendMessage("This does not work on that");
				}
			}
		}
	}
}