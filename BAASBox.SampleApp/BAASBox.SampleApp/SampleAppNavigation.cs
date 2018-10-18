using System;
using BAASBox.CRUD.UI;

namespace BAASBox.SampleApp
{
	public class SampleAppNavigation : AbstractNavigationPage
	{
		public SampleAppNavigation () : base(App.Instance, new SampleSignInPage())
		{
		}

		#region implemented abstract members of AbstractNavigationPage

		protected override Xamarin.Forms.Page CreatePersonalPages ()
		{
			return new SamplePersonalStartPage ();
		}

		#endregion
	}
}

