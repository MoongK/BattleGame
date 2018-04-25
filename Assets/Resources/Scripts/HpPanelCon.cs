using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpPanelCon : MonoBehaviour {


    void Update()
    {
        if (GameObject.Find("Boss") != null)
        {
            if (GameObject.Find("Boss").GetComponent<Animator>().GetBool("isStarted"))
                transform.GetChild(0).gameObject.SetActive(true);
            else if (!GameObject.Find("Boss").GetComponent<Animator>().GetBool("isStarted"))
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        else
            transform.GetChild(0).gameObject.SetActive(false);
    }
}
