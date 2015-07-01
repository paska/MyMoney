using System;
using System.Collections.Generic;

using MyMoney.Core.Data;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MyMoney.AndroidApp.Fw;

namespace MyMoney.AndroidApp
{
	[Activity (Label = "MyMoney.AndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		private ListView listView;
		
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			IList<Account> accounts;
			using (var manager = Account.Manager)
				accounts = manager.GetAll();
			listView = FindViewById<ListView>(Resource.Id.accountList);
			listView.Adapter = new ListAdapter<Account>(this, accounts, a => string.Format("{0}\r\n${1}", a.Name, a.Balance));
			listView.ItemClick += ListView_ItemClick;
		}

		void ListView_ItemClick (object sender, AdapterView.ItemClickEventArgs e)
		{
			Account account = ((ListAdapter<Account>)listView.Adapter).GetItem(e.Position);
			var intent = new Intent (this, typeof(TransactionActivity));
			intent.PutExtra ("AccountId", account.Id);
			StartActivity (intent);
		}
	}
}


