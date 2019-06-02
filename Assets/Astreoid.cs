using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astreoid : MonoBehaviour {

    public GameObject astreoid;
    public Vector3 initPoss;

    GameObject shipClone;
    // Use this for initialization
    void Start () {
        initPoss = astreoid.transform.position;
        InvokeRepeating("LaunchProjectile", 5.0f, 5f);
    }
	
	// Update is called once per frame
	void Update () {

        //StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(10);
        shipClone = (GameObject)Instantiate(astreoid, initPoss, Quaternion.identity);

    }
    public IEnumerator Spawner()
    {
        bool flag = true;

        while (flag)
        {
            shipClone = (GameObject)Instantiate(astreoid, initPoss, Quaternion.identity);
            yield return new WaitForSeconds(35f);
        }
    }
    void LaunchProjectile()
    {
        shipClone = (GameObject)Instantiate(astreoid, initPoss, Quaternion.identity);

    }
}
