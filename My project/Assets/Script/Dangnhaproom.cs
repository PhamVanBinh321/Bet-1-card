using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class Dangnhaproom : MonoBehaviourPunCallbacks
{
    public TMP_InputField tennguoichoi;


    public void vaophong()
    {
        PhotonNetwork.JoinOrCreateRoom("abc",null,null,null);
        PhotonNetwork.NickName = tennguoichoi.text;
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.LoadLevel("Gameplay");
    }
}
