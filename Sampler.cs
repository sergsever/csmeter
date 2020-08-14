using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace csmeter
{
	public class Sampler
	{
		private HttpClient client;

		public Sampler()
		{
			client = new HttpClient();
		}
		public async Task<int> AsyncRun()
		{
			int res = 0;
			string url = Config.GetParam("url");
			int count = int.Parse(Config.GetParam("count"));
			Stopwatch timer = new Stopwatch();
			timer.Start();
			try
			{
				for (int i = 0; i < count; i++)
				{
					HttpResponseMessage resp = await client.GetAsync(url);
					if (resp.StatusCode != System.Net.HttpStatusCode.OK)
						throw new Exception("Error response");
				}
			}
			catch(Exception e)
			{
				Debug.WriteLine("Sampler error: " + e.Message);
			}

			timer.Stop();
			res = (int)timer.Elapsed.TotalMilliseconds;


			return res;
		}
	}
}
