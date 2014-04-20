using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace HelloWorld
{
	[Activity (Label = "HelloWorld", MainLauncher = true)]
	public class MainActivity : Activity
	{
		int count = 1;

		AlertDialog ActivityDialog;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create the Dialog object used to display messages
			AlertDialog.Builder builder = new AlertDialog.Builder(this);
			ActivityDialog = builder.Create ();
			ActivityDialog.SetTitle("HelloWorld");
			ActivityDialog.DismissEvent += (sender, e) => {
				FindViewById<TextView> (Resource.Id.textViewMessage).Text = "Alert dismissed at " + DateTime.Now.ToLongTimeString();
			};

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button buttonClicker = FindViewById<Button> (Resource.Id.myButton);
			
			buttonClicker.Click += delegate {
				buttonClicker.Text = string.Format ("{0} clicks!", count++);
			};

			FindViewById<Button> (Resource.Id.buttonPopupMessage).Click += buttonPopupMessage_Click;
		}

		private void buttonPopupMessage_Click(object sender, EventArgs e)
		{
			ActivityDialog.SetMessage ("Hello Android World");
			ActivityDialog.SetButton ("OK", (s, a) => {
				((Button)sender).Text = "Say hello again :3";
			});

			ActivityDialog.Show ();
		}
	}
}


