
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
	public class ChuteAddon : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {2147, -1, 1, 0}, {2148, -2, 1, 0}, {2148, -2, 0, 0}// 1	2	3	
			, {2148, 3, 1, 0}, {2149, -2, -1, 0}, {1803, 2, 2, 0}// 4	5	6	
			, {2147, 0, 1, 0}, {2149, 3, -1, 0}, {2147, 2, -1, 0}// 7	8	9	
			, {2147, 0, -1, 0}, {1801, 1, 2, 0}, {2147, -1, -1, 0}// 10	11	12	
			, {2148, 3, 0, 0}, {2147, 1, -1, 0}, {2147, 3, 1, 0}// 13	14	15	
			, {2147, 3, -1, 0}, {2147, 2, 1, 0}// 16	17	
		};

 
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new ChuteAddonDeed();
			}
		}

		[ Constructable ]
		public ChuteAddon()
		{

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );


		}

		public ChuteAddon( Serial serial ) : base( serial )
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

	public class ChuteAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new ChuteAddon();
			}
		}

		[Constructable]
		public ChuteAddonDeed()
		{
			Name = "Chute";
		}

		public ChuteAddonDeed( Serial serial ) : base( serial )
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