using System;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ProcessDeepLink : MonoBehaviour
{
    private void Start()
    {
        var label = GetComponent<Text>();
        
        Application.deepLinkActivated += onDeepLinkActivated;
        if (!String.IsNullOrEmpty(Application.absoluteURL))
        {
            // cold start and Application.absoluteURL not null
            onDeepLinkActivated(Application.absoluteURL);
            Debug.Log("AbsoluteURL: " + Application.absoluteURL);
            label.text = $"DeepFromAwake:{Application.absoluteURL}";
        }
        else
        {
            label.text = "init not deep";
        }       
    }

    private void onDeepLinkActivated(string url)
    {
        // in this case url = Application.absoluteURL  
        // In real implementation Check valitidy of URL before any processing 
        var label = GetComponent<Text>();
        label.text = $"DeepFromActivated:{url}";
        Debug.Log($"Started with onDeepLinkActivated:{url}");
        //hardcoding loading a scene to test DeepLink activation
        SceneManager.LoadScene("SafeAreaControl");
       

    }
}


