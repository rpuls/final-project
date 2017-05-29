using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowStarScript : MonoBehaviour, IMove {

    public GameObject SpinnerImg;
    public GameObject Arrow;
    public TurnManager Turnmanager;
    public float SpinnerSpeed;
    private float SpinnerSpeedStartValue;
    private bool StopSpinner;
    private bool SlowDownSpinner;
    private bool ActivateSpinner;
    public GameObject ThrowingStarPrefab;
    private Vector3 SpawnPos1 = new Vector3(92.1F, 57.8F, 54.7F);
    private Vector3 SpawnPos2 = new Vector3(92F, 65F, -85F);

    // Use this for initialization
    void Start () {
	}

    private void CalculateEndPosition(float z)
    {
        int StarsToBeThrowed = 0;
     if(z > 324)
        {
            StarsToBeThrowed = 6;
            Debug.Log("Six Has been hit!");
        }
      else if (z <= 324 && z > 288)
        {
            StarsToBeThrowed = 7;
            Debug.Log("Seven Has been hit!");
        }
      else if (z <= 288 && z > 250)
        {
            StarsToBeThrowed = 8;
            Debug.Log("Eight Has been hit!");
        }
      else if (z <= 250 && z > 240)
        {
            StarsToBeThrowed = 9;
            Debug.Log("Nine Has been hit!");
        }
      else if (z <= 240 && z > 210)
        {
            StarsToBeThrowed = 10;
            Debug.Log("Ten Has been hit!");
        }
      else if (z <= 210 && z > 180)
        {
            StarsToBeThrowed = 1;
            Debug.Log("One Has been hit!");
        }
      else if (z <= 180 && z > 130)
        {
            StarsToBeThrowed = 2;
            Debug.Log("Two Has been hit!");
        }
      else if (z <= 130 && z > 90)
        {
            StarsToBeThrowed = 3;
            Debug.Log("Three Has been hit!");
        }
      else if (z <= 90 && z > 40)
        {
            StarsToBeThrowed = 4;
            Debug.Log("Four Has been hit!");
        }
      else if (z < 40)
        {
            StarsToBeThrowed = 5;
            Debug.Log("Five Has been hit!");
        }

        else
        {
            Debug.Log("Developer Fucked up!");
        }

        ThrowStars(StarsToBeThrowed);
    }

    private void ThrowStars(int starsToBeThrowed)
    {
        Arrow.SetActive(false);
        SpinnerImg.SetActive(false);
        this.gameObject.GetComponent<Text>().text = "Attacking with: " + starsToBeThrowed;
        StartCoroutine(CreateThrowingStars(starsToBeThrowed));
    }

    private IEnumerator CreateThrowingStars(int stars)
    {
        CameraScript.ChangeCamera(CameraView.ThowringStar);
        bool flag = true;
        for (int count = 0; count <= stars; count++)
        {
            if (flag) {
                Instantiate(ThrowingStarPrefab, SpawnPos1, Quaternion.identity);
            }
            else {
             Instantiate(ThrowingStarPrefab, SpawnPos2, Quaternion.identity);
        }
            flag = !flag;
            yield return new WaitForSeconds(0.5F);
        }
        yield return new WaitForSeconds(3.0F);
        Turnmanager.GameManager.playerOne.GiveDamage(5 * stars);
        CleanUp();
    }



    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("space"))
            {
            SlowDownSpinner = true;
            }

            if (!StopSpinner)
            {
                if (SlowDownSpinner)
                {
                    SpinnerSpeed -= 36;
                    if (SpinnerSpeed <= 0)
                    {
                        SpinnerSpeed = 0;
                        StopSpinner = true;
                        CalculateEndPosition(Arrow.transform.localEulerAngles.z);
                    }
                }
                Arrow.transform.Rotate(new Vector3(0F, 0F, -SpinnerSpeed) * Time.deltaTime);
            }
    }

    public void CleanUp()
    {
        SpinnerSpeed = SpinnerSpeedStartValue;
        ActivateSpinner = false;
        Turnmanager.MoveIsDone(this.gameObject);
    }

    public void DoMove()
    {
        this.gameObject.SetActive(true);
        StopSpinner = false;
        SpinnerSpeedStartValue = SpinnerSpeed;
        this.gameObject.GetComponent<Text>().text = "Press Space To Stop";
        SlowDownSpinner = false;
        SpinnerImg.SetActive(true);
        Arrow.SetActive(true);
        ActivateSpinner = true;
    }

    public void FixedUpdate()
    {
    }
}
