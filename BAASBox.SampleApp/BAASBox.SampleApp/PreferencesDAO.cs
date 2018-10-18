using System;
using BAASBox.CRUD.UI.DAO;

namespace BAASBox.SampleApp
{
	public class PreferencesDAO : AbstractPreferencesDAO<PersonalPreferences>
	{
		public PreferencesDAO() : base(App.Instance.BAASBoxConfig, "preferences")
		{
		}
	}
}

