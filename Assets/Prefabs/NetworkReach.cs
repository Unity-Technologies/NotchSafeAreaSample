using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkReach : MonoBehaviour
{
    public UnityEngine.UI.Image InternetOnIcon;
    public UnityEngine.UI.Image InternetOffIcon;
    public UnityEngine.UI.Image CellIcon;
    public UnityEngine.UI.Image WifiIcon;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the device cannot reach the internet
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            //"Not Reachable."
            InternetOffIcon.enabled = true;
            InternetOnIcon.enabled=false;

            CellIcon.enabled = false;
            WifiIcon.enabled = false;

        }
        //Check if the device can reach the internet via a carrier data network
        else if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
        {
            // "Reachable via carrier data network."
            InternetOffIcon.enabled = false;
            InternetOnIcon.enabled = true;
            CellIcon.enabled = true;
            WifiIcon.enabled = false;
        }
        //Check if the device can reach the internet via a LAN
        else if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            // "Reachable via Local Area Network.";
            InternetOffIcon.enabled = false;
            InternetOnIcon.enabled = true;
            CellIcon.enabled = false;
            WifiIcon.enabled = true;
        }

    }
}
