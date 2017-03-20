using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamestate : MonoBehaviour
{
    public static int playercount;
    public static bool hasChosenCard;
    // Use this for initialization
    void Start()
    {
        Network.maxConnections = 2;
    }
    private void OnConnectedToServer()
    {
        playercount++;
    }
    // Update is called once per frame
    void Update()
    {


    }


}
public enum ActivePlayer { P1, P2 };