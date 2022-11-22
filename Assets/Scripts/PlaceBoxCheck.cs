using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlaceBoxCheck : MonoBehaviour
{

    private float TimeToCheckCircle = 1;
    private float TimeToCheck;
    float cellSize = _global.Global_Scale;

    void Start()
    {
        TimeToCheck = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        TimeToCheck += Time.deltaTime;
        Debug.DrawRay(transform.position, Vector3.up * cellSize*3, Color.green);

        if (TimeToCheckCircle < TimeToCheck)
        {
            TimeToCheck = 0;
            
            if (PlaceBoxChek()) 
            {
                
            }
        }


    }



    bool PlaceBoxChek()
    {

        if (Physics.Raycast(transform.position, Vector3.up * cellSize*3, out RaycastHit hit, cellSize))
        { 
            Debug.Log(hit.point);
        return true;
        }
        return false;
    }
}
