using UnityEngine;
using Photon.Pun;

public class MySingleton : MonoBehaviourPunCallbacks
{
    private static MySingleton instance;

    public GameObject cube;
    public static MySingleton Instance
    {
        get
        {
            if (instance == null)
            {
                
                instance = FindObjectOfType<MySingleton>();

               
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(MySingleton).Name);
                    instance = singletonObject.AddComponent<MySingleton>();
                }
            }

            return instance;
        }
    }

    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
         if(Gameplay.Instance.luotcuatoi==true)
        {
            cube.transform.position = new Vector3(421,263,-179);
        }
        else
        {
            cube.transform.position = new Vector3(406, 271, -179);
        }
    }

    public void MyMethod()
    {
        Debug.Log("MySingleton method called");
    }
}

