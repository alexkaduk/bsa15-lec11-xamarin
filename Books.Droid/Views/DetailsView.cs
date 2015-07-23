using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace Books.Droid.Views
{
    [Activity(Label = "View for DetailsViewModel")]
    public class DetailsView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.DetailsView);
        }
    }
}