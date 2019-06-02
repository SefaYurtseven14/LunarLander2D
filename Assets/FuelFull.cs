using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelFull : MonoBehaviour {

    public GameObject ship;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ship.GetComponent<LunarController>().currentFuel = 100;
            Destroy(gameObject);
        }
    }
}
