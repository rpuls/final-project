using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	//main
	private Vector3 CameraCenterPos = new Vector3(0f, 49.1f, 254.6f);
	private Vector3 CameraCenterAng = new Vector3(5.482f, 182.834f, 0.271f);

	//p1
	private static Vector3 CameraP1Pos = new Vector3(225f, 51f, 0f);
	private static Vector3 CameraP1Ang = new Vector3(17f, 270f, 0f);
	private static Vector3 CameraP1AimPos = new Vector3(168.5f, 24.1f, 0f);
	private static Vector3 CameraP1AimAng = new Vector3(-3f, 271f, 0f);

	//p2
	private static Vector3 CameraP2Pos = new Vector3(-175f, 38f, 0f);
	private static Vector3 CameraP2Ang = new Vector3(27f, 90f, 0f);
	private static Vector3 CameraP2AimPos = new Vector3(-139f,26.7f, 0f);
	private static Vector3 CameraP2AimAng = new Vector3(11.2f, 89f, 0f);


    // Use this for initialization
    void Start() {
        //cv = CameraView.Center;
    }

    public static void ChangeCamera(CameraView cv) {
        GameObject camera = GameObject.Find("Main Camera");

        if (cv == CameraView.Center) {
            //print("Center");
            camera.transform.position = new Vector3(0f, 49.1f, 254.6f);
            camera.transform.eulerAngles = new Vector3(5.482f, 182.834f, 0.271f);
        }
        else if (cv == CameraView.P1) {
            //print("P1");
			camera.transform.position = CameraP1AimPos;
            camera.transform.eulerAngles = CameraP1AimAng;
        }
        else if (cv == CameraView.P2) {
            //print("P2");
			camera.transform.position = CameraP2AimPos;
			camera.transform.eulerAngles = CameraP2AimAng;
        }

    }
}
public enum CameraView { Center, P1, P2 };