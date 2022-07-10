using System;
using System.Collections.Generic;

public class Program
{
	private static readonly Random rand = new Random();
	private static readonly object syncLock = new object ();
	
	private static string GetRandomUserAgent()
	{
		string userAgent = "";
		var browserType = new string[]{"chrome", "firefox", };
		var UATemplate = new Dictionary<string, string>{{"chrome", "Mozilla/5.0 ({0}) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/{1} Safari/537.36"}, {"firefox", "Mozilla/5.0 ({0}; rv:{1}.0) Gecko/20100101 Firefox/{1}.0"}, };
		var OS = new string[]{"Windows NT 10.0; Win64; x64", "X11; Linux x86_64", "Macintosh; Intel Mac OS X 12_4"};
		string OSsystem = "";
		lock (syncLock)
		{ // synchronize
			OSsystem = OS[rand.Next(OS.Length)];
			int version = rand.Next(93, 104);
			int minor = 0;
			int patch = rand.Next(4950, 5162);
			int build = rand.Next(80, 212);
			string randomBroswer = browserType[rand.Next(browserType.Length)];
			string browserTemplate = UATemplate[randomBroswer];
			string finalVersion = version.ToString();
			if (randomBroswer == "chrome")
			{
				finalVersion = String.Format("{0}.{1}.{2}.{3}", version, minor, patch, build);
			}

			userAgent = String.Format(browserTemplate, OSsystem, finalVersion);
		}

		return userAgent;
	}

	public static void Main()
	{
		Console.WriteLine(GetRandomUserAgent());
		Console.WriteLine(GetRandomUserAgent());
		Console.WriteLine(GetRandomUserAgent());
	}
}
