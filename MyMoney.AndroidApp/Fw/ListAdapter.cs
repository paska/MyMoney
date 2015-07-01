using System;
using Android.Widget;
using System.Collections.Generic;
using Android.Views;
using Android.App;

namespace MyMoney.AndroidApp.Fw
{
	public class ListAdapter<TObject> : ArrayAdapter<TObject>
	{
		private Func<TObject, string> getDescription;

		private IList<TObject> data;

		public ListAdapter (Activity context, IList<TObject> data, Func<TObject, string> getDescription)
			: base(context, Android.Resource.Layout.SimpleListItem1, data)
		{
			this.getDescription = getDescription;
			this.data = data;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView;
			if (view == null)
				view = ((Activity)base.Context).LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
			view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = getDescription(base.GetItem(position));
			return view;
		}

		public new TObject GetItem(int position)
		{
			return data [position];
		}
	}
}

