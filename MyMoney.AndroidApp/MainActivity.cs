using System;
using System.Collections.Generic;

using MyMoney.Core.Data;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MyMoney.AndroidApp
{
	[Activity (Label = "MyMoney.AndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            using (AccountManager manager = new AccountManager ())
            {
                IList<Account> cuentas = manager.GetAll ();
                // Check ammout
                Account a = new Account ();
                a.Name = "Account 1";
                manager.Insert (a);
                // Check Id
                a = new Account ();
                a.Name = "account 2";
                manager.Insert (a);
                // Check Id
                a.Name = "Account 2";
                manager.Update (a);
                cuentas = manager.GetAll ();
                // Check ammout and values
                manager.Delete(a);
                cuentas = manager.GetAll ();
                // Check ammout
            }

			using (AccountManager manager = new AccountManager ())
            {
                IList<Account> cuentas = manager.GetAll ();
                // Check ammout
            }

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);
			};
		}
	}
}


