using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public CameraView cv;
    // Use this for initialization
    void Start()
    {
        //cv = CameraView.Center;
    }

    // Update is called once per frame
    void Update()
    {
        if (cv == CameraView.Center)
        {
            //print("Center");
            gameObject.transform.position.Set(0f, 49.1f, 254.6f);
            gameObject.transform.rotation.Set(5.482f, 182.834f, 0.271f, 0);
        }
        else if (cv == CameraView.P1)
        {
            //print("P1");
            camera.transform.position = new Vector3(206.8f, 29.4f, 4.2f);
            camera.transform.eulerAngles = new Vector3(14.0f, 265f, 0f);

            //camera.transform.position.Set(-205.4f, 55.2f, 60.7f);
            //camera.transform.rotation.Set(18.091f, 92.86f,0.9f, 0);
        }
        else if (cv == CameraView.P2)
        {
            //print("P2");
            camera.transform.position = new Vector3(-220f, 41f, -15.36f);
            camera.transform.eulerAngles = new Vector3(14.0f, 90.0f, 0f);
            //camera.transform.position.Set(261.8f, 81f, 62.2f);
            //camera.transform.rotation.Set(21.75f, -91.04f, 1.4f, 0);
        }

    }
}
public enum CameraView { Center, P1, P2 };