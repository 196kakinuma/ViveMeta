using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViveMeta;

public class HandController : MonoBehaviour
{
    public bool rightCtrler = false;

    [SerializeField]
    GameObject calibrationObject;
    [SerializeField]
    GameObject calibrationObject2;
    void Awake ()
    {
        if ( ViveMeta.System.InitializeSettings.Instance.GetDeviceType () == DeviceType.META )
        {
            Destroy (this);
        }
    }
    [HideInInspector]
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

    public Vector3 GetRCalibrationObjPosition ()
    {
        if ( !rightCtrler )
        {
            Debug.LogError ("this is right hand");
            return Vector3.zero;
        }
        else
        {
            return calibrationObject.transform.position;
        }
    }

    public Vector3 GetRCalibrationObjRotation ()
    {
        if ( !rightCtrler )
        {
            Debug.LogError ("this is right hand");
            return Vector3.zero;
        }
        else
        {
            return ( transform.position - calibrationObject.transform.position ).normalized;
        }
    }



    public Vector3 GetRCalibrationObj2Position ()
    {
        if ( !rightCtrler )
        {
            Debug.LogError ("this is right hand");
            return Vector3.zero;
        }
        else
        {
            return calibrationObject2.transform.position;
        }
    }

    public Vector3 GetRCalibrationObj2Rotation ()
    {
        if ( !rightCtrler )
        {
            Debug.LogError ("this is right hand");
            return Vector3.zero;
        }
        else
        {
            return ( transform.position - calibrationObject2.transform.position ).normalized;
        }
    }
}
