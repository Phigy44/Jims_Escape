using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public GameObject Inventroy;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            Debug.Log("InInventroyFunction");
            Inventroy.SetActive(!Inventroy.activeSelf);

        }
    }
}
