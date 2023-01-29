using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gem : MonoBehaviour
{
    private PlayerController player;
    protected int _value;
    private int value
    {
        get
        {
            return _value;
        }
        set
        {
            _value = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _value = 1;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject.GetComponent<PlayerController>();
            player._score += _value;
            Destroy(gameObject);
        }
    }
    protected void Ray()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 2, Color.red);
    }
}
