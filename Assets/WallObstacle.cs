﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallObstacle : MonoBehaviour {

    public GameObject Wall1;
    public GameObject Wall2;
    public GameObject Wall3;
    public GameObject Wall4;

    // Start is called before the first frame update
    void Start() {
        int destructableWall1 = Random.Range(1, 4);
        int destructableWall2 = Random.Range(1, 4);

        while(destructableWall1 == destructableWall2) {
            destructableWall2 = Random.Range(1, 4);
        }

        switch(destructableWall1) {
            case 1:
                Wall1.GetComponent<Wall>().destructable = true;
                break;
            case 2:
                Wall2.GetComponent<Wall>().destructable = true;
                break;
            case 3:
                Wall3.GetComponent<Wall>().destructable = true;
                break;
            case 4:
                Wall4.GetComponent<Wall>().destructable = true;
                break;

        }
        switch (destructableWall1) {
            case 1:
                Wall1.GetComponent<Wall>().destructable = true;
                break;
            case 2:
                Wall2.GetComponent<Wall>().destructable = true;
                break;
            case 3:
                Wall3.GetComponent<Wall>().destructable = true;
                break;
            case 4:
                Wall4.GetComponent<Wall>().destructable = true;
                break;

        }
    }
}
