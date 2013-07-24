using UnityEngine;
using System.Collections;

namespace Kogarasi
{
	namespace WebView
	{
		public class WebViewNull : IWebView
		{

			public void Init( string name ){}
			public void Term(){}
			public void SetMargins( int left, int top, int right, int bottom ){}
			public void SetVisibility( bool state ){}
			public void LoadURL( string url ){}
			public void EvaluateJS( string js ){}
		}
	}
}
