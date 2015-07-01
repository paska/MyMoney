
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyMoney.Core.Data;

namespace MyMoney.AndroidApp
{
	[Activity (Label = "TransactionActivity")]			
	public class TransactionActivity : Activity
	{
		private int accountId;

		private EditText txtAmmount;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Transaction);

			accountId = Intent.GetIntExtra ("AccountId", 0);

			// todo: find out why every FindViewById returns null!!! :(

			txtAmmount = FindViewById<EditText> (Resource.Id.ammount);

			Button btnCancel = FindViewById<Button>(Resource.Id.btnCancel);
			btnCancel.Click += BtnCancel_Click;

			Button btnSave = FindViewById<Button>(Resource.Id.btnSave);
			btnSave.Click += BtnSave_Click;
		}

		void BtnCancel_Click (object sender, EventArgs e)
		{
			this.Finish();
		}

		void BtnSave_Click (object sender, EventArgs e)
		{
			decimal ammount = decimal.Parse (txtAmmount.Text);
			using (var accountManager = Account.Manager)
			using (var transactionManager = Transaction.Manager)
			{
				Transaction t = new Transaction {
					AccountId = accountId,
					Ammount = ammount
				};
				transactionManager.Insert (t);
				Account a = accountManager.Get (accountId);
				a.Balance += t.Ammount;
				accountManager.Update (a);
			}

			this.Finish();
		}
	}
}

