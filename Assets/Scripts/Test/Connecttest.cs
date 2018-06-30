using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace ViveMeta.Test
{
    public class Connecttest : MonoBehaviour
    {


        // Use this for initialization
        void Start ()
        {

        }

        // Update is called once per frame
        void Update ()
        {
            this.transform.position = this.transform.position + new Vector3 (1, 0, 0);
        }
    }
}