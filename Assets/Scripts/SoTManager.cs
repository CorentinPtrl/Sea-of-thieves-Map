
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoT;
using System;
using SoT.Game;

public class SoTManager : MonoBehaviour
{
    private SotCore core;

    public GameObject ShipPrefab;

    public GameObject LocalPlayerMap;
    public List<GameObject> Ships;

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
    
    public bool ShipAlreadyExist(UEObject ship)
    {
        foreach(GameObject gameObject in Ships)
        {
            if (gameObject.GetComponent<Ship>().ship == ship)
                return true;
        }
        return false;
    }

    void Update()
    {
        SoT.Data.Vector3 localPlayerPos = core.LocalPlayer.Position;
        if(localPlayerPos.Y < 0)
        {
            localPlayerPos.Y = Math.Abs(localPlayerPos.Y);
        }
        else
        {
            localPlayerPos.Y = localPlayerPos.Y * -1;
        }
        Vector3 PlayerPos = new Vector3(localPlayerPos.X, localPlayerPos.Y, -1)/1000;
        PlayerPos.z = -1;
        LocalPlayerMap.transform.position = PlayerPos;

        foreach(UE4Actor actor in core.GetActors())
        {
            if (actor.Name.Equals("BP_SmallShipTemplate_C") || actor.Name.Equals("BP_SmallShipNetProxy") || actor.Name.Equals("BP_MediumShipTemplate_C") || actor.Name.Equals("BP_MediumShipNetProxy") || actor.Name.Equals("BP_LargeShipTemplate_C") || actor.Name.Equals("BP_LargeShipNetProxy") || actor.Name.Equals("BP_Rowboat_C") || actor.Name.Equals("BP_RowboatRowingSeat_C") || actor.Name.Equals("BP_RowboatRowingSeat_C") || actor.Name.Equals("BP_Rowboat_WithFrontHarpoon_C"))
            {
                if (!ShipAlreadyExist(actor))
                {
                    SoT.Game.Ship SoTShip = new SoT.Game.Ship(actor);
                    GameObject ship = Instantiate(ShipPrefab);
                    ship.GetComponent<Ship>().ship = SoTShip;
                    Ships.Add(ship);
                }
            }
        }
    }
}
