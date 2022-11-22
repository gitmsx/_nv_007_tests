using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    private List<GameObject> listPoints = new List<GameObject>();
    public GameObject PF_chess1;
    public GameObject PF_chess2;

    public GameObject PlaceToBox;

    private float TimeToCheckCircle = 2;
    private float TimeToCheck;
    float cellSize = _global.Global_Scale;




    void Start()
    {



        float scale_pf = _global.Global_Scale;
        GameObject[] ChessTmp = new GameObject[2];

        ChessTmp[0] = PF_chess1;
        ChessTmp[1] = PF_chess2;

        for (int i = 0; i < 20; i++)
            for (int j = 0; j < 20; j++)
            {
                Vector3 NewPos = new Vector3(scale_pf * i, 0.1f, scale_pf * j);
                var BoxClone = Instantiate(ChessTmp[(i + j) % 2], NewPos, Quaternion.identity);
              
            }

    


    


        for (int i = 0; i < 2; i++)
        {
            Vector3 SpownPoint = new Vector3(5.2f, 1.1f, 5.2f + i);
            var Place = Instantiate(PlaceToBox, SpownPoint, Quaternion.identity);
            
            listPoints.Add(Place);
        }    
        
        
        


        

    }

    // Update is called once per frame
    void Update()
    {
        TimeToCheck += Time.deltaTime;
        Debug.DrawRay(transform.position, -Vector3.up * cellSize, Color.green);


        if (TimeToCheckCircle < TimeToCheck)
        {
            TimeToCheck = 0;
           bool  status = CheckWin();
        }


    }


    bool CheckWin()
    {
        int all_pnts = 0;
        int all_Cheked = 0;
        foreach (var PTs in listPoints)
        {
            all_pnts++;
            if (PTs.GetComponent("PlaceBoxCheck"))
            {

            }
        }
        return false;
    }





}
