using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stars : MonoBehaviour
{
    public static stars Instance;

    public stars GetInstance()
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
