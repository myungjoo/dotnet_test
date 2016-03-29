using System;

namespace stress
{
	class exec
	{
		static int arithmetic_fib(int x)
		{
			int res;
			if (x <= 1)
				return 1;

			int[] data = new int[x];

			data[x-1] = arithmetic_fib(x - 1);
			data[x-2] = arithmetic_fib(x - 2);
			data[0] = data[x - 1] + data[x - 2];

			return data[0];
		}
		static ulong arithmetic_fac(int x)
		{
			ulong res = 1;
			if (x <= 1)
				return 1;
			res = arithmetic_fac(x - 1);
			return res * (ulong) x;
		}
		static void arithmetic(int i)
		{
			Console.WriteLine("Arithmetic Stress Test "+i+" Fib Result = "+arithmetic_fib(i));
			Console.WriteLine("Arithmetic Stress Test "+i+" Fac Result = "+arithmetic_fac(i));
		}

		static int[] bigdata(int x, bool first)
		{
			int i;
			int[] data = new int[x];

			for (i = 0; i < x; i++) data[i] = 0;
			if (x <= 1)
				data[0] = 1;
			else {
				int [] got = bigdata(x - 1, false);
				for (i = 0; i < x - 1; i++) {
					data[i + 1] += got[i];
					data[i] += got[i];
				}
			}

			if (first) {
				Console.Write("Big Array Test "+x);
				for (i = 0; i < x; i++)
					Console.Write(" "+ data[i]);
				Console.WriteLine("|");
			}
			return data;
		}
		static void Main(string[] args)
		{
			int i = 1;

			Console.WriteLine("Starting the stress test.");

			do {
				Console.WriteLine("Starting Instance #"+i);

				arithmetic (i);
				bigdata(i, true);

				Console.WriteLine("Finished Instance #"+i);
				i++;
			} while (true);
		}
	}
}





