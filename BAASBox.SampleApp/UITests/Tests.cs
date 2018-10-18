using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace BAASBox.SampleApp.UITests
{
	[TestFixture]
	public class Tests
	{
		AndroidApp app;

		[SetUp]
		public void BeforeEachTest ()
		{
			app = ConfigureApp.Android.StartApp ();
		}

		[Test]
		public void SignInPageDisplayed ()
		{
			AppResult[] results = app.WaitForElement (c => c.Marked (" Sign in to Sample App"));
			app.Screenshot ("Sign In screen.");

			Assert.IsTrue (results.Any ());
		}
	}
}

