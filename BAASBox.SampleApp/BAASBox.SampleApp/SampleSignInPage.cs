using System;
using BAASBox.CRUD.UI.Pages;
using System.Collections.Generic;
using BAASBox.CRUD.UI;

namespace BAASBox.SampleApp
{
	public class SampleSignInPage : AbstractSignInPage<PreferencesDAO, PersonalPreferences>
	{
		public SampleSignInPage () 
			: base(" Sign in to Sample App", App.Instance, App.Instance, App.Instance)
		{
		}

		#region implemented abstract members of AbstractSignInPage

		protected override void MenuButtonSelection_Chosen (string selection)
		{
			UIHelper.InformUser (this, "You chose: " + selection);
		}

		protected override PreferencesDAO CreatePrefsDAO ()
		{
			return new PreferencesDAO ();
		}

		protected override System.Collections.Generic.IEnumerable<string> MenuItems {
			get {
				return new List<string> () {
					"Option 1",
					"Option 2",
					"Option 3"

				};
			}
		}

		#endregion
	}
}

