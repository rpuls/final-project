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
            transform.position = new Vector3(169.9f, 34.9f, 63.3f);
            transform.eulerAngles = new Vector3(5.482f, -86f, -0.271f);
        }
        else if (cv == CameraView.P2)
        {
            //print("P2");
            gameObject.transform.position.Set(0f, 49.1f, 63.3f);
            gameObject.transform.rotation.Set(5.482f, -86f, -0.271f, 0);
        }

    }
}
public enum CameraView { Center, P1, P2 };