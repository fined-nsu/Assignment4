using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pinPrefab;
    public static GameObject clone;

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            SpawnPin();
        }
    }

    void SpawnPin()
    {
        clone = Instantiate(pinPrefab, transform.position, transform.rotation);
    }
}
