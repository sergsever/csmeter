using System;
using System.Threading.Tasks;

namespace csmeter
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			int res = GetResult().Result;
			Console.WriteLine("Result -" + res + "ms");

		}

		static async Task<int> GetResult()
		{
			int res = await Task.Run(() => new Sampler().AsyncRun());
			return res;
		}
	}
}
