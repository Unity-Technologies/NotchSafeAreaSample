using System;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProcessDeepLinkMngr : MonoBehaviour
{
    public static ProcessDeepLinkMngr Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            Application.deepLinkActivated += onDeepLinkActivated;

            if (!String.IsNullOrEmpty(Application.absoluteURL))
            {
                // cold start and Application.absoluteURL not null
                onDeepLinkActivated(Application.absoluteURL);
                Debug.Log("AbsoluteURL: " + Application.absoluteURL);
             }
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void onDeepLinkActivated(string url)
    {
        // in this case url = Application.absoluteURL  
        // In real implementation Check valitidy of URL before any processing 
        Debug.Log($"Started with onDeepLinkActivated:{url}");
        //hardcoding loading a scene to test DeepLink activation
        SceneManager.LoadScene("SafeAreaControl");


    }
}


