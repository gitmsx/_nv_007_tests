using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;





public class PlaceBoxCheck : MonoBehaviour
{


   public  bool Ffull = false;
    float cellSize = _global.Global_Scale;
    private float TimeToCheckCircle = 2;
    private float TimeToCheck;
    
    void Update()
    {
        TimeToCheck += Time.deltaTime;
        Debug.DrawRay(transform.position, -Vector3.up * cellSize * 1.1f, Color.green);
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
        if (Physics.Raycast(transform.position, -Vector3.up * cellSize * 1.1f, out RaycastHit hit, cellSize, layerMask))
        {

            var Text__info003 = GameObject.Find("Text__info003").GetComponent<Text>();
            Text__info003.text = " Win !!!!!!!!!";

            Ffull = true;
                
            return true;
        }
        return false;
    }
}
