using UnityEngine;
using Photon.Pun;
using System.Collections;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Quanlynguoichoi : MonoBehaviourPunCallbacks
{
    Gameplay gameplay = Gameplay.Instance;
    PhotonView Pv1;
    public int tien=0;
    public int tiencuocdoithu = 0;
    public int labai = 0;
    public bool thamgiavanbai;
    public bool luotcuatoi;
    public bool thangthua;
    public GameObject datten;
    public GameObject canvans;
    public Button theo;
    public Button bobai;
    public Button tangcuoc;

    void Awake()
    {
        Pv1 = GetComponent<PhotonView>();
        canvans = GameObject.Find("nutdanh");
        // value = gameplay.tiencuocchung;
    }

    /*
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            
            stream.SendNext(tien);
        }
        else
        {
         
            tiencuocdoithu = (int)stream.ReceiveNext();
        }
    }
    */
    public void setbai(ref int labai, int giatriset)
    {
        labai = giatriset;
    }
    /*
    public void hamtheobai()
    {
        
        if (Pv1.IsMine)
        {
            if (luotcuatoi == true)
            {
                luotcuatoi = false;
                //Pv1.RPC("batnutnguoitiep", RpcTarget.OthersBuffered, PhotonNetwork.LocalPlayer.ActorNumber);
                
                Debug.Log("da bam nut theo");
            }
            else
            {
                Debug.Log("chua toi luot cua ban");
            }
        }
         Pv1.RPC("batnutnguoitiep", RpcTarget.OthersBuffered, PhotonNetwork.LocalPlayer.ActorNumber);

    }
    public void hambobai()
    {
        if (luotcuatoi == true)
        {
            
            Pv1.RPC("batnutnguoitiep", RpcTarget.Others, PhotonNetwork.LocalPlayer.ActorNumber);
            luotcuatoi = false;
        }
        else
        {
            Debug.Log("chua toi luot cua ban");
        }
    }
    public void hamtangcuoc()
    {
        if (luotcuatoi == true)
        {
            
            Pv1.RPC("batnutnguoitiep", RpcTarget.Others, PhotonNetwork.LocalPlayer.ActorNumber);
            luotcuatoi = false;
        }
        else
        {
            Debug.Log("chua toi luot cua ban");
        }
    }



    [PunRPC]
    private void batnutnguoitiep(int thutunguoichoidau)
    {
        
            if (thutunguoichoidau + 1 == PhotonNetwork.LocalPlayer.ActorNumber)
            {

                luotcuatoi = true;
                Debug.Log("da toi luot may");
                Debug.Log(luotcuatoi);




            }
        
           
        
       
    }
    */



    public void sinhnguoichoi(int thutunguoichoi)
    {
        if (thutunguoichoi == 1)
        {
            PhotonNetwork.Instantiate("Cube", new Vector3(424, 172, 0), Quaternion.identity);
          /*  canvans.SetActive(true);
            Button theo = canvans.transform.Find("Theo").GetComponent<Button>();
            Button bobai = canvans.transform.Find("Bo").GetComponent<Button>();
            Button tangcuoc = canvans.transform.Find("Cuoc").GetComponent<Button>();
            theo.onClick.AddListener(hamtheobai);
            bobai.onClick.AddListener(hambobai);
            tangcuoc.onClick.AddListener(hamtangcuoc);*/

        }
        else if (thutunguoichoi == 2)
        {
            PhotonNetwork.Instantiate("Cube", new Vector3(289, 258, 0), Quaternion.identity);
         /*   canvans.SetActive(true);
            Button theo = canvans.transform.Find("Theo").GetComponent<Button>();
            Button bobai = canvans.transform.Find("Bo").GetComponent<Button>();
            Button tangcuoc = canvans.transform.Find("Cuoc").GetComponent<Button>();
            theo.onClick.AddListener(hamtheobai);
            bobai.onClick.AddListener(hambobai);
            tangcuoc.onClick.AddListener(hamtangcuoc);
            theo.GetComponent<RectTransform>().anchoredPosition = new Vector2(-430, 243);
            bobai.GetComponent<RectTransform>().anchoredPosition = new Vector2(-343, 243);
            tangcuoc.GetComponent<RectTransform>().anchoredPosition = new Vector2(-255, 243);*/
            
        }
        else if (thutunguoichoi == 3)
        {
            PhotonNetwork.Instantiate("Cube", new Vector3(103, 4, 0), Quaternion.identity);//chua sua, can sua
        }
        else
        {
            PhotonNetwork.Instantiate("Cube", new Vector3(424, 335, 0), Quaternion.identity);
        }
    }
    // Start is called before the first frame update


      
    

    IEnumerator LogEverySixSeconds()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(6f);

            Debug.Log(Gameplay.tiencuocchung);
            Debug.Log(labai);
            Debug.Log(tien);
         //   Debug.Log(luotcuatoi);
        }
    }

    void Start()
    {
        if(Pv1.IsMine)
        {
            
                datten = GameObject.Find("PlayerManager(Clone)");
                datten.name = PhotonNetwork.NickName;
                Debug.Log(PhotonNetwork.NickName);
            
            
            tien = 500;
            sinhnguoichoi(PhotonNetwork.LocalPlayer.ActorNumber);
            StartCoroutine(LogEverySixSeconds());


            if(PhotonNetwork.IsMasterClient)
            {
                luotcuatoi = true;
                
            }
            else
            {
                luotcuatoi= false;
            }
         
        }
        
       
    }

    

    // Update is called once per frame
    void Update()
    {
       
    }
}
