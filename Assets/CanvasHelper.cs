using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Canvas))]
public class CanvasHelper : MonoBehaviour
{
    // Thank you to Adriaan de Jongh https://twitter.com/adriaandejongh
    // author of Hidden Folks
    // for the bulk of the script below
    public static UnityEvent onOrientationChange = new UnityEvent();
    public static UnityEvent onResolutionChange = new UnityEvent();
    public static bool isLandscape { get; private set; }

    private static List<CanvasHelper> helpers = new List<CanvasHelper>();

    private static bool screenChangeVarsInitialized = false;
    private static ScreenOrientation lastOrientation = ScreenOrientation.Portrait;
    private static Vector2 lastResolution = Vector2.zero;
    private static Rect lastSafeArea = Rect.zero;

    private Canvas canvas;
    private RectTransform rectTransform;
    private RectTransform safeAreaTransform;
    
    void Awake()
    {
        if (!helpers.Contains(this))
            helpers.Add(this);
        canvas = GetComponent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        // the canvas/panel you want to react to the SafeArea needs to be called "SafeArea",  
        // and be a child of the top canvas where this script is attached
        safeAreaTransform = transform.Find("SafeArea") as RectTransform;
        if (!screenChangeVarsInitialized)
        {
            lastOrientation = Screen.orientation;
            lastResolution.x = Screen.width;
            lastResolution.y = Screen.height;
            lastSafeArea = Screen.safeArea;
            screenChangeVarsInitialized = true;
        }
    }

    void Start()
    {
        ApplySafeArea();
    }

    void Update()
    {
        if (helpers[0] != this)
            return;
        if (Screen.orientation != lastOrientation)
            OrientationChanged();
        if (Screen.safeArea != lastSafeArea)
            SafeAreaChanged();
        if (Screen.width != lastResolution.x || Screen.height != lastResolution.y)
                ResolutionChanged();      
    }

    void ApplySafeArea()
    {       
        if (safeAreaTransform == null)
            return;

        var safeArea = Screen.safeArea;
        var anchorMin = safeArea.position;
        var anchorMax = safeArea.position + safeArea.size;
        anchorMin.x /= canvas.pixelRect.width;
        anchorMin.y /= canvas.pixelRect.height;
        anchorMax.x /= canvas.pixelRect.width;
        anchorMax.y /= canvas.pixelRect.height;
        safeAreaTransform.anchorMin = anchorMin;
        safeAreaTransform.anchorMax = anchorMax;

        //Debug.Log(
        //"Applied SafeArea:" +
        // "\n Screen.orientation: " + Screen.orientation +
        // "\n Screen.safeArea.position: " + Screen.safeArea.position.ToString() +
        // "\n Screen.safeArea.size: " + Screen.safeArea.size.ToString() +
        // "\n Screen.width / height: (" + Screen.width.ToString() + ", " + Screen.height.ToString() + ")" +
        // "\n canvas.pixelRect.size: " + canvas.pixelRect.size.ToString() +
        // "\n anchorMin: " + anchorMin.ToString() +
        // "\n anchorMax: " + anchorMax.ToString());
    }

    void OnDestroy()
    {
        if (helpers != null && helpers.Contains(this))
            helpers.Remove(this);
    }

    private static void OrientationChanged()
    {
        Debug.Log("Orientation changed from " + lastOrientation + " to " + Screen.orientation + " at " + Time.time);

        lastOrientation = Screen.orientation;
        lastResolution.x = Screen.width;
        lastResolution.y = Screen.height;

        isLandscape = lastOrientation == ScreenOrientation.LandscapeLeft || lastOrientation == ScreenOrientation.LandscapeRight || lastOrientation == ScreenOrientation.Landscape;
        onOrientationChange.Invoke();

    }

    private static void ResolutionChanged()
    {
        if (lastResolution.x == Screen.width && lastResolution.y == Screen.height)
            return;

        Debug.Log("Resolution changed from " + lastResolution + " to (" + Screen.width + ", " + Screen.height + ") at " + Time.time);

        lastResolution.x = Screen.width;
        lastResolution.y = Screen.height;

        isLandscape = Screen.width > Screen.height;
        onResolutionChange.Invoke();
    }

    private static void SafeAreaChanged()
    {
        if (lastSafeArea == Screen.safeArea)
            return;

        Debug.Log("Safe Area changed from " + lastSafeArea + " to " + Screen.safeArea.size + " at " + Time.time);

        lastSafeArea = Screen.safeArea;

        for (int i = 0; i < helpers.Count; i++)
        {
            helpers[i].ApplySafeArea();
        }
    }

    public static Vector2 GetCanvasSize()
    {
        return helpers[0].rectTransform.sizeDelta;
    }

    public static Vector2 GetSafeAreaSize()
    {
        for (int i = 0; i < helpers.Count; i++)
        {
            if (helpers[i].safeAreaTransform != null)
            {
                return helpers[i].safeAreaTransform.sizeDelta;
            }
        }

        return GetCanvasSize();
    }
}