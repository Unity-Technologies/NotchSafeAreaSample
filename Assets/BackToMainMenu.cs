using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.InputSystem.Keyboard.current.anyKey.wasPressedThisFrame)
        {   
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
            Debug.Log("Back to main menu!");
            //UnityEngine.InputSystem 
        }
        //if (  Input.anyKeyDown)
        //{
        //    UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");    
        //}

    }
}
