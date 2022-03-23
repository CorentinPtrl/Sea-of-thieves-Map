
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoT;
using System;

public class SoTManager : MonoBehaviour
{
    private SotCore core;

    public GameObject LocalPlayerMap;

    void Start()
    {
        core = new SotCore(500f);

        if (core.Prepare(false))
        {
            Debug.Log("Successfully started");
        }
        else
        {
            Debug.Log("Error Window not detected");
        }
    }

    // Update is called once per frame
    void Update()
    {
        SoT.Data.Vector3 localPlayerPos = core.LocalPlayer.Position;
        Debug.Log(localPlayerPos);
        if(localPlayerPos.Y < 0)
        {
            Debug.Log("Hey");
            localPlayerPos.Y = Math.Abs(localPlayerPos.Y);
        }
        else
        {
            localPlayerPos.Y = localPlayerPos.Y * -1;
        }
        Vector3 PlayerPos = new Vector3(localPlayerPos.X, localPlayerPos.Y, -1)/1000;
        PlayerPos.z = -1;
        LocalPlayerMap.transform.position = PlayerPos;
    }
}
