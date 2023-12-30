using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Spells;
using System.Collections;
using System.Collections.Generic;
using Server.Network;
using Server.Gumps;

namespace Server.Items 
{ 
	[FlipableAttribute( 4461, 4462 )]
	public class MoongateController : Item
	{ 
		private bool m_VoiceActivation = false;
		[CommandProperty( AccessLevel.GameMaster )]
		public bool VoiceActivation
		{
			get { return m_VoiceActivation; }
			set { m_VoiceActivation = value; }
		}
		
		private string m_VoiceCommand = "moongate";
		[CommandProperty( AccessLevel.GameMaster )]
		public string VoiceCommand
		{
			get { return m_VoiceCommand; }
			set { m_VoiceCommand = value; }
		}
		
		private string m_CircuitName = "Public Circuit";
		[CommandProperty( AccessLevel.GameMaster )]
		public string CircuitName
		{
			get { return m_CircuitName; }
			set { m_CircuitName = value;InvalidateProperties(); }
		}
		
		private bool m_Enabled;
		[CommandProperty( AccessLevel.GameMaster )]
		public bool Enabled
		{
			get { return m_Enabled; }
			set { m_Enabled = value; }
		}
		
		private MoongateTimer m_MoongateTimer;
		public void Stop()
		{
			if (m_MoongateTimer != null)
			{
				m_Enabled = false;
				m_MoongateTimer.Stop();
				m_MoongateTimer = null;
			}
		}
		
		private int m_TimerCycle=60;
		[CommandProperty( AccessLevel.GameMaster )]
		public int TimerCycle
		{
			get { return m_TimerCycle; }
			set { m_TimerCycle = value;}
		}
		public void Start()
		{
			m_Enabled = true;
			if (m_MoongateTimer == null)
			{
				m_MoongateTimer = new MoongateTimer(this);
			}
			m_MoongateTimer.Start();
		}
		
		private List<ClassicPublicMoongate> m_Moongates = new List<ClassicPublicMoongate>();
		public List<ClassicPublicMoongate> Moongates
		{
			get{ return m_Moongates;}
		}
		
		private bool m_NewbieTitles = true;
		[CommandProperty( AccessLevel.GameMaster )]
		public bool NewbieTitles
		{
			get { return m_NewbieTitles; }
			set { m_NewbieTitles = value; }
		}
		
		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
			if (!m_Enabled)
				Start();
			if ((m_CircuitName != null) && (m_CircuitName != ""))
				list.Add("Circuit: "+m_CircuitName);
		}
		
		[Constructable] 
		public MoongateController() : base( 4461 ) 
		{ 
			Name = "a Moongate Controller";
			Movable = false;
		} 
		
		public override void OnDoubleClick( Mobile from )
		{
			if (from.AccessLevel>=AccessLevel.GameMaster)
			{
				from.CloseGump( typeof(MoongateControllerGump) );
				from.SendGump( new MoongateControllerGump(this) );
			}
			else
				from.SendMessage("You may not use this");
		}
		
		public virtual void UpdateAll(MoongateController u_MGC)
		{
			for ( int i = 0; i < u_MGC.Moongates.Count; ++i )
			{
				ClassicPublicMoongate CPMG = (ClassicPublicMoongate)u_MGC.Moongates[i];
				if (!CPMG.UseGump)
				{
					CPMG.LeftOffAt = i;
					CPMG.GetInformation();
				}
			}
		}
		
		public class MoongateTimer: Timer
		{
			private MoongateController t_MGC;
			private ClassicPublicMoongate t_CPMG;
			
			public MoongateTimer(MoongateController MGC ) : base(TimeSpan.FromSeconds(MGC.TimerCycle), TimeSpan.FromSeconds(MGC.TimerCycle))
			{
				Priority = TimerPriority.OneSecond;
				t_MGC = (MoongateController) MGC;
			}
			
			protected override void OnTick()
			{
				for ( int i = 0; i < t_MGC.Moongates.Count; ++i )
				{
					t_CPMG = (ClassicPublicMoongate)t_MGC.Moongates[i];
					if (!t_CPMG.UseGump)
						t_CPMG.GetInformation();
				}
			}
		}
		
		public override void OnDelete()
		{
			for (int i = m_Moongates.Count -1; i >= 0; i-- )
			{
				m_Moongates[i].Delete();
			}
			base.OnDelete();
		}
		
		public MoongateController( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 
			writer.Write( (int) 1 ); // version 
			
			//case 1
			writer.Write( (bool) m_VoiceActivation );
			writer.Write( (string) m_VoiceCommand );
			
			//case 0
			writer.Write( (string) m_CircuitName );
			writer.Write( (int) m_TimerCycle );
			writer.Write( (bool) m_NewbieTitles);
			writer.Write( m_Moongates.Count);
			for (int i=0;i< m_Moongates.Count; ++i)
			{
				writer.Write((ClassicPublicMoongate)m_Moongates[i]);
			}
		} 
		
		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 
			int version = reader.ReadInt(); 
			switch (version)
			{
				case 1:
				{
					m_VoiceActivation = reader.ReadBool();
					m_VoiceCommand = reader.ReadString();
					goto case 0;
				}
				case 0:
				{
					m_CircuitName = reader.ReadString();
					m_TimerCycle = reader.ReadInt();
					m_NewbieTitles = reader.ReadBool();
					int count = reader.ReadInt();
					for (int i=0;i<count;++i)
					{
						m_Moongates.Add((ClassicPublicMoongate)reader.ReadItem());
					}
					break;
				}
			}
		} 
	} 
	
	public class MoongateInterfaceTool : Item
	{
		private MoongateController m_MGC;
		public MoongateController MGC
		{
			get {return m_MGC;}
			set {m_MGC = value;}
		}
		
		[Constructable]
		public MoongateInterfaceTool() : base( 5359 ) 
		{
			Name = "a Moongate Interface Tool";
			LootType = LootType.Blessed;
		}
		
		public override void OnDoubleClick( Mobile from )
		{
			if (this.IsChildOf( from.Backpack ))
			{
				if (from.AccessLevel >= AccessLevel.GameMaster)
				{
					if (m_MGC == null || m_MGC.Deleted)
					{
						from.SendMessage("The Controller has been deleted");
						this.Delete();
					}
					else
					{
						from.CloseGump( typeof(MoongateControllerGump) );
						from.SendGump( new MoongateControllerGump(m_MGC) );
					}
				}
				else
					from.SendMessage("You may not use that");
			}
			else
			{
				from.SendMessage("That must be in your backpack to use");
			}
		}
		
		public MoongateInterfaceTool( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
			writer.Write((MoongateController)m_MGC);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			m_MGC = (MoongateController)reader.ReadItem();
		}
	}
}
namespace Server.Gumps
{
	public class MoongateControllerGump : Gump
	{
		private MoongateController m_mgc;
		private ClassicPublicMoongate m_cpmg;
		
		public MoongateControllerGump(MoongateController MGC) : base( 0, 0 )
		{
			m_mgc = MGC;
			
			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			this.AddPage(0);
			this.AddBackground(90, 5, 625, 535, 9200);
			this.AddLabel(350, 40 , 85, @"Moongate Controller");
			this.AddLabel(200, 65, 0, @"Circuit");
			this.AddBackground(245, 65, 170, 20, 3000);
			this.AddTextEntry(250, 65, 160, 20, 0, 1, m_mgc.CircuitName);//Circuit Name Entry = 1
			this.AddLabel(465, 65, 0, @"Cycle Time");
			this.AddBackground(535, 65, 40, 20, 3000);
			this.AddTextEntry(540, 65, 35, 20, 0, 6, m_mgc.TimerCycle.ToString());//Cycle Time Entry = 6
			
			this.AddLabel(200, 90, 0, @"Voice");
			this.AddCheck(260, 90, 210, 211, m_mgc.VoiceActivation, 8);//Voice Activation Checkbox = 8
			this.AddBackground(285, 90, 130, 20, 3000);
			this.AddTextEntry(290, 90, 125, 20, 0, 9, m_mgc.VoiceCommand);//Voice Command Entry = 9
			
			this.AddImage(95, 40, 7035);
			this.AddImage(640, 40, 7035);
			this.AddImageTiled(90, 20, 625, 15, 10100);
			this.AddImageTiled(90, 490, 625, 15, 10100);
			
			this.AddLabel(135, 510, 0, @"Restart Cycle");
			this.AddButton(100, 510, 4008, 4009, 2, GumpButtonType.Reply, 0);//Update All = 2
			this.AddLabel(480,510,0, @"Interface Tool");
			this.AddButton(460,515,30008,30009,7, GumpButtonType.Reply,0);//Interface Tool = 7 
			this.AddLabel(600, 510, 0, @"Placement Tool");
			this.AddButton(580, 515, 30008, 30009, 3, GumpButtonType.Reply, 0);//Placement Tool = 3 
			this.AddButton(375, 510, 247, 248, 4, GumpButtonType.Reply, 0);//Okay Button = 4
			this.AddLabel(255, 510, 0, @"Newbie Names");
			this.AddCheck(230, 510, 210, 211, m_mgc.NewbieTitles, 5);//Newbie Names = 5
			
			this.AddBackground(130, 120, 35, 360, 3000);
			this.AddBackground(195, 120, 175, 360, 3000);
			this.AddBackground(440, 120, 35, 360, 3000);
			this.AddBackground(505, 120, 175, 360, 3000);
			
			for ( int i = 0; i < m_mgc.Moongates.Count; ++i )
			{
				int thue = 0;
				int nhue = 0;
				int col = ( ( (int)(i/18) ) *310);
				int row = ( (i- ( ( (int) i/18) *18 ) ) *20);
				m_cpmg = (ClassicPublicMoongate)m_mgc.Moongates[i];
				if (m_mgc.Moongates[i].Map == Map.Felucca)
					nhue=38;
				else if (m_mgc.Moongates[i].Map == Map.Trammel)
					nhue=93;
				else if (m_mgc.Moongates[i].Map == Map.Ilshenar)
					nhue=68;
				else if (m_mgc.Moongates[i].Map == Map.Malas)
					nhue=48;
				else if (m_mgc.Moongates[i].Map == Map.Tokuno)
					nhue=18;
				else
					nhue=53;
					
				if (!m_mgc.Moongates[i].IsActive)
					thue=999;
				else if (m_mgc.Moongates[i].IsCriminal || m_mgc.Moongates[i].IsMurderer)
					thue=33;
				else 
					thue=93;
				
				this.AddLabel(200+col,120+row, thue, m_cpmg.NewbieName);
				this.AddLabel(140+col,120+row, nhue, (1+i).ToString() );
				this.AddButton(165+col, 120+row,4029,4030,(i+10), GumpButtonType.Reply,0);//Props = 10+
			}
		}
		
		public override void OnResponse(NetState sender, RelayInfo info)
		{
			Mobile from = sender.Mobile;
			if ( from == null )
				return;
			if (info.ButtonID==2)//Update All
			{
				m_mgc.UpdateAll(m_mgc);
				from.CloseGump( typeof(MoongateControllerGump) );
				from.SendGump( new MoongateControllerGump(m_mgc) );
			}
			else if (info.ButtonID==3) //Toggle Placement Tool
			{
				PlayerMobile m = (PlayerMobile) from;
				Item mpt = m.Backpack.FindItemByType( typeof( MoongatePlacementTool ), true );
				if ( mpt != null && !mpt.Deleted )
				{
					MoongatePlacementTool MGPT = (MoongatePlacementTool) mpt;
					if (MGPT.MGC == m_mgc)
					{
						MGPT.Delete();
					}
					else
					{
						from.SendMessage("You can only use one Placement Tool at a time");
					}
				}
				else if (m_mgc.Moongates.Count >=35 )
				{
					from.SendMessage("The Controller is at Maximum Moongates");
				}
				else
				{
					MoongatePlacementTool MGPT = new MoongatePlacementTool();
					MGPT.MGC = m_mgc;
					from.AddToBackpack(MGPT);
				}
				from.CloseGump( typeof(MoongateControllerGump) );
				from.SendGump( new MoongateControllerGump(m_mgc) );
			}
			else if (info.ButtonID==7) //Toggle Interface Tool
			{
				PlayerMobile m = (PlayerMobile) from;
				Item mit = m.Backpack.FindItemByType( typeof( MoongateInterfaceTool ), true );
				if ( mit != null && !mit.Deleted )
				{
					MoongateInterfaceTool MGIT = (MoongateInterfaceTool) mit;
					if (MGIT.MGC == m_mgc)
					{
						MGIT.Delete();
					}
					else
					{
						from.SendMessage("You can only have one Interface Tool at a time");
					}
				}
				else
				{
					MoongateInterfaceTool MGIT = new MoongateInterfaceTool();
					MGIT.MGC = m_mgc;
					from.AddToBackpack(MGIT);
				}
				from.CloseGump( typeof(MoongateControllerGump) );
				from.SendGump( new MoongateControllerGump(m_mgc) );
			}
			else if (info.ButtonID >= 10)  //Moongate Props
			{
				from.CloseGump( typeof(MoongatePropsGump) );
				from.SendGump( new MoongatePropsGump(m_mgc, (info.ButtonID -10)) );
			}
			else if (info.ButtonID == 4) //Okay
			{
				m_mgc.VoiceActivation = info.IsSwitched(8);
				m_mgc.VoiceCommand = (string)info.GetTextEntry(9).Text;
				m_mgc.NewbieTitles = info.IsSwitched(5);
				m_mgc.CircuitName = (string)info.GetTextEntry(1).Text;
				TextRelay CT = info.GetTextEntry(6);
				try
				{
					int tc = Convert.ToInt32(CT.Text);
					if ((tc != m_mgc.TimerCycle) && tc > 0)
					{
						m_mgc.Stop();
						m_mgc.TimerCycle = tc;
						m_mgc.Start();
					}
				}
				catch
				{
					from.SendMessage("Bad Cycle Time entry. A number was expected.");
				}
				from.CloseGump( typeof(MoongateControllerGump) );
				from.SendGump( new MoongateControllerGump(m_mgc) );
			}
		}
	}
	
	public class MoongatePropsGump : Gump
	{
		private MoongateController m_mgc;
		private int m_mgi;
		
		public MoongatePropsGump(MoongateController MGC, int MoongateIndex): base( 0, 0 )
		{
			m_mgc = MGC;
			m_mgi = MoongateIndex;
			
			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			this.AddBackground(185, 5, 375, 420, 9200);
			this.AddLabel(305, 45, 85, @"Moongate Properties");
			this.AddImage(190, 40, 2275);
			this.AddImage(510, 40, 2275);
			this.AddImageTiled(185, 20, 375, 15, 10100);
			this.AddImageTiled(185, 375, 375, 15, 10100);
			
			this.AddLabel(205, 100, 0, @"Newbie Name");
			this.AddBackground(200, 120, 205, 25, 3000);
			this.AddTextEntry(205, 125, 200, 20, 0, 1, m_mgc.Moongates[m_mgi].NewbieName);//NewbieName Entry = 1
			this.AddLabel(205, 150, 0, @"Description");
			this.AddBackground(200, 170, 205, 95, 3000);
			this.AddTextEntry(205, 175, 200, 90, 0, 2, m_mgc.Moongates[m_mgi].Description);//Description Entry = 2
			
			this.AddLabel(225, 275, 0, @"Only Out");
			this.AddCheck(200, 275, 210, 211, m_mgc.Moongates[m_mgi].OutOnly, 3);//OnlyOut Checkbox = 3
			
			this.AddLabel(225, 300, 0, @"Allow Criminal");
			this.AddCheck(200, 300, 210, 211, m_mgc.Moongates[m_mgi].IsCriminal, 4);//Criminal Checkbox = 4
			
			this.AddLabel(225, 325, 0, @"Allow Murderer");
			this.AddCheck(200, 325, 210, 211, m_mgc.Moongates[m_mgi].IsMurderer, 5);//Murderer Checkbox = 5
			
			this.AddLabel(225, 350, 0, @"Allow Faction Sigil");
			this.AddCheck(200, 350, 210, 211, m_mgc.Moongates[m_mgi].HasSigil, 6);//Has Sigil Checkbox = 6
			
			this.AddLabel(440, 100, 0, @"Felucca Key");
			this.AddCheck(415, 100, 210, 211, m_mgc.Moongates[m_mgi].FeluccaKey, 7);//IsFelucca Checkbox = 7
			
			this.AddLabel(440, 125, 0, @"Trammel Key");
			this.AddCheck(415, 125, 210, 211, m_mgc.Moongates[m_mgi].TrammelKey, 8);//IsTrammel Checkbox = 8
			
			this.AddLabel(440, 150, 0, @"Ilshenar Key");
			this.AddCheck(415, 150, 210, 211, m_mgc.Moongates[m_mgi].IlshenarKey, 9);//IsIlshenar Checkbox = 9
			
			this.AddLabel(440, 175, 0, @"Malas Key");
			this.AddCheck(415, 175, 210, 211, m_mgc.Moongates[m_mgi].MalasKey, 10);//IsMalas Checkbox = 10
			
			this.AddLabel(440, 200, 0, @"Tokuno Key");
			this.AddCheck(415, 200, 210, 211, m_mgc.Moongates[m_mgi].TokunoKey, 11);//IsTokuno Checkbox = 11
			
			this.AddLabel(440, 225, 0, @"TerMur Key");
			this.AddCheck(415, 225, 210, 211, m_mgc.Moongates[m_mgi].TerMurKey, 12);//IsTerMuc Checkbox = 12
			
			this.AddLabel(440, 250, 0, @"Underworld Key");
			this.AddCheck(415, 250, 210, 211, m_mgc.Moongates[m_mgi].UnderworldKey, 13);//IsUnderworld Checkbox = 13
			
			//this.AddLabel(440, 275, 0, @"Out Only");
			//this.AddCheck(415, 275, 210, 211, m_mgc.Moongates[m_mgi].OutOnly, 14);//Out Only Checkbox = 14
			
			this.AddLabel(440, 300, 0, @"Is Active");
			this.AddCheck(415, 300, 210, 211, m_mgc.Moongates[m_mgi].IsActive, 19);//IsActive Checkbox = 19
			
			this.AddLabel(440, 325, 0, @"Use Gump");
			this.AddCheck(415, 325, 210, 211, m_mgc.Moongates[m_mgi].UseGump, 20);//Use Gump Checkbox = 20
			
			this.AddLabel(415, 355, 0, @"ItemID");
			this.AddBackground(460, 350, 60, 25, 3000);
			this.AddTextEntry(465, 355, 55, 20, 0, 18, m_mgc.Moongates[m_mgi].GateItemID.ToString() );//Hue Entry = 18
			
			this.AddLabel(220, 395, 0, @"Go To");
			this.AddButton(200, 400, 30008, 30009, 15, GumpButtonType.Reply, 0);//Go Button = 15
			
			this.AddLabel(505, 395, 40, @"Remove");
			this.AddCheck(460, 388, 2642, 2643, false, 16);//Remove Button = 16
			
			this.AddButton(340, 395, 247, 248, 17, GumpButtonType.Reply, 0);//OKAY Button = 17
		}
		
		public override void OnResponse(NetState sender, RelayInfo info)
		{
			Mobile from = sender.Mobile;
			if ( from == null )
				return;
			
			if (info.ButtonID == 17) //Okay Pressed
			{
				if (info.IsSwitched(16)) //Remove
				{
					m_mgc.Moongates[m_mgi].Delete();
					from.CloseGump( typeof(MoongateControllerGump) );
					from.SendGump( new MoongateControllerGump(m_mgc) );
				}
				else
				{
					m_mgc.Moongates[m_mgi].NewbieName = (string)info.GetTextEntry(1).Text;
					m_mgc.Moongates[m_mgi].Description = (string)info.GetTextEntry(2).Text;
				
					m_mgc.Moongates[m_mgi].OutOnly = info.IsSwitched( 3 );
					m_mgc.Moongates[m_mgi].IsCriminal = info.IsSwitched( 4 );
					m_mgc.Moongates[m_mgi].IsMurderer = info.IsSwitched( 5 );
					m_mgc.Moongates[m_mgi].HasSigil = info.IsSwitched( 6 );
					m_mgc.Moongates[m_mgi].FeluccaKey = info.IsSwitched( 7 );
					m_mgc.Moongates[m_mgi].TrammelKey = info.IsSwitched( 8 );
					m_mgc.Moongates[m_mgi].IlshenarKey = info.IsSwitched( 9 );
					m_mgc.Moongates[m_mgi].MalasKey = info.IsSwitched( 10 );
					m_mgc.Moongates[m_mgi].TokunoKey = info.IsSwitched( 11 );
					m_mgc.Moongates[m_mgi].TerMurKey = info.IsSwitched( 12 );
					m_mgc.Moongates[m_mgi].UnderworldKey = info.IsSwitched( 13 );
					//m_mgc.Moongates[m_mgi].OutOnly = info.IsSwitched( 14 );
					m_mgc.Moongates[m_mgi].IsActive = info.IsSwitched( 19 );
					m_mgc.Moongates[m_mgi].UseGump = info.IsSwitched( 20 );
					
					TextRelay GID = info.GetTextEntry(18);
					try
					{
						m_mgc.Moongates[m_mgi].GateItemID = Convert.ToInt32(GID.Text);
					}
					catch
					{
						from.SendMessage("Bad GateItemID entry. A number was expected.");
					}
					m_mgc.Moongates[m_mgi].GetInformation();
					m_mgc.UpdateAll(m_mgc);
					from.CloseGump( typeof(MoongatePropsGump) );
					from.SendGump( new MoongatePropsGump(m_mgc, m_mgi) );
				}
			}
			else if (info.ButtonID == 15) //Go
			{
				from.MoveToWorld( m_mgc.Moongates[m_mgi].Location, m_mgc.Moongates[m_mgi].Map );
				Effects.PlaySound( m_mgc.Moongates[m_mgi].Location, m_mgc.Moongates[m_mgi].Map, 0x1FE );
				from.CloseGump( typeof(MoongateControllerGump) );
				from.SendGump( new MoongateControllerGump(m_mgc) );
			}
			else
			{
				from.CloseGump( typeof(MoongateControllerGump) );
				from.SendGump( new MoongateControllerGump(m_mgc) );
			}
		}
	}
}