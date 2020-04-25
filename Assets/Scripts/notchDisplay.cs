using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Text;

public class notchDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        _staticRectTexture = new Texture2D(1, 1);
        _staticRectStyle = new GUIStyle();
        _staticRectStyle.fontSize = 42;
        _staticRectStyle.alignment = TextAnchor.MiddleCenter;
        
    }
    private static Texture2D _staticRectTexture;
    private static GUIStyle _staticRectStyle;

    // Update is called once per frame
    void OnGUI()
    {

        var res = Screen.currentResolution;
        var safeArea = Screen.safeArea;
        var cutouts = Screen.cutouts;
        // Screen.cutouts maps to Android native API. 
        // On iOS, no native API but Unity >> xCode project
        // contains notch definitions in the 'Unity.mm' file
        StringBuilder output = new StringBuilder();
        output.Append($"Resolution {res.width}x{res.height}\n");
        output.Append($"safeArea: {safeArea.x}:{safeArea.y} {safeArea.width}x{safeArea.height}\n") ;
        //Check for notch(es)
        if (cutouts.Length > 0)
        {
            foreach (var c in cutouts)
            {
                //if any draw Red and display coordinates
                GUIDrawRect(c, Color.red, "");
                output.Append($"cutout x:{c.x} y:{c.y} {c.width}x{c.height}\n");
            }              
        }
        else
        {
            output.Append("No cutouts detected\n");
        }
        //Add rest of System Info:
        output.Append($"OS: {SystemInfo.operatingSystem}, familly:{SystemInfo.operatingSystemFamily}\n");
        output.Append($"Device Model: {SystemInfo.deviceModel}\n");
        output.Append($"Processor: {SystemInfo.processorType}\n");
        output.Append($"Gyro?: {SystemInfo.supportsGyroscope}\n");
        output.Append($"System Language: {Application.systemLanguage.ToString()}\n");
        output.Append($"Culture: {System.Globalization.CultureInfo.CurrentCulture.Name}\n");
        //Draw Safe Area + System Info
        GUIDrawRect(safeArea, Color.green, output.ToString());

    }

    public static void GUIDrawRect(Rect position, Color color, string text)
    {
        position.y = Screen.height - position.y - position.height;
        _staticRectTexture.SetPixel(0, 0, color);
        _staticRectTexture.Apply();
        _staticRectStyle.normal.background = _staticRectTexture;
        GUI.Box(position, text, _staticRectStyle);
    }
}

// iOS notch definitions
// Unity.mm file
// void ReportSafeAreaChangeForView(UIView* view)
// {
//    CGRect safeArea = ComputeSafeArea(view);
//    UnityReportSafeAreaChange(safeArea.origin.x, safeArea.origin.y,
//        safeArea.size.width, safeArea.size.height);

//    switch (UnityDeviceGeneration())
//    {
//        case deviceiPhoneXR:
//            {
//                const float x = 184, y = 1726, w = 460, h = 66;
//                UnityReportDisplayCutouts(&x, &y, &w, &h, 1);
//                break;
//            }
//        case deviceiPhoneX:
//        case deviceiPhoneXS:
//            {
//                const float x = 250, y = 2346, w = 625, h = 90;
//                UnityReportDisplayCutouts(&x, &y, &w, &h, 1);
//                break;
//            }
//        case deviceiPhoneXSMax:
//            {
//                const float x = 308, y = 2598, w = 626, h = 90;
//                UnityReportDisplayCutouts(&x, &y, &w, &h, 1);
//                break;
//            }
//        default:
//            UnityReportDisplayCutouts(nullptr, nullptr, nullptr, nullptr, 0);
//    }
//}