using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	//main
	private static Vector3 CameraCenterPos = new Vector3(0f, 49.1f, 254.6f);
	private static Vector3 CameraCenterAng = new Vector3(5.482f, 182.834f, 0.271f);

    //Thowring Stars
    private static Vector3 CameraPosThowringStar = new Vector3(27f, 104f, -7f);
    private static Vector3 CameraAngThowringStar = new Vector3(38.1f, 89f, 0f);
    private static Hashtable HashThrow = iTween.Hash("x", -27f, "y", 104f, "z", -7f, "time", 3);//, "easetype", iTween.EaseType.easeInQuad);

    //p1
    private static Vector3 CameraP1Pos = new Vector3(225f, 51f, 0f);
	private static Vector3 CameraP1Ang = new Vector3(17f, 270f, 0f);
	private static Vector3 CameraP1AimPos = new Vector3(168.5f, 24.1f, 0f);
	private static Vector3 CameraP1AimAng = new Vector3(-3f, 271f, 0f);

	//p2
	private static Vector3 CameraP2Pos = new Vector3(-254.97F, 55.9f, 0f);
	private static Vector3 CameraP2Ang = new Vector3(12f, 90f, 0f);
	private static Vector3 CameraP2AimPos = new Vector3(-139f,26.7f, 0f);
	private static Vector3 CameraP2AimAng = new Vector3(11.2f, 89f, 0f);
	private static Vector3 CameraP2KatanaPos = new Vector3(-145f,23f, -28f);
	private static Vector3 CameraP2KatanaAng = new Vector3(10f, 56f, 0f);


    // Use this for initialization
    void Start() {
        //cv = CameraView.Center;
    }

    public static void ChangeCamera(CameraView cv) {
        GameObject camera = GameObject.Find("Main Camera");

        if (cv == CameraView.Center) {
			camera.transform.position = CameraCenterPos;
			camera.transform.eulerAngles = CameraCenterAng;
        }
        else if (cv == CameraView.P1) {
			camera.transform.position = CameraP1Pos;
            camera.transform.eulerAngles = CameraP1Ang;
        }
		else if (cv == CameraView.P1A) {
			camera.transform.position = CameraP1AimPos;
			camera.transform.eulerAngles = CameraP1AimAng;
		}
        else if (cv == CameraView.P2) {
			camera.transform.position = CameraP2Pos;
			camera.transform.eulerAngles = CameraP2Ang;
        }
		else if (cv == CameraView.P2A) {
			camera.transform.position = CameraP2AimPos;
			camera.transform.eulerAngles = CameraP2AimAng;
		}
		else if (cv == CameraView.P2K) {
			camera.transform.position = CameraP2KatanaPos;
			camera.transform.eulerAngles = CameraP2KatanaAng;
		}
        else if (cv == CameraView.ThowringStar)
        {
            iTween.MoveTo(camera, HashThrow);
        }

    }
}
public enum CameraView { Center, P1, P1A, P2, P2A, P2K, ThowringStar };