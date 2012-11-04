using System;
using System.IO;
using System.Collections.Generic;

namespace VolatileReader.Evtx
{
	public class SubstitutionArray 
	{
		private SubstitutionArray (){}
		
		public SubstitutionArray (BinaryReader reader)
		{
			this.Length = 0;
			this.ElementCount = reader.ReadInt32();
			
			this.Length += 4;
			
			if (this.ElementCount != 0)
			{
				int[,] sizetype = new int[this.ElementCount, 2];
				
				for (int i = 0; i < this.ElementCount; i++)
				{
					int size = reader.ReadInt16();
					byte type = reader.ReadByte();
					reader.BaseStream.Position++; //unknown
					
					this.Length += 4;
					
					sizetype[i,0] = size;
					sizetype[i,1] = type;
				}
				
				this.Types = new List<IType>();
				
				for (int i = 0; i < this.ElementCount; i++)
					this.Types.Add(LogType.NewType(reader, sizetype[i,0], sizetype[i,1]));
			}
		}
		
		public int ElementCount { get; private set; }
		
		public List<IType> Types { get; private set; }
		
		public int Length { get; private set; }
	}
}
