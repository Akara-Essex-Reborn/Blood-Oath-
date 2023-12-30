using System;
using Server;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;
using System.Collections;

namespace Server.Items
{
	public class FacetKey : Item
	{
		private bool InUse;
		public enum Facet
		{
			Felucca,
			Trammel,
			Ilshenar,
			Malas,
			Tokuno,
			TerMur,
			Underworld
		}
		
		private Facet m_Key;
		[CommandProperty( AccessLevel.GameMaster )]
		public Facet Key
		{
			get { return m_Key; }
			set { m_Key = value;}
		}
		
		[Constructable]
		public FacetKey() : base( 576 ) 
		{
			Name = "a facet key";
			//Hue = 1175;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if (this.IsChildOf( from.Backpack ))
			{
				from.SendMessage("Target the Moongate");
				from.Target = new MoongateTarget(this);
			}
			else
				from.SendMessage("That must be in your backpack to use");
		}

		private class MoongateTarget : Target
		{
			private FacetKey k;

			public MoongateTarget(FacetKey K) : base( 10, false, TargetFlags.None )
			{
				k = K;
			}
	
			protected override void OnTarget( Mobile from, object targ )
			{
				if (targ is Item)
				{
					Item item = (Item) targ;
					if ( from.InRange( item.GetWorldLocation(), 2 ) )
					{
						if (targ is ClassicPublicMoongate)
						{
							ClassicPublicMoongate cpm = (ClassicPublicMoongate) targ;
							
							if (k.Key == Facet.Felucca)
							{
								if (cpm.FeluccaKey)
									cpm.FeluccaKey = false;
								else 
									cpm.FeluccaKey = true;
								from.SendMessage("You {0} the moongate", cpm.FeluccaKey ? "unlock" : "lock");
								Effects.PlaySound( cpm.Location, cpm.Map, 0xF8 );
								Effects.SendLocationParticles( EffectItem.Create( cpm.Location, cpm.Map, EffectItem.DefaultDuration ), 0x376A, 9, 32, 5022 );
								cpm.GetInformation();
								k.Delete();
							}
							if (k.Key == Facet.Trammel)
							{
								if (cpm.TrammelKey)
									cpm.TrammelKey = false;
								else 
									cpm.TrammelKey = true;
								from.SendMessage("You {0} the moongate", cpm.TrammelKey ? "unlock" : "lock");
								Effects.PlaySound( cpm.Location, cpm.Map, 0xF8 );
								Effects.SendLocationParticles( EffectItem.Create( cpm.Location, cpm.Map, EffectItem.DefaultDuration ), 0x376A, 9, 32, 5022 );
								cpm.GetInformation();
								k.Delete();
							}
							if (k.Key == Facet.Ilshenar)
							{
								if (cpm.IlshenarKey)
									cpm.IlshenarKey = false;
								else 
									cpm.IlshenarKey = true;
								from.SendMessage("You {0} the moongate", cpm.IlshenarKey ? "unlock" : "lock");
								Effects.PlaySound( cpm.Location, cpm.Map, 0xF8 );
								Effects.SendLocationParticles( EffectItem.Create( cpm.Location, cpm.Map, EffectItem.DefaultDuration ), 0x376A, 9, 32, 5022 );
								cpm.GetInformation();
								k.Delete();
							}
							if (k.Key == Facet.Malas)
							{
								if (cpm.MalasKey)
									cpm.MalasKey = false;
								else 
									cpm.MalasKey = true;
								from.SendMessage("You {0} the moongate", cpm.MalasKey ? "unlock" : "lock");
								Effects.PlaySound( cpm.Location, cpm.Map, 0xF8 );
								Effects.SendLocationParticles( EffectItem.Create( cpm.Location, cpm.Map, EffectItem.DefaultDuration ), 0x376A, 9, 32, 5022 );
								cpm.GetInformation();
								k.Delete();
							}
							if (k.Key == Facet.Tokuno)
							{
								if (cpm.TokunoKey)
									cpm.TokunoKey = false;
								else 
									cpm.TokunoKey = true;
								from.SendMessage("You {0} the moongate", cpm.TokunoKey ? "unlock" : "lock");
								Effects.PlaySound( cpm.Location, cpm.Map, 0xF8 );
								Effects.SendLocationParticles( EffectItem.Create( cpm.Location, cpm.Map, EffectItem.DefaultDuration ), 0x376A, 9, 32, 5022 );
								cpm.GetInformation();
								k.Delete();
							}
							if (k.Key == Facet.TerMur)
							{
								if (cpm.TerMurKey)
									cpm.TerMurKey = false;
								else 
									cpm.TerMurKey = true;
								from.SendMessage("You {0} the moongate", cpm.TerMurKey ? "unlock" : "lock");
								Effects.PlaySound( cpm.Location, cpm.Map, 0xF8 );
								Effects.SendLocationParticles( EffectItem.Create( cpm.Location, cpm.Map, EffectItem.DefaultDuration ), 0x376A, 9, 32, 5022 );
								cpm.GetInformation();
								k.Delete();
							}
							if (k.Key == Facet.Underworld)
							{
								if (cpm.UnderworldKey)
									cpm.UnderworldKey = false;
								else 
									cpm.UnderworldKey = true;
								from.SendMessage("You {0} the moongate", cpm.UnderworldKey ? "unlock" : "lock");
								Effects.PlaySound( cpm.Location, cpm.Map, 0xF8 );
								Effects.SendLocationParticles( EffectItem.Create( cpm.Location, cpm.Map, EffectItem.DefaultDuration ), 0x376A, 9, 32, 5022 );
								cpm.GetInformation();
								k.Delete();
							}
						}
						else
							from.SendMessage("Target only Public Moongates");
					}
					else
						from.SendMessage("That's too far away");
				}
			}
		}

		public FacetKey( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
			writer.Write((int)m_Key);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			m_Key = (Facet) reader.ReadInt();
		}
	}
}