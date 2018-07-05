using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViveMeta.System
{
    enum EXE
    {
        NONE,
        CALIBRATION

    }
    public class KeyInputHandler : MonoBehaviour
    {
        [SerializeField]
        bool exeOrder = false;

        [SerializeField]
        EXE order;
        // Use this for initialization
        void Start ()
        {
            if ( InitializeSettings.Instance.GetDeviceType () != DeviceType.VIVE )
            {
                Destroy (this);
            }
        }

        // Update is called once per frame
        void Update ()
        {
            if ( exeOrder )
            {
                exeOrder = false;

                switch ( order )
                {
                    case EXE.NONE:
                        break;
                    case EXE.CALIBRATION:
                        Caliburation.Instance.Caliburate ();
                        break;
                }
            }
        }
    }
}