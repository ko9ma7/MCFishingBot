using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace MCFishingBot
{
	public partial class MCMacro
	{
		/// <summary>
		/// 이미지 크기 계산용
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct MyVector
		{
			public int X;
			public int Y;
			
			public MyVector(int x, int y)
			{
				X = x;
				Y = y;
			}

			public override bool Equals(object obj)
			{
				if(!(obj is MyVector)) 
					return false;
				return Equals((MyVector)obj);
			}

			public bool Equals(MyVector obj)
			{
				return X.Equals(obj.X) && Y.Equals(obj.Y);
			}

			public override int GetHashCode()
			{
				return X.GetHashCode() ^ (Y.GetHashCode() << 2);
			}

			public override string ToString()
			{
				return $"X값 : {X}, Y값 : {Y}";
			}

			public MyVector Zero => new MyVector();

			public static MyVector operator *(double percent, MyVector v)
			{
				return new MyVector((int)(v.X * percent), (int)(v.Y * percent));
			}

			public static MyVector operator *(MyVector v, double percent)
			{
				return new MyVector((int)(v.X * percent), (int)(v.Y * percent));
			}

			public static MyVector operator -(MyVector v1, MyVector v2)
			{
				return new MyVector(v1.X - v2.X , v1.Y - v2.Y);
			}

			public static MyVector operator +(MyVector v1, MyVector v2)
			{
				return new MyVector(v1.X + v2.X, v1.Y + v2.Y);
			}
		}
	}
}
