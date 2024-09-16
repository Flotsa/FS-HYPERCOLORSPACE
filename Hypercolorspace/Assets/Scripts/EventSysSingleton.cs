using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSysSingleton : MonoBehaviour
{
    public static EventSysSingleton Instance;

    public EventSysSingleton GetInstance()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }

        return Instance;
    }


    // Start is called before the first frame update
    void Start()
    {
        GetInstance();
    }

}
