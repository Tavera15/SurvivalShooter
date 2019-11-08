using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Transform[] players;
    public static PlayerManager instance;


    // Start is called before the first frame update
    void Start()
    {     
        if (instance == null)
            instance = this;
        if (this != instance)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
