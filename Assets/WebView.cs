using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebView : MonoBehaviour
{
    WebViewObject webViewObject;

    void Start()
    {
        webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
        webViewObject.Init(
            ld: (msg) => Debug.Log(string.Format("CallOnLoaded[{0}]", msg)),
            enableWKWebView: true);

#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
        webViewObject.bitmapRefreshCycle = 1;
#endif
        // ���D����Margin�ɂ��Ă�������
        webViewObject.SetMargins(100, 100, 100, 100);
        webViewObject.SetVisibility(true);
        // ���D����URL�ɂ��Ă�������
        webViewObject.LoadURL("https://www.google.co.jp");
    }

    void OnGUI()
    {
        GUI.enabled = webViewObject.CanGoBack();
        if (GUI.Button(new Rect(10, 10, 80, 80), "<"))
        {
            // �u���E�U�F�O�̃y�[�W��
            webViewObject.GoBack();
        }
        GUI.enabled = true;

        GUI.enabled = webViewObject.CanGoForward();
        if (GUI.Button(new Rect(100, 10, 80, 80), ">"))
        {
            // �u���E�U�F���̃y�[�W��
            webViewObject.GoForward();
        }
        GUI.enabled = true;
    }
}
