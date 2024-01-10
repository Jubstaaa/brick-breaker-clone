using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    static SoundController SinglePlayer = null;

    void Awake()
    {
        if (SinglePlayer != null)
        {
            Destroy(gameObject);
        }
        else
        {
            SinglePlayer = this;
            GameObject.DontDestroyOnLoad(this);
        }
    }

 
}
