package md58bf177768e08d5c776c0cfac4de9c37b;


public class DetailsView
	extends md57b8dd31b26d57b878589ceca204f3b49.MvxActivity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Books.Droid.Views.DetailsView, Books.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DetailsView.class, __md_methods);
	}


	public DetailsView () throws java.lang.Throwable
	{
		super ();
		if (getClass () == DetailsView.class)
			mono.android.TypeManager.Activate ("Books.Droid.Views.DetailsView, Books.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
