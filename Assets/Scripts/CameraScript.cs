using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	//main
	private static Vector3 CameraCenterPos = new Vector3(0f, 49.1f, 254.6f);
	private static Vector3 CameraCenterAng = new Vector3(5.482f, 182.834f, 0.271f);
	private static Hashtable HashCameraCenterPos = iTween.Hash("x", 0f, "y", 49.1f, "z", 254.6f, "time", 3);
	private static Hashtable HashCameraCenterAng = iTween.Hash("x", 5.482f, "y", 182.834f, "z", 0.271f, "time", 3);

    //Thowring Stars
    private static Vector3 CameraPosThowringStar = new Vector3(27f, 104f, -7f);
    private static Vector3 CameraAngThowringStar = new Vector3(38.1f, 89f, 0f);
	private static Hashtable HashCameraPosThowringStar = iTween.Hash("x", -27f, "y", 104f, "z", -7f, "time", 3);
	private static Hashtable HashCameraAngThowringStar = iTween.Hash("x", 38.1f, "y", 89f, "z", 0f, "time", 3);

    //p1
    private static Vector3 CameraP1Pos = new Vector3(225f, 51f, 0f);
	private static Vector3 CameraP1Ang = new Vector3(17f, 270f, 0f);
	private static Hashtable HashCameraP1Pos = iTween.Hash("x", 225f, "y", 51f, "z", 0f, "time", 3);
	private static Hashtable HashCameraP1Ang = iTween.Hash("x", 17f, "y", 270f, "z", 0f, "time", 3);
	private static Vector3 CameraP1AimPos = new Vector3(168.5f, 24.1f, 0f);
	private static Vector3 CameraP1AimAng = new Vector3(-3f, 271f, 0f);
	private static Hashtable HashCameraP1AimPos = iTween.Hash("x", 168.5f, "y", 24.1f, "z", 0f, "time", 3);
	private static Hashtable HashCameraP1AimAng = iTween.Hash("x", -1f, "y", 271f, "z", 0f, "time", 3);

	//p2
	private static Vector3 CameraP2Pos = new Vector3(-254.97F, 55.9f, 0f);
	private static Vector3 CameraP2Ang = new Vector3(12f, 90f, 0f);
	private static Hashtable HashCameraP2Pos = iTween.Hash("x", -255f, "y", 56f, "z", 0f, "time", 3);
	private static Hashtable HashCameraP2Ang = iTween.Hash("x", 12f, "y", 90f, "z", 0f, "time", 3);
	private static Vector3 CameraP2AimPos = new Vector3(-139f,26.7f, 0f);
	private static Vector3 CameraP2AimAng = new Vector3(11.2f, 89f, 0f);
	private static Hashtable HashCameraP2AimPos = iTween.Hash("x", -139f, "y", 26.7f, "z", 0f, "time", 3);
	private static Hashtable HashCameraP2AimAng = iTween.Hash("x", 11.2f, "y", 89f, "z", 0f, "time", 3);
	private static Hashtable HashKatanaPos = iTween.Hash("x", -145f, "y", 23f, "z", -28f, "time", 3);
	private static Hashtable HashKatanaAng = iTween.Hash("x", 10f, "y", 56f, "z", 0f, "time", 3);

    // Use this for initialization
    void Start() {
        //cv = CameraView.Center;
    }

    public static void ChangeCamera(CameraView cv) {
        GameObject camera = GameObject.Find("Main Camera");

        if (cv == CameraView.Center) {
			//camera.transform.position = CameraCenterPos;
			//camera.transform.eulerAngles = CameraCenterAng;
			iTween.MoveTo(camera, HashCameraCenterPos);
			iTween.RotateTo (camera, HashCameraCenterAng);
        }
        else if (cv == CameraView.P1) {
			//camera.transform.position = CameraP1Pos;
            //camera.transform.eulerAngles = CameraP1Ang;
			iTween.MoveTo(camera, HashCameraP1Pos);
			iTween.RotateTo (camera, HashCameraP1Ang);
        }
		else if (cv == CameraView.P1A) {
			//camera.transform.position = CameraP1AimPos;
			//camera.transform.eulerAngles = CameraP1AimAng;
			iTween.MoveTo(camera, HashCameraP1AimAng);
			iTween.RotateTo (camera, HashCameraP1AimPos);
		}
        else if (cv == CameraView.P2) {
			//camera.transform.position = CameraP2Pos;
			//camera.transform.eulerAngles = CameraP2Ang;
			iTween.MoveTo(camera, HashCameraP2Pos);
			iTween.RotateTo (camera, HashCameraP2Ang);
        }
		else if (cv == CameraView.P2A) {
			//camera.transform.position = CameraP2AimPos;
			//camera.transform.eulerAngles = CameraP2AimAng;
			iTween.MoveTo(camera, HashCameraP2AimAng);
			iTween.RotateTo (camera, HashCameraP2AimPos);
		}
		else if (cv == CameraView.P2K) {			
			iTween.MoveTo(camera, HashKatanaPos);
			iTween.RotateTo (camera, HashKatanaAng);
		}
        else if (cv == CameraView.ThowringStar)
        {
			iTween.MoveTo(camera, HashCameraPosThowringStar);
			iTween.RotateTo (camera, HashCameraAngThowringStar);
        }

    }
}
public enum CameraView { Center, P1, P1A, P2, P2A, P2K, ThowringStar };