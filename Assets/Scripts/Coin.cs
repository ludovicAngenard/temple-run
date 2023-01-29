using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Gem
{
    private int rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 100;
        _value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }

}
