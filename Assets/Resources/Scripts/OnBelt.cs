using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBelt : MonoBehaviour {
	
	void Update () {

        if (transform.parent != null && transform.parent.CompareTag("BowBelt"))
        {
            for (int i = 0; i < transform.parent.childCount; i++)
            {
                if (transform.parent.GetChild(i) == transform)
                {
                    switch (i)
                    {
                        case 0:
                            transform.localPosition = BeltStatus.child_zeroPos;
                            transform.localRotation = BeltStatus.child_zeroRot;
                            break;
                        case 1:
                            transform.localPosition = BeltStatus.child_firstPos;
                            transform.localRotation = BeltStatus.child_firstRot;
                            break;
                        case 2:
                            transform.localPosition = BeltStatus.child_secondPos;
                            transform.localRotation = BeltStatus.child_secondRot;
                            break;
                        case 3:
                            transform.localPosition = BeltStatus.child_thirdPos;
                            transform.localRotation = BeltStatus.child_thirdRot;
                            break;
                        case 4:
                            transform.localPosition = BeltStatus.child_fourthPos;
                            transform.localRotation = BeltStatus.child_fourthRot;
                            break;
                    }
                }

            }
        }
        else if (transform.parent != null && transform.parent.name == "ArrowGrab" && BeltStatus.reloading)
        {
            for (int i = 0; i < transform.parent.childCount; i++)
            {
                if (transform.parent.GetChild(i) == transform)
                {
                    switch (i)
                    {
                        case 0:
                            transform.localPosition = GrabControll.rl_child_zeroPos;
                            transform.localRotation = GrabControll.rl_child_zeroRot;
                            break;
                        case 1:
                            transform.localPosition = GrabControll.rl_child_firstPos;
                            transform.localRotation = GrabControll.rl_child_firstRot;
                            break;
                        case 2:
                            transform.localPosition = GrabControll.rl_child_secondPos;
                            transform.localRotation = GrabControll.rl_child_secondRot;
                            break;
                        case 3:
                            transform.localPosition = GrabControll.rl_child_thirdPos;
                            transform.localRotation = GrabControll.rl_child_thirdRot;
                            break;
                        case 4:
                            transform.localPosition = GrabControll.rl_child_fourthPos;
                            transform.localRotation = GrabControll.rl_child_fourthRot;
                            break;
                    }
                }

            }
        }
        else
            return;

	}
}
