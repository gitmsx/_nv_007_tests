using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlaceBoxCheck : MonoBehaviour
{

    private float TimeToCheckCircle = 2;
    private float TimeToCheck;
    float cellSize = _global.Global_Scale;
    LayerMask LayerBox = 8;

    void Start()
    {
        TimeToCheck = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        TimeToCheck += Time.deltaTime;
        Debug.DrawRay(transform.position, -Vector3.up * cellSize , Color.green);
        

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

        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        //  layerMask = ~layerMask;

        if (Physics.Raycast(transform.position, -Vector3.up * cellSize, out RaycastHit hit, cellSize, layerMask))
        {
            Debug.Log(hit.point);
            return true;
        }

        //Debug.Log("Not hited !!!");
        //Debug.Log(transform.position);
        
        return false;
    }
}
