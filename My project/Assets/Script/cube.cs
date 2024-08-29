using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.UI;

public class cube : MonoBehaviourPunCallbacks
{
    public TMP_Text ten;
    public TMP_Text bienhientien;
    [SerializeField] PhotonView Pv;
    public Quanlynguoichoi quanlynguoichoi;
    int tienhientrenban1;
    int tienhientrenban2;
    private void Awake()
    {
        Pv = GetComponent<PhotonView>();
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
                tienhientrenban2 = quanlynguoichoi.tiencuocdoithu;
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
    {
        ten.text = Pv.Owner.NickName;
        
       
    }
    private void LateUpdate()
    {
        
        if(Pv.IsMine)
        {
            hientiencanhan();
            bienhientien.text = tienhientrenban1.ToString() + "$";
        }
        else
        {
            hientiencanhan();
            bienhientien.text = tienhientrenban2.ToString() + "$";
        }
        
       
    }

}
