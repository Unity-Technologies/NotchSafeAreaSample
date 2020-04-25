using System;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProcessDeepLinkMngr : MonoBehaviour
{
    public static ProcessDeepLinkMngr Instance { get; private set; }
    public string deeplinkURL;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
                    
            Application.deepLinkActivated += onDeepLinkActivated;

            if (!String.IsNullOrEmpty(Application.absoluteURL))
            {
                // cold start and Application.absoluteURL not null
                onDeepLinkActivated(Application.absoluteURL);
                Debug.Log("AbsoluteURL: " + Application.absoluteURL);
            }
            else deeplinkURL = "[none]";
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void onDeepLinkActivated(string url)
    {
        // in this case url = Application.absoluteURL  
        Debug.Log($"Started with onDeepLinkActivated:{url}");
        // update DeepLink Manager global variable, so URL can be accessed from anywhere 
        deeplinkURL = url;

        //hardcoding loading a scene to test DeepLink activation
        // In real implementation Check valitidy of URL before any processing 
        string sceneName = url.Split("?"[0])[1];
        Debug.Log($"Deep Link Scene:{sceneName}");
        bool validScene;
        switch (sceneName)
        {
            case "DisplayNotchSafeArea":
                validScene = true;
                break;
            case "SafeAreaControl":
                validScene = true;
                break;
            case "Menu":
                validScene = true;
                break;
            default:
                validScene = false;
                break;
        }
        if (validScene) SceneManager.LoadScene(sceneName);


    }
}


