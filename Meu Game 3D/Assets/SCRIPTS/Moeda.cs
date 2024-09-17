using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    public int velocidadeGiro = 50;
    
    // Start is called before the first frame update

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bola")
        {
            FindObjectOfType<GameManager>().SubtrairMoedas(valor:1);
            Destroy(gameObject);
        }
    }

    void Update()
    { 
        transform.Rotate(Vector3.up * velocidadeGiro * Time.deltaTime, Space.World);
    }
}
