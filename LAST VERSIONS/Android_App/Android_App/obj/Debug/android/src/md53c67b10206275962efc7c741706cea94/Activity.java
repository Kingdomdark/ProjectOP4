package md53c67b10206275962efc7c741706cea94;


public class Activity
	extends md59e336b20c5f59a4196ec0611a339f132.AndroidGameActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Android_App.Activity, Project 4 App2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Activity.class, __md_methods);
	}


	public Activity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Activity.class)
			mono.android.TypeManager.Activate ("Android_App.Activity, Project 4 App2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
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
