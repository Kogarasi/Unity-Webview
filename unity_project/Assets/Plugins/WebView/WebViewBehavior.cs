#region zlib License
/*
 * Copyright (C) 2011 Keijiro Takahashi
 * Copyright (C) 2012 GREE, Inc.
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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using Kogarasi.WebView;

public class WebViewBehavior : MonoBehaviour
{

	IWebView			webView;
	IWebViewCallback	callback;

#region Method

	public void Awake()
	{

#if UNITY_ANDROID
		webView = new WebViewAndroid();
#elif UNITY_IPHONE
		webView = new WebViewIOS();
#else
		webView = new WebViewNull();
#endif

		webView.Init( name );

		callback = null;
	}

	public void OnDestroy()
	{
		webView.Term();
	}

	// 
	public void Update()
	{
		webView.OnUpdate( this.gameObject );
	}

	public void SetMargins( int left, int top, int right, int bottom )
	{
		webView.SetMargins( left, top, right, bottom );
	}
	public void SetVisibility( bool state )
	{
		webView.SetVisibility( state );
	}

	public void LoadURL( string url )
	{
		webView.LoadURL( url );
	}

	public void EvaluateJS( string js )
	{
		webView.EvaluateJS( js );
	}

	/*
	public void CallFromJS( string message )
	{
		Debug.Log( "CallFromJS : " + message );
	}
	*/

	public void setCallback( IWebViewCallback _callback )
	{
		callback = _callback;
	}

	public void onLoadStart( string url )
	{
		if( callback != null )
		{
			callback.onLoadStart( url );
		}
	}

	public void onLoadFinish( string url )
	{
		if( callback != null )
		{
			callback.onLoadFinish( url );
		}
	}

	public void onLoadFail( string url )
	{
		if( callback != null )
		{
			callback.onLoadFail( url );
		}
	}

#endregion

}
