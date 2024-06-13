using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public Player player;

    private void Awake()
    {
        //prevent existence of multiple instances 
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
    }
}
