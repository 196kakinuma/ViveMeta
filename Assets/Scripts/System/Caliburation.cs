﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IkLibrary.Unity;

namespace ViveMeta.System
{
    public class Caliburation : SingletonMonoBehaviour<Caliburation>
    {
        bool getResp = false;
        [SerializeField]
        Vive.ViveInformation info;

        Vector3 firstCalibPos = Vector3.zero; //Metaからの情報
        Vector3 firstPos = Vector3.zero;
        Vector3 firstCalibRot;  //Viveでの推定値
        Vector3 firstPot;

        Vector3 secondCalibPos = Vector3.zero;
        Vector3 secondPos = Vector3.zero;
        Vector3 secondCalibRot;  //Viveでの推定値
        Vector3 secondPot;
        // Use this for initialization
        void Start ()
        {

        }

        // Update is called once per frame
        void Update ()
        {

        }

        public void Caliburate ()
        {
            StartCoroutine (StartCaliburation ());
        }

        IEnumerator StartCaliburation ()
        {
            Debug.Log ("calibration start");
            //いっかいめ
            ConnectNetClient.Instance.ReqChangeMeta2CalibMode (1);
            Debug.Log ("Waiting for Space key");
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
            Debug.Log ("first point" + firstCalibPos);

            //二回目
            ConnectNetClient.Instance.ReqChangeMeta2CalibMode (2);
            Debug.Log ("Waiting for Space key");
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
            Debug.Log ("first point" + secondCalibPos);

            //計算送信終了
            ConnectNetClient.Instance.PostMetaOffset (CalcMetaPosition ());

        }


        public void SetCaliburationValue ( int num, Vector3 hmdpos, Vector3 hmdrot )
        {
            if ( num == 1 )
            {
                firstCalibPos = hmdpos;
                firstCalibRot = hmdrot;
                Debug.Log ("first val:" + hmdpos);
            }
            else if ( num == 2 )
            {
                secondCalibPos = hmdpos;
                secondCalibRot = hmdrot;
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
                firstPos = info.GetCalibPos ();
                firstPot = info.GetCalibRot ();
            }
            else if ( num == 2 )
            {
                secondPos = info.GetCalibPos ();
                secondPot = info.GetCalibRot ();
            }
            else
            {
                Debug.LogError ("num is out of range:" + num);
            }
        }

        //メタのoffsetを計算して返す
        Vector3 CalcMetaPosition ()
        {
            //TODO:
            return Vector3.zero;
        }

        Quaternion CalcMetaRotationOffset ()
        {
            //TODO:
            return Quaternion.identity;
        }
    }

}