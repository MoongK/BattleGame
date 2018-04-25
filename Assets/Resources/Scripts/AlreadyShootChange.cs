using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlreadyShootChange : MonoBehaviour {

    void ChangeStat()
    {
        Shooter.AlreadyShoot = false;
        print("(AlreadyShootChange) : Chaged!");
    }
}
