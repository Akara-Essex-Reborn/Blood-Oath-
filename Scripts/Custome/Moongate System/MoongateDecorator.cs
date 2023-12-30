using System;
using Server;
using Server.Items;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using System.Collections;
using Server.Gumps;

namespace Server.Items
{
	public class MoongateDecorator : Item
	{
		private MoongateController m_MGC;
		public MoongateController MGC
		{
			get {return m_MGC;}
			set {m_MGC = value;}
		}
		
		[Constructable]
		public MoongateDecorator() : base( 576 ) 
		{
			Name = "a moongate decoration tool";
		}
		
		public override void OnDoubleClick( Mobile from )
		{
			if (this.IsChildOf( from.Backpack ))
			{
				if (m_MGC == null)
				{
					from.SendMessage("You need to associate a Moongate Controller");
					from.SendMessage("before you can use the Decorator.");
					from.SendMessage("Target Moongate Controller");
					from.Target = new MoongateControllerTarget(m_MGC);
				}
				else
				{
					from.CloseGump( typeof(MoongateDecoratorGump) );
					from.SendGump( new MoongateDecoratorGump(m_MGC) );
				}
			}
			else
				from.SendMessage("That must be in your backpack to use");
		}
		
		public MoongateDecorator( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
		
		private class MoongateControllerTarget : Target
		{
			private MoongateController t_MGC;

			public MoongateControllerTarget(MoongateController MGC) : base( 10, false, TargetFlags.None )
			{
				t_MGC = MGC;
			}
	
			protected override void OnTarget( Mobile from, object targ )
			{
				if (targ is Item)
				{
					if (targ is MoongateController)
					{
						MoongateController mgc = (MoongateController) targ;
						t_MGC = mgc;
						from.CloseGump( typeof(MoongateDecoratorGump) );
						from.SendGump( new MoongateDecoratorGump(t_MGC) );
					}
					else
						from.SendMessage("Target only Moongate Controller");
				}
			}
		}
	}
}
namespace Server.Gumps
{
	public class MoongateDecoratorGump : Gump
	{
		private MoongateController g_MGC;
		private ClassicPublicMoongate CPMG;
		
		public MoongateDecoratorGump(MoongateController MGC) : base( 0, 0 )
		{
			g_MGC = MGC;
			
			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			
			this.AddBackground(210, 5, 310, 270, 9200);
			this.AddImageTiled(210, 20, 310, 15, 10100);
			this.AddImage(215, 40, 2275);
			this.AddImage(470, 40, 2275);
			this.AddLabel(330, 45, 1152, @"ServUO");
			this.AddLabel(295, 65, 87, @"Moongate Decorator");
			
			this.AddLabel(245, 155, 0, @"Circuit");
			this.AddBackground(290, 150, 170, 25, 3000);
			this.AddLabel(295, 155, 0, g_MGC.CircuitName);
			this.AddLabel(245, 190, 0, @"Number of Gates");
			this.AddBackground(360, 185, 48, 26, 3000);
			this.AddLabel(365, 190, 0, @"34");
			this.AddLabel(275, 240, 0, @"Place Gates");
			this.AddButton(355, 240, 247, 248, 1, GumpButtonType.Reply, 0); //Place Moongates = 1
		}
		
		public override void OnResponse(NetState sender, RelayInfo info)
		{
			Mobile from = sender.Mobile;
			if ( from == null )
				return;

			if (info.ButtonID == 1)
			{
				if(g_MGC.Moongates.Count==0)
				{
					from.SendMessage("Placing Gates...");
					CreateMoongate(1336, 1997, 5, Map.Felucca, false, true, true, true, true, true, true, true, true, true, true, false, 0, "Britain", "... see a road to the east and mountains in the distance to the west.");
					CreateMoongate(1500, 3772, 5, Map.Felucca, false, true, true, true, true, true, true, true, true, true, true, false, 0, "Jhelom", "... see a vast body of water to the east while to the west a city can be seen nearby.");
					CreateMoongate(3564, 2140, 31, Map.Felucca, false, true, true, true, true, true, true, true, true, true, true, false, 0, "Magincia", "... see what appears to be a small peninsula covered in lush foliage.");
					CreateMoongate(2702, 692, 5, Map.Felucca, false, true, true, true, true, true, true, true, true, true, true, false, 0, "Minoc", "... can just make out a road to the southwest and a river to the north.");
					CreateMoongate(4468, 1284, 5, Map.Felucca, false, true, true, true, true, true, true, true, true, true, true, false, 0, "Moonglow", "... see a small escarpment to the south and a large city to the North. ");
					CreateMoongate(645, 2068, 5, Map.Felucca, false, true, true, true, true, true, true, true, true, true, true, false, 0, "Skara Brae", "... see a small city to the south, while a vast ocean lies in all other directions");
					CreateMoongate(1829, 2949, -20, Map.Felucca, false, true, true, true, true, true, true, true, true, true, true, false, 0, "Trinsic", "... see a large sandstone city standing on a far bank of the river to the north.");
					CreateMoongate(771, 754, 5, Map.Felucca, false, true, true, true, true, true, true, true, true, true, true, false, 0, "Yew", "... see deep forest on all sides.");
					CreateMoongate(2711, 2234, 1, Map.Felucca, false, true, true, true, true, true, true, true, true, true, true, false, 0, "Buccaneer's Ded", "... see a small hamlet on a jungle island.");
					
					
					CreateMoongate(1336, 1997, 5, Map.Trammel, false, false, false, true, true, true, true, true, true, true, true, false, 0, "Britain", "... see a road to the east and mountains in the distance to the west.");
					CreateMoongate(1500, 3772, 5, Map.Trammel, false, false, false, true, true, true, true, true, true, true, true, false, 0, "Jhelom", "... see a vast body of water to the east while to the west a city can be seen nearby.");
					CreateMoongate(3564, 2140, 31, Map.Trammel, false, false, false, true, true, true, true, true, true, true, true, false, 0, "Magincia", "... see what appears to be a small peninsula covered in lush foliage.");
					CreateMoongate(2702, 692, 5, Map.Trammel, false, false, false, true, true, true, true, true, true, true, true, false, 0, "Minoc", "... can just make out a road to the southwest and a river to the north.");
					CreateMoongate(4468, 1284, 5, Map.Trammel, false, false, false, true, true, true, true, true, true, true, true, false, 0, "Moonglow", "... see a small escarpment to the south and a large city to the North. ");
					CreateMoongate(645, 2068, 5, Map.Trammel, false, false, false, true, true, true, true, true, true, true, true, false, 0, "Skara Brae", "... see a small city to the south, while a vast ocean lies in all other directions");
					CreateMoongate(1829, 2949, -20, Map.Trammel, false, false, false, true, true, true, true, true, true, true, true, false, 0, "Trinsic", "... see a large sandstone city standing on a far bank of the river to the north.");
					CreateMoongate(771, 754, 5, Map.Trammel, false, false, false, true, true, true, true, true, true, true, true, false, 0, "Yew", "... see deep forest on all sides.");
					CreateMoongate(3450, 2677, 25, Map.Trammel, false, false, false, true, true, true, true, true, true, true, true, false, 0, "New Haven", "... see a wooded island with a busy town.");
					
					CreateMoongate(1721, 218, 96, Map.Ilshenar, false, false, false, true, true, true, true, true, true, true, true, false, 0, "Chaos", "... see a shrine surrounded by rivers of lava.");
					CreateMoongate(1215, 467, -13, Map.Ilshenar, false, false, false, true, true, true, true, true, true, true, true, false, 0, "Compassion", "... see a shrine with marble floors and cut stone walls.");
					CreateMoongate(722, 1366, -60, Map.Ilshenar, false, false, false, true, true, true, true, true, true, true, true, false, 0, "Honesty", "... see a shrine in a forest pass.");
					CreateMoongate(744, 724, -28, Map.Ilshenar, false, false, false, true, true, true, true, true, true, true, true, false, 0, "Honor", "... see a shrine in a jungle.");
					CreateMoongate(281, 1016, 3, Map.Ilshenar, false, false, false, true, true, true, true, true, true, true, true, false, 0, "Humility", "... see a stone shrine and a swamp to the south.");
					CreateMoongate(987, 1011, -32, Map.Ilshenar, false, false, false, true, true, true, true, true, true, true, true, false, 0, "Justice", "... see a ruined shrine in forested valley.");
					CreateMoongate(1174, 1286, -30, Map.Ilshenar, false, false, false, true, true, true, true, true, true, true, true, false, 0, "Sacrifice", "... see a shrine overlooking a lake town.");
					CreateMoongate(1532, 1340, 0, Map.Ilshenar, false, false, false, true, true, true, true, true, true, true, true, false, 0, "Spirituality", "... see a shrine at the edge of a mysterious forest.");
					CreateMoongate(528, 216, -44, Map.Ilshenar, false, false, false, true, true, true, true, true, true, true, true, false, 0, "Valor", "... see a stone shrine in a deep forest.");
					
					CreateMoongate(1015, 527, -65, Map.Malas, false, false, false, true, true, true, true, true, true, true, true, false, 0, "Luna", "... see a couragous city of sandstone.");
					CreateMoongate(1998, 1387, -85, Map.Malas, false, false, false, true, true, true, true, true, true, true, true, false, 0, "Umbra", "... see a disorganized city of darkness and death.");
					
					CreateMoongate(802, 1204, 25, Map.Tokuno, false, false, false, true, true, true, true, true, true, true, true, false, 0, "Zento Makoto-Jima", "... see a peaceful city by the sea.");
					CreateMoongate(1169, 998, 41, Map.Tokuno, false, false, false, true, true, true, true, true, true, true, true, false, 0, "Isamu-Jima", "... see a volcano through the jungle.");
					CreateMoongate(270, 628, 15, Map.Tokuno, false, false, false, true, true, true, true, true, true, true, true, false, 0, "Homare-Jima", "... see a wooded island with a busy town.");
					
					CreateMoongate(851, 3525, -38, Map.TerMur, false, false, false, true, true, true, true, true, true, true, true, false, 0, "Royal City", "... see a vast city with a tall castle.");
					CreateMoongate(926, 3989, -36, Map.TerMur, false, false, false, true, true, true, true, true, true, true, true, false, 0, "Holy City", "... see a city with snow capped mountains.");
					
					
					
					PlayerMobile m = (PlayerMobile) from;
					Item mgd = m.Backpack.FindItemByType( typeof( MoongateDecorator ), true );
					if ( mgd != null && !mgd.Deleted )
					{
						mgd.Delete();
					}
				}
				else
					from.SendMessage("Moongate Controller already has moongates...abort");
			}
		}
		
		public virtual void CreateMoongate( int xLoc, int yLoc, int zLoc, Map map, bool OutOnly, bool IsCriminal, bool IsMurderer, bool FeluccaKey, bool TrammelKey, bool IlshenarKey, bool MalasKey, bool TokunoKey, bool TerMurKey, bool UnderworldKey, bool IsActive, bool UseGump, int GateItemID, string NewbieName, string Description )
		{
			CPMG = new ClassicPublicMoongate();
			CPMG.MGC = g_MGC;
			g_MGC.Moongates.Add(CPMG);
			CPMG.X = xLoc;
			CPMG.Y = yLoc;
			CPMG.Z = zLoc;
			CPMG.Map = map;
			CPMG.OutOnly = OutOnly;
			CPMG.IsCriminal=IsCriminal;
			CPMG.IsMurderer=IsMurderer;
			CPMG.FeluccaKey=FeluccaKey;
			CPMG.TrammelKey=TrammelKey;
			CPMG.IlshenarKey=IlshenarKey;
			CPMG.MalasKey=MalasKey;
			CPMG.TokunoKey=TokunoKey;
			CPMG.TerMurKey=TerMurKey;
			CPMG.UnderworldKey=UnderworldKey;
			CPMG.IsActive=IsActive;
			CPMG.UseGump=UseGump;
			CPMG.GateItemID=GateItemID;
			CPMG.NewbieName=NewbieName;
			CPMG.Description=Description;
			CPMG.Movable = false;
			CPMG.MoveToWorld(new Point3D( xLoc, yLoc, zLoc ), map);
		}
	}
}