

using System;
using System.Diagnostics;
using UnityEngine.XR;
using UnityEngine;

public class _main 
{
    public static void EntryPoint()
    {

        GameObject _handl = GameObject.Find("_GameStart");
        _handl.AddComponent<ReadMaps>();
        _handl.GetComponent<ReadMaps>().Start1(3);

        ReadMaps readMaps = new ReadMaps();
        

        readMaps.Start1(4);
        Console.WriteLine("Start //// ");
    }

}
