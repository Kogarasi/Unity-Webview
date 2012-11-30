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
using System.Collections;

#if UNITY_ANDROID

namespace Kogarasi.WebView
{
	public class WebViewAndroid : IWebView
	{

		AndroidJavaObject	webView			= null;
		string				inputString		= "";

		public void Init( string name )
		{
			webView = new AndroidJavaObject( "com.kogarasi.unity.webview.WebViewPlugin" );
			SafeCall( "Init", name );
		}
		
		public void Term()
		{
			SafeCall( "Destroy" );
		}

		public void SetMargins( int left, int top, int right, int bottom )
		{
			SafeCall( "SetMargins", left, top, right, bottom );
		}

		public void SetVisibility( bool state )
		{
			SafeCall( "SetVisibility", state );
		}

		public void LoadURL( string url )
		{
			SafeCall( "LoadURL", url );
		}

		public void EvaluateJS( string js )
		{
			SafeCall( "LoadURL", "javascript:" + js );
		}

		public void OnUpdate( GameObject go )
		{
			inputString += Input.inputString;

			if( inputString.Length > 0 )
			{
				int keyCode = (int)inputString[0];
				inputString = inputString.Substring(1);

				SafeCall( "DispatchKeyEvent", keyCode );
			}
		}
		
		private void SafeCall( string method, params object[] args )
		{
			if( webView != null )
			{
				webView.Call( method, args );
			}
			else
			{
				Debug.LogError( "webview is not created. you check is a call 'Init' method" );
			}
		}
		
	}
}

#endif