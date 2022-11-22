using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlaceBoxCheck : MonoBehaviour
{


   public  bool Ffull = false;
    float cellSize = _global.Global_Scale;
    private float TimeToCheckCircle = 2;
    private float TimeToCheck;


    void Update()
    {
        TimeToCheck += Time.deltaTime;
        Debug.DrawRay(transform.position, -Vector3.up * cellSize, Color.green);
        if (TimeToCheckCircle < TimeToCheck)
        {
            TimeToCheck = 0;
            if (PlaceBoxChek())
            {
                Debug.Log("Win!!!");
            }
        }


    }



    bool PlaceBoxChek()
    {
        int layerMask = 1 << 8;
        if (Physics.Raycast(transform.position, -Vector3.up * cellSize, out RaycastHit hit, cellSize, layerMask))
        {
            Ffull = true;
            return true;
        }
        return false;
    }
}
