
////////////////////////////////////////
//                                     //
//   Generated by CEO's YAAAG - Ver 2  //
// (Yet Another Arya Addon Generator)  //
//    Modified by Hammerhand for       //
//      SA & High Seas content         //
//                                     //
////////////////////////////////////////
using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class bathhousetubladderbothsidesAddon : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {5461, 2, 0, 0}, {5457, 0, 2, 0}, {5343, 0, -2, 0}// 1	2	3	
			, {5342, -2, 0, 0}, {5335, 1, 1, 0}, {5460, 0, -1, 0}// 4	5	6	
			, {5458, -1, 0, 0}, {5464, -1, -1, 0}, {5465, 0, 0, 0}// 7	8	9	
					};

 
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new bathhousetubladderbothsidesAddonDeed();
			}
		}

		[ Constructable ]
		public bathhousetubladderbothsidesAddon()
		{

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );


		}

		public bathhousetubladderbothsidesAddon( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class bathhousetubladderbothsidesAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new bathhousetubladderbothsidesAddon();
			}
		}

		[Constructable]
		public bathhousetubladderbothsidesAddonDeed()
		{
			Name = "bathhousetubladderbothsides";
		}

		public bathhousetubladderbothsidesAddonDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void	Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}