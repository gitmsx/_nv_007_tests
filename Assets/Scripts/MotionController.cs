using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class MotionController : MonoBehaviour
{

    int new_direction = 0;
    bool isMoving = false;
    public float speed = 2f;
    Vector3 destPos; //позиция куда двигаемся
    AudioSource AudioSource1;
    [HideInInspector] private Text Text__info003;
    [HideInInspector] private Text Text__info001;
    [HideInInspector] private Text Text__info002;

    public Transform Pointer;  // collide with Ray

    private Vector3[] DirectionM = new Vector3[4];


    float cellSize = _global.Global_Scale;


    private void Start()
    {
        //AudioSource1 = GetComponent<AudioSource>();

        Text__info001 = GameObject.Find("Text__info001").GetComponent<Text>();
        Text__info002 = GameObject.Find("Text__info002").GetComponent<Text>();
        Text__info003 = GameObject.Find("Text__info003").GetComponent<Text>();
        Text__info003.text = "Text__info003";

        DirectionM[0] = Vector3.forward;
        DirectionM[1] = Vector3.right;
        DirectionM[2] = -Vector3.forward;
        DirectionM[3] = -Vector3.right;





    }

    void Update()
    {
        if (isMoving)
        {
            destPos = transform.position + DirectionM[new_direction] * cellSize;




            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, destPos, step);//двигаем персонажа
            transform.position = destPos;
            if (transform.position == destPos) isMoving = false;



        }
        else
        {
            if (Input.GetKeyDown(KeyCode.W)) { new_direction = 0; isMoving = true; }
            else if (Input.GetKeyDown(KeyCode.D)) { new_direction = 1; isMoving = true; }
            else if (Input.GetKeyDown(KeyCode.S)) { new_direction = 2; isMoving = true; }
            else if (Input.GetKeyDown(KeyCode.A)) { new_direction = 3; isMoving = true; }


        }


        if (isMoving)

        {

            Ray ray = new Ray(transform.position, DirectionM[new_direction] * cellSize);

            Debug.DrawRay(transform.position, DirectionM[new_direction] * cellSize);
            if (Physics.Raycast(transform.position, DirectionM[new_direction], out RaycastHit hit,3* cellSize))

                if (hit.collider.gameObject.tag == "Box")

                {
                    Text__info003.text = hit.transform.position.x.ToString() + " " + hit.collider.gameObject.tag;
                    Pointer.position = hit.point;
                }





        }





    }
}