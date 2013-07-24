using UnityEngine;

namespace Kogarasi.WebView
{
	public interface IWebView
	{

		void Init( string name );
		void Term();

		void SetMargins( int left, int top, int right, int bottom );
		void SetVisibility( bool state );

		void LoadURL( string url );

		void EvaluateJS( string js );

		void OnUpdate( GameObject go );
	}

	public interface IWebViewCallback
	{
		void onLoadStart( string url );
		void onLoadFinish( string url );
		void onLoadFail( string url );
	}
}