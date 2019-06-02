using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour {

    public Vector3 pos1;
    public Vector3 pos2;
    public Vector3 pos3;
    public Vector3 pos4;

    public int pos = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (pos == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos1, Time.deltaTime * 10);
            if (transform.position == pos1)
            {
                pos = 2;
            }
        }
        else if (pos == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos2, Time.deltaTime * 10);
            if (transform.position == pos2)
            {
                pos = 3;
            }
        }
        else if (pos == 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos3, Time.deltaTime * 10);
            if (transform.position == pos3)
            {
                pos = 4;
            }
        }
        else if (pos == 4)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos4, Time.deltaTime * 10);
            if (transform.position == pos4)
            {
                pos = 1;
            }
        }
    }
}
