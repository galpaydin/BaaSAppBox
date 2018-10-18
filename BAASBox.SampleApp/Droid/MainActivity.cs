using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace BAASBox.SampleApp.Droid
{
	[Activity (Label = "BAASBox.SampleApp.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			AndroidEnvironment.UnhandledExceptionRaiser += HandleExceptions;

			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			App.Instance.Init (new LocalAdaptor ());
			LoadApplication (App.Instance);
		}

		public static void HandleExceptions (object sender, RaiseThrowableEventArgs e)
		{
			Console.WriteLine ("Exception caught:\n" + e.Exception);
			// e.Handled = true;
		}
	}
}

