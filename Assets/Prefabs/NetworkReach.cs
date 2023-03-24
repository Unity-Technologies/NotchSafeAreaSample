using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Device Simulator provides simulated classes, which you can use to test code that responds to device-specific behaviors in the Device Simulator.
// These simulated classes have the same members as their regular UnityEngine namespace counterparts. 
// You can use them anywhere in your codebase where you would normally use the regular classes. There is no performance impact, and you can use them in release builds.
// to convert existing code to use classes from the UnityEngine.Device namespace, it’s best practice to use alias directives
using Application = UnityEngine.Device.Application;


public class NetworkReach : MonoBehaviour
{
    public UnityEngine.UI.Image InternetOnIcon;
    public UnityEngine.UI.Image InternetOffIcon;
    public UnityEngine.UI.Image CellIcon;
    public UnityEngine.UI.Image WifiIcon;

    // Update is called once per frame
    void Update()
    {
        //Check if the device can reach the internet
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            //Not Reachable. 
            InternetOffIcon.enabled = true;
            InternetOnIcon.enabled=false;

            CellIcon.enabled = false;
            WifiIcon.enabled = false;

        }
        //Check if the device can reach the internet via a carrier data network
        else if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
        {
            // Reachable via carrier data network.
            InternetOffIcon.enabled = false;
            InternetOnIcon.enabled = true;
            CellIcon.enabled = true;
            WifiIcon.enabled = false;
        }
        //Check if the device can reach the internet via a LAN
        else if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            // Reachable via Local Area Network.;
            InternetOffIcon.enabled = false;
            InternetOnIcon.enabled = true;
            CellIcon.enabled = false;
            WifiIcon.enabled = true;
        }

    }
}
