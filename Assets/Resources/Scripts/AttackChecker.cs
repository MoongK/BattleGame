﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackChecker : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        print("mob attack!");
    }
}
