using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLogoSwitch : MonoBehaviour {

    public UnityEngine.UI.Image Unity_Editor;
    public UnityEngine.UI.Image Android;
    public UnityEngine.UI.Image iOS;
    private string CurrentOS="";
    
	void Start () {
        //CurrentOS = SystemInfo.operatingSystem;
        //SetPlatform(0);
    }

    // Update is called once per frame
    void Update () {
        //Check if something has changed
        if (CurrentOS != SystemInfo.operatingSystem) 
        {
            CurrentOS = SystemInfo.operatingSystem;
            if (CurrentOS.StartsWith("Android"))
            {
                SetPlatform(1);
            } else 
            if (CurrentOS.StartsWith("iOS"))
            {
                SetPlatform(2);
            } else 
            {
                SetPlatform(0);
            }
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
