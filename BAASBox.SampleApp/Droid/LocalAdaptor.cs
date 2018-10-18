using System;
using BAASBox.CRUD.UI;
using System.Net;
using System.Security.Cryptography;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services;
using Android.Media;
using Android.App;

namespace BAASBox.SampleApp.Droid
{
	public class LocalAdaptor : ILocalAdaptor
	{
		public event Action<AudioState> OnAudioStateChange;

		public bool AudioSupported {
			get {
				return true;
			}
		}

		protected MediaPlayer player;

		public int? GetRawResourceId(string resourceName)
		{
			return (int?)typeof(Resource.Raw).GetField(resourceName).GetValue(null);
		}

		private AudioState _audioState = AudioState.Stopped;
		public AudioState AudioState
		{
			get {
				return _audioState;
			}
			private set {
				AudioState previous = _audioState;
				_audioState = value;
				if (previous != _audioState && OnAudioStateChange != null) {
					OnAudioStateChange (value);
				}
			}
		}

		public void InitAndPlayAudio (string trackSource)
		{
			var resourceId = GetRawResourceId(trackSource);
			Console.WriteLine("Resource id for " + trackSource + " = " 
				+ (resourceId.HasValue ? resourceId.Value.ToString() : "(null)"));


			if (player != null) {
				if (player.IsPlaying) {
					player.Stop ();
				}
				player.Reset ();
				player.Release ();
				player = null;
			}

			if (resourceId.HasValue) {
				player = MediaPlayer.Create (Application.Context, resourceId.Value);

				// do not use player.Prepare () -- MediaPlayer.Create takes care of this

				player.Completion += (sender, e) => {
					player.Reset ();
					player.Release ();
					player = null;
					AudioState = AudioState.Stopped;
				};

				AudioState = AudioState.Playing;
				player.Start ();
			}
		}

		public void PauseAudio ()
		{
			player.Pause ();
			AudioState = AudioState.Paused;
		}

		public void ResumeAudio ()
		{
			player.Start ();
			AudioState = AudioState.Playing;
		}

		public void StopAudio ()
		{
			player.Stop ();
			player.Release ();
			player = null;
			AudioState = AudioState.Stopped;
		}

		public static AesCryptoServiceProvider aes;

		public void InitRequisites()
		{
			aes = new AesCryptoServiceProvider();

			var container = new SimpleContainer ();
			container.Register<IDevice> (t => AndroidDevice.CurrentDevice);
			container.Register<IDisplay> (t => t.Resolve<IDevice> ().Display);
			container.Register<INetwork>(t=> t.Resolve<IDevice>().Network);
			Resolver.SetResolver (container.GetResolver ());
		}

		public void AllowAnyCertificates()
		{
			ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) =>
			{
				return 
					cert != null;
			};
		}

		public void DisplayCertificateHashes()
		{
			ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) =>
			{
				if (cert != null) {
					var certStr = cert.GetCertHashString();
					System.Diagnostics.Debug.WriteLine(certStr);
				}
				return true;
			};
		}

		public void AllowOnlySpecificCertificate(string certHashString)
		{
			ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) =>
			{
				return
					cert != null &&
					cert.GetCertHashString().Equals(certHashString);
			};
		}

	}
}

