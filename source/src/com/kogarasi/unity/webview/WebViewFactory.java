package com.kogarasi.unity.webview;

import android.app.Activity;
import android.view.View;
import android.webkit.WebChromeClient;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.webkit.WebSettings.PluginState;


public class WebViewFactory {

	public static WebView Create( Activity actvitiy, final String gameObject )
	{
		
		// Create WebView Instance
		WebView webview = new WebView( actvitiy );
		
		// Set WebView Optimize;
		webview.setVisibility( View.GONE );
		webview.setFocusable( true );
		webview.setFocusableInTouchMode( true );
		
		webview.setWebChromeClient(new WebChromeClient());
		
		// set Custom WebView Client
		UnityWebViewClient client = new UnityWebViewClient();
		client.setGameObject( gameObject );
		webview.setWebViewClient( client );
		
		/*
		webview.addJavascriptInterface(
			new WebViewPluginInterface(gameObject), "Unity");
		*/

		// Init WebSettings
		WebSettings webSettings = webview.getSettings();
		webSettings.setSupportZoom(false);
		webSettings.setJavaScriptEnabled(true);
		webSettings.setPluginState( PluginState.ON );
		

		return webview;
		
	}
}
