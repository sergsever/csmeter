using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace csmeter
{
	public static class Config
	{
		private static IConfigurationRoot configuration;
		static Config()
		{
			configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();


		}
		public static string GetParam(string name)
		{
			return configuration.GetSection(name).Value;
		}
	}
}
