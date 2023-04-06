using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOpenWay : MonoBehaviour
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
        openWay.SetBool("OpenWay", isOpen);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isOpen = true;
            print("碰到了" + other);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        print("关门");
        isOpen = false;
    }
}
