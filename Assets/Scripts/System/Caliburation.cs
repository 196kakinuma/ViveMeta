using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IkLibrary.Unity;

namespace ViveMeta.System
{
    public class Caliburation : SingletonMonoBehaviour<Caliburation>
    {
        bool getResp = false;

        Vector3 firstCalib = Vector3.zero;
        Vector3 firstPos = Vector3.zero;
        Vector3 secondCalib = Vector3.zero;
        Vector3 secondPos = Vector3.zero;
        // Use this for initialization
        void Start ()
        {

        }

        // Update is called once per frame
        void Update ()
        {

        }

        IEnumerator StartCaliburation ()
        {
            //いっかいめ
            ConnectNetClient.Instance.ReqChangeMeta2CalibMode (1);
            while ( !Input.GetKeyUp (KeyCode.Space) )
            {
                yield return new WaitForEndOfFrame ();
            }
            ConnectNetClient.Instance.ReqestMetaPosition (1);
            while ( !getResp )
            {
                yield return new WaitForEndOfFrame ();
            }
            getResp = false;

            //二回目
            ConnectNetClient.Instance.ReqChangeMeta2CalibMode (2);
            while ( !Input.GetKeyUp (KeyCode.Space) )
            {
                yield return new WaitForEndOfFrame ();
            }
            ConnectNetClient.Instance.ReqestMetaPosition (2);
            while ( !getResp )
            {
                yield return new WaitForEndOfFrame ();
            }
            getResp = false;

            //計算送信終了
            ConnectNetClient.Instance.PostMetaOffset (CalcMetaPosition ());

        }


        public void SetCaliburationValue ( int num, Vector3 hmdpos )
        {
            if ( num == 1 )
            {
                firstCalib = hmdpos;
                Debug.Log ("first val:" + hmdpos);
            }
            else if ( num == 2 )
            {
                secondCalib = hmdpos;
                Debug.Log ("second val:" + hmdpos);
            }
            else
            {
                Debug.LogError ("num is out of range:" + num);
            }

            getResp = true;
        }

        /// <summary>
        /// コントローラの位置から今のMetaのポジションを推定する
        /// </summary>
        void SetMetaPosFromRightController ( int num )
        {
            if ( num == 1 )
            {
                //TODO:
                //firstPos=
            }
            else if ( num == 2 )
            {
                //secondPos
            }
            else
            {
                Debug.LogError ("num is out of range:" + num);
            }
        }

        //メタのoffsetを計算して返す
        Vector3 CalcMetaPosition ()
        {
            return Vector3.zero;
        }
    }

}