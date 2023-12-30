using System;
using Server;
using System.Collections;
using System.Collections.Generic;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Gumps;
using Server.Items;

namespace Server.Items
{
	public enum MoongateGFX
	{
		Red = 3546,
		Blue = 3948, 
		Black = 8148,
		White = 8167,
	}
	
	public class ClassicPublicMoongate : Item
	{
		private int m_LeftOffAt;
		[CommandProperty( AccessLevel.GameMaster )]
		public int LeftOffAt
		{
			get { return m_LeftOffAt; }
			set { m_LeftOffAt = value;InvalidateProperties(); }
		}
		
		private MoongateController m_MGC;
		public MoongateController MGC
		{
			get {return m_MGC;}
			set {m_MGC = value;}
		}
		
		private string m_NewbieName = "[Endlessness]";
		[CommandProperty( AccessLevel.GameMaster )]
		public string NewbieName
		{
			get { return m_NewbieName; }
			set { m_NewbieName = value; InvalidateProperties(); }
		}
		
		private string m_Description = "... see a doorway into infinity.";
		[CommandProperty( AccessLevel.GameMaster )]
		public string Description
		{
			get { return m_Description; }
			set { m_Description = value; InvalidateProperties(); }
		}
		
		private int m_GateItemID;
		[CommandProperty( AccessLevel.GameMaster )]
		public int GateItemID
		{
			get { return m_GateItemID; }
			set { m_GateItemID = value; InvalidateProperties(); }
		}
		
		private bool m_IsActive = true;
		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsActive
		{
			get { return m_IsActive; }
			set { m_IsActive = value;}
		}
		
		private bool m_InCombat = false;
		[CommandProperty( AccessLevel.GameMaster )]
		public bool InCombat
		{
			get { return m_InCombat; }
			set { m_InCombat = value; }
		}

		private bool m_IsCriminal = false;
		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsCriminal
		{
			get { return m_IsCriminal; }
			set { m_IsCriminal = value; }
		}
		
		private bool m_IsMurderer = false;
		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsMurderer
		{
			get { return m_IsMurderer; }
			set { m_IsMurderer = value; }
		}

		private bool m_HasSigil = false;
		[CommandProperty( AccessLevel.GameMaster )]
		public bool HasSigil
		{
			get { return m_HasSigil; }
			set { m_HasSigil = value; }
		}
		
		private bool m_FeluccaKey = false;
		[CommandProperty( AccessLevel.GameMaster )]
		public bool FeluccaKey 
		{
			get { return m_FeluccaKey ; }
			set { m_FeluccaKey = value; }
		}
		
		private bool m_TrammelKey = false;
		[CommandProperty( AccessLevel.GameMaster )]
		public bool TrammelKey 
		{
			get { return m_TrammelKey ; }
			set { m_TrammelKey = value; }
		}
		
		private bool m_IlshenarKey = false;
		[CommandProperty( AccessLevel.GameMaster )]
		public bool IlshenarKey 
		{
			get { return m_IlshenarKey ; }
			set { m_IlshenarKey  = value; }
		}
		
		private bool m_MalasKey = false;
		[CommandProperty( AccessLevel.GameMaster )]
		public bool MalasKey 
		{
			get { return m_MalasKey ; }
			set { m_MalasKey = value; }
		}
		
		private bool m_TokunoKey = false;
		[CommandProperty( AccessLevel.GameMaster )]
		public bool TokunoKey 
		{
			get { return m_TokunoKey ; }
			set { m_TokunoKey = value; }
		}
		
		private bool m_TerMurKey = false;
		[CommandProperty( AccessLevel.GameMaster )]
		public bool TerMurKey 
		{
			get { return m_TerMurKey ; }
			set { m_TerMurKey = value; }
		}
		
		private bool m_UnderworldKey = false;
		[CommandProperty( AccessLevel.GameMaster )]
		public bool UnderworldKey 
		{
			get { return m_UnderworldKey ; }
			set { m_UnderworldKey = value; }
		}
		
		private bool m_OutOnly = false;
		[CommandProperty( AccessLevel.GameMaster )]
		public bool OutOnly 
		{
			get { return m_OutOnly ; }
			set { m_OutOnly = value; }
		}
		
		private bool m_UseGump = false;
		[CommandProperty( AccessLevel.GameMaster )]
		public bool UseGump 
		{
			get { return m_UseGump ; }
			set { m_UseGump = value; }
		}
		
		public override void OnDoubleClick( Mobile from )
		{
			if (m_MGC == null)
			{
				from.SendMessage("This is an invalid Moongate...deleting.");
				this.Delete();
			}
			if (!m_IsActive)
			{
				from.SendMessage("This Moongate is currently inactive");
			}
			else if ( from.InRange( GetWorldLocation(), 1 ) )
				UseGate( from );
			else
				from.SendLocalizedMessage( 500446 ); // That is too far away.
		}
		
		public override bool OnMoveOver( Mobile from )
		{
			if (m_MGC == null)
			{
				from.SendMessage("This is an invalid Moongate...deleting");
				this.Delete();
				return false;
			}
			
			if (!m_IsActive)
			{
				from.SendMessage("This Moongate is currently inactive");
				return false;
			}
			
			if ((m_MGC.Moongates[m_LeftOffAt] == this) && !m_UseGump)
			{
				from.SendMessage("There are no gates available");
				return false;
			}
			
			if ( from.Player )
			{
				UseGate( from );
				return false;
			}
			
			return true;
		}
		
		public bool UseGate( Mobile from )
		{
			if (m_LeftOffAt > m_MGC.Moongates.Count-1) 
			{
				from.SendMessage("There are no gates available");
				return false;
			}
			
			if ( SpellHelper.CheckCombat( from ) && !m_MGC.Moongates[m_LeftOffAt].InCombat )
			{
				from.SendLocalizedMessage( 1005564, "", 0x22 ); // Wouldst thou flee during the heat of battle??
				return false;
			}
			else if ( from.Spell != null )
			{
				from.SendLocalizedMessage( 1049616 ); // You are too busy to do that at the moment.
				return false;
			}
			else if (UseGump)
			{
				if ( !from.Hidden || from.AccessLevel == AccessLevel.Player )
					Effects.PlaySound( from.Location, from.Map, 0x20E );
				from.CloseGump( typeof(MoongateMenuGump) );
				from.SendGump( new MoongateMenuGump(this,from) );
				return true;
			}
			else if ( from.Criminal && !m_MGC.Moongates[m_LeftOffAt].IsCriminal )
			{
				from.SendLocalizedMessage( 1005561, "", 0x22 ); // Thou'rt a criminal and cannot escape so easily.
				return false;
			}
			else if ( from.Player && from.Kills >= 5 && !m_MGC.Moongates[m_LeftOffAt].IsMurderer )
			{
				from.SendLocalizedMessage( 1019004 ); // You are not allowed to travel there.
				return false;
			}
			else if ( Factions.Sigil.ExistsOn( from ) && !m_MGC.Moongates[m_LeftOffAt].HasSigil)
			{
				from.SendLocalizedMessage( 1019004 ); // You are not allowed to travel there.
				return false;
			}
			else
			{
				if ( !from.Hidden || from.AccessLevel == AccessLevel.Player )
					Effects.PlaySound( from.Location, from.Map, 0x20E );
				
				BaseCreature.TeleportPets( from, m_MGC.Moongates[m_LeftOffAt].Location, m_MGC.Moongates[m_LeftOffAt].Map );
				from.Combatant = null;
				from.Warmode = false;
				from.Hidden = true;
				from.MoveToWorld( m_MGC.Moongates[m_LeftOffAt].Location, m_MGC.Moongates[m_LeftOffAt].Map );
				Effects.PlaySound( m_MGC.Moongates[m_LeftOffAt].Location, m_MGC.Moongates[m_LeftOffAt].Map, 0x1FE );
				return true;
			}
		}
		
		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
			
			string toDescription;
			string toNewbieName;
			
			if (m_MGC != null && !m_MGC.Deleted && !m_UseGump)
			{
				if (m_LeftOffAt > m_MGC.Moongates.Count-1 || !m_IsActive) 
				{
					list.Add("...a moongate to nowhere...");
					if (m_MGC.NewbieTitles)
						list.Add("Endlessness");
				}
				else
				{
					toDescription = m_MGC.Moongates[m_LeftOffAt].Description;
					toNewbieName= m_MGC.Moongates[m_LeftOffAt].NewbieName;
					list.Add(toDescription);
					if (m_MGC.NewbieTitles)
						list.Add(toNewbieName);
				}
			}
		}
		
		public override bool HandlesOnSpeech{ get{ return true; } }
		public override void OnSpeech( SpeechEventArgs e )
		{
			if (!e.Handled && m_MGC != null && !m_MGC.Deleted && e.Mobile.InRange( this, 5 ) )
			{
				e.Handled = true;
				String command = e.Speech;
				if (m_MGC.VoiceActivation && m_MGC.VoiceCommand == command && !m_UseGump)
				{
					if (m_LeftOffAt > m_MGC.Moongates.Count-1 || !m_IsActive) 
					{
						this.PublicOverheadMessage( MessageType.Regular, 0x0 , false,"...a moongate to nowhere...");
						this.PublicOverheadMessage( MessageType.Regular, 0x0 , false,"Endlessness");
					}
					else
					{
						this.PublicOverheadMessage( MessageType.Regular, 0x0 , false,m_MGC.Moongates[m_LeftOffAt].Description);
						if (m_MGC.NewbieTitles)
							this.PublicOverheadMessage( MessageType.Regular, 0x0 , false,m_MGC.Moongates[m_LeftOffAt].NewbieName);
					}
				}
			}
		}
		
		[Constructable]
		public ClassicPublicMoongate() : base( (int)MoongateGFX.Blue )
		{
			Name = "a Moongate";
			Movable = false;
			Light = LightType.Circle300;
		}
		
		public virtual bool IsUnderworld(ClassicPublicMoongate testing)
		{
			if (((testing.Map == Map.Felucca) || (testing.Map == Map.Trammel)) && (testing.X > 5120))
				return true;
			return false;
		}
		
		public virtual bool IsRed(ClassicPublicMoongate testing)
		{
			if (testing.IsCriminal || testing.IsMurderer) 
				return true;
			return false;
		}
		
		public virtual void GetInformation()
		{
			if (!m_IsActive) 
				ItemID=(int)MoongateGFX.White;
			else if (!m_UseGump) 
				ItemID=(int)MoongateGFX.White; //needed to update properties
			else
				ItemID=(int)MoongateGFX.Blue;
			if (m_MGC != null && m_IsActive && !m_UseGump)
			{
				int MGArraySize = m_MGC.Moongates.Count-1;
				int cycles=0;
				bool GotIt=false;
				int leftoff = m_LeftOffAt;
				while (!GotIt)
				{
					if (( leftoff >= MGArraySize ))// || (leftoff==0 && cycles<1))
						leftoff=0;
					else 
						++leftoff;
					
					if (cycles > MGArraySize)
					{
						break;
					}
					
					if ( (m_MGC.Moongates[leftoff] != this) && !(m_MGC.Moongates[leftoff].OutOnly) && ((IsUnderworld(m_MGC.Moongates[leftoff])) && m_UnderworldKey))
					{
						m_LeftOffAt=leftoff;
						GotIt=true;
						if (m_GateItemID > 0)
							ItemID=m_GateItemID;
						else if (IsRed(m_MGC.Moongates[m_LeftOffAt]))
							ItemID = (int)MoongateGFX.Red;
						else
							ItemID = (int)MoongateGFX.Black;
					}
					else if ( (m_MGC.Moongates[leftoff] != this) && !(m_MGC.Moongates[leftoff].OutOnly) && !(IsUnderworld(m_MGC.Moongates[leftoff])) && ( (m_MGC.Moongates[leftoff].Map == Map.Felucca && m_FeluccaKey) || (m_MGC.Moongates[leftoff].Map == Map.Trammel && m_TrammelKey) || (m_MGC.Moongates[leftoff].Map == Map.Ilshenar && m_IlshenarKey) || (m_MGC.Moongates[leftoff].Map == Map.Malas && m_MalasKey) || (m_MGC.Moongates[leftoff].Map == Map.Tokuno && m_TokunoKey) || (m_MGC.Moongates[leftoff].Map == Map.TerMur && m_TerMurKey)  ) )
					{
						m_LeftOffAt=leftoff;
						GotIt=true;
						if (m_GateItemID > 0)
							ItemID=m_GateItemID;
						else if (IsRed(m_MGC.Moongates[m_LeftOffAt]))
							ItemID = (int)MoongateGFX.Red;
						else
							ItemID = (int)MoongateGFX.Blue;
					}
					else 
						++cycles;
				}
			}
			if (!m_UseGump && m_MGC.VoiceActivation)
			{
				if (m_LeftOffAt > m_MGC.Moongates.Count-1 || !m_IsActive) 
				{
					this.PublicOverheadMessage( MessageType.Regular, 0x0 , false,"...a moongate to nowhere...");
					this.PublicOverheadMessage( MessageType.Regular, 0x0 , false,"Endlessness");
				}
				else
				{
					this.PublicOverheadMessage( MessageType.Regular, 0x0 , false,m_MGC.Moongates[m_LeftOffAt].Description);
					if (m_MGC.NewbieTitles)
						this.PublicOverheadMessage( MessageType.Regular, 0x0 , false,m_MGC.Moongates[m_LeftOffAt].NewbieName);
				}
			}
		}
		
		public override void OnDelete()
		{
			if (m_MGC !=null)
			{
				m_MGC.Stop();
				m_MGC.Moongates.Remove(this);
				m_MGC.UpdateAll(m_MGC);
				m_MGC.Start();
			}
			base.OnDelete();
		}
		
		public ClassicPublicMoongate( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 
			writer.Write( (int) 1 ); // version 
			
			writer.Write((MoongateController)m_MGC);
			writer.Write( (int) m_LeftOffAt );
			writer.Write( (string) m_Description );
			writer.Write( (string) m_NewbieName );
			writer.Write( (int) m_GateItemID );
			writer.Write( (bool) m_InCombat);
			writer.Write( (bool) m_IsCriminal);
			writer.Write( (bool) m_IsMurderer);
			writer.Write( (bool) m_HasSigil);
			writer.Write( (bool) m_FeluccaKey);
			writer.Write( (bool) m_TrammelKey);
			writer.Write( (bool) m_IlshenarKey);
			writer.Write( (bool) m_MalasKey);
			writer.Write( (bool) m_TokunoKey);
			writer.Write( (bool) m_TerMurKey);
			writer.Write( (bool) m_UnderworldKey);
			writer.Write( (bool) m_OutOnly);
			writer.Write( (bool) m_IsActive);
			// version 1
				writer.Write( (bool) m_UseGump);
		} 

		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 
			int version = reader.ReadInt(); 
			
			m_MGC = (MoongateController)reader.ReadItem();
			m_LeftOffAt = reader.ReadInt();
			m_Description = reader.ReadString();
			m_NewbieName = reader.ReadString();
			m_GateItemID = reader.ReadInt();
			m_InCombat = reader.ReadBool();
			m_IsCriminal = reader.ReadBool();
			m_IsMurderer = reader.ReadBool();
			m_HasSigil = reader.ReadBool();
			m_FeluccaKey = reader.ReadBool();
			m_TrammelKey = reader.ReadBool();
			m_IlshenarKey = reader.ReadBool();
			m_MalasKey = reader.ReadBool();
			m_TokunoKey = reader.ReadBool();
			m_TerMurKey = reader.ReadBool();
			m_UnderworldKey = reader.ReadBool();
			m_OutOnly = reader.ReadBool();
			m_IsActive = reader.ReadBool();
			if (version>0)
				m_UseGump = reader.ReadBool();
		} 
	}
}
namespace Server.Gumps
{
	public class MoongateMenuGump : Gump
	{
		private MoongateController m_mgc;
		private ClassicPublicMoongate m_cpmg;
		
		public virtual bool IsUnderworld(ClassicPublicMoongate testing)
		{
			if (((testing.Map == Map.Felucca) || (testing.Map == Map.Trammel)) && (testing.X > 5120))
				return true;
			return false;
		}
		
		public MoongateMenuGump(ClassicPublicMoongate CPMG, Mobile from) : base( 0, 0 )
		{
			m_mgc = CPMG.MGC;
			m_cpmg = CPMG;
			
			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			this.AddPage(0);
			this.AddBackground(135, 5, 500, 535, 9200);
			this.AddLabel(355, 45 , 85, @"Moongate");
			this.AddLabel(310, 80, 0, @"Circuit");
			this.AddBackground(355, 75, 120, 25, 3000);
			this.AddLabel(360, 80, 0, m_mgc.CircuitName);
			this.AddImage(145, 40, 7035);
			this.AddImage(550, 40, 7035);
			this.AddImageTiled(135, 20, 500, 15, 10100);
			this.AddImageTiled(135, 490, 500, 15, 10100);
			
			this.AddBackground(180, 120, 175, 360, 3000);
			this.AddBackground(430, 120, 175, 360, 3000);
			
			int thue = 0;
			bool murd = (from.Kills >= 5);
			for ( int i = 0; i < m_mgc.Moongates.Count; ++i )
			{
				int col = ( ( (int)(i/18) ) *250);
				int row = ( (i- ( ( (int) i/18) *18 ) ) *20);
				if (!m_mgc.Moongates[i].IsActive)
					thue=999;
				else if (m_mgc.Moongates[i].IsCriminal || m_mgc.Moongates[i].IsMurderer)
					thue=33;
				else 
					thue=93;
				
				if (!m_mgc.Moongates[i].OutOnly && (m_mgc.Moongates[i] != m_cpmg) && m_mgc.Moongates[i].IsActive)
				{
					if ((( from.Criminal && m_mgc.Moongates[i].IsCriminal ) || !from.Criminal) && ( (murd && m_mgc.Moongates[i].IsMurderer) || !murd) && ( Factions.Sigil.ExistsOn( from ) == m_mgc.Moongates[i].HasSigil) )
					{
						if ( (IsUnderworld(m_mgc.Moongates[i]) && m_cpmg.UnderworldKey) || (m_mgc.Moongates[i].Map == Map.Felucca && m_cpmg.FeluccaKey && !IsUnderworld(m_mgc.Moongates[i])) || (m_mgc.Moongates[i].Map == Map.Trammel && m_cpmg.TrammelKey && !IsUnderworld(m_mgc.Moongates[i])) || (m_mgc.Moongates[i].Map == Map.Ilshenar && m_cpmg.IlshenarKey) || (m_mgc.Moongates[i].Map == Map.Malas && m_cpmg.MalasKey) || (m_mgc.Moongates[i].Map == Map.Tokuno && m_cpmg.TokunoKey) || (m_mgc.Moongates[i].Map == Map.TerMur && m_cpmg.TerMurKey) )
						{
							this.AddLabel(190+col,120+row, thue, m_mgc.Moongates[i].NewbieName);
							this.AddButton(160+col, 125+row,30008,30009,i+1, GumpButtonType.Reply,0);
						}
					}
				}
			}
		}
		
		public override void OnResponse(NetState sender, RelayInfo info)
		{
			Mobile from = sender.Mobile;
			if ( from == null )
				return;
			
			from.CloseGump( typeof(MoongateMenuGump) );
			
			if (info.ButtonID > 0)
			{
				int button = info.ButtonID -1;
				BaseCreature.TeleportPets( from, m_mgc.Moongates[button].Location, m_mgc.Moongates[button].Map );
				from.Combatant = null;
				from.Warmode = false;
				from.Hidden = true;
				from.MoveToWorld( m_mgc.Moongates[button].Location, m_mgc.Moongates[button].Map );
				Effects.PlaySound( m_mgc.Moongates[button].Location, m_mgc.Moongates[button].Map, 0x1FE );
			}
		}
	}
}