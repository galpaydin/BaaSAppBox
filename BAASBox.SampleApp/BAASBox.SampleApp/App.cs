using System;

using Xamarin.Forms;
using BAASBox.CRUD.UI;
using BAASBox.Access.Business;
using BAASBox.Access.AppState;
using BAASBox.Access.DAO;

namespace BAASBox.SampleApp
{
	public class App 
		: Application, IPreferencesProvider<PersonalPreferences>, IConfigProvider, IAuthProvider
	{
		private static App instance;
		public static App Instance
		{
			get {
				if (instance == null) {
					instance = new App ();
				}
				return instance;
			}
		}

		public App ()
		{
			Initialised = false;
		}

		public bool Initialised { get; private set; }

		public ILocalAdaptor adaptor { get; private set; }
		public IAudioAdaptor Audio { get; private set; }
		public AuthState AuthState { get; private set; }
		public BAASBoxConfig BAASBoxConfig { get; private set; }
		public AbstractNavigationPage Navigation { get; private set; }

		public event Action<PersonalPreferences> OnPreferencesReady;

		public AuthLogic AuthLogic { get; private set; }
		public FeedLogic FeedLogic { get; private set; }

		public void Init(ILocalAdaptor adaptor)
		{
			this.adaptor = adaptor;

			adaptor.AllowAnyCertificates ();
			adaptor.DisplayCertificateHashes ();

			Audio = (IAudioAdaptor)adaptor;

			AuthState = new AuthState ();
			BAASBoxConfig = new SampleAppConfig ();
			Navigation = new SampleAppNavigation ();

			MainPage = Navigation;

			AuthLogic = new AuthLogic (AuthState, BAASBoxConfig);
			FeedLogic = new FeedLogic (AuthState, BAASBoxConfig);

			Initialised = true;
		}

		private PersonalPreferences _userPreferences;
		public PersonalPreferences PersonalPreferences {
			get {
				return _userPreferences;
			}
			set {
				_userPreferences = value;
				if (OnPreferencesReady != null) {
					OnPreferencesReady (_userPreferences);
				}
			}
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
			InitialiseStyles();
		}

		protected override void OnSleep ()
		{
			AuthState.StoreTo (Properties);
		}

		protected override void OnResume ()
		{
			AuthState.RestoreFrom (Properties);
		}

		protected void InitialiseStyles()
		{
			Application.Current.Resources = new ResourceDictionary ();
			var listItemTextStyle = new Style (typeof(ListView)) {
				Setters = {
					new Setter { Property = ListView.HasUnevenRowsProperty, Value = true },
					new Setter { Property = ListView.HeightRequestProperty, Value = 64 }
				}
			};

			// no Key specified
			Application.Current.Resources.Add (listItemTextStyle);
		}
	}
}

