﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace ViveMeta.Vive
{
    /// <summary>
    /// こんとろーらのコピーをSpwanしたり
    /// </summary>
    public class ViveInitializer : MonoBehaviour
    {
        [SerializeField]
        GameObject CtrlPref;
        HandController rightHandController;
        HandController leftHandController;

        [SerializeField]
        GameObject baseRCtrler;
        [SerializeField]
        GameObject baseLCtrler;

        [SerializeField]
        GameObject virtualSpace;

        // Use this for initialization
        void Start ()
        {
            rightHandController = Instantiate (CtrlPref, virtualSpace.transform).GetComponent<HandController> ();
            leftHandController = Instantiate (CtrlPref, virtualSpace.transform).GetComponent<HandController> ();
            rightHandController.targetObject = baseRCtrler;
            leftHandController.targetObject = baseLCtrler;

            NetworkServer.Spawn (rightHandController.gameObject);
            NetworkServer.Spawn (leftHandController.gameObject);
        }

        // Update is called once per frame
        void Update ()
        {

        }
    }
}