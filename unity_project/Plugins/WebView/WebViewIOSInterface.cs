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

#if UNITY_IPHONE

namespace Kogarasi.WebView
{
	public class WebViewIOS : IWebView
	{
		
		private IntPtr instance;
		
		#region Interface Method
		public void Init( string name )
		{
			instance = _WebViewPlugin_Init( name );
		}
		public void Term()
		{
			_WebViewPlugin_Destroy( instance );
		}

		public void SetMargins( int left, int top, int right, int bottom )
		{
			_WebViewPlugin_SetMargins( instance, left, top, right, bottom );
		}
		public void SetVisibility( bool state )
		{
			_WebViewPlugin_SetVisibility( instance, state );
		}

		public void LoadURL( string url )
		{
			_WebViewPlugin_LoadURL( instance, url );
		}

		public void EvaluateJS( string js )
		{
			//_WebViewPlugin_EvaluateJS( instance, js );
		}

		public void OnUpdate( GameObject go )
		{
			// no somthing
		}
		#endregion
		
		#region Native Access Method
		[DllImport("__Internal")]
		private static extern IntPtr _WebViewPlugin_Init(string gameObject);
		
		[DllImport("__Internal")]
		private static extern int _WebViewPlugin_Destroy(IntPtr instance);
		
		[DllImport("__Internal")]
		private static extern void _WebViewPlugin_SetMargins(
			IntPtr instance, int left, int top, int right, int bottom);
		
		[DllImport("__Internal")]
		private static extern void _WebViewPlugin_SetVisibility(
			IntPtr instance, bool visibility);
		
		[DllImport("__Internal")]
		private static extern void _WebViewPlugin_LoadURL(
			IntPtr instance, string url);
		
		[DllImport("__Internal")]
		private static extern void _WebViewPlugin_EvaluateJS(
			IntPtr instance, string url);
		
		#endregion
	}
}

#endif