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
		[SerializeField]
		GameObject calibrationObject;
		[SerializeField]
		GameObject calibrationObject2;
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
		public void SetActiveCalibrationObj(bool b)
		{
			calibrationObject.SetActive (b);
		}
		public void SetActiveCalibrationObj2(bool b)
		{
			calibrationObject2.SetActive (b);
		}
    }
}