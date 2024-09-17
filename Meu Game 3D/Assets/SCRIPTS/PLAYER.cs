 using System;
 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using  Vector3 = UnityEngine.Vector3;

public class PLAYER : MonoBehaviour

{
    public int velocidade = 10;
    public int forcaPulo = 10;
    public bool noChao = false;
    
   private Rigidbody rb;
   private AudioSource source;
    void Start()
    {
        Debug.Log("start");
        TryGetComponent(out rb);
        TryGetComponent(out source);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "chão")
        {
            noChao = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(message:"update");
        float h = Input.GetAxis("Horizontal"); //-1 esquerda,0 nada,1 direita
        float v = Input.GetAxis("Vertical"); // -1 pra baixo,0 nada, 1 pra frente

        Vector3 direcao = new Vector3(h,0,v);
        rb.AddForce(direcao * (velocidade * Time.deltaTime), ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.Space) && noChao == true)
        {
           //pulo
           source.Play();
           
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            noChao = false;
        }
            
        if (transform.position.y <= -10)
        {
          //jogador caiu
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
