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
