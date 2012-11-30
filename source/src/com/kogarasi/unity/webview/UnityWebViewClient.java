package com.kogarasi.unity.webview;

import com.unity3d.player.UnityPlayer;

import android.graphics.Bitmap;
import android.webkit.WebView;
import android.webkit.WebViewClient;

public class UnityWebViewClient extends WebViewClient
{

	private String mGameObject;
	
	public void setGameObject( String gameObject )
	{
		mGameObject = gameObject;
	}
	

	@Override
	public void onPageStarted( WebView view, String url, Bitmap favicon)
	{
		UnityPlayer.UnitySendMessage( mGameObject , "onLoadStart",url );
	}

	@Override
	public void onPageFinished( WebView view, String url )
	{
		UnityPlayer.UnitySendMessage( mGameObject, "onLoadFinish", url );
	}

	@Override
	public void onReceivedError( WebView view, int errorCode, String desc, String url )
	{
		UnityPlayer.UnitySendMessage( mGameObject, "onLoadFail", url );
	}
}
