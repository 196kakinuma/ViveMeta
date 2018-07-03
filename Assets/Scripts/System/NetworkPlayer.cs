using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace ViveMeta.System
{
    public class NetworkPlayer : NetworkBehaviour
    {
        public GameObject connectNetPref;

        // Use this for initialization
        void Start ()
        {
            //サーバーでこのオブジェクトを作った人なら
            if ( this.hasAuthority && this.isServer )
            {
                //ordersyncmanager作成
                Debug.Log ("私はサーバです");
            }
            else if ( !this.isServer )
            {
                CmdCreateSyncObject (this.gameObject);
                Debug.Log ("私はクライアントです");
            }
        }

        [Command]
        public void CmdCreateSyncObject ( GameObject games )
        {
            NetworkServer.SpawnWithClientAuthority (Instantiate (connectNetPref), games);
        }


    }
}