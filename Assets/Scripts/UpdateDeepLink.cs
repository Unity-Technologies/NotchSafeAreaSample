using System;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UpdateDeepLink : MonoBehaviour
{
    private void Update()
    {
        //Get Deep link value from global deeplink manager
        var label = GetComponent<Text>();
        label.text = ProcessDeepLinkMngr.Instance.deeplinkURL;
    }
}


