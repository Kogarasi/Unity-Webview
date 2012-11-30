#region zlib License
/*
 * Copyright (C) 2012 Kogarasi
 * 
 * This software is provided 'as-is', without any express or implied
 * warranty.  In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would be
 *    appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be
 *    misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
 */
#endregion

using UnityEngine;
using System.Collections;

class WebViewCallbackTest : Kogarasi.WebView.IWebViewCallback
{
	public void onLoadStart( string url )
	{
		Debug.Log( "call onLoadStart : " + url );
	}
	public void onLoadFinish( string url )
	{
		Debug.Log( "call onLoadFinish : " + url );
	}
	public void onLoadFail( string url )
	{
		Debug.Log( "call onLoadFail : " + url );
	}
}

public class WebViewTest : MonoBehaviour
{

	WebViewCallbackTest m_callback;

	// Use this for initialization
	void Start () {

		m_callback = new WebViewCallbackTest();

		WebViewBehavior webview = GetComponent<WebViewBehavior>();
	
		if( webview != null )
		{
			webview.LoadURL( "http://www.google.co.jp" );
			webview.SetVisibility( true );
			webview.setCallback( m_callback );
		}
	}
	
}
