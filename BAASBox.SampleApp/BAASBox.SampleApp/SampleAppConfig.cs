using System;
using BAASBox.Access.DAO;

namespace BAASBox.SampleApp
{
	public class SampleAppConfig : BAASBoxConfig
	{
		public SampleAppConfig ()
			: base("https://baasbox.example.com", 443, "1234567890")
		{
		}
	}
}

