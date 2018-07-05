using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IkLibrary.Unity;
namespace ViveMeta.System
{

    public class ConnectNetClient : SingletonMonoBehaviour<ConnectNetClient>
    {


        private ConnectNet connectNet;

        DeviceType deviceType
        {
            get
            {
                return InitializeSettings.Instance.GetDeviceType ();
            }
        }
        // Use this for initialization
        void Start ()
        {
            connectNet = GetComponent<ConnectNet> ();

        }

        // Update is called once per frame
        void Update ()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num">何回目のキャリブレーションか</param>
        public void ReqestMetaPosition ( int num )
        {
            if ( deviceType != DeviceType.VIVE ) return;
            connectNet.CmdReqestMetaPosition (deviceType, num);
        }

        public void ResponseMetaposition ( int num, Vector3 hmdpos, Vector3 hmdrot )
        {
            Caliburation.Instance.SetCaliburationValue (num, hmdpos, hmdrot);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num">何回目のキャリブレーションか<aram>
        public void ReqChangeMeta2CalibMode ( int num )
        {
            if ( deviceType != DeviceType.VIVE ) return;
            connectNet.CmdChangeMeta2CalibMode (deviceType, num);
        }

        /// <summary>
        /// Metaをキャリブレーションモードにして、調整用のオブジェクトを表示
        /// </summary>
        /// <param name="num">1:一回目 2:2回目3:きゃりぶモード終了</param>
        public void ChangeMeta2CalibMode ( int num )
        {
            if ( deviceType == DeviceType.VIVE ) return;
            switch ( num )
            {
                case 1:
                    Meta.MetaInformation.Instance.SetActiveCalibrationObj (true);
                    break;
                case 2:
                    Meta.MetaInformation.Instance.SetActiveCalibrationObj (false);
                    Meta.MetaInformation.Instance.SetActiveCalibrationObj2 (true);
                    break;
                case 3:
                    Meta.MetaInformation.Instance.SetActiveCalibrationObj (false);
                    Meta.MetaInformation.Instance.SetActiveCalibrationObj2 (false);
                    break;
                default:
                    Meta.MetaInformation.Instance.SetActiveCalibrationObj (false);
                    Meta.MetaInformation.Instance.SetActiveCalibrationObj2 (false);
                    Debug.LogError ("unknown num:" + num);
                    break;

            }
        }

        public void PostMetaOffset ( Vector3 offsetPos, Quaternion offsetRot )
        {
            if ( deviceType != DeviceType.VIVE ) return;
            connectNet.CmdPostMetaOffset (deviceType, offsetPos, offsetRot);
        }
        /// <summary>
        /// MRデバイスでのみ呼ぶ
        /// </summary>
        public void SetMetaoffset ( Vector3 offset, Quaternion offsetRot )
        {
            if ( deviceType == DeviceType.VIVE ) return;
            Meta.MetaInformation.Instance.SetMetaOffset (offset, offsetRot);
        }

        public Vector3 GetHMDPosition ()
        {
            if ( InitializeSettings.Instance.GetDeviceType () == DeviceType.VIVE )
            {
                return Vive.ViveInformation.Instance.GetHMDPosition ();
            }
            else
            {
                return Meta.MetaInformation.Instance.GetHMDPosition ();
            }
        }

        public Vector3 GetHMDRotation ()
        {
            if ( InitializeSettings.Instance.GetDeviceType () == DeviceType.VIVE )
            {
                return Vive.ViveInformation.Instance.GEtHMDForward ();
            }
            else
            {
                Debug.Log ("return HMD rotation");
                return Meta.MetaInformation.Instance.GetHMDForward ();
            }
        }
    }
}