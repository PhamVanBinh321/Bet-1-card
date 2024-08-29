using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.UI;
using Unity.VisualScripting;

public class hientien : MonoBehaviourPunCallbacks
{
   
    public TMP_Text bienhientien;
    [SerializeField] PhotonView Pv;
    public GameObject canvashientien;
    public Quanlynguoichoi quanlynguoichoi;
    int tienhientrenban1;
    int tienhientrenban2;


    private void Awake()
    {
        Pv = GetComponent<PhotonView>();
        canvashientien = GameObject.Find("hientiennguoichoi");
    }
    void hientiencanhan()
    {
        GameObject quanlynguoichoiObject = GameObject.Find(PhotonNetwork.LocalPlayer.NickName);

        if (quanlynguoichoiObject != null)
        {

            Quanlynguoichoi quanlynguoichoi = quanlynguoichoiObject.GetComponent<Quanlynguoichoi>();

            if (quanlynguoichoi != null)
            {
                tienhientrenban1 = quanlynguoichoi.tien;
                //tienhientrenban2 = quanlynguoichoi.tiencuocdoithu;
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
    // Start is called before the first frame update
    void Start()
    {/*
        if(PhotonNetwork.LocalPlayer.ActorNumber==1)
        {
            
            TMP_Text bienhientien = canvashientien.transform.Find("hientientext").GetComponent<TMP_Text>();
            bienhientien.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -123);
        }
        if (PhotonNetwork.LocalPlayer.ActorNumber == 2)
        {

            TMP_Text bienhientien = canvashientien.transform.Find("hientientext").GetComponent<TMP_Text>();
            bienhientien.GetComponent<RectTransform>().anchoredPosition = new Vector2(-320, 32);
        }

        */
    }
    private void Update()
    {
        
        
            hientiencanhan();
            bienhientien.text = tienhientrenban1.ToString();
        
       
        

    }

}

