using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Connecttest : MonoBehaviour
{

    public GameObject cube;
    // Use this for initialization
    void Start ()
    {
        NetworkServer.Spawn (Instantiate (cube));
    }

    // Update is called once per frame
    void Update ()
    {

    }
}
