using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class hienthibai : MonoBehaviourPunCallbacks
{
    PhotonView Pv2;
    public TMP_Text labaichoi;
    int value;
    public Quanlynguoichoi quanlynguoichoi;
    // Start is called before the first frame update
    void Start()
    {
        
        
            GameObject quanlynguoichoiObject = GameObject.Find(PhotonNetwork.LocalPlayer.NickName);

            if (quanlynguoichoiObject != null)
            {

                Quanlynguoichoi quanlynguoichoi = quanlynguoichoiObject.GetComponent<Quanlynguoichoi>();

                if (quanlynguoichoi != null)
                {
                    
                    value = quanlynguoichoi.labai;
                   
                }
                else
                {
                    Debug.LogError("Script Quanlynguoichoi kkhong duoc tim thay tren doi tuong");
                }
            }
            else
            {
                Debug.LogError("Khong tim thay doi tuong");
            }
        
       
    }

    private void Awake()
    {
        Pv2 = GetComponent<PhotonView>();
    }
    // Update is called once per frame
    void Update()
    {
        
        labaichoi.text = value.ToString();
    }
}
