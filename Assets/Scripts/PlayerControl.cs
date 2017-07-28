/**
 * Controls player based on mouse movement. Static speed value 
 * and no rotation.
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;

public class PlayerControl : MonoBehaviour
{
	public int maxSpeed = 80;
	public int minSpeed = 20;
	public float rotationSpeed = 10;
	public int currrentSpeed = 50;
    private bool max = false;
    int off, on;
    int state;
    Boolean isClick;
    float[] coordinats = new float[4] { 1f, 2f, 2f, 1f };
   // private AndroidJavaClass ajc;// = new AndroidJavaClass("com.raccoon.cvd.rclip_librarydemo");
    private AndroidJavaObject ajo=null;
    private AndroidJavaObject _activeContext;
    private AndroidJavaObject _pluginClass;
    private AndroidJavaClass _activeClass;
    //private AndroidJavaObject ajo = new AndroidJavaObject("rclip.lib");


    void Start()
    {
        isClick = false;
        if(SystemInfo.deviceType==DeviceType.Handheld)
        {
//            _activeClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
//            _activeContext = _activeClass.GetStatic<AndroidJavaObject>("currentActivity");
            _pluginClass = new AndroidJavaObject("rclip.lib.RClip");
            state= _pluginClass.Call<int>("AutoConnect");
//            Debug.Log(_activeClass.ToString() + " 1 " + _activeContext.ToString() + " 2 " + _pluginClass.ToString());
            if(_pluginClass==null)
            {
                Debug.Log(state.ToString());
                Application.Quit();
            }
            else
            {
                Debug.Log(state.ToString() +"  _plugin not null");
            }
            
        }
        /*if(off==0||off==2)
        {
            Application.Quit();
        }*/
        //ajo.Call("AutoConnect");
        //Debug.Log(ajo.Get<int>("State").ToString());
    }

    void Update()
    {
        if(_pluginClass.Call<Boolean>("GetBtnState",2))
        {
            Application.Quit();
        }
        /*if(Input.GetKey(KeyCode.Space))
        {
            currrentSpeed =2500;
            if (Camera.main.GetComponent<Camera>().fieldOfView<120f)
            {
                Camera.main.GetComponent<Camera>().fieldOfView += 1f;
            }
        }
        else
        {
            if (Camera.main.GetComponent<Camera>().fieldOfView > 80f)
            {
                Camera.main.GetComponent<Camera>().fieldOfView -= 5f ;
            }
            currrentSpeed = 500;
        }*/
    }

    void LateUpdate()
    {
        if (_pluginClass != null)
        {
            _pluginClass.Call("GetQuat", coordinats);
            Debug.Log(coordinats[0].ToString() + "  " + coordinats[1].ToString()+"  " + coordinats[2].ToString() + "  " + coordinats[3].ToString());
            Vector3 mouseMovement = (100*new Vector3(coordinats[1], coordinats[2], coordinats[3]) - (new Vector3(Screen.width, Screen.height, 0) / 2.0f)) * 1;
            transform.Rotate(new Vector3(-mouseMovement.y, mouseMovement.x, -mouseMovement.x) * 0.005f);
            transform.Translate(new Vector3(mouseMovement.x, mouseMovement.y, 0) * 0.005f);
        }
        transform.Translate(Vector3.forward * Time.deltaTime * currrentSpeed);
    }


}

