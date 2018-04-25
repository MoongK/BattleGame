using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossNameTx : MonoBehaviour {

    private void Start()
    {
        string name = "Jergernut";
        GetComponent<Text>().text = name;
    }
}
