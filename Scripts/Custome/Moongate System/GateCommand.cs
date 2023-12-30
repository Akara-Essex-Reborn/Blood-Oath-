using System;
using System.IO;
using Server;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Server.Accounting;
using Server.Mobiles;
using Server.Items;
using Server.Menus;
using Server.Menus.Questions;
using Server.Menus.ItemLists;
using Server.Network;
using Server.Spells;
using Server.Targeting;
using Server.Targets;
using Server.Gumps;
using Server.Commands.Generic;
using Server.Diagnostics;

using Server.Multis;


using Server.Misc;
using Server.Regions;


namespace Server.Commands
{
	public class GateCommand
	{
		public GateCommand()
		{
		}
		
		public static void Initialize()
		{
			CommandSystem.Register( "Gate", AccessLevel.Counselor, new CommandEventHandler( GateCommand_OnCommand ) );
		}
		
		[Usage( "Gate [name | (x y [z]) | (deg min (N | S) deg min (E | W))]" )]
		[Description( "With no arguments, this command does nothing. With one argument, (name), you are moved to that regions \"gate location.\"  Two or three arguments, (x y [z]), will move your character to that location. When six arguments are specified, (deg min (N | S) deg min (E | W)), your character will go to an approximate of those sextant coordinates." )]
		private static void GateCommand_OnCommand( CommandEventArgs e )
		{
			Mobile from = e.Mobile;

			if ( e.Length == 1 )
			{
				try
				{
					int ser = e.GetInt32( 0 );

					IEntity ent = World.FindEntity( ser );

					string name = e.GetString( 0 );
					Map map;
					Point3D loc;

					for ( int i = 0; i < Map.AllMaps.Count; ++i ) //goes to chosen MAP
					{
						map = Map.AllMaps[i];

						if ( map.MapIndex == 0x7F || map.MapIndex == 0xFF )
							continue;

						if ( Insensitive.Equals( name, map.Name ) )
						{
							//from.Map = map;
							loc = from.Location;
							from.SendLocalizedMessage( 501024 ); // You open a magical gate to another location
							Effects.PlaySound( from.Location, from.Map, 0x20E );
							InternalItem firstGate = new InternalItem( loc, map );
							firstGate.MoveToWorld( from.Location, from.Map );
							Effects.PlaySound( loc, map, 0x20E );
							InternalItem secondGate = new InternalItem( from.Location, from.Map );
							secondGate.MoveToWorld( loc, map );
					
							return;
						}
					}

					Dictionary<string, Region> list = from.Map.Regions;

					foreach( KeyValuePair<string, Region> kvp in list ) //goes to chosen REGION, same map?
					{
						Region r = kvp.Value;

						if ( Insensitive.Equals( r.Name, name ) )
						{
							//from.Location = new Point3D( r.GoLocation );
							loc = new Point3D( r.GoLocation );
							from.SendLocalizedMessage( 501024 ); // You open a magical gate to another location
							Effects.PlaySound( from.Location, from.Map, 0x20E );
							InternalItem firstGate = new InternalItem( loc, r.Map );
							firstGate.MoveToWorld( from.Location, from.Map );
							Effects.PlaySound( loc, r.Map, 0x20E );
							InternalItem secondGate = new InternalItem( from.Location, from.Map );
							secondGate.MoveToWorld( loc, r.Map );
					
							return;
						}
					}

					for( int i = 0; i < Map.AllMaps.Count; ++i ) //goes to 
					{
						Map m = Map.AllMaps[i];

						if( m.MapIndex == 0x7F || m.MapIndex == 0xFF || from.Map == m )
							continue;

						foreach( Region r in m.Regions.Values )
						{
							if( Insensitive.Equals( r.Name, name ) )
							{
								//from.MoveToWorld( r.GoLocation, m );
								from.SendLocalizedMessage( 501024 ); // You open a magical gate to another location
								Effects.PlaySound( from.Location, from.Map, 0x20E );
								InternalItem firstGate = new InternalItem( r.GoLocation, m );
								firstGate.MoveToWorld( from.Location, from.Map );
								Effects.PlaySound(  r.GoLocation, m , 0x20E );
								InternalItem secondGate = new InternalItem( from.Location, from.Map );
								secondGate.MoveToWorld( r.GoLocation, m );
								
								return;
							}
						}
					}

					if ( ser != 0 )
						from.SendMessage( "No object with that serial was found." );
					else
						from.SendMessage( "No region with that name was found." );

					return;
				}
				catch
				{
				}

				from.SendMessage( "Region name not found" );
			}
			else if ( e.Length == 2 || e.Length == 3 ) //goes to XYZ coordinate
			{
				Map map = from.Map;

				if ( map != null )
				{
					try
					{
						/*
						 * This to avoid being teleported to (0,0) if trying to teleport
						 * to a region with spaces in its name.
						 */
						int x = int.Parse( e.GetString( 0 ) );
						int y = int.Parse( e.GetString( 1 ) );
						int z = (e.Length == 3 ) ? int.Parse( e.GetString( 2 ) ) : map.GetAverageZ( x, y );

						//from.Location = new Point3D( x, y, z );
						Point3D loc = new Point3D(x, y, z);
						from.SendLocalizedMessage( 501024 ); // You open a magical gate to another location
						Effects.PlaySound( from.Location, map, 0x20E );
						InternalItem firstGate = new InternalItem( loc, map );
						firstGate.MoveToWorld( from.Location, map );
						Effects.PlaySound(  loc, map , 0x20E );
						InternalItem secondGate = new InternalItem( from.Location, map );
						secondGate.MoveToWorld( loc, map );
					}
					catch
					{
						from.SendMessage( "Region name not found." );
					}
				}
			}
			else if ( e.Length == 6 ) //goes to coordinate in Degrees
			{
				Map map = from.Map;

				if ( map != null )
				{
					Point3D p = Sextant.ReverseLookup( map, e.GetInt32( 3 ), e.GetInt32( 0 ), e.GetInt32( 4 ), e.GetInt32( 1 ), Insensitive.Equals( e.GetString( 5 ), "E" ), Insensitive.Equals( e.GetString( 2 ), "S" ) );

					if ( p != Point3D.Zero )
					{
						//from.Location = p;
						from.SendLocalizedMessage( 501024 ); // You open a magical gate to another location
						Effects.PlaySound( from.Location, map, 0x20E );
						InternalItem firstGate = new InternalItem( from.Location, map );
						firstGate.MoveToWorld( from.Location, map );
						Effects.PlaySound(  p, map , 0x20E );
						InternalItem secondGate = new InternalItem( p, map );
						secondGate.MoveToWorld( p, map );
					}
					else
						from.SendMessage( "Sextant reverse lookup failed." );
				}
			}
			else
			{
				from.SendMessage( "Format: Go [name | serial | (x y [z]) | (deg min (N | S) deg min (E | W)]" );
			}
		}
		
		private class InternalItem : Moongate
		{
			public InternalItem( Point3D target, Map map ) : base( target, map )
			{
				Map = map;

				InternalTimer t = new InternalTimer( this );
				t.Start();
			}

			public InternalItem( Serial serial ) : base( serial )
			{
			}

			public override void Serialize( GenericWriter writer )
			{
				base.Serialize( writer );
			}

			public override void Deserialize( GenericReader reader )
			{
				base.Deserialize( reader );

				Delete();
			}

			private class InternalTimer : Timer
			{
				private Item m_Item;

				public InternalTimer( Item item ) : base( TimeSpan.FromSeconds( 30.0 ) )
				{
					Priority = TimerPriority.OneSecond;
					m_Item = item;
				}

				protected override void OnTick()
				{
					m_Item.Delete();
				}
			}
		}
	}
}