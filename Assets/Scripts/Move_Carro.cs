using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move_Carro : MonoBehaviour {

    public float velocidade;

    //criar ponteiros
    private GameObject roda_1;
    private GameObject roda_2;
    private GameObject roda_3;
    private GameObject roda_4;

    private GameObject cam_1a_pessoa;
    private GameObject cam_3a_pessoa;


    // Use this for initialization
    void Start() { 
   
        roda_1 = this.transform.Find("Roda_A").gameObject;
        roda_2 = this.transform.Find("Roda_B").gameObject;
        roda_3 = this.transform.Find("Roda_C").gameObject;
        roda_4 = this.transform.Find("Roda_D").gameObject;

        cam_1a_pessoa = this.transform.Find("Camera_1aPessoa").gameObject;
        cam_3a_pessoa = this.transform.Find("Camera_3aPessoa").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            this.transform.Translate(0, 0, velocidade*Time.deltaTime);

            //girar as rodas rodar em torno eixo x
            roda_1.transform.Rotate(new Vector3(velocidade, 0, 0));
            roda_2.transform.Rotate(new Vector3(velocidade, 0, 0));
            roda_3.transform.Rotate(new Vector3(velocidade, 0, 0));
            roda_4.transform.Rotate(new Vector3(velocidade, 0, 0));
        }
        if (Input.GetKey("s"))
        {
            this.transform.Translate(0, 0, -velocidade * Time.deltaTime);

            //girar as rodas rodar em torno eixo x
            roda_1.transform.Rotate(new Vector3(-velocidade, 0, 0));
            roda_2.transform.Rotate(new Vector3(-velocidade, 0, 0));
            roda_3.transform.Rotate(new Vector3(-velocidade, 0, 0));
            roda_4.transform.Rotate(new Vector3(-velocidade, 0, 0));
        }
        if (Input.GetKey("a"))
        {
            this.transform.Translate(-velocidade * Time.deltaTime, 0, 0);

            //girar as rodas rodar em torno eixo z
            roda_1.transform.Rotate(new Vector3(0, 0, -velocidade));
            roda_2.transform.Rotate(new Vector3(0, 0, -velocidade));
            roda_3.transform.Rotate(new Vector3(0, 0, -velocidade));
            roda_4.transform.Rotate(new Vector3(0, 0, -velocidade));
        }
        if (Input.GetKey("d"))
        {
            this.transform.Translate(velocidade * Time.deltaTime, 0, 0);
            //girar as rodas rodar em torno eixo z
            roda_1.transform.Rotate(new Vector3(0, 0, velocidade));
            roda_2.transform.Rotate(new Vector3(0, 0, velocidade));
            roda_3.transform.Rotate(new Vector3(0, 0, velocidade));
            roda_4.transform.Rotate(new Vector3(0, 0, velocidade));
        }
        if (Input.GetKeyDown("space"))
        {
            //this.transform.Translate(0, 10, 0);
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * 900f);
        }
        if (Input.GetKey("1"))
        {
            cam_1a_pessoa.SetActive(true);
            cam_1a_pessoa.SetActive(false);
        }
        if (Input.GetKey("3"))
        {
            cam_1a_pessoa.SetActive(false);
            cam_1a_pessoa.SetActive(true);
        }
        if (Input.GetKey("r"))
        {
            this.transform.localPosition = new Vector3(0f, 0f, 0f);
            this.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
            this.GetComponent<Rigidbody>().useGravity = true;
            this.GetComponent<Rigidbody>().isKinematic = false;
        }
        if (Input.GetKey("p"))
        {
            //SceneManager.LoadScene("7_Scene"); //iria carregar a determinada cena
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);//
        }
    }
}
