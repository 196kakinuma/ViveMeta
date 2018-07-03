using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace ViveMeta.System
{
    public class ConnectNet : NetworkBehaviour
    {

        // Use this for initialization
        void Start ()
        {

        }

        // Update is called once per frame
        void Update ()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientDevice"></param>
        /// <param name="num">何回目の入力か</param>
        [Command]
        public void CmdReqestMetaPosition ( DeviceType clientDevice, int num )
        {
            RpcRequestMetaposition (clientDevice, num);
        }

        /// <summary>
        /// Metaでのみすべて実行される
        /// </summary>
        /// <param name="clientDevice"></param>
        /// <param name="num"></param>
        [ClientRpc]
        void RpcRequestMetaposition ( DeviceType clientDevice, int num )
        {
            if ( clientDevice == InitializeSettings.Instance.GetDeviceType () ) return;

            var hmdpos = ConnectNetClient.Instance.GetHMDPosition ();

            CmdResponseMetaPosition (ReverseDeviceType (clientDevice), num, hmdpos);

        }

        [Command]
        public void CmdResponseMetaPosition ( DeviceType clientDevice, int num, Vector3 hmdpos )
        {
            RpcResponseMetaposition (clientDevice, num, hmdpos);
        }

        /// <summary>
        /// Viveデノミすべて実行される
        /// </summary>
        /// <param name="clientDeivce"></param>
        /// <param name="num"></param>
        /// <param name="hmdpos"></param>
        [ClientRpc]
        void RpcResponseMetaposition ( DeviceType clientDeivce, int num, Vector3 hmdpos )
        {
            if ( clientDeivce == InitializeSettings.Instance.GetDeviceType () ) return;

            ConnectNetClient.Instance.ResponseMetaposition (num, hmdpos);
        }

        [Command]
        public void CmdChangeMeta2CalibMode ( DeviceType clientDevice, int num )
        {
            RpcChangemeta2CalibMode (clientDevice, num);
        }

        [ClientRpc]
        void RpcChangemeta2CalibMode ( DeviceType clientDevice, int num )
        {
            if ( clientDevice == InitializeSettings.Instance.GetDeviceType () ) return;
            //TODO:

        }


        [Command]
        public void CmdPostMetaOffset ( DeviceType clientDevice, Vector3 offset )
        {
            RpcPostMetaOffset (clientDevice, offset);
        }

        [ClientRpc]
        void RpcPostMetaOffset ( DeviceType clientDevice, Vector3 offset )
        {
            if ( clientDevice == InitializeSettings.Instance.GetDeviceType () ) return;
            ConnectNetClient.Instance.SetMetaoffset (offset);
        }


        private DeviceType ReverseDeviceType ( DeviceType type )
        {
            if ( type == DeviceType.VIVE ) return DeviceType.META;
            else if ( type == DeviceType.META ) return DeviceType.VIVE;
            else return DeviceType.HOLO;
        }

        #region EXAMPLE
        /// <summary>
        /// クライアントから呼ばれる
        /// </summary>
        [Command]
        public void CmdCall ()
        {

        }

        /// <summary>
        /// ホストから呼ばれて全クライアントで実行される
        /// </summary>
        [ClientRpc]
        void RpcCall ( DeviceType clientDeivce )
        {
            ///これのcmdを呼び出したクライアントのデバイスとの比較=>じぶんが呼び出した命令であれば、無視する
            if ( clientDeivce == InitializeSettings.Instance.GetDeviceType () ) return;


        }
        #endregion
    }
}