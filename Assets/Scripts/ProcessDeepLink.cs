using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ProcessDeepLink : MonoBehaviour
{
    private void Start()
    {
        if (!String.IsNullOrEmpty(Application.absoluteURL))
        {
            Debug.Log("AbsoluteURL: " + Application.absoluteURL);
        }
        Application.deepLinkActivated += onDeepLinkActivated;
        Debug.Log("registering onDeepLinkActivated");
        var label = GetComponent<Text>();
        label.text = "init not deep";
    }


    private void onDeepLinkActivated(string url)
    {
        // in this case url = Application.absoluteURL        
        var label = GetComponent<Text>();
        label.text = url;
        Debug.Log($"Started with onDeepLinkActivated:{url}");

    }
}


