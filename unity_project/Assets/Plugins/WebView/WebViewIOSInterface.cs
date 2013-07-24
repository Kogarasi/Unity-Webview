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