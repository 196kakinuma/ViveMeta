using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using IkLibrary.Unity;

public enum DeviceType
{
    VIVE,
    META,
    HOLO
}

namespace ViveMeta.System
{


    public class InitializeSettings : SingletonMonoBehaviour<InitializeSettings>
    {
        [SerializeField]
        DeviceType deviceType = DeviceType.VIVE;

        [SerializeField]
        GameObject ViveCameras;
        [SerializeField]
        GameObject MetaCameras;
        [SerializeField]
        NetworkManager netManager;


        void Awake ()
        {
            if ( deviceType == DeviceType.VIVE )
            {
            }
            else if ( deviceType == DeviceType.META )
            {

            }
            else
            {
                Debug.LogError ("No DeviceType Selected");
            }
        }


        // Use this for initialization
        void Start ()
        {
            if ( deviceType == DeviceType.VIVE )
            {
                netManager.StartHost ();
                ViveCameras.SetActive (true);

            }
            else if ( deviceType == DeviceType.META )
            {
                netManager.StartClient ();
                MetaCameras.SetActive (true);
            }
            else
            {
                Debug.LogError ("No DeviceType Selected");
            }
        }

        // Update is called once per frame
        void Update ()
        {

        }

        public DeviceType GetDeviceType ()
        {
            return deviceType;
        }
    }
}