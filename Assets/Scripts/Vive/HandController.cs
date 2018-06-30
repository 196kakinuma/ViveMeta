using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViveMeta;

public class HandController : MonoBehaviour
{

    void Awake ()
    {
        if ( ViveMeta.System.InitializeSettings.Instance.GetDeviceType () == DeviceType.META )
        {
            Destroy (this);
        }
    }
    public GameObject targetObject;

    // Use this for initialization
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        this.transform.position = targetObject.transform.position;
        this.transform.rotation = targetObject.transform.rotation;
    }
}
