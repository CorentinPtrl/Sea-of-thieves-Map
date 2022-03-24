using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public SoT.Game.Ship ship;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SoT.Data.Vector3 localShipPos = ship.Position;
        if (localShipPos.Y < 0)
        {
            localShipPos.Y = Math.Abs(localShipPos.Y);
        }
        else
        {
            localShipPos.Y = localShipPos.Y * -1;
        }
        Vector3 ShipPos = new Vector3(localShipPos.X, localShipPos.Y, -1) / 1000;
        ShipPos.z = -1;
        transform.position = ShipPos;
    }
}
