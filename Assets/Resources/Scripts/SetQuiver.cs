using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetQuiver : MonoBehaviour {

    int maxQuiverArrows;
    GameObject Belt, Grab;
    Object Arrows;


	void Awake () {
        maxQuiverArrows = 50;
        Arrows = Resources.Load("Prefabs/Arrow");
        Belt = GameObject.Find("BowBelt");
        Grab = GameObject.Find("ArrowGrab");

        for (int i = 0; i < maxQuiverArrows; i++)
        {
            var myAr = Instantiate(Arrows, transform.position, Quaternion.identity, transform) as GameObject;
            myAr.SetActive(false);
            
        }
	}

    public void TakedByGrab()
    {
        if (transform.childCount != 0)
        {
            transform.GetChild(transform.childCount - 1).gameObject.SetActive(true);
            Transform aChild = transform.GetChild(transform.childCount - 1);
            transform.GetChild(transform.childCount - 1).SetParent(Grab.transform);
            aChild.localRotation = Quaternion.Euler(Vector3.zero);
        }
    }

    public void GoToBelt()
    {
        Grab.transform.GetChild(Grab.transform.childCount - 1).SetParent(Belt.transform);
    }
	
}
