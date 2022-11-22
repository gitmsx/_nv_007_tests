using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameStart : MonoBehaviour
{


    [HideInInspector] private Text Text__info003;
    [HideInInspector] private Text Text__info001;
    [HideInInspector] private Text Text__info002;




    private List<GameObject> listPoints = new List<GameObject>();
    public GameObject PF_chess1;
    public GameObject PF_chess2;

    public GameObject PlaceToBox;


    float cellSize = _global.Global_Scale;





    void Start()
    {
        float scale_pf = _global.Global_Scale;
        GameObject[] ChessTmp = new GameObject[2];

        Text__info001 = GameObject.Find("Text__info001").GetComponent<Text>();
        Text__info002 = GameObject.Find("Text__info002").GetComponent<Text>();
        Text__info003 = GameObject.Find("Text__info003").GetComponent<Text>();
        Text__info003.text = "Text__info003";




        ChessTmp[0] = PF_chess1;
        ChessTmp[1] = PF_chess2;

        for (int i = 0; i < 20; i++)
            for (int j = 0; j < 20; j++)
            {
                Vector3 NewPos = new Vector3(scale_pf * i, -0.101f, scale_pf * j);
                //  Instantiate(ChessTmp[(i + j) % 2], NewPos, Quaternion.identity);
            }


        for (int i = 0; i < 5; i++)
        {
            Vector3 SpownPoint = new Vector3(5.02f, 1.201f, 5.02f + i);
            listPoints.Add(Instantiate(PlaceToBox, SpownPoint, Quaternion.identity));
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (CheckWin()) Text__info002.text = "  Winner !!!!!  ";



    }


    bool CheckWin()
    {
        int all_Targets = 0;
        int all_Cheked = 0;
        int layerMask = 1 << 8;


        foreach (GameObject gameObject in listPoints)
        {
            all_Targets++;
            Vector3 CurrentTargetTransformPosition = gameObject.transform.position;
            if (Physics.Raycast(CurrentTargetTransformPosition, -Vector3.up, out RaycastHit hit, cellSize, layerMask))

                all_Cheked++;
        }


        if (all_Cheked > 3) return true;
        return false;
    }





}
