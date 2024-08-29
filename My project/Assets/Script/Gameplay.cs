using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using System.Collections;

public class Gameplay : MonoBehaviourPunCallbacks//, IPunObservable
{
    public static Gameplay Instance;
    public GameObject doichupong;
    public GameObject batdau;
    public static int songuoichoi = 0;
    public Quanlynguoichoi quanlynguoichoi;
    public static int[] bai;
    public static List<int> baidung;
    public  static int tiencuocchung= 0;
    public GameObject hientiencuoc;
    
    public GameObject canvanshienbai;

    public int sotheobai = 0;
    public int sotangcuoc = 0;
    public int sobobai = 0;
    public int sotheodoi = 0;
    public int tiencuoccanhan=0;
    public bool thamgiavanbai;
    public bool luotcuatoi;
    public bool boolbobai;

    public bool doithuvuatangcuoc;

    public GameObject canvans;
    public Button theo;
    public Button bobai;
    public Button tangcuoc;
    PhotonView Pvv;

    //chon bai
    public GameObject atchuon;
    public GameObject atbich;
    public GameObject atro;
    public GameObject atco;

    public GameObject haichuon;
    public GameObject haibich;
    public GameObject hairo;
    public GameObject haico;

    public GameObject bachuon;
    public GameObject babich;
    public GameObject baro;
    public GameObject baco;

    public GameObject bonchuon;
    public GameObject bonbich;
    public GameObject bonro;
    public GameObject bonco;

    public GameObject namchuon;
    public GameObject nambich;
    public GameObject namro;
    public GameObject namco;

    public GameObject sauchuon;
    public GameObject saubich;
    public GameObject sauro;
    public GameObject sauco;

    public GameObject baychuon;
    public GameObject baybich;
    public GameObject bayro;
    public GameObject bayco;

    public GameObject tamchuon;
    public GameObject tambich;
    public GameObject tamro;
    public GameObject tamco;

    public GameObject chinchuon;
    public GameObject chinbich;
    public GameObject chinro;
    public GameObject chinco;

    public GameObject muoichuon;
    public GameObject muoibich;
    public GameObject muoiro;
    public GameObject muoico;

    public GameObject boichuon;
    public GameObject boibich;
    public GameObject boiro;
    public GameObject boico;

    public GameObject damchuon;
    public GameObject dambich;
    public GameObject damro;
    public GameObject damco;

    public GameObject giachuon;
    public GameObject giabich;
    public GameObject giaro;
    public GameObject giaco;



    public Vector3 rotationAngles = new Vector3(180f, 0f, 0f);
    public Vector3 rotationAngles2 = new Vector3(0f, 0f, 0f);
    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;

        Pvv = this.GetComponent<PhotonView>();
        
        hientiencuoc.SetActive(false);

        canvans = GameObject.Find("nutdanh");
    }

    
    public void hamtheobai()
    {
            if (luotcuatoi == true && sotheodoi==0)
            {
                luotcuatoi = false;
                Pvv.RPC("batnutnguoitiep", RpcTarget.Others, PhotonNetwork.LocalPlayer.ActorNumber, PhotonNetwork.CurrentRoom.PlayerCount);
                Debug.Log("da bam nut theo");

                thamgiavanbai = true;

            Pvv.RPC("capnhatsotheodoi",RpcTarget.All);
            Pvv.RPC("capnhatsotheobai", RpcTarget.All);
            /* GameObject quanlynguoichoiObjecttt = GameObject.Find(PhotonNetwork.LocalPlayer.NickName);


             if (quanlynguoichoiObjecttt != null)
             {

                 Quanlynguoichoi quanlynguoichoi = quanlynguoichoiObjecttt.GetComponent<Quanlynguoichoi>();

                 if (quanlynguoichoi != null)
                 {
                     quanlynguoichoi.tien += -10;

                 }
                 else
                 {
                     Debug.LogError("Script Quanlynguoichoi kkhong duoc tim thay tren doi tuong");
                 }
             }
             else
             {
                 Debug.LogError("Khong tim thay doi tuong");
             }*/



        }

            else if(luotcuatoi==true && sotheodoi==1 && sotheobai==1)
            {
            Pvv.RPC("xetbai",RpcTarget.MasterClient);
            }
            else if(luotcuatoi==true&& doithuvuatangcuoc==true)
        {
            doithuvuatangcuoc = false;
            GameObject quanlynguoichoiObjecttt = GameObject.Find(PhotonNetwork.LocalPlayer.NickName);
            if (quanlynguoichoiObjecttt != null)
            {

                Quanlynguoichoi quanlynguoichoi = quanlynguoichoiObjecttt.GetComponent<Quanlynguoichoi>();

                if (quanlynguoichoi != null)
                {
                    quanlynguoichoi.tien += -10;

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
            Pvv.RPC("tangtiencuocchung", RpcTarget.All);
            Pvv.RPC("xetbai", RpcTarget.MasterClient);
        }
        else
            {
                Debug.Log("chua toi luot cua ban");
            }
        

            

    }
    public void hambobai()
    {
        if (luotcuatoi == true)
        {
            luotcuatoi = false;
            Pvv.RPC("batnutnguoitiep", RpcTarget.Others, PhotonNetwork.LocalPlayer.ActorNumber, PhotonNetwork.CurrentRoom.PlayerCount);
            Debug.Log("da bam nut theo");
            thamgiavanbai = false;

            Pvv.RPC("capnhatsotheodoi", RpcTarget.All);
            Pvv.RPC("capnhatbobai", RpcTarget.All);

             Pvv.RPC("hamwin",RpcTarget.Others);
            //quanlynguoichoi.tien += 10;
            Invoke("huybaicuahambobai",2.9f);

            StartCoroutine(DelayedCallsaubo());
        }
        else
        {
            Debug.Log("chua toi luot cua ban");
        }
    }


    void huybaicuahambobai()
    {
        Pvv.RPC("huybaisauwin", RpcTarget.All);
    }
    public void hamtangcuoc()
    {
        if (luotcuatoi == true)
        {
            luotcuatoi = false;
            Pvv.RPC("batnutnguoitiep", RpcTarget.Others, PhotonNetwork.LocalPlayer.ActorNumber, PhotonNetwork.CurrentRoom.PlayerCount);
            Debug.Log("da bam nut theo");
            thamgiavanbai = true;

            Pvv.RPC("capnhatsotheodoi", RpcTarget.All);
            Pvv.RPC("capnhatbooltangcuoc", RpcTarget.Others);

            GameObject quanlynguoichoiObjecttt = GameObject.Find(PhotonNetwork.LocalPlayer.NickName);
            if (quanlynguoichoiObjecttt != null)
            {

                Quanlynguoichoi quanlynguoichoi = quanlynguoichoiObjecttt.GetComponent<Quanlynguoichoi>();

                if (quanlynguoichoi != null)
                {
                    quanlynguoichoi.tien += -10;

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
            Pvv.RPC("tangtiencuocchung",RpcTarget.All);




            }
        else if(luotcuatoi==true && doithuvuatangcuoc==true)
        {
            luotcuatoi = false;
            Pvv.RPC("batnutnguoitiep", RpcTarget.Others, PhotonNetwork.LocalPlayer.ActorNumber, PhotonNetwork.CurrentRoom.PlayerCount);
            Debug.Log("da bam nut theo");
            thamgiavanbai = true;

            Pvv.RPC("capnhatsotheodoi", RpcTarget.All);
            Pvv.RPC("capnhatbooltangcuoc", RpcTarget.Others);

            GameObject quanlynguoichoiObjecttt = GameObject.Find(PhotonNetwork.LocalPlayer.NickName);
            if (quanlynguoichoiObjecttt != null)
            {

                Quanlynguoichoi quanlynguoichoi = quanlynguoichoiObjecttt.GetComponent<Quanlynguoichoi>();

                if (quanlynguoichoi != null)
                {
                    quanlynguoichoi.tien += -20;

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
            Pvv.RPC("tangtiencuocchungcuoc", RpcTarget.All);
            doithuvuatangcuoc=false;
        }
        else
        {
            Debug.Log("chua toi luot cua ban");
        }
    }

    [PunRPC]
    private void tangtiencuocchung()
    {
        tiencuocchung += 10;
    }

    [PunRPC]
    private void tangtiencuocchungcuoc()
    {
        tiencuocchung += 20;
    }

    [PunRPC]
    void xetbai()
    {
        Quaternion rotation = Quaternion.Euler(rotationAngles);
        Quaternion rotation2 = Quaternion.Euler(rotationAngles2);

        switch (bai[0] - 1)
        {
            case 0:
                GameObject haibich1 = PhotonNetwork.Instantiate("2bich", new Vector3(424, 217, 0), rotation);
                haibich1.transform.localScale = new Vector3(300, 300, 1);haibich1.name = "baichungonl";
                break;
            case 1:
                GameObject haichuon1 = PhotonNetwork.Instantiate("2chuon", new Vector3(424, 217,0), rotation);
                haichuon1.transform.localScale = new Vector3(300, 300, 1); haichuon1.name = "baichungonl";
                break;
            case 2:
                GameObject hairo1 = PhotonNetwork.Instantiate("2ro", new Vector3(424, 217, 0), rotation);
                hairo1.transform.localScale = new Vector3(300, 300, 1); hairo1.name = "baichungonl";
                break;
            case 3:
                GameObject haico1 = PhotonNetwork.Instantiate("2co", new Vector3(424, 217, 0), rotation);
                haico1.transform.localScale = new Vector3(300, 300, 1); haico1.name = "baichungonl";
                break;
            case 4:
                GameObject babich1 = PhotonNetwork.Instantiate("3bich", new Vector3(424, 217, 0), rotation);
                babich1.transform.localScale = new Vector3(300, 300, 1); babich1.name = "baichungonl";
                break;
            case 5:
                GameObject bachuon1 = PhotonNetwork.Instantiate("3chuon", new Vector3(424, 217, 0), rotation);
                bachuon1.transform.localScale = new Vector3(300, 300, 1); bachuon1.name = "baichungonl";
                break;
            case 6:
                GameObject baro1 = PhotonNetwork.Instantiate("3ro", new Vector3(424, 217, 0), rotation);
                baro1.transform.localScale = new Vector3(300, 300, 1); baro1.name = "baichungonl";
                break;
            case 7:
                GameObject baco1 = PhotonNetwork.Instantiate("3co", new Vector3(424, 217, 0), rotation);
                baco1.transform.localScale = new Vector3(300, 300, 1); baco1.name = "baichungonl";
                break;
            case 8:
                GameObject bonbich1 = PhotonNetwork.Instantiate("4bich", new Vector3(424, 217, 0), rotation);
                bonbich1.transform.localScale = new Vector3(300, 300, 1); bonbich1.name = "baichungonl";
                break;
            case 9:
                GameObject bonchuon1 = PhotonNetwork.Instantiate("4chuon", new Vector3(424, 217, 0), rotation);
                bonchuon1.transform.localScale = new Vector3(300, 300, 1); bonchuon1.name = "baichungonl";
                break;
            case 10:
                GameObject bonro1 = PhotonNetwork.Instantiate("4ro", new Vector3(424, 217, 0), rotation);
                bonro1.transform.localScale = new Vector3(300, 300, 1); bonro1.name = "baichungonl";
                break;
            case 11:
                GameObject bonco1 = PhotonNetwork.Instantiate("4co", new Vector3(424, 217, 0), rotation);
                bonco1.transform.localScale = new Vector3(300, 300, 1); bonco1.name = "baichungonl";
                break;
            case 12:
                GameObject nambich1 = PhotonNetwork.Instantiate("5bich", new Vector3(424, 217, 0), rotation);
                nambich1.transform.localScale = new Vector3(300, 300, 1); nambich1.name = "baichungonl";
                break;
            case 13:
                GameObject namchuon1 = PhotonNetwork.Instantiate("5chuon", new Vector3(424, 217, 0), rotation);
                namchuon1.transform.localScale = new Vector3(300, 300, 1); namchuon1.name = "baichungonl";
                break;
            case 14:
                GameObject namro1 = PhotonNetwork.Instantiate("5ro", new Vector3(424, 217, 0), rotation);
                namro1.transform.localScale = new Vector3(300, 300, 1); namro1.name = "baichungonl";
                break;
            case 15:
                GameObject namco1 = PhotonNetwork.Instantiate("5co", new Vector3(424, 217, 0), rotation);
                namco1.transform.localScale = new Vector3(300, 300, 1); namco1.name = "baichungonl";
                break;
            case 16:
                GameObject saubich1 = PhotonNetwork.Instantiate("6bich", new Vector3(424, 217, 0), rotation);
                saubich1.transform.localScale = new Vector3(300, 300, 1); saubich1.name = "baichungonl";
                break;
            case 17:
                GameObject sauchuon1 = PhotonNetwork.Instantiate("6chuon", new Vector3(424, 217, 0), rotation);
                sauchuon1.transform.localScale = new Vector3(300, 300, 1); sauchuon1.name = "baichungonl";
                break;
            case 18:
                GameObject sauro1 = PhotonNetwork.Instantiate("6ro", new Vector3(424, 217, 0), rotation);
                sauro1.transform.localScale = new Vector3(300, 300, 1); sauro1.name = "baichungonl";
                break;
            case 19:
                GameObject sauco1 = PhotonNetwork.Instantiate("6co", new Vector3(424, 217, 0), rotation);
                sauco1.transform.localScale = new Vector3(300, 300, 1); sauco1.name = "baichungonl";
                break;
            case 20:
                GameObject baybich1 = PhotonNetwork.Instantiate("7bich", new Vector3(424, 217, 0), rotation);
                baybich1.transform.localScale = new Vector3(300, 300, 1); baybich1.name = "baichungonl";
                break;
            case 21:
                GameObject baychuon1 = PhotonNetwork.Instantiate("7chuon", new Vector3(424, 217, 0), rotation);
                baychuon1.transform.localScale = new Vector3(300, 300, 1); baychuon1.name = "baichungonl";
                break;
            case 22:
                GameObject bayro1 = PhotonNetwork.Instantiate("7ro", new Vector3(424, 217, 0), rotation);
                bayro1.transform.localScale = new Vector3(300, 300, 1); bayro1.name = "baichungonl";
                break;
            case 23:
                GameObject bayco1 = PhotonNetwork.Instantiate("7co", new Vector3(424, 217,0), rotation);
                bayco1.transform.localScale = new Vector3(300, 300, 1); bayco1.name = "baichungonl";
                break;
            case 24:
                GameObject tambich1 = PhotonNetwork.Instantiate("8bich", new Vector3(424, 217, 0), rotation);
                tambich1.transform.localScale = new Vector3(300, 300, 1); tambich1.name = "baichungonl";
                break;
            case 25:
                GameObject tamchuon1 = PhotonNetwork.Instantiate("8chuon", new Vector3(424, 217,0), rotation);
                tamchuon1.transform.localScale = new Vector3(300, 300, 1); tamchuon1.name = "baichungonl";
                break;
            case 26:
                GameObject tamro1 = PhotonNetwork.Instantiate("8ro", new Vector3(424, 217, 0), rotation);
                tamro1.transform.localScale = new Vector3(300, 300, 1); tamro1.name = "baichungonl";
                break;
            case 27:
                GameObject tamco1 = PhotonNetwork.Instantiate("8co", new Vector3(424, 217, 0), rotation);
                tamco1.transform.localScale = new Vector3(300, 300, 1); tamco1.name = "baichungonl";
                break;
            case 28:
                GameObject chinbich1 = PhotonNetwork.Instantiate("9bich", new Vector3(424, 217, 0), rotation);
                chinbich1.transform.localScale = new Vector3(300, 300, 1); chinbich1.name = "baichungonl";
                break;
            case 29:
                GameObject chinchuon1 = PhotonNetwork.Instantiate("9chuon", new Vector3(424, 217, 0), rotation);
                chinchuon1.transform.localScale = new Vector3(300, 300, 1); chinchuon1.name = "baichungonl";
                break;
            case 30:
                GameObject chinro1 = PhotonNetwork.Instantiate("9ro", new Vector3(424, 217, 0), rotation);
                chinro1.transform.localScale = new Vector3(300, 300, 1); chinro1.name = "baichungonl";
                break;
            case 31:
                GameObject chinco1 = PhotonNetwork.Instantiate("9co", new Vector3(424, 217, 0), rotation);
                chinco1.transform.localScale = new Vector3(300, 300, 1); chinco1.name = "baichungonl";
                break;
            case 32:
                GameObject muoibich1 = PhotonNetwork.Instantiate("10bich", new Vector3(424, 217, 0), rotation);
                muoibich1.transform.localScale = new Vector3(300, 300, 1); muoibich1.name = "baichungonl";
                break;
            case 33:
                GameObject muoichuon1 = PhotonNetwork.Instantiate("10chuon", new Vector3(424, 217, 0), rotation);
                muoichuon1.transform.localScale = new Vector3(300, 300, 1); muoichuon1.name = "baichungonl";
                break;
            case 34:
                GameObject muoiro1 = PhotonNetwork.Instantiate("10ro", new Vector3(424, 217, 0), rotation);
                muoiro1.transform.localScale = new Vector3(300, 300, 1); muoiro1.name = "baichungonl";
                break;
            case 35:
                GameObject muoico1 = PhotonNetwork.Instantiate("10co", new Vector3(424, 217, 0), rotation);
                muoico1.transform.localScale = new Vector3(300, 300, 1); muoico1.name = "baichungonl";
                break;
            case 36:
                GameObject boibich1 = PhotonNetwork.Instantiate("Jbich", new Vector3(424, 217, 0), rotation);
                boibich1.transform.localScale = new Vector3(300, 300, 1); boibich1.name = "baichungonl";
                break;
            case 37:
                GameObject boichuon1 = PhotonNetwork.Instantiate("Jchuon", new Vector3(424, 217, 0), rotation);
                boichuon1.transform.localScale = new Vector3(300, 300, 1); boichuon1.name = "baichungonl";
                break;
            case 38:
                GameObject boiro1 = PhotonNetwork.Instantiate("Jro", new Vector3(424, 217, 0), rotation); boiro1.transform.localScale = new Vector3(300, 300, 1); boiro1.name = "baichungonl";
                break;
            case 39:
                GameObject boico1 = PhotonNetwork.Instantiate("Jco", new Vector3(424, 217, 0), rotation); boico1.transform.localScale = new Vector3(300, 300, 1); boico1.name = "baichungonl";
                break;
            case 40:
                GameObject dambich1 = PhotonNetwork.Instantiate("Qbich", new Vector3(424, 217, 0), rotation); dambich1.transform.localScale = new Vector3(300, 300, 1); dambich1.name = "baichungonl";
                break;
            case 41:
                GameObject damchuon1 = PhotonNetwork.Instantiate("Qchuon", new Vector3(424, 217, 0), rotation); damchuon1.transform.localScale = new Vector3(300, 300, 1); damchuon1.name = "baichungonl";
                break;
            case 42:
                GameObject damro1 = PhotonNetwork.Instantiate("Qro", new Vector3(424, 217, 0), rotation); damro1.transform.localScale = new Vector3(300, 300, 1); damro1.name = "baichungonl";
                break;
            case 43:
                GameObject damco1 = PhotonNetwork.Instantiate("Qco", new Vector3(424, 217, 0), rotation); damco1.transform.localScale = new Vector3(300, 300, 1); damco1.name = "baichungonl";
                break;
            case 44:
                GameObject giabich1 = PhotonNetwork.Instantiate("Kbich", new Vector3(424, 217, 0), rotation); giabich1.transform.localScale = new Vector3(300, 300, 1); giabich1.name = "baichungonl";
                break;
            case 45:
                GameObject giachuon1 = PhotonNetwork.Instantiate("Kchuon", new Vector3(424, 217, 0), rotation); giachuon1.transform.localScale = new Vector3(300, 300, 1); giachuon1.name = "baichungonl";
                break;
            case 46:
                GameObject giaro1 = PhotonNetwork.Instantiate("Kro", new Vector3(424, 217, 0), rotation); giaro1.transform.localScale = new Vector3(300, 300, 1); giaro1.name = "baichungonl";
                break;
            case 47:
                GameObject giaco1 = PhotonNetwork.Instantiate("Kco", new Vector3(424, 217, 0), rotation); giaco1.transform.localScale = new Vector3(300, 300, 1); giaco1.name = "baichungonl";
                break;
            case 48:
                GameObject atbich1 = PhotonNetwork.Instantiate("Abich", new Vector3(424, 217, 0), rotation); atbich1.transform.localScale = new Vector3(300, 300, 1); atbich1.name = "baichungonl";
                break;
            case 49:
                GameObject atchuon1 = PhotonNetwork.Instantiate("Achuon", new Vector3(424, 217, 0), rotation); atchuon1.transform.localScale = new Vector3(300, 300, 1); atchuon1.name = "baichungonl";
                break;
            case 50:
                GameObject atro1 = PhotonNetwork.Instantiate("Aro", new Vector3(424, 217, 0), rotation); atro1.transform.localScale = new Vector3(300, 300, 1); atro1.name = "baichungonl";
                break;
            case 51:
                GameObject atco1 = PhotonNetwork.Instantiate("Aco", new Vector3(424, 217, 1), rotation); atco1.transform.localScale = new Vector3(300, 300, 1); atco1.name = "baichungonl";
                break;




        }


        switch (bai[1] - 1)
        {
            case 0:
                GameObject haibich1 = PhotonNetwork.Instantiate("2bich", new Vector3(289, 300, 0), rotation);
                haibich1.transform.localScale = new Vector3(300, 300, 1); haibich1.name = "baichungonl2";
                break;
            case 1:
                GameObject haichuon1 = PhotonNetwork.Instantiate("2chuon", new Vector3(289, 300, 0), rotation);
                haichuon1.transform.localScale = new Vector3(300, 300, 1); haichuon1.name = "baichungonl2";
                break;
            case 2:
                GameObject hairo1 = PhotonNetwork.Instantiate("2ro", new Vector3(289, 300, 0), rotation);
                hairo1.transform.localScale = new Vector3(300, 300, 1); hairo1.name = "baichungonl2";
                break;
            case 3:
                GameObject haico1 = PhotonNetwork.Instantiate("2co", new Vector3(289, 300, 0), rotation);
                haico1.transform.localScale = new Vector3(300, 300, 1); haico1.name = "baichungonl2";
                break;
            case 4:
                GameObject babich1 = PhotonNetwork.Instantiate("3bich", new Vector3(289, 300, 0), rotation);
                babich1.transform.localScale = new Vector3(300, 300, 1); babich1.name = "baichungonl2";
                break;
            case 5:
                GameObject bachuon1 = PhotonNetwork.Instantiate("3chuon", new Vector3(289, 300, 0), rotation);
                bachuon1.transform.localScale = new Vector3(300, 300, 1); bachuon1.name = "baichungonl2";
                break;
            case 6:
                GameObject baro1 = PhotonNetwork.Instantiate("3ro", new Vector3(289, 300, 0), rotation);
                baro1.transform.localScale = new Vector3(300, 300, 1); baro1.name = "baichungonl2";
                break;
            case 7:
                GameObject baco1 = PhotonNetwork.Instantiate("3co", new Vector3(289, 300, 0), rotation);
                baco1.transform.localScale = new Vector3(300, 300, 1); baco1.name = "baichungonl2";
                break;
            case 8:
                GameObject bonbich1 = PhotonNetwork.Instantiate("4bich", new Vector3(289, 300, 0), rotation);
                bonbich1.transform.localScale = new Vector3(300, 300, 1); bonbich1.name = "baichungonl2";
                break;
            case 9:
                GameObject bonchuon1 = PhotonNetwork.Instantiate("4chuon", new Vector3(289, 300, 0), rotation);
                bonchuon1.transform.localScale = new Vector3(300, 300, 1); bonchuon1.name = "baichungonl2";
                break;
            case 10:
                GameObject bonro1 = PhotonNetwork.Instantiate("4ro", new Vector3(289, 300, 0), rotation);
                bonro1.transform.localScale = new Vector3(300, 300, 1); bonro1.name = "baichungonl2";
                break;
            case 11:
                GameObject bonco1 = PhotonNetwork.Instantiate("4co", new Vector3(289, 300, 0), rotation);
                bonco1.transform.localScale = new Vector3(300, 300, 1); bonco1.name = "baichungonl2";
                break;
            case 12:
                GameObject nambich1 = PhotonNetwork.Instantiate("5bich", new Vector3(289, 300, 0), rotation);
                nambich1.transform.localScale = new Vector3(300, 300, 1); nambich1.name = "baichungonl2";
                break;
            case 13:
                GameObject namchuon1 = PhotonNetwork.Instantiate("5chuon", new Vector3(289, 300, 0), rotation);
                namchuon1.transform.localScale = new Vector3(300, 300, 1); namchuon1.name = "baichungonl2";
                break;
            case 14:
                GameObject namro1 = PhotonNetwork.Instantiate("5ro", new Vector3(289, 300, 0), rotation);
                namro1.transform.localScale = new Vector3(300, 300, 1); namro1.name = "baichungonl2";
                break;
            case 15:
                GameObject namco1 = PhotonNetwork.Instantiate("5co", new Vector3(289, 300, 0), rotation);
                namco1.transform.localScale = new Vector3(300, 300, 1); namco1.name = "baichungonl2";
                break;
            case 16:
                GameObject saubich1 = PhotonNetwork.Instantiate("6bich", new Vector3(289, 300, 0), rotation);
                saubich1.transform.localScale = new Vector3(300, 300, 1); saubich1.name = "baichungonl2";
                break;
            case 17:
                GameObject sauchuon1 = PhotonNetwork.Instantiate("6chuon", new Vector3(289, 300, 0), rotation);
                sauchuon1.transform.localScale = new Vector3(300, 300, 1); sauchuon1.name = "baichungonl2";
                break;
            case 18:
                GameObject sauro1 = PhotonNetwork.Instantiate("6ro", new Vector3(289, 300, 0), rotation);
                sauro1.transform.localScale = new Vector3(300, 300, 1); sauro1.name = "baichungonl2";
                break;
            case 19:
                GameObject sauco1 = PhotonNetwork.Instantiate("6co", new Vector3(289, 300, 0), rotation);
                sauco1.transform.localScale = new Vector3(300, 300, 1); sauco1.name = "baichungonl2";
                break;
            case 20:
                GameObject baybich1 = PhotonNetwork.Instantiate("7bich", new Vector3(289, 300, 0), rotation);
                baybich1.transform.localScale = new Vector3(300, 300, 1); baybich1.name = "baichungonl2";
                break;
            case 21:
                GameObject baychuon1 = PhotonNetwork.Instantiate("7chuon", new Vector3(289, 300, 0), rotation);
                baychuon1.transform.localScale = new Vector3(300, 300, 1); baychuon1.name = "baichungonl2";
                break;
            case 22:
                GameObject bayro1 = PhotonNetwork.Instantiate("7ro", new Vector3(289, 300, 0), rotation);
                bayro1.transform.localScale = new Vector3(300, 300, 1); bayro1.name = "baichungonl2";
                break;
            case 23:
                GameObject bayco1 = PhotonNetwork.Instantiate("7co", new Vector3(289, 300, 0), rotation);
                bayco1.transform.localScale = new Vector3(300, 300, 1); bayco1.name = "baichungonl2";
                break;
            case 24:
                GameObject tambich1 = PhotonNetwork.Instantiate("8bich", new Vector3(289, 300, 0), rotation);
                tambich1.transform.localScale = new Vector3(300, 300, 1); tambich1.name = "baichungonl2";
                break;
            case 25:
                GameObject tamchuon1 = PhotonNetwork.Instantiate("8chuon", new Vector3(289, 300, 0), rotation);
                tamchuon1.transform.localScale = new Vector3(300, 300, 1); tamchuon1.name = "baichungonl2";
                break;
            case 26:
                GameObject tamro1 = PhotonNetwork.Instantiate("8ro", new Vector3(289, 300, 0), rotation);
                tamro1.transform.localScale = new Vector3(300, 300, 1); tamro1.name = "baichungonl2";
                break;
            case 27:
                GameObject tamco1 = PhotonNetwork.Instantiate("8co", new Vector3(289, 300, 0), rotation);
                tamco1.transform.localScale = new Vector3(300, 300, 1); tamco1.name = "baichungonl2";
                break;
            case 28:
                GameObject chinbich1 = PhotonNetwork.Instantiate("9bich", new Vector3(289, 300, 0), rotation);
                chinbich1.transform.localScale = new Vector3(300, 300, 1); chinbich1.name = "baichungonl2";
                break;
            case 29:
                GameObject chinchuon1 = PhotonNetwork.Instantiate("9chuon", new Vector3(289, 300, 0), rotation);
                chinchuon1.transform.localScale = new Vector3(300, 300, 1); chinchuon1.name = "baichungonl2";
                break;
            case 30:
                GameObject chinro1 = PhotonNetwork.Instantiate("9ro", new Vector3(289, 300, 0), rotation);
                chinro1.transform.localScale = new Vector3(300, 300, 1); chinro1.name = "baichungonl2";
                break;
            case 31:
                GameObject chinco1 = PhotonNetwork.Instantiate("9co", new Vector3(289, 300, 0), rotation);
                chinco1.transform.localScale = new Vector3(300, 300, 1); chinco1.name = "baichungonl2";
                break;
            case 32:
                GameObject muoibich1 = PhotonNetwork.Instantiate("10bich", new Vector3(289, 300, 0), rotation);
                muoibich1.transform.localScale = new Vector3(300, 300, 1); muoibich1.name = "baichungonl2";
                break;
            case 33:
                GameObject muoichuon1 = PhotonNetwork.Instantiate("10chuon", new Vector3(289, 300, 0), rotation);
                muoichuon1.transform.localScale = new Vector3(300, 300, 1); muoichuon1.name = "baichungonl2";
                break;
            case 34:
                GameObject muoiro1 = PhotonNetwork.Instantiate("10ro", new Vector3(289, 300, 0), rotation);
                muoiro1.transform.localScale = new Vector3(300, 300, 1); muoiro1.name = "baichungonl2";
                break;
            case 35:
                GameObject muoico1 = PhotonNetwork.Instantiate("10co", new Vector3(289, 300, 0), rotation);
                muoico1.transform.localScale = new Vector3(300, 300, 1); muoico1.name = "baichungonl2";
                break;
            case 36:
                GameObject boibich1 = PhotonNetwork.Instantiate("Jbich", new Vector3(289, 300, 0), rotation);
                boibich1.transform.localScale = new Vector3(300, 300, 1); boibich1.name = "baichungonl2";
                break;
            case 37:
                GameObject boichuon1 = PhotonNetwork.Instantiate("Jchuon", new Vector3(289, 300, 0), rotation);
                boichuon1.transform.localScale = new Vector3(300, 300, 1); boichuon1.name = "baichungonl2";
                break;
            case 38:
                GameObject boiro1 = PhotonNetwork.Instantiate("Jro", new Vector3(289, 300, 0), rotation); boiro1.transform.localScale = new Vector3(300, 300, 1); boiro1.name = "baichungonl2";
                break;
            case 39:
                GameObject boico1 = PhotonNetwork.Instantiate("Jco", new Vector3(289, 300, 0), rotation); boico1.transform.localScale = new Vector3(300, 300, 1); boico1.name = "baichungonl2";
                break;
            case 40:
                GameObject dambich1 = PhotonNetwork.Instantiate("Qbich", new Vector3(289, 300, 0), rotation); dambich1.transform.localScale = new Vector3(300, 300, 1); dambich1.name = "baichungonl2";
                break;
            case 41:
                GameObject damchuon1 = PhotonNetwork.Instantiate("Qchuon", new Vector3(289, 300, 0), rotation); damchuon1.transform.localScale = new Vector3(300, 300, 1); damchuon1.name = "baichungonl2";
                break;
            case 42:
                GameObject damro1 = PhotonNetwork.Instantiate("Qro", new Vector3(289, 300, 0), rotation); damro1.transform.localScale = new Vector3(300, 300, 1); damro1.name = "baichungonl2";
                break;
            case 43:
                GameObject damco1 = PhotonNetwork.Instantiate("Qco", new Vector3(289, 300, 0), rotation); damco1.transform.localScale = new Vector3(300, 300, 1); damco1.name = "baichungonl2";
                break;
            case 44:
                GameObject giabich1 = PhotonNetwork.Instantiate("Kbich", new Vector3(289, 300, 0), rotation); giabich1.transform.localScale = new Vector3(300, 300, 1); giabich1.name = "baichungonl2";
                break;
            case 45:
                GameObject giachuon1 = PhotonNetwork.Instantiate("Kchuon", new Vector3(289, 300, 0), rotation); giachuon1.transform.localScale = new Vector3(300, 300, 1); giachuon1.name = "baichungonl2";
                break;
            case 46:
                GameObject giaro1 = PhotonNetwork.Instantiate("Kro", new Vector3(289, 300, 0), rotation); giaro1.transform.localScale = new Vector3(300, 300, 1); giaro1.name = "baichungonl2";
                break;
            case 47:
                GameObject giaco1 = PhotonNetwork.Instantiate("Kco", new Vector3(289, 300, 0), rotation); giaco1.transform.localScale = new Vector3(300, 300, 1); giaco1.name = "baichungonl2";
                break;
            case 48:
                GameObject atbich1 = PhotonNetwork.Instantiate("Abich", new Vector3(289, 300, 0), rotation); atbich1.transform.localScale = new Vector3(300, 300, 1); atbich1.name = "baichungonl2";
                break;
            case 49:
                GameObject atchuon1 = PhotonNetwork.Instantiate("Achuon", new Vector3(289, 300, 0), rotation); atchuon1.transform.localScale = new Vector3(300, 300, 1); atchuon1.name = "baichungonl2";
                break;
            case 50:
                GameObject atro1 = PhotonNetwork.Instantiate("Aro", new Vector3(289, 300, 0), rotation); atro1.transform.localScale = new Vector3(300, 300, 1); atro1.name = "baichungonl2";
                break;
            case 51:
                GameObject atco1 = PhotonNetwork.Instantiate("Aco", new Vector3(289, 300, 1), rotation); atco1.transform.localScale = new Vector3(300, 300, 1); atco1.name = "baichungonl2";
                break;




        }
        if (bai[0] > bai[1])
        {
            hamwin();
        }
        else
        {
            Pvv.RPC("guirpcxetbai",RpcTarget.Others);

            
        }
        StartCoroutine(DelayedCall());
       
    }

    [PunRPC]
    void huybaicahaionl()
    {
        GameObject bai1 = GameObject.Find("baichungonl");
        GameObject bai2 = GameObject.Find("baichungonl2");
        PhotonNetwork.Destroy(bai1);
        PhotonNetwork.Destroy(bai2);
    }

   

    private IEnumerator DelayedCall()
    {
        // doi 3 giay
        yield return new WaitForSeconds(3f);
        // cai dat ham o duoi


        Pvv.RPC("huybaisauwin",RpcTarget.All);
        Pvv.RPC("huybaicahaionl", RpcTarget.MasterClient);
        Debug.Log("dagui666666");
        Pvv.RPC("hamresetchisosauwin",RpcTarget.All);
        batdaugame();
      
    }

    private IEnumerator DelayedCallsaubo()
    {
        // doi 3 giay
        yield return new WaitForSeconds(3f);
        // cai dat ham o duoi

        /*
        Pvv.RPC("huybaisauwin", RpcTarget.All);
        Pvv.RPC("huybaicahaionl", RpcTarget.MasterClient);
        Debug.Log("dagui666666");*/
        Pvv.RPC("hamresetchisosauwin", RpcTarget.All);
        batdaugame();

    }

    [PunRPC]
    void hamresetchisosauwin()
    {
        sotheobai = 0;
        sotangcuoc = 0;
        sobobai = 0;
        sotheodoi = 0;
    }


    [PunRPC]
    void guirpcxetbai()
    {
        
            hamwin();
        
    }

    [PunRPC]
    private void batnutnguoitiep(int thutunguoichoidau,int songuoichoitrongphong)
    {

        if (thutunguoichoidau + 1 == PhotonNetwork.LocalPlayer.ActorNumber)
        {

            luotcuatoi = true;
            Debug.Log("da toi luot may");
            Debug.Log(luotcuatoi);

        }
        
        if(songuoichoitrongphong == thutunguoichoidau)
        {
            if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
            {

                luotcuatoi = true;
                Debug.Log("da toi luot may");
                Debug.Log(luotcuatoi);
                Debug.Log("da nhan duoc dau tien");
            }

            Debug.Log("da nhan duoc rpc");
        }



    }

    [PunRPC]
    private void batnutnguoidautien()
    {
        if ( PhotonNetwork.LocalPlayer.ActorNumber == 1)
        {

            luotcuatoi = true;
            Debug.Log("da toi luot may");
            Debug.Log(luotcuatoi);
            Debug.Log("da nhan duoc dau tien");
        }
    }

    [PunRPC]
    private void capnhatsotheodoi()
    {
        sotheodoi++;
    }

    [PunRPC]
    private void capnhatbooltangcuoc()
    {
        doithuvuatangcuoc = true;
    }

    [PunRPC]
    private void capnhatsotheobai()
    {
        sotheobai++;
    }

    [PunRPC]
    private void capnhatbobai()
    {
        sobobai++;
    }
    [PunRPC]
    void hamresettiencuocchung()
    {
        tiencuocchung = 0;
    }
    [PunRPC]
    public void hamwin()
    {
        GameObject quanlynguoichoiObject = GameObject.Find(PhotonNetwork.LocalPlayer.NickName);

        if (quanlynguoichoiObject != null)
        {

            Quanlynguoichoi quanlynguoichoi = quanlynguoichoiObject.GetComponent<Quanlynguoichoi>();

            if (quanlynguoichoi != null)
            {
                quanlynguoichoi.tien += tiencuocchung;
                Pvv.RPC("hamresettiencuocchung", RpcTarget.All);
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
        
       
            GameObject canvaswin = PhotonNetwork.Instantiate("hienwin", new Vector3(), Quaternion.identity);
           // GameObject newCanvas = Instantiate(canvanshienbai);
            TMP_Text chuwin = canvaswin.transform.Find("hienthichuwin").GetComponent<TMP_Text>();

            switch (PhotonNetwork.LocalPlayer.ActorNumber)
            {
                case 1:
                    chuwin.GetComponent<RectTransform>().anchoredPosition = new Vector2(62, -41);
                Debug.Log("vaohamdoicho1");
                    break;
                case 2:
                    chuwin.GetComponent<RectTransform>().anchoredPosition = new Vector2(-274, 165);
                Debug.Log("vaohamdoicho1");
                break;
                default:
                    break;
            }
        Invoke("CallDestroyGameObject",2.8f);

        
    }

    void CallDestroyGameObject()
    {
   
        GameObject canvaswin = GameObject.Find("hienwin(Clone)");

       
        DestroyGameObject(canvaswin);
    }

    void DestroyGameObject(GameObject objToDestroy)
    {
    
        if (objToDestroy != null)
        {
        
            PhotonNetwork.Destroy(objToDestroy);
        }
    }
    






    public void sinhnguoichoi(int thutunguoichoi)
    {
        if (thutunguoichoi == 1)
        {
           // PhotonNetwork.Instantiate("Cube", new Vector3(424, 172, 0), Quaternion.identity);
            canvans.SetActive(true);
            Button theo = canvans.transform.Find("Theo").GetComponent<Button>();
            Button bobai = canvans.transform.Find("Bo").GetComponent<Button>();
            Button tangcuoc = canvans.transform.Find("Cuoc").GetComponent<Button>();
            theo.onClick.AddListener(hamtheobai);
            bobai.onClick.AddListener(hambobai);
            tangcuoc.onClick.AddListener(hamtangcuoc);

        }
        else if (thutunguoichoi == 2)
        {
            //PhotonNetwork.Instantiate("Cube", new Vector3(289, 258, 0), Quaternion.identity);
            canvans.SetActive(true);
            Button theo = canvans.transform.Find("Theo").GetComponent<Button>();
            Button bobai = canvans.transform.Find("Bo").GetComponent<Button>();
            Button tangcuoc = canvans.transform.Find("Cuoc").GetComponent<Button>();
            theo.onClick.AddListener(hamtheobai);
            bobai.onClick.AddListener(hambobai);
            tangcuoc.onClick.AddListener(hamtangcuoc);
            theo.GetComponent<RectTransform>().anchoredPosition = new Vector2(-430, 243);
            bobai.GetComponent<RectTransform>().anchoredPosition = new Vector2(-343, 243);
            tangcuoc.GetComponent<RectTransform>().anchoredPosition = new Vector2(-255, 243);

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



    [PunRPC]
    void hienthibaithat()
    {
        Quaternion rotation = Quaternion.Euler(rotationAngles);
        Quaternion rotation2 = Quaternion.Euler(rotationAngles2);
        if (PhotonNetwork.LocalPlayer.ActorNumber==1)
        {
            switch(bai[0]-1)
            {
                case 0:
                   GameObject haibich1 = Instantiate(haibich,new Vector3(424,217,1), rotation);
                    haibich1.transform.localScale = new Vector3(300, 300, 1);
                    haibich1.name = "baicuatoioff";

                    break;
                case 1:
                    GameObject haichuon1 = Instantiate(haichuon, new Vector3(424, 217, 1), rotation);
                    haichuon1.transform.localScale = new Vector3(300, 300, 1);
                    haichuon1.name = "baicuatoioff";
                    break;
                case 2:
                    GameObject hairo1 = Instantiate(hairo, new Vector3(424, 217, 1), rotation);
                    hairo1.transform.localScale = new Vector3(300, 300, 1);
                    hairo1.name = "baicuatoioff";
                    break;
                case 3:
                    GameObject haico1 = Instantiate(haico, new Vector3(424, 217, 1), rotation);
                    haico1.transform.localScale = new Vector3(300, 300, 1);
                    haico1.name = "baicuatoioff";
                    break;
                case 4:
                    GameObject babich1 = Instantiate(babich, new Vector3(424, 217, 1), rotation);
                    babich1.transform.localScale = new Vector3(300, 300, 1); babich1.name = "baicuatoioff";
                    break;
                case 5:
                    GameObject bachuon1 = Instantiate(bachuon, new Vector3(424, 217, 1), rotation);
                    bachuon1.transform.localScale = new Vector3(300, 300, 1); bachuon1.name = "baicuatoioff";
                    break;
                case 6:
                    GameObject baro1 = Instantiate(baro, new Vector3(424, 217, 1), rotation);
                    baro1.transform.localScale = new Vector3(300, 300, 1); baro1.name = "baicuatoioff";
                    break;
                case 7:
                    GameObject baco1 = Instantiate(baco, new Vector3(424, 217, 1), rotation);
                    baco1.transform.localScale = new Vector3(300, 300, 1); baco1.name = "baicuatoioff";
                    break;
                case 8:
                    GameObject bonbich1 = Instantiate(bonbich, new Vector3(424, 217, 1), rotation);
                    bonbich1.transform.localScale = new Vector3(300, 300, 1); bonbich1.name = "baicuatoioff";
                    break;
                case 9:
                    GameObject bonchuon1 = Instantiate(bonchuon, new Vector3(424, 217, 1), rotation);
                    bonchuon1.transform.localScale = new Vector3(300, 300, 1); bonchuon1.name = "baicuatoioff";
                    break;
                case 10:
                    GameObject bonro1 = Instantiate(bonro, new Vector3(424, 217, 1), rotation);
                    bonro1.transform.localScale = new Vector3(300, 300, 1); bonro1.name = "baicuatoioff";
                    break;
                case 11:
                    GameObject bonco1 = Instantiate(bonco, new Vector3(424, 217, 1), rotation);
                    bonco1.transform.localScale = new Vector3(300, 300, 1); bonco1.name = "baicuatoioff";
                    break;
                case 12:
                    GameObject nambich1 = Instantiate(nambich, new Vector3(424, 217, 1), rotation);
                    nambich1.transform.localScale = new Vector3(300, 300, 1); nambich1.name = "baicuatoioff";
                    break;
                case 13:
                    GameObject namchuon1 = Instantiate(namchuon, new Vector3(424, 217, 1), rotation);
                    namchuon1.transform.localScale = new Vector3(300, 300, 1); namchuon1.name = "baicuatoioff";
                    break;
                case 14:
                    GameObject namro1 = Instantiate(namro, new Vector3(424, 217, 1), rotation);
                    namro1.transform.localScale = new Vector3(300, 300, 1); namro1.name = "baicuatoioff";
                    break;
                case 15:
                    GameObject namco1 = Instantiate(namco, new Vector3(424, 217, 1), rotation);
                    namco1.transform.localScale = new Vector3(300, 300, 1); namco1.name = "baicuatoioff";
                    break;
                case 16:
                    GameObject saubich1 = Instantiate(saubich, new Vector3(424, 217, 1), rotation);
                    saubich1.transform.localScale = new Vector3(300, 300, 1); saubich1.name = "baicuatoioff";
                    break;
                case 17:
                    GameObject sauchuon1 = Instantiate(sauchuon, new Vector3(424, 217, 1), rotation);
                    sauchuon1.transform.localScale = new Vector3(300, 300, 1); sauchuon1.name = "baicuatoioff";
                    break;
                case 18:
                    GameObject sauro1 = Instantiate(sauro, new Vector3(424, 217, 1), rotation);
                    sauro1.transform.localScale = new Vector3(300, 300, 1); sauro1.name = "baicuatoioff";
                    break;
                case 19:
                    GameObject sauco1 = Instantiate(sauco, new Vector3(424, 217, 1), rotation);
                    sauco1.transform.localScale = new Vector3(300, 300, 1); sauco1.name = "baicuatoioff";
                    break;
                case 20:
                    GameObject baybich1 = Instantiate(baybich, new Vector3(424, 217, 1), rotation);
                    baybich1.transform.localScale = new Vector3(300, 300, 1); baybich1.name = "baicuatoioff";
                    break;
                case 21:
                    GameObject baychuon1 = Instantiate(baychuon, new Vector3(424, 217, 1), rotation);
                    baychuon1.transform.localScale = new Vector3(300, 300, 1); baychuon1.name = "baicuatoioff";
                    break;
                case 22:
                    GameObject bayro1 = Instantiate(bayro, new Vector3(424, 217, 1), rotation);
                    bayro1.transform.localScale = new Vector3(300, 300, 1); bayro1.name = "baicuatoioff";
                    break;
                case 23:
                    GameObject bayco1 = Instantiate(bayco, new Vector3(424, 217, 1), rotation);
                    bayco1.transform.localScale = new Vector3(300, 300, 1); bayco1.name = "baicuatoioff";
                    break;
                case 24:
                    GameObject tambich1 = Instantiate(tambich, new Vector3(424, 217, 1), rotation);
                    tambich1.transform.localScale = new Vector3(300, 300, 1); tambich1.name = "baicuatoioff";
                    break;
                case 25:
                    GameObject tamchuon1 = Instantiate(tamchuon, new Vector3(424, 217, 1), rotation);
                    tamchuon1.transform.localScale = new Vector3(300, 300, 1); tamchuon1.name = "baicuatoioff";
                    break;
                case 26:
                    GameObject tamro1 = Instantiate(tamro, new Vector3(424, 217, 1), rotation);
                    tamro1.transform.localScale = new Vector3(300, 300, 1); tamro1.name = "baicuatoioff";
                    break;
                case 27:
                    GameObject tamco1 = Instantiate(tamco, new Vector3(424, 217, 1), rotation);
                    tamco1.transform.localScale = new Vector3(300, 300,1); tamco1.name = "baicuatoioff";
                    break;
                case 28:
                    GameObject chinbich1 = Instantiate(chinbich, new Vector3(424, 217, 1), rotation);
                    chinbich1.transform.localScale = new Vector3(300, 300, 1); chinbich1.name = "baicuatoioff";
                    break;
                case 29:
                    GameObject chinchuon1 = Instantiate(chinchuon, new Vector3(424, 217, 1), rotation);
                    chinchuon1.transform.localScale = new Vector3(300, 300, 1); chinchuon1.name = "baicuatoioff";
                    break;
                case 30:
                    GameObject chinro1 = Instantiate(chinro, new Vector3(424, 217, 1), rotation);
                    chinro1.transform.localScale = new Vector3(300, 300, 1); chinro1.name = "baicuatoioff";
                    break;
                case 31:
                    GameObject chinco1 = Instantiate(chinco, new Vector3(424, 217, 1), rotation);
                    chinco1.transform.localScale = new Vector3(300, 300, 1); chinco1.name = "baicuatoioff";
                    break;
                case 32:
                    GameObject muoibich1 = Instantiate(muoibich, new Vector3(424, 217, 1), rotation);
                    muoibich1.transform.localScale = new Vector3(300, 300, 1); muoibich1.name = "baicuatoioff";
                    break;
                case 33:
                    GameObject muoichuon1 = Instantiate(muoichuon, new Vector3(424, 217, 1), rotation);
                    muoichuon1.transform.localScale = new Vector3(300, 300, 1); muoichuon1.name = "baicuatoioff";
                    break;
                case 34:
                    GameObject muoiro1 = Instantiate(muoiro, new Vector3(424, 217, 1), rotation);
                    muoiro1.transform.localScale = new Vector3(300, 300, 1); muoiro1.name = "baicuatoioff";
                    break;
                case 35:
                    GameObject muoico1 = Instantiate(muoico, new Vector3(424, 217, 1), rotation);
                    muoico1.transform.localScale = new Vector3(300, 300, 1); muoico1.name = "baicuatoioff";
                    break;
                case 36:
                    GameObject boibich1 = Instantiate(boibich, new Vector3(424, 217, 1), rotation);
                    boibich1.transform.localScale = new Vector3(300, 300, 1); boibich1.name = "baicuatoioff";
                    break;
                case 37:
                    GameObject boichuon1 = Instantiate(boichuon, new Vector3(424, 217, 1), rotation);
                    boichuon1.transform.localScale = new Vector3(300, 300, 1); boichuon1.name = "baicuatoioff";
                    break;
                case 38:
                    GameObject boiro1 = Instantiate(boiro, new Vector3(424, 217, 1), rotation); boiro1.transform.localScale = new Vector3(300, 300,1); boiro1.name = "baicuatoioff";
                    break;
                case 39:
                    GameObject boico1 = Instantiate(boico, new Vector3(424, 217, 1), rotation); boico1.transform.localScale = new Vector3(300, 300, 1); boico1.name = "baicuatoioff";
                    break;
                case 40:
                    GameObject dambich1 = Instantiate(dambich, new Vector3(424, 217, 1), rotation); dambich1.transform.localScale = new Vector3(300, 300,1); dambich1.name = "baicuatoioff";
                    break;
                case 41:
                    GameObject damchuon1 = Instantiate(damchuon, new Vector3(424, 217, 1), rotation); damchuon1.transform.localScale = new Vector3(300, 300, 1); damchuon1.name = "baicuatoioff";
                    break;
                case 42:
                    GameObject damro1 = Instantiate(damro, new Vector3(424, 217, 1), rotation); damro1.transform.localScale = new Vector3(300, 300, 1); damro1.name = "baicuatoioff";
                    break;
                case 43:
                    GameObject damco1 = Instantiate(damco, new Vector3(424, 217, 1), rotation); damco1.transform.localScale = new Vector3(300, 300, 1); damco1.name = "baicuatoioff";
                    break;
                case 44:
                    GameObject giabich1 = Instantiate(giabich, new Vector3(424, 217, 1), rotation); giabich1.transform.localScale = new Vector3(300, 300, 1); giabich1.name = "baicuatoioff";
                    break;
                case 45:
                    GameObject giachuon1 = Instantiate(giachuon, new Vector3(424, 217, 1), rotation); giachuon1.transform.localScale = new Vector3(300, 300, 1); giachuon1.name = "baicuatoioff";
                    break;
                case 46:
                    GameObject giaro1 = Instantiate(giaro, new Vector3(424, 217, 1), rotation); giaro1.transform.localScale = new Vector3(300, 300, 1); giaro1.name = "baicuatoioff";
                    break;
                case 47:
                    GameObject giaco1 = Instantiate(giaco, new Vector3(424, 217, 1), rotation); giaco1.transform.localScale = new Vector3(300, 300, 1); giaco1.name = "baicuatoioff";
                    break;
                case 48:
                    GameObject atbich1 = Instantiate(atbich, new Vector3(424, 217, 1), rotation); atbich1.transform.localScale = new Vector3(300, 300, 1); atbich1.name = "baicuatoioff";
                    break;
                case 49:
                    GameObject atchuon1 = Instantiate(atchuon, new Vector3(424, 217, 1), rotation); atchuon1.transform.localScale = new Vector3(300, 300, 1); atchuon1.name = "baicuatoioff";
                    break;
                case 50:
                    GameObject atro1 = Instantiate(atro, new Vector3(424, 217, 1), rotation); atro1.transform.localScale = new Vector3(300, 300, 1); atro1.name = "baicuatoioff";
                    break;
                case 51:
                    GameObject atco1 = Instantiate(atco, new Vector3(424, 217, 1), rotation); atco1.transform.localScale = new Vector3(300, 300, 1); atco1.name = "baicuatoioff";
                    break;
                



            }
            GameObject atcoo1 = Instantiate(atco, new Vector3(289, 300, 1), rotation2); atcoo1.transform.localScale = new Vector3(300, 300, 1); atcoo1.name = "baicuatoionl";
        }


      


        if (PhotonNetwork.LocalPlayer.ActorNumber == 2)
        {
            int value;
            GameObject quanlynguoichoiObject = GameObject.Find(PhotonNetwork.LocalPlayer.NickName);

           
                Quanlynguoichoi quanlynguoichoi = quanlynguoichoiObject.GetComponent<Quanlynguoichoi>();

               
                    value = quanlynguoichoi.labai;

            switch (value - 1)
            {
                case 0:
                    GameObject haibich1 = Instantiate(haibich, new Vector3(289, 300, 1), rotation);
                    haibich1.transform.localScale = new Vector3(300, 300, 1); haibich1.name = "baicuatoioff";
                    break;
                case 1:
                    GameObject haichuon1 = Instantiate(haichuon, new Vector3(289, 300, 1), rotation);
                    haichuon1.transform.localScale = new Vector3(300, 300, 1); haichuon1.name = "baicuatoioff";
                    break;
                case 2:
                    GameObject hairo1 = Instantiate(hairo, new Vector3(289, 300, 1), rotation);
                    hairo1.transform.localScale = new Vector3(300, 300, 1); hairo1.name = "baicuatoioff";
                    break;
                case 3:
                    GameObject haico1 = Instantiate(haico, new Vector3(289, 300, 1), rotation);
                    haico1.transform.localScale = new Vector3(300, 300, 1); haico1.name = "baicuatoioff";
                    break;
                case 4:
                    GameObject babich1 = Instantiate(babich, new Vector3(289, 300, 1), rotation);
                    babich1.transform.localScale = new Vector3(300, 300, 1); babich1.name = "baicuatoioff";
                    break;
                case 5:
                    GameObject bachuon1 = Instantiate(bachuon, new Vector3(289, 300, 1), rotation);
                    bachuon1.transform.localScale = new Vector3(300, 300, 1); bachuon1.name = "baicuatoioff";
                    break;
                case 6:
                    GameObject baro1 = Instantiate(baro, new Vector3(289, 300, 1), rotation);
                    baro1.transform.localScale = new Vector3(300, 300, 1); baro1.name = "baicuatoioff";
                    break;
                case 7:
                    GameObject baco1 = Instantiate(baco, new Vector3(289, 300, 1), rotation);
                    baco1.transform.localScale = new Vector3(300, 300, 1); baco1.name = "baicuatoioff";
                    break;
                case 8:
                    GameObject bonbich1 = Instantiate(bonbich, new Vector3(289, 300, 1), rotation);
                    bonbich1.transform.localScale = new Vector3(300, 300, 1); bonbich1.name = "baicuatoioff";
                    break;
                case 9:
                    GameObject bonchuon1 = Instantiate(bonchuon, new Vector3(289, 300, 1), rotation);
                    bonchuon1.transform.localScale = new Vector3(300, 300, 1); bonchuon1.name = "baicuatoioff";
                    break;
                case 10:
                    GameObject bonro1 = Instantiate(bonro, new Vector3(289, 300, 1), rotation);
                    bonro1.transform.localScale = new Vector3(300, 300, 1); bonro1.name = "baicuatoioff";
                    break;
                case 11:
                    GameObject bonco1 = Instantiate(bonco, new Vector3(289, 300, 1), rotation);
                    bonco1.transform.localScale = new Vector3(300, 300, 1); bonco1.name = "baicuatoioff";
                    break;
                case 12:
                    GameObject nambich1 = Instantiate(nambich, new Vector3(289, 300, 1), rotation);
                    nambich1.transform.localScale = new Vector3(300, 300, 1); nambich1.name = "baicuatoioff";
                    break;
                case 13:
                    GameObject namchuon1 = Instantiate(namchuon, new Vector3(289, 300, 1), rotation);
                    namchuon1.transform.localScale = new Vector3(300, 300, 1); namchuon1.name = "baicuatoioff";
                    break;
                case 14:
                    GameObject namro1 = Instantiate(namro, new Vector3(289, 300, 1), rotation);
                    namro1.transform.localScale = new Vector3(300, 300, 1); namro1.name = "baicuatoioff";
                    break;
                case 15:
                    GameObject namco1 = Instantiate(namco, new Vector3(289, 300, 1), rotation);
                    namco1.transform.localScale = new Vector3(300, 300, 1); namco1.name = "baicuatoioff";
                    break;
                case 16:
                    GameObject saubich1 = Instantiate(saubich, new Vector3(289, 300, 1), rotation);
                    saubich1.transform.localScale = new Vector3(300, 300, 1); saubich1.name = "baicuatoioff";
                    break;
                case 17:
                    GameObject sauchuon1 = Instantiate(sauchuon, new Vector3(289, 300, 1), rotation);
                    sauchuon1.transform.localScale = new Vector3(300, 300, 1); sauchuon1.name = "baicuatoioff";
                    break;
                case 18:
                    GameObject sauro1 = Instantiate(sauro, new Vector3(289, 300, 1), rotation);
                    sauro1.transform.localScale = new Vector3(300, 300, 1); sauro1.name = "baicuatoioff";
                    break;
                case 19:
                    GameObject sauco1 = Instantiate(sauco, new Vector3( 289, 300, 1), rotation);
                    sauco1.transform.localScale = new Vector3(300, 300, 1); sauco1.name = "baicuatoioff";
                    break;
                case 20:
                    GameObject baybich1 = Instantiate(baybich, new Vector3(289, 300, 1), rotation);
                    baybich1.transform.localScale = new Vector3(300, 300, 1); baybich1.name = "baicuatoioff";
                    break;
                case 21:
                    GameObject baychuon1 = Instantiate(baychuon, new Vector3(289, 300, 1), rotation);
                    baychuon1.transform.localScale = new Vector3(300, 300, 1); baychuon1.name = "baicuatoioff";
                    break;
                case 22:
                    GameObject bayro1 = Instantiate(bayro, new Vector3(289, 300, 1), rotation);
                    bayro1.transform.localScale = new Vector3(300, 300, 1); bayro1.name = "baicuatoioff";
                    break;
                case 23:
                    GameObject bayco1 = Instantiate(bayco, new Vector3(289, 300, 1), rotation);
                    bayco1.transform.localScale = new Vector3(300, 300, 1); bayco1.name = "baicuatoioff";
                    break;
                case 24:
                    GameObject tambich1 = Instantiate(tambich, new Vector3(289, 300, 1), rotation);
                    tambich1.transform.localScale = new Vector3(300, 300, 1); tambich1.name = "baicuatoioff";
                    break;
                case 25:
                    GameObject tamchuon1 = Instantiate(tamchuon, new Vector3(289, 300, 1), rotation);
                    tamchuon1.transform.localScale = new Vector3(300, 300, 1); tamchuon1.name = "baicuatoioff";
                    break;
                case 26:
                    GameObject tamro1 = Instantiate(tamro, new Vector3(289, 300, 1), rotation);
                    tamro1.transform.localScale = new Vector3(300, 300, 1); tamro1.name = "baicuatoioff";
                    break;
                case 27:
                    GameObject tamco1 = Instantiate(tamco, new Vector3(289, 300, 1), rotation);
                    tamco1.transform.localScale = new Vector3(300, 300, 1); tamco1.name = "baicuatoioff";
                    break;
                case 28:
                    GameObject chinbich1 = Instantiate(chinbich, new Vector3(289, 300, 1), rotation);
                    chinbich1.transform.localScale = new Vector3(300, 300, 1); chinbich1.name = "baicuatoioff";
                    break;
                case 29:
                    GameObject chinchuon1 = Instantiate(chinchuon, new Vector3(289, 300, 1), rotation);
                    chinchuon1.transform.localScale = new Vector3(300, 300, 1); chinchuon1.name = "baicuatoioff";
                    break;
                case 30:
                    GameObject chinro1 = Instantiate(chinro, new Vector3(289, 300, 1), rotation);
                    chinro1.transform.localScale = new Vector3(300, 300, 1); chinro1.name = "baicuatoioff";
                    break;
                case 31:
                    GameObject chinco1 = Instantiate(chinco, new Vector3(289, 300, 1), rotation);
                    chinco1.transform.localScale = new Vector3(300, 300, 1); chinco1.name = "baicuatoioff";
                    break;
                case 32:
                    GameObject muoibich1 = Instantiate(muoibich, new Vector3(289, 300, 1), rotation);
                    muoibich1.transform.localScale = new Vector3(300, 300, 1); muoibich1.name = "baicuatoioff";
                    break;
                case 33:
                    GameObject muoichuon1 = Instantiate(muoichuon, new Vector3(289, 300, 1), rotation);
                    muoichuon1.transform.localScale = new Vector3(300, 300, 1); muoichuon1.name = "baicuatoioff";
                    break;
                case 34:
                    GameObject muoiro1 = Instantiate(muoiro, new Vector3(289, 300, 1), rotation);
                    muoiro1.transform.localScale = new Vector3(300, 300, 1); muoiro1.name = "baicuatoioff";
                    break;
                case 35:
                    GameObject muoico1 = Instantiate(muoico, new Vector3(289, 300, 1), rotation);
                    muoico1.transform.localScale = new Vector3(300, 300, 1); muoico1.name = "baicuatoioff";
                    break;
                case 36:
                    GameObject boibich1 = Instantiate(boibich, new Vector3(289, 300, 1), rotation);
                    boibich1.transform.localScale = new Vector3(300, 300, 1); boibich1.name = "baicuatoioff";
                    break;
                case 37:
                    GameObject boichuon1 = Instantiate(boichuon, new Vector3(289, 300, 1), rotation);
                    boichuon1.transform.localScale = new Vector3(300, 300, 1); boichuon1.name = "baicuatoioff";
                    break;
                case 38:
                    GameObject boiro1 = Instantiate(boiro, new Vector3(289, 300, 1), rotation); boiro1.transform.localScale = new Vector3(300, 300, 1); boiro1.name = "baicuatoioff";
                    break;
                case 39:
                    GameObject boico1 = Instantiate(boico, new Vector3(289, 300, 1), rotation); boico1.transform.localScale = new Vector3(300, 300, 1); boico1.name = "baicuatoioff";
                    break;
                case 40:
                    GameObject dambich1 = Instantiate(dambich, new Vector3(289, 300, 1), rotation); dambich1.transform.localScale = new Vector3(300, 300, 1); dambich1.name = "baicuatoioff";
                    break;
                case 41:
                    GameObject damchuon1 = Instantiate(damchuon, new Vector3(289, 300, 1), rotation); damchuon1.transform.localScale = new Vector3(300, 300, 1); damchuon1.name = "baicuatoioff";
                    break;
                case 42:
                    GameObject damro1 = Instantiate(damro, new Vector3(289, 300, 1), rotation); damro1.transform.localScale = new Vector3(300, 300, 1); damro1.name = "baicuatoioff";
                    break;
                case 43:
                    GameObject damco1 = Instantiate(damco, new Vector3(289, 300, 1), rotation); damco1.transform.localScale = new Vector3(300, 300, 1); damco1.name = "baicuatoioff";
                    break;
                case 44:
                    GameObject giabich1 = Instantiate(giabich, new Vector3(289, 300, 1), rotation); giabich1.transform.localScale = new Vector3(300, 300, 1); giabich1.name = "baicuatoioff";
                    break;
                case 45:
                    GameObject giachuon1 = Instantiate(giachuon, new Vector3(289, 300, 1), rotation); giachuon1.transform.localScale = new Vector3(300, 300, 1); giachuon1.name = "baicuatoioff";
                    break;
                case 46:
                    GameObject giaro1 = Instantiate(giaro, new Vector3(289, 300, 1), rotation); giaro1.transform.localScale = new Vector3(300, 300, 1); giaro1.name = "baicuatoioff";
                    break;
                case 47:
                    GameObject giaco1 = Instantiate(giaco, new Vector3(289, 300, 1), rotation); giaco1.transform.localScale = new Vector3(300, 300, 1); giaco1.name = "baicuatoioff";
                    break;
                case 48:
                    GameObject atbich1 = Instantiate(atbich, new Vector3(289, 300, 1), rotation); atbich1.transform.localScale = new Vector3(300, 300, 1); atbich1.name = "baicuatoioff";
                    break;
                case 49:
                    GameObject atchuon1 = Instantiate(atchuon, new Vector3(289, 300, 1), rotation); atchuon1.transform.localScale = new Vector3(300, 300, 1); atchuon1.name = "baicuatoioff";
                    break;
                case 50:
                    GameObject atro1 = Instantiate(atro, new Vector3(289, 300, 1), rotation); atro1.transform.localScale = new Vector3(300, 300, 1); atro1.name = "baicuatoioff";
                    break;
                case 51:
                    GameObject atco1 = Instantiate(atco, new Vector3(289, 300, 1), rotation); atco1.transform.localScale = new Vector3(300, 300, 1); atco1.name = "baicuatoioff";
                    break;




            }
            GameObject atcoo1 = Instantiate(atco, new Vector3(424, 217, 1), rotation2); atcoo1.transform.localScale = new Vector3(300, 300, 1); atcoo1.name = "baicuatoionl";
        }
    }


    [PunRPC]
    void huybaisauwin()
    {
        GameObject baicuatoi = GameObject.Find("baicuatoioff");
        GameObject baidoithu2 = GameObject.Find("baicuatoionl");
        Destroy(baicuatoi);
        Destroy(baidoithu2);
    }

    public void batdaugame()
    {
        
        int songuoichoimot = PhotonNetwork.CurrentRoom.PlayerCount;
        laysonguoichoi(songuoichoimot,ref songuoichoi);
        batdau.SetActive(false);
        

            Pvv.RPC("RPC_TatDoiChuPong", RpcTarget.Others);
            chiabai(songuoichoi);
        
            photonView.RPC("laytienban", RpcTarget.All);
        
        Pvv.RPC("hientiencuocham", RpcTarget.All);
      //  Pvv.RPC("hienthilabai", RpcTarget.All,songuoichoi);

        
        photonView.RPC("StartMyCoroutineRPC", RpcTarget.All);
        Pvv.RPC("hienthibaithat",RpcTarget.All);
    }

    [PunRPC]
    private void RPC_TatDoiChuPong()
    {
        
        doichupong.SetActive(false);
    }

    [PunRPC]
    private void hientiencuocham()
    {
        hientiencuoc.SetActive(true);
    }

    private void laysonguoichoi(int songuoichoihai,ref int songuoichoi)
    {
        songuoichoi = songuoichoihai;
        bai = new int[songuoichoi];
    }

    
    List<int> GenerateUniqueRandomNumbers(int minValue, int maxValue, int count)
    {
            List<int> result = new List<int>();
            HashSet<int> usedNumbers = new HashSet<int>();

            for (int i = 0; i < count;)
            {
                int randomNumber = Random.Range(minValue, maxValue + 1);

                
                if (!usedNumbers.Contains(randomNumber))
                {
                    usedNumbers.Add(randomNumber);
                    result.Add(randomNumber);
                    i++; 
                }
            }

            return result;
     }
        private void chiabai(int songuoichoiba)
    {
        
        
        Debug.Log(songuoichoiba);
        baidung = new List<int>();
        baidung = GenerateUniqueRandomNumbers(1, 52, songuoichoiba);
        int[] baidung2 = baidung.ToArray(); 
        for (int i = 0; i<songuoichoiba; i++)
        {

            bai[i] = baidung2[i];
            Pvv.RPC("Phanbaichonguoichoi", RpcTarget.All, i, bai[i]);
        }
        
    }

    [PunRPC]
    private void Phanbaichonguoichoi(int songuoichoibon,int chisobai)
    {
        GameObject quanlynguoichoiObject = GameObject.Find(PhotonNetwork.LocalPlayer.NickName);

        if (quanlynguoichoiObject != null)
        {
            
            Quanlynguoichoi quanlynguoichoi = quanlynguoichoiObject.GetComponent<Quanlynguoichoi>();

            if (quanlynguoichoi != null)
            {
                if (PhotonNetwork.LocalPlayer.ActorNumber == (songuoichoibon + 1))
                {
                    Debug.Log("123");
                    quanlynguoichoi.setbai(ref quanlynguoichoi.labai, chisobai);
                }
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
    [PunRPC]
    public void laytienban() 
    {
        
            GameObject quanlynguoichoiObjecttt = GameObject.Find(PhotonNetwork.LocalPlayer.NickName);


            if (quanlynguoichoiObjecttt != null)
            {

                Quanlynguoichoi quanlynguoichoi = quanlynguoichoiObjecttt.GetComponent<Quanlynguoichoi>();

                if (quanlynguoichoi != null)
                {
                    quanlynguoichoi.tien += -10;

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

        tiencuocchung = 10 * (PhotonNetwork.PlayerList.Length);

    }
    [PunRPC]
    void hienthilabai(int thutunguoichoi)
    {
        GameObject newCanvas = Instantiate(canvanshienbai); 
        TMP_Text labaichoi = newCanvas.transform.Find("hienthibai").GetComponent<TMP_Text>();

        switch (thutunguoichoi)
        {
            case 1:
                labaichoi.GetComponent<RectTransform>().anchoredPosition = new Vector2(71, -100);
                break;
            case 2:
                labaichoi.GetComponent<RectTransform>().anchoredPosition = new Vector2(-329, 129);
                break;
            default:
                break;
        }

        
    }

    [PunRPC]
    void capnhattiendoithu(int tienn)
    {
        GameObject quanlynguoichoiObjecttt = GameObject.Find(PhotonNetwork.LocalPlayer.NickName);


        if (quanlynguoichoiObjecttt != null)
        {

            Quanlynguoichoi quanlynguoichoi = quanlynguoichoiObjecttt.GetComponent<Quanlynguoichoi>();

            if (quanlynguoichoi != null)
            {
                quanlynguoichoi.tiencuocdoithu = tienn;

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

        GameObject newObject = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, Quaternion.identity);
      //  PhotonNetwork.Instantiate("hientiennguoichoi", Vector3.zero, Quaternion.identity);
        //newObject.name = PhotonNetwork.LocalPlayer.NickName;
        sinhnguoichoi(PhotonNetwork.LocalPlayer.ActorNumber);
        if (PhotonNetwork.IsMasterClient)
        {
            //newObject.name = PhotonNetwork.LocalPlayer.NickName;
            batdau.SetActive(true);
            doichupong.SetActive(false);
            luotcuatoi = true;
        }
        else
        {
           
            doichupong.SetActive(true);
            batdau.SetActive(false);
            luotcuatoi = false;

        }


    }


    [PunRPC]
    private void RequestChangeMasterClient(PhotonMessageInfo info)
    {
        if (info.Sender.IsMasterClient)
        {
            PhotonNetwork.SetMasterClient(info.Sender);
        }
    }


    private void Update()
    {
       
    }


    [PunRPC]
    private void UpdateAndSendData(int data)
    {

        GameObject quanlynguoichoiObjecttt = GameObject.Find(PhotonNetwork.LocalPlayer.NickName);


        if (quanlynguoichoiObjecttt != null)
        {

            Quanlynguoichoi quanlynguoichoi = quanlynguoichoiObjecttt.GetComponent<Quanlynguoichoi>();

            if (quanlynguoichoi != null)
            {

                quanlynguoichoi.tiencuocdoithu = data;
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

    private IEnumerator UpdateAndSendDataCoroutine()
    {
        while (true)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                GameObject quanlynguoichoiObjecttt = GameObject.Find(PhotonNetwork.LocalPlayer.NickName);


                if (quanlynguoichoiObjecttt != null)
                {

                    Quanlynguoichoi quanlynguoichoi = quanlynguoichoiObjecttt.GetComponent<Quanlynguoichoi>();

                    if (quanlynguoichoi != null)
                    {

                        photonView.RPC("UpdateAndSendData", RpcTarget.Others, quanlynguoichoi.tien);
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
             //   photonView.RPC("UpdateAndSendData", RpcTarget.All, 42);
            }
            else
            {
                GameObject quanlynguoichoiObjecttt = GameObject.Find(PhotonNetwork.LocalPlayer.NickName);


                if (quanlynguoichoiObjecttt != null)
                {

                    Quanlynguoichoi quanlynguoichoi = quanlynguoichoiObjecttt.GetComponent<Quanlynguoichoi>();

                    if (quanlynguoichoi != null)
                    {

                        photonView.RPC("UpdateAndSendData", RpcTarget.Others, quanlynguoichoi.tien);
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

            yield return null;
        }
    }

    [PunRPC]
    private void StartMyCoroutineRPC()
    {
        
        StartCoroutine(UpdateAndSendDataCoroutine());
    }

}


