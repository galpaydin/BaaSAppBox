using System;
using BAASBox.CRUD.UI.Pages;
using BAASBox.CRUD.UI;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace BAASBox.SampleApp
{
	public class SamplePersonalStartPage : AbstractPersonalContentPage<PersonalPreferences>
	{
		private ImageButton signOutButton;

		public SamplePersonalStartPage () : base(App.Instance, App.Instance)
		{
			signOutButton = UIHelper.CreateButton (
				"Sign out", 
				UIHelper.ButtonStyle.Warning,
				LayoutAlignment.Center,
				false);

			signOutButton.Clicked += (sender, e) => {
				SignOutNow();
			};

			Content = new StackLayout () {
				Orientation = StackOrientation.Vertical,
				Children = {
					new Label() { 
						Text = "You are signed in." },
						signOutButton
				}
			};

			menuItems.Add ("Do nothing");
			menuItems.Add ("Sign out");
			OnMenuSelection += DoMenu;
		}

		private void DoMenu(string choice)
		{
			if (choice == "Sign out") {
				SignOutNow ();
			}
		}

		private void SignOutNow()
		{
			ap.AuthState.Clear ();		
		}
			
		#region implemented abstract members of AbstractPersonalContentPage

		protected override void PrefsChanged ()
		{
			UIHelper.InformUser (this,
				"Your user preferences have changed. " +
				"This page would update now if it displayed data that depends on it.");
		}

		#endregion
	}
}

