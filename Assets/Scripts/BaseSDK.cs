using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSDK : MonoBehaviour {

    private static AndroidJavaObject _activeContext;

    private static AndroidJavaObject  _pluginClass;

    private static AndroidJavaClass _activeClass;

    private static float[] coordinats = new float[3];

    private static Boolean isclicked; 

    private static int i = 0;

    void Awake()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            _activeClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            _activeContext = _activeClass.GetStatic<AndroidJavaObject>("currentActivity");
            _pluginClass = new AndroidJavaObject("rclip.lib.RClip");
            while (i != 1)
            {
                i = _pluginClass.Call<int>("AutoConnect");
            }
            if (_pluginClass == null)
            {
                Application.Quit();
            }
        }
    }
	
	void Update () {
        if (i == 1)
        {
            coordinats = _pluginClass.Call<float[]>("GetAxel");
        }
    }

    public static float[] GetAxel()
    {
        return coordinats;
    }

    public static bool GetButton(int _i)
    {
        if (i == 1)
        {
            return _pluginClass.Call<bool>("GetBtnState", _i);
        }
        else
        {
            return false;
        }
    }

    /*public static bool GetButtonMenu()
    {

    }*/

    public static void Vibro()
    {
        _pluginClass.Call("makeVibration", 2);
    }
}
