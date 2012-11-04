using System;
using System.IO;

namespace VolatileReader.Evtx
{
	public class _x0D : INode
	{
		private _x0D (){}
		
		public _x0D (BinaryReader log)
		{
			log.BaseStream.Position -= 1;
			this.Header = log.ReadByte();
			
			short index = log.ReadInt16();
			byte type = log.ReadByte();
			
			Console.WriteLine(type);
		}
		
		#region INode implementation
		public int Length {
			get {
				return 4;
			}
		}

		public int EndOfStream { get; set; }
		
		public byte Header {get; private set;}
		#endregion
	}
}
