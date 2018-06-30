using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace ViveMeta.System
{
    enum DeviceType
    {
        VIVE,
        META,
        HOLO
    }



    public class InitializeSettings : MonoBehaviour
    {
        [SerializeField]
        DeviceType deviceType = DeviceType.VIVE;

        [SerializeField]
        GameObject ViveCameras;
        [SerializeField]
        GameObject MetaCameras;
        [SerializeField]
        NetworkManager netManager;

        public GameObject cube;



        void Awake ()
        {
            if ( deviceType == DeviceType.VIVE )
            {
                ViveCameras.SetActive (true);
            }
            else if ( deviceType == DeviceType.META )
            {
                MetaCameras.SetActive (true);
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
            }
            else if ( deviceType == DeviceType.META )
            {
                netManager.StartClient ();
                NetworkServer.Spawn (cube);
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
    }
}