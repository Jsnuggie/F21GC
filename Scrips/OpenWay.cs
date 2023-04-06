using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWay : MonoBehaviour
{
    public Animator openWay;
    bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        openWay = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isOpen = true;
            openWay.SetBool("OpenWay", isOpen);
            print("碰到了" + other);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            print("关门");
            isOpen = false;
            openWay.SetBool("OpenWay", isOpen);
        }
    }
}
