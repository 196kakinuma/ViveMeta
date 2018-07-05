using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IkLibrary.Unity;

namespace ViveMeta.System
{
    public class Caliburation : SingletonMonoBehaviour<Caliburation>
    {
        bool getResp = false;
        bool getKeySpace = false;
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
            if ( Input.GetKeyUp (KeyCode.Space) )
            {
                getKeySpace = true;
            }
        }

        public void Caliburate ()
        {
            StartCoroutine (StartCaliburation ());
        }

        IEnumerator StartCaliburation ()
        {
            Debug.Log ("calibration start");

            //いっかいめ エディタ上で、コントローラの正面がz軸方向に向いていることを確認
            ConnectNetClient.Instance.ReqChangeMeta2CalibMode (1);
            Debug.Log ("Waiting for Space key");
            while ( !getKeySpace )
            {
                yield return new WaitForEndOfFrame ();
            }
            getKeySpace = false;
            ConnectNetClient.Instance.ReqestMetaPosition (1);
            while ( !getResp )
            {
                yield return new WaitForEndOfFrame ();
            }
            getResp = false;
            Debug.Log ("first point" + firstCalibPos);
            Debug.Log ("first rot" + firstCalibRot);

            //二回目
            ConnectNetClient.Instance.ReqChangeMeta2CalibMode (2);
            Debug.Log ("Waiting for Space key");
            while ( !getKeySpace )
            {
                yield return new WaitForEndOfFrame ();
            }
            getKeySpace = false;

            ConnectNetClient.Instance.ReqestMetaPosition (2);
            while ( !getResp )
            {
                yield return new WaitForEndOfFrame ();
            }
            getResp = false;
            Debug.Log ("second point" + secondCalibPos);
            Debug.Log ("second rot" + secondCalibRot);

            //計算送信終了
            ConnectNetClient.Instance.PostMetaOffset (CalcMetaPositionOffset (), CalcMetaRotationOffset ());
            ConnectNetClient.Instance.ReqestMetaPosition (3);

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
                firstPos = info.GetCalibPos (num);
                firstPot = info.GetCalibRot (num);
            }
            else if ( num == 2 )
            {
                secondPos = info.GetCalibPos (num);
                secondPot = info.GetCalibRot (num);
            }
            else
            {
                Debug.LogError ("num is out of range:" + num);
            }
        }

        //メタのoffsetを計算して返す
        Vector3 CalcMetaPositionOffset ()
        {
            var z = firstPos.z - firstCalibPos.z;
            var y1 = firstPos.y - firstCalibPos.y;
            var x = firstPos.x - firstCalibPos.x;
            var y2 = firstPos.y - firstCalibPos.y;

            var y = ( y1 + y2 ) / 2;

            return new Vector3 (x, y, z);
        }

        Quaternion CalcMetaRotationOffset ()
        {
            //TODO:
            return Quaternion.identity;
        }
    }

}