
////////////////////////////////////////
//                                    //
//   Generated by CEO's YAAAG - V1.2  //
// (Yet Another Arya Addon Generator) //
//                                    //
////////////////////////////////////////
using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class maginciaopeairmarketAddon : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {590, -16, -18, 2}, {590, -16, -17, 2}, {590, -16, -21, 2}// 1	2	3	
			, {590, -16, -20, 2}, {590, -16, -19, 2}, {590, -16, -15, 2}// 4	5	6	
			, {590, -16, -22, 2}, {590, -16, -16, 2}, {602, -16, -23, 2}// 7	8	9	
			, {602, -16, -7, 2}, {590, -16, -3, 2}, {590, -16, 1, 2}// 10	11	12	
			, {590, -16, -4, 2}, {590, -16, -2, 2}, {590, -16, -5, 2}// 13	14	15	
			, {590, -16, -1, 2}, {590, -16, 0, 2}, {590, -16, -6, 2}// 16	17	18	
			, {603, -16, 17, 2}, {590, -16, 18, 2}, {590, -16, 22, 2}// 20	21	22	
			, {590, -16, 21, 2}, {590, -16, 23, 2}, {590, -16, 24, 2}// 23	24	25	
			, {590, -16, 19, 2}, {590, -16, 20, 2}, {589, -4, -23, 2}// 26	27	30	
			, {589, -9, -15, 2}, {589, -11, -15, 2}, {589, -6, -23, 2}// 31	33	34	
			, {589, -14, -15, 2}, {589, -3, -23, 2}, {589, 0, -23, 2}// 35	36	37	
			, {589, -15, -15, 2}, {589, -8, -15, 2}, {589, -13, -15, 2}// 38	39	42	
			, {589, -5, -23, 2}, {589, -7, -23, 2}, {589, -10, -15, 2}// 43	44	46	
			, {589, -1, -23, 2}, {589, -2, -23, 2}, {589, -8, -23, 2}// 47	48	52	
			, {589, -9, -23, 2}, {589, -12, -15, 2}, {2870, -4, -22, 2}// 53	54	55	
			, {2870, -14, -22, 2}, {589, -11, -23, 2}, {589, -10, -23, 2}// 56	57	58	
			, {589, -13, -23, 2}, {589, -12, -23, 2}, {589, -15, -23, 2}// 59	60	61	
			, {589, -14, -23, 2}, {370, -4, -15, 2}, {370, -3, -15, 2}// 62	68	69	
			, {370, -2, -15, 2}, {2493, -13, -3, 7}, {2494, -13, -4, 7}// 70	71	72	
			, {2494, -12, -4, 8}, {2516, -13, -2, 6}, {2516, -12, -2, 6}// 73	74	75	
			, {2517, -12, -3, 6}, {3220, -13, -10, 2}, {3220, -10, -11, 2}// 76	77	78	
			, {3221, -12, -10, 2}, {3222, -11, -11, 2}, {3231, -11, -10, 2}// 79	80	81	
			, {3232, -12, -11, 2}, {3233, -11, -9, 2}, {3236, -10, -9, 2}// 82	83	84	
			, {3236, -10, -12, 2}, {369, -8, -2, 2}, {589, -12, -7, 2}// 85	87	88	
			, {369, -8, -4, 2}, {589, -15, -7, 2}, {589, -11, -7, 2}// 89	91	92	
			, {589, -13, -7, 2}, {2879, -12, -2, 0}, {603, -8, 1, 2}// 95	99	100	
			, {2877, -12, -3, 0}, {370, -12, 1, 2}, {589, -10, -7, 2}// 101	102	103	
			, {589, -9, -7, 2}, {589, -8, -7, 2}, {2877, -13, -3, 0}// 104	105	106	
			, {589, -14, -7, 2}, {590, -8, -10, 2}, {590, -8, -8, 2}// 108	109	111	
			, {590, -8, -11, 2}, {590, -8, -13, 2}, {590, -8, -14, 2}// 112	113	114	
			, {2879, -13, -2, 0}, {2879, -12, -4, 0}, {590, -8, -12, 2}// 116	117	119	
			, {369, -8, -3, 2}, {590, -8, -7, 2}, {590, -8, -9, 2}// 120	121	122	
			, {2879, -13, -4, 0}, {370, -11, 1, 2}, {2493, -13, -3, 6}// 123	124	125	
			, {2494, -12, -4, 6}, {2494, -13, -4, 6}, {2914, -15, 6, 2}// 126	127	128	
			, {2915, -15, 4, 2}, {2916, -15, 5, 2}, {590, -8, 5, 2}// 129	130	131	
			, {589, -10, 17, 2}, {590, -8, 10, 2}, {590, -8, 2, 2}// 132	133	134	
			, {590, -8, 17, 2}, {590, -8, 3, 2}, {590, -8, 15, 2}// 135	136	137	
			, {589, -9, 17, 2}, {589, -15, 17, 2}, {590, -8, 11, 2}// 138	139	140	
			, {589, -8, 17, 2}, {590, -8, 16, 2}, {590, -8, 14, 2}// 141	142	143	
			, {590, -8, 4, 2}, {590, -8, 9, 2}, {589, -11, 17, 2}// 144	145	146	
			, {590, -8, 8, 2}, {590, -8, 12, 2}, {590, -8, 13, 2}// 147	148	149	
			, {590, -8, 6, 2}, {590, -8, 7, 2}, {589, -14, 17, 2}// 150	151	152	
			, {589, -13, 17, 2}, {589, -12, 17, 2}, {3817, -5, 2, 6}// 153	154	155	
			, {3817, -3, 2, 6}, {3817, -6, 2, 6}, {3817, -4, 2, 6}// 156	157	158	
			, {3817, -2, 2, 6}, {3616, -12, 18, 6}, {3619, -11, 18, 6}// 159	160	161	
			, {3817, -9, 18, 6}, {3817, -8, 18, 6}, {3817, -12, 18, 6}// 162	163	164	
			, {4030, -10, 18, 6}, {4032, -10, 18, 6}, {2880, -8, 18, 0}// 165	166	176	
			, {2878, -10, 18, 0}, {2878, -9, 18, 0}, {2880, -12, 18, 0}// 177	178	179	
			, {2878, -11, 18, 0}, {589, 8, -23, 2}, {589, 1, -23, 2}// 181	189	192	
			, {589, 4, -23, 2}, {589, 5, -23, 2}, {589, 7, -23, 2}// 202	203	204	
			, {589, 6, -23, 2}, {589, 3, -23, 2}, {589, 2, -23, 2}// 205	206	207	
			, {699, 16, -26, 21}, {699, 16, -25, 21}, {699, 16, -24, 21}// 217	218	219	
			, {699, 16, -23, 21}, {699, 15, -24, 2}, {699, 16, -23, 2}// 220	221	222	
			, {3828, 1, 17, 6}, {3829, 1, 15, 6}, {3834, 1, 13, 6}// 240	241	242	
			, {3834, 1, 11, 6}, {3834, 1, 12, 6}, {3839, 1, 16, 7}// 243	244	245	
			, {3847, 1, 16, 6}, {7978, 15, 15, 2}, {369, 14, 13, 2}// 246	247	248	
			, {7978, 15, 12, 2}, {7979, 15, 15, 9}, {369, 14, 14, 2}// 249	252	260	
			, {353, 14, 9, 2}, {7979, 15, 12, 9}, {2877, 1, 16, 0}// 263	265	266	
			, {2877, 1, 12, 0}, {367, 14, 13, 2}, {2879, 1, 15, 0}// 267	268	269	
			, {2879, 1, 11, 0}, {2879, 1, 13, 0}, {2879, 1, 17, 0}// 270	271	272	
			, {366, 14, 14, 2}, {3834, 11, 5, 26}, {4029, 4, 4, 6}// 278	279	280	
			, {4031, 4, 3, 6}, {3827, 10, 18, 6}, {3830, 11, 18, 6}// 281	284	285	
			, {3831, 12, 18, 6}, {3832, 13, 18, 6}, {3833, 14, 18, 6}// 286	287	288	
			, {3837, 1, 21, 9}, {3841, 14, 18, 7}, {3842, 13, 18, 4}// 289	290	291	
			, {3844, 1, 20, 11}, {3847, 10, 18, 11}, {3850, 1, 20, 6}// 292	293	294	
			, {3851, 1, 19, 10}, {3851, 10, 18, 4}, {3852, 1, 19, 6}// 295	296	297	
			, {2878, 13, 18, 0}, {2878, 11, 18, 0}, {2878, 10, 18, 0}// 303	304	305	
			, {2880, 9, 18, 0}, {2878, 12, 18, 0}, {2877, 1, 20, 0}// 306	308	311	
			, {2879, 1, 21, 0}, {2879, 1, 19, 0}, {2880, 14, 18, 0}// 312	313	314	
			, {3837, 1, 21, 8}, {3841, 14, 18, 6}, {3847, 10, 18, 12}// 331	332	333	
			, {698, 17, -23, 21}// 337	
		};

 
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new maginciaopeairmarketAddonDeed();
			}
		}

		[ Constructable ]
		public maginciaopeairmarketAddon()
		{

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );


			AddComplexComponent( (BaseAddon) this, 2852, -16, 10, 4, 0, 1, "", 1);// 19
			AddComplexComponent( (BaseAddon) this, 2852, -16, 26, 4, 0, 1, "", 1);// 28
			AddComplexComponent( (BaseAddon) this, 596, 0, -22, 2, 0, 1, "", 1);// 29
			AddComplexComponent( (BaseAddon) this, 596, 0, -20, 2, 0, 1, "", 1);// 32
			AddComplexComponent( (BaseAddon) this, 596, 0, -16, 2, 0, 1, "", 1);// 40
			AddComplexComponent( (BaseAddon) this, 596, 0, -17, 2, 0, 1, "", 1);// 41
			AddComplexComponent( (BaseAddon) this, 596, 0, -19, 2, 0, 1, "", 1);// 45
			AddComplexComponent( (BaseAddon) this, 596, 0, -15, 2, 0, 1, "", 1);// 49
			AddComplexComponent( (BaseAddon) this, 596, 0, -18, 2, 0, 1, "", 1);// 50
			AddComplexComponent( (BaseAddon) this, 596, 0, -21, 2, 0, 1, "", 1);// 51
			AddComplexComponent( (BaseAddon) this, 595, 0, -15, 2, 0, 1, "", 1);// 63
			AddComplexComponent( (BaseAddon) this, 595, -5, -15, 2, 0, 1, "", 1);// 64
			AddComplexComponent( (BaseAddon) this, 595, -6, -15, 2, 0, 1, "", 1);// 65
			AddComplexComponent( (BaseAddon) this, 595, -1, -15, 2, 0, 1, "", 1);// 66
			AddComplexComponent( (BaseAddon) this, 595, -7, -15, 2, 0, 1, "", 1);// 67
			AddComplexComponent( (BaseAddon) this, 595, -10, 1, 2, 0, 1, "", 1);// 86
			AddComplexComponent( (BaseAddon) this, 596, -8, -1, 2, 0, 1, "", 1);// 90
			AddComplexComponent( (BaseAddon) this, 595, -12, -11, 22, 0, 1, "", 1);// 93
			AddComplexComponent( (BaseAddon) this, 596, -8, -6, 2, 0, 1, "", 1);// 94
			AddComplexComponent( (BaseAddon) this, 595, -15, 1, 2, 0, 1, "", 1);// 96
			AddComplexComponent( (BaseAddon) this, 596, -8, 0, 2, 0, 1, "", 1);// 97
			AddComplexComponent( (BaseAddon) this, 595, -9, 1, 2, 0, 1, "", 1);// 98
			AddComplexComponent( (BaseAddon) this, 595, -14, 1, 2, 0, 1, "", 1);// 107
			AddComplexComponent( (BaseAddon) this, 595, -13, 1, 2, 0, 1, "", 1);// 110
			AddComplexComponent( (BaseAddon) this, 596, -8, -5, 2, 0, 1, "", 1);// 115
			AddComplexComponent( (BaseAddon) this, 594, -8, 1, 2, 0, 1, "", 1);// 118
			AddComplexComponent( (BaseAddon) this, 595, -1, 24, 2, 0, 1, "", 1);// 167
			AddComplexComponent( (BaseAddon) this, 596, 0, 25, 2, 0, 1, "", 1);// 168
			AddComplexComponent( (BaseAddon) this, 595, -7, 24, 2, 0, 1, "", 1);// 169
			AddComplexComponent( (BaseAddon) this, 595, -15, 24, 2, 0, 1, "", 1);// 170
			AddComplexComponent( (BaseAddon) this, 595, -6, 24, 2, 0, 1, "", 1);// 171
			AddComplexComponent( (BaseAddon) this, 595, -3, 24, 2, 0, 1, "", 1);// 172
			AddComplexComponent( (BaseAddon) this, 595, -4, 24, 2, 0, 1, "", 1);// 173
			AddComplexComponent( (BaseAddon) this, 595, -9, 24, 2, 0, 1, "", 1);// 174
			AddComplexComponent( (BaseAddon) this, 595, -5, 24, 2, 0, 1, "", 1);// 175
			AddComplexComponent( (BaseAddon) this, 595, -2, 24, 2, 0, 1, "", 1);// 180
			AddComplexComponent( (BaseAddon) this, 595, 0, 24, 2, 0, 1, "", 1);// 182
			AddComplexComponent( (BaseAddon) this, 595, -8, 24, 2, 0, 1, "", 1);// 183
			AddComplexComponent( (BaseAddon) this, 595, -12, 24, 2, 0, 1, "", 1);// 184
			AddComplexComponent( (BaseAddon) this, 595, -11, 24, 2, 0, 1, "", 1);// 185
			AddComplexComponent( (BaseAddon) this, 595, -14, 24, 2, 0, 1, "", 1);// 186
			AddComplexComponent( (BaseAddon) this, 595, -13, 24, 2, 0, 1, "", 1);// 187
			AddComplexComponent( (BaseAddon) this, 595, -10, 24, 2, 0, 1, "", 1);// 188
			AddComplexComponent( (BaseAddon) this, 595, 10, -15, 2, 0, 1, "", 1);// 190
			AddComplexComponent( (BaseAddon) this, 596, 8, -21, 2, 0, 1, "", 1);// 191
			AddComplexComponent( (BaseAddon) this, 596, 8, -22, 2, 0, 1, "", 1);// 193
			AddComplexComponent( (BaseAddon) this, 595, 9, -15, 2, 0, 1, "", 1);// 194
			AddComplexComponent( (BaseAddon) this, 595, 16, -15, 2, 0, 1, "", 1);// 195
			AddComplexComponent( (BaseAddon) this, 596, 8, -15, 2, 0, 1, "", 1);// 196
			AddComplexComponent( (BaseAddon) this, 596, 8, -19, 2, 0, 1, "", 1);// 197
			AddComplexComponent( (BaseAddon) this, 596, 8, -17, 2, 0, 1, "", 1);// 198
			AddComplexComponent( (BaseAddon) this, 596, 8, -18, 2, 0, 1, "", 1);// 199
			AddComplexComponent( (BaseAddon) this, 596, 8, -20, 2, 0, 1, "", 1);// 200
			AddComplexComponent( (BaseAddon) this, 596, 8, -16, 2, 0, 1, "", 1);// 201
			AddComplexComponent( (BaseAddon) this, 595, 12, -15, 2, 0, 1, "", 1);// 208
			AddComplexComponent( (BaseAddon) this, 595, 14, -15, 2, 0, 1, "", 1);// 209
			AddComplexComponent( (BaseAddon) this, 595, 13, -15, 2, 0, 1, "", 1);// 210
			AddComplexComponent( (BaseAddon) this, 595, 15, -15, 2, 0, 1, "", 1);// 211
			AddComplexComponent( (BaseAddon) this, 595, 11, -15, 2, 0, 1, "", 1);// 212
			AddComplexComponent( (BaseAddon) this, 662, 16, -24, 2, 0, 0, "", 1);// 213
			AddComplexComponent( (BaseAddon) this, 662, 16, -23, 2, 0, 0, "", 1);// 214
			AddComplexComponent( (BaseAddon) this, 662, 16, -26, 2, 0, 0, "", 1);// 215
			AddComplexComponent( (BaseAddon) this, 662, 16, -25, 2, 0, 0, "", 1);// 216
			AddComplexComponent( (BaseAddon) this, 596, 16, -11, 2, 0, 0, "", 1);// 223
			AddComplexComponent( (BaseAddon) this, 596, 16, 1, 2, 0, 0, "", 1);// 224
			AddComplexComponent( (BaseAddon) this, 596, 16, 0, 2, 0, 0, "", 1);// 225
			AddComplexComponent( (BaseAddon) this, 596, 16, -7, 2, 0, 0, "", 1);// 226
			AddComplexComponent( (BaseAddon) this, 596, 16, -10, 2, 0, 0, "", 1);// 227
			AddComplexComponent( (BaseAddon) this, 596, 16, -1, 2, 0, 0, "", 1);// 228
			AddComplexComponent( (BaseAddon) this, 596, 16, -14, 2, 0, 0, "", 1);// 229
			AddComplexComponent( (BaseAddon) this, 596, 16, -13, 2, 0, 0, "", 1);// 230
			AddComplexComponent( (BaseAddon) this, 596, 16, -2, 2, 0, 0, "", 1);// 231
			AddComplexComponent( (BaseAddon) this, 596, 16, -9, 2, 0, 0, "", 1);// 232
			AddComplexComponent( (BaseAddon) this, 596, 16, -12, 2, 0, 0, "", 1);// 233
			AddComplexComponent( (BaseAddon) this, 596, 16, -5, 2, 0, 0, "", 1);// 234
			AddComplexComponent( (BaseAddon) this, 596, 16, -4, 2, 0, 0, "", 1);// 235
			AddComplexComponent( (BaseAddon) this, 596, 16, -3, 2, 0, 0, "", 1);// 236
			AddComplexComponent( (BaseAddon) this, 596, 16, -6, 2, 0, 0, "", 1);// 237
			AddComplexComponent( (BaseAddon) this, 596, 16, -8, 2, 0, 0, "", 1);// 238
			AddComplexComponent( (BaseAddon) this, 595, 15, 9, 2, 0, 1, "", 1);// 239
			AddComplexComponent( (BaseAddon) this, 596, 16, 7, 2, 0, 0, "", 1);// 250
			AddComplexComponent( (BaseAddon) this, 596, 16, 6, 2, 0, 0, "", 1);// 251
			AddComplexComponent( (BaseAddon) this, 596, 16, 4, 2, 0, 0, "", 1);// 253
			AddComplexComponent( (BaseAddon) this, 596, 16, 3, 2, 0, 0, "", 1);// 254
			AddComplexComponent( (BaseAddon) this, 596, 16, 5, 2, 0, 0, "", 1);// 255
			AddComplexComponent( (BaseAddon) this, 596, 16, 2, 2, 0, 0, "", 1);// 256
			AddComplexComponent( (BaseAddon) this, 596, 14, 15, 2, 0, 0, "", 1);// 257
			AddComplexComponent( (BaseAddon) this, 596, 14, 16, 2, 0, 0, "", 1);// 258
			AddComplexComponent( (BaseAddon) this, 596, 16, 9, 2, 0, 0, "", 1);// 259
			AddComplexComponent( (BaseAddon) this, 596, 14, 17, 2, 0, 0, "", 1);// 261
			AddComplexComponent( (BaseAddon) this, 596, 16, 8, 2, 0, 1, "", 1);// 262
			AddComplexComponent( (BaseAddon) this, 596, 14, 10, 2, 0, 1, "", 1);// 264
			AddComplexComponent( (BaseAddon) this, 595, 16, 9, 2, 0, 0, "", 1);// 273
			AddComplexComponent( (BaseAddon) this, 596, 14, 11, 2, 0, 0, "", 1);// 274
			AddComplexComponent( (BaseAddon) this, 596, 14, 12, 2, 0, 0, "", 1);// 275
			AddComplexComponent( (BaseAddon) this, 595, 15, 17, 2, 0, 1, "", 1);// 276
			AddComplexComponent( (BaseAddon) this, 595, 16, 17, 2, 0, 1, "", 1);// 277
			AddComplexComponent( (BaseAddon) this, 3631, 1, 21, 6, 0, 2, "", 1);// 282
			AddComplexComponent( (BaseAddon) this, 3631, 9, 18, 8, 0, 2, "", 1);// 283
			AddComplexComponent( (BaseAddon) this, 595, 3, 25, 2, 0, 1, "", 1);// 298
			AddComplexComponent( (BaseAddon) this, 595, 5, 25, 2, 0, 1, "", 1);// 299
			AddComplexComponent( (BaseAddon) this, 595, 4, 25, 2, 0, 1, "", 1);// 300
			AddComplexComponent( (BaseAddon) this, 595, 2, 25, 2, 0, 1, "", 1);// 301
			AddComplexComponent( (BaseAddon) this, 595, 1, 25, 2, 0, 1, "", 1);// 302
			AddComplexComponent( (BaseAddon) this, 595, 6, 25, 2, 0, 1, "", 1);// 307
			AddComplexComponent( (BaseAddon) this, 595, 8, 25, 2, 0, 1, "", 1);// 309
			AddComplexComponent( (BaseAddon) this, 595, 7, 25, 2, 0, 1, "", 1);// 310
			AddComplexComponent( (BaseAddon) this, 596, 16, 20, 2, 0, 0, "", 1);// 315
			AddComplexComponent( (BaseAddon) this, 596, 16, 21, 2, 0, 0, "", 1);// 316
			AddComplexComponent( (BaseAddon) this, 596, 16, 22, 2, 0, 0, "", 1);// 317
			AddComplexComponent( (BaseAddon) this, 596, 16, 23, 2, 0, 0, "", 1);// 318
			AddComplexComponent( (BaseAddon) this, 596, 16, 24, 2, 0, 0, "", 1);// 319
			AddComplexComponent( (BaseAddon) this, 596, 16, 25, 2, 0, 0, "", 1);// 320
			AddComplexComponent( (BaseAddon) this, 595, 9, 25, 2, 0, 0, "", 1);// 321
			AddComplexComponent( (BaseAddon) this, 595, 10, 25, 2, 0, 0, "", 1);// 322
			AddComplexComponent( (BaseAddon) this, 595, 11, 25, 2, 0, 0, "", 1);// 323
			AddComplexComponent( (BaseAddon) this, 595, 12, 25, 2, 0, 0, "", 1);// 324
			AddComplexComponent( (BaseAddon) this, 595, 13, 25, 2, 0, 0, "", 1);// 325
			AddComplexComponent( (BaseAddon) this, 595, 14, 25, 2, 0, 0, "", 1);// 326
			AddComplexComponent( (BaseAddon) this, 595, 15, 25, 2, 0, 0, "", 1);// 327
			AddComplexComponent( (BaseAddon) this, 595, 16, 25, 2, 0, 0, "", 1);// 328
			AddComplexComponent( (BaseAddon) this, 596, 16, 18, 2, 0, 1, "", 1);// 329
			AddComplexComponent( (BaseAddon) this, 596, 16, 19, 2, 0, 1, "", 1);// 330
			AddComplexComponent( (BaseAddon) this, 3631, 9, 18, 6, 0, 2, "", 1);// 334
			AddComplexComponent( (BaseAddon) this, 2852, 17, -15, 4, 0, 1, "", 1);// 335
			AddComplexComponent( (BaseAddon) this, 661, 17, -23, 2, 0, 1, "", 1);// 336
			AddComplexComponent( (BaseAddon) this, 2854, 17, -26, 4, 0, 1, "", 1);// 338
			AddComplexComponent( (BaseAddon) this, 2852, 17, 2, 4, 0, 1, "", 1);// 339
			AddComplexComponent( (BaseAddon) this, 2852, 17, 26, 4, 0, 1, "", 1);// 340

		}

		public maginciaopeairmarketAddon( Serial serial ) : base( serial )
		{
		}

        private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset, int hue, int lightsource)
        {
            AddComplexComponent(addon, item, xoffset, yoffset, zoffset, hue, lightsource, null, 1);
        }

        private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset, int hue, int lightsource, string name, int amount)
        {
            AddonComponent ac;
            ac = new AddonComponent(item);
            if (name != null && name.Length > 0)
                ac.Name = name;
            if (hue != 0)
                ac.Hue = hue;
            if (amount > 1)
            {
                ac.Stackable = true;
                ac.Amount = amount;
            }
            if (lightsource != -1)
                ac.Light = (LightType) lightsource;
            addon.AddComponent(ac, xoffset, yoffset, zoffset);
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

	public class maginciaopeairmarketAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new maginciaopeairmarketAddon();
			}
		}

		[Constructable]
		public maginciaopeairmarketAddonDeed()
		{
			Name = "maginciaopeairmarket";
		}

		public maginciaopeairmarketAddonDeed( Serial serial ) : base( serial )
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