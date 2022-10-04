using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortcutHandler : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
        else if (Input.GetKeyDown(KeyCode.F11))
        {
            FullScreenMode currentScreenMode = Screen.fullScreenMode;

            //If it is on Windowed mode then it switches to Fullscreen mode.
            if ((currentScreenMode == FullScreenMode.Windowed) || (currentScreenMode == FullScreenMode.MaximizedWindow))
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            //If not, it is already in fullscreen and it must switch to
            //windowed mode
            else
                Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }
}
