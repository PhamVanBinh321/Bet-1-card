using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using Photon.Pun;

public class tienchuocchomoinguoi : MonoBehaviourPunCallbacks
{
      
    public TMP_Text tiencuocc;
    int value;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        value = Gameplay.tiencuocchung;
        tiencuocc.text = "Tien cuoc: "+ value.ToString() +"$";
    }
}
