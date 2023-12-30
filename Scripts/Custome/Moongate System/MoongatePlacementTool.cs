using System;
using Server;
using System.Collections;
using System.Collections.Generic;
using Server.Mobiles;
using Server.Prompts;
using Server.Gumps;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class MoongatePlacementTool : Item
	{
		private MoongateController m_MGC;
		public MoongateController MGC
		{
			get {return m_MGC;}
			set {m_MGC = value;}
		}
		
		[Constructable]
		public MoongatePlacementTool() : base( 5359 ) 
		{
			Name = "a Moongate Placement Tool";
			LootType = LootType.Blessed;
		}
		
		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
			if ((m_MGC.CircuitName != null) && (m_MGC.CircuitName != ""))
				list.Add("Circuit: "+m_MGC.CircuitName);
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
					else if (m_MGC.Moongates.Count >= 35)
					{
						from.SendMessage("The Controller is at Maximum Moongates");
						this.Delete();
					}
					else
					{
						from.CloseGump( typeof(MoongatePlacementGump) );
						from.SendGump( new MoongatePlacementGump(this, from) );
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
		
		public MoongatePlacementTool( Serial serial ) : base( serial )
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
	public class MoongatePlacementGump : Gump
	{
		private MoongatePlacementTool m_mgpt;
		private Mobile m_pm;
		ClassicPublicMoongate CPMG = new ClassicPublicMoongate();
		
		public virtual bool IsUnderworld(Mobile testing)
		{
			if (((testing.Map == Map.Felucca) || (testing.Map == Map.Trammel)) && (testing.X > 5120) )
				return true;
			return false;
		}
		
		public MoongatePlacementGump(MoongatePlacementTool MGPT, Mobile PM) : base( 0, 0 )
		{
			m_mgpt = MGPT;
			m_pm = PM;
			
			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			
			this.AddPage(0);
			this.AddBackground(185, 5, 375, 420, 9200);
			this.AddLabel(300, 45, 85, @"Moongate Placement Tool");
			this.AddImage(190, 40, 2275);
			this.AddImage(510, 40, 2275);
			this.AddImageTiled(185, 20, 375, 15, 10100);
			this.AddImageTiled(185, 375, 375, 15, 10100);
			
			this.AddLabel(205, 100, 0, @"Newbie Name");
			this.AddBackground(200, 120, 205, 25, 3000);
			this.AddTextEntry(205, 125, 200, 20, 0, 1, @"");//NewbieName Entry = 1
			this.AddLabel(205, 150, 0, @"Description");
			this.AddBackground(200, 170, 205, 95, 3000);
			this.AddTextEntry(205, 175, 200, 90, 0, 2, @"");//Description Entry = 2
			
			this.AddLabel(225, 275, 0, @"Out Only");
			this.AddCheck(200, 275, 210, 211, false, 3);//OutOnly Checkbox = 3
			
			this.AddLabel(225, 300, 0, @"Allow Criminal");
			this.AddCheck(200, 300, 210, 211, false, 4);//Criminal Checkbox = 4
			
			this.AddLabel(225, 325, 0, @"Allow Murderer");
			this.AddCheck(200, 325, 210, 211, false, 5);//Murderer Checkbox = 5
			
			this.AddLabel(225, 350, 0, @"Allow Faction Sigil");
			this.AddCheck(200, 350, 210, 211, false, 6);//Has Sigil Checkbox = 6
			
			this.AddLabel(440, 100, 0, @"Felucca Key");
			this.AddCheck(415, 100, 210, 211, (m_pm.Map == Map.Felucca && !IsUnderworld(m_pm)), 7);//IsFelucca Checkbox = 7
			
			this.AddLabel(440, 125, 0, @"Trammel Key");
			this.AddCheck(415, 125, 210, 211, (m_pm.Map == Map.Trammel && !IsUnderworld(m_pm)), 8);//IsTrammel Checkbox = 8
			
			this.AddLabel(440, 150, 0, @"Ilshenar Key");
			this.AddCheck(415, 150, 210, 211, (m_pm.Map == Map.Ilshenar && !IsUnderworld(m_pm)), 9);//IsIlshenar = 9
			
			this.AddLabel(440, 175, 0, @"Malas Key");
			this.AddCheck(415, 175, 210, 211, (m_pm.Map == Map.Malas && !IsUnderworld(m_pm)), 10);//IsMalas Checkbox = 10
			
			this.AddLabel(440, 200, 0, @"Tokuno Key");
			this.AddCheck(415, 200, 210, 211, (m_pm.Map == Map.Tokuno && !IsUnderworld(m_pm)), 11);//IsTokuno Checkbox = 11
			
			this.AddLabel(440, 225, 0, @"TerMur Key");
			this.AddCheck(415, 225, 210, 211, (m_pm.Map == Map.TerMur && !IsUnderworld(m_pm)), 12);//IsTerMur Checkbox = 12
			
			this.AddLabel(440, 250, 0, @"Underworld Key");
			this.AddCheck(415, 250, 210, 211, (IsUnderworld(m_pm)), 13);//IsUnderworld Checkbox = 13
			
			//this.AddLabel(440, 275, 0, @"Out Only");
			//this.AddCheck(415, 275, 210, 211, false, 14);//OutOnly Checkbox = 14
			
			this.AddLabel(440, 300, 0, @"Use Gump");
			this.AddCheck(415, 300, 210, 211, false, 16);//UseGump Checkbox = 16
			
			this.AddLabel(230, 395, 0, @"Decorate Tool");
			this.AddButton(210, 400, 30008, 30009, 17, GumpButtonType.Reply, 0);//Decorate Tool Button = 17
			
			this.AddButton(340, 395, 247, 248, 15, GumpButtonType.Reply, 0);//OKAY Button = 15
		}
		
		public override void OnResponse(NetState sender, RelayInfo info)
		{
			Mobile from = sender.Mobile;
			if ( from == null )
				return;

			if (info.ButtonID == 15)
			{
				CPMG.NewbieName = (string)info.GetTextEntry(1).Text;
				CPMG.Description = (string)info.GetTextEntry(2).Text;
				
				CPMG.OutOnly = info.IsSwitched(3);
				CPMG.IsCriminal = info.IsSwitched(4);
				CPMG.IsMurderer = info.IsSwitched(5);
				CPMG.HasSigil = info.IsSwitched(6);
				CPMG.FeluccaKey = info.IsSwitched(7);
				CPMG.TrammelKey = info.IsSwitched(8);
				CPMG.IlshenarKey = info.IsSwitched(9);
				CPMG.MalasKey = info.IsSwitched(10);
				CPMG.TokunoKey = info.IsSwitched(11);
				CPMG.TerMurKey = info.IsSwitched(12);
				CPMG.UnderworldKey = info.IsSwitched(13);
				//CPMG.OutOnly = info.IsSwitched(14);
				CPMG.UseGump = info.IsSwitched(16);
				
				CPMG.Movable = false;
				CPMG.MGC=m_mgpt.MGC;
				Map map = from.Map;
				Point3D loc = from.Location;
				m_mgpt.MGC.Moongates.Add(CPMG);

				CPMG.ItemID = 3948;
				Effects.SendLocationEffect( loc, map, 6899, 50 );

				Timer.DelayCall( TimeSpan.FromSeconds( 1.7 ), delegate
				{
					Effects.PlaySound( loc, map, 0x20E );
					CPMG.MoveToWorld(loc, map);
				} );
			}
			else if (info.ButtonID==17) //Toggle Decorate Tool
			{
				PlayerMobile m = (PlayerMobile) from;
				Item mgd = m.Backpack.FindItemByType( typeof( MoongateDecorator ), true );
				if ( mgd != null && !mgd.Deleted )
				{
					mgd.Delete();
				}
				else if (m_mgpt.MGC.Moongates.Count > 0 )
				{
					from.SendMessage("Decorator can only be used with empty controllers");
				}
				else
				{
					MoongateDecorator MGD = new MoongateDecorator();
					MGD.MGC = m_mgpt.MGC;
					from.AddToBackpack(MGD);
				}
				from.CloseGump( typeof(MoongatePlacementGump) );
				from.SendGump( new MoongatePlacementGump(m_mgpt, from) );
			}
		}
	}
}