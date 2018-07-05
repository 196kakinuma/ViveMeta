using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViveMeta.System;
using IkLibrary.Unity;
namespace ViveMeta.Vive
{
    public class ViveInformation : SingletonMonoBehaviour<ViveInformation>
    {
        [SerializeField]
        GameObject hmdPos;

        public HandController rightHandCtrl;

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

        public Vector3 GEtHMDForward ()
        {
            return hmdPos.transform.forward;
        }

        public Vector3 GetCalibPos ()
        {
            return rightHandCtrl.GetRCalibrationObjPosition ();
        }

        public Vector3 GetCalibRot ()
        {
            return rightHandCtrl.GetRCalibrationObjRotation ();
        }
    }

}