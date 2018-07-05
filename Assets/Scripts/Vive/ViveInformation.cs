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

        public Vector3 GetCalibPos ( int num )
        {
            if ( num == 1 )
            {
                return rightHandCtrl.GetRCalibrationObjPosition ();
            }
            else if ( num == 2 )
            {
                return rightHandCtrl.GetRCalibrationObj2Position ();
            }
            else
            {
                Debug.LogError (" num is out of range:" + num);
                return Vector3.zero;
            }
        }

        public Vector3 GetCalibRot ( int num )
        {

            if ( num == 1 )
            {
                return rightHandCtrl.GetRCalibrationObjRotation ();
            }
            else if ( num == 2 )
            {
                return rightHandCtrl.GetRCalibrationObj2Rotation ();
            }
            else
            {
                Debug.LogError (" num is out of range:" + num);
                return Vector3.zero;
            }
        }
    }

}