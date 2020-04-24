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
        //var label = GetComponent<Text>();
        //label.text = "[No Deep]";
              
    }

    private void Update()

    {
        var label = GetComponent<Text>();
        label.text = ProcessDeepLinkMngr.Instance.deeplinkURL;
    }
}


