using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLogoSwitch : MonoBehaviour {

    public UnityEngine.UI.Image Unity_Editor;
    public UnityEngine.UI.Image Android;
    public UnityEngine.UI.Image iOS;
    private string CurrentOS="";
    
    // Update is called once per frame
    void Update () {
        //Check if OS has changed
        if (CurrentOS != SystemInfo.operatingSystem) 
        {
            CurrentOS = SystemInfo.operatingSystem;
            int platID = (CurrentOS.StartsWith("Android") == true) ?  1 : 
                         (CurrentOS.StartsWith("iOS") == true) ? 2 : 0;
            SetPlatform(platID);
        }
	}

    private void SetPlatform(int id)
    {
        switch (id)
        {
            case 0:
                Unity_Editor.enabled = true;
                Android.enabled = false;
                iOS.enabled = false;
                break;
            case 1:
                Unity_Editor.enabled = false;
                Android.enabled = true;
                iOS.enabled = false;
                break;
            case 2:
                Unity_Editor.enabled = false;
                Android.enabled = false;
                iOS.enabled = true;
                break;
            default:
                break;
        }
    }
}
