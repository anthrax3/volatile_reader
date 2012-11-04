using System;
using System.IO;
using System.Collections.Generic;

namespace VolatileReader.Evtx
{
	public static class LogNode
	{
		public static INode NewNode (BinaryReader log)
		{	
			long pos = log.BaseStream.Position;
			byte op = log.ReadByte();	
			int flags = op >> 4;
			
			//This is important, you will come across bytes in the hex editor
			//that start a node with BA, BC, etc and this is what will "fix" them
			op = (byte)(op & 0x0f);
			
			Console.WriteLine("New " + op + " node at offset: " + pos);
			
			if (op == 0x0f)
				return new _x0F(log);
			else if (op == 0x0c)
				return new _x0C(log);
			else if (op == 0x01)
				return new _x01(log, flags);
			else if (op == 0x02)
				return new _x02(log);
			else if (op == 0x03)
				return new _x03(log);
			else if (op == 0x04)
				return new _x04(log);
			else if (op == 0x07)
				return new _x07(log);
			else if (op == 0x06)
				return new _x06(log);
			else if (op == 0x05)
				return new _x05(log);
			else if (op == 0x0b)
				return new _x0B(log);
			else if (op == 0x0d)
				return new _x0D(log);
			else if (op == 0x0e)
				return new _x0E(log);
			else if (op == 0x00)
				return new _x00(log);
			else
				throw new Exception(String.Format("Don't know op: 0x{0:x2} at position {1}", op, pos));
		}
	}
}
