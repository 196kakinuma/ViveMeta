using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IkLibrary.Unity;

namespace ViveMeta.Meta
{
    public class MetaInformation : SingletonMonoBehaviour<MetaInformation>
    {
        [SerializeField]
        GameObject hmdPos;
        // Use this for initialization
        void Start ()
        {

        }

        // Update is called once per frame
        void Update ()
        {

        }

        public Vector3 GetHMDPosition ()
        {
            return hmdPos.transform.position;
        }
        public Vector3 GetHMDForward ()
        {
            return hmdPos.transform.forward;
        }
    }
}