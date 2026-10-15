using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;


[RequireComponent(typeof(CharacterController))]

public class Personagem : MonoBehaviour

{

    [Header("Movimento")]

    public float velocidade = 5f;

    public float velocidadeGiro = 720f;

    [Header("Pulo Gravidade")]

    public float alturaPulo = 1.5f;

    public float gravidade = -20f;

    private CharacterController Controller;

    private float velocidadeY;

    void Start()

    {

        Controller = GetComponent<CharacterController>();

    }


    void Update()

    {

        float h = Input.GetAxis("Horizontal");

        float v = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(h, 0f, v);

        if (direcao.magnitude > 1f)

        {

            direcao.Normalize();

        }

        Controller.Move(direcao * velocidade * Time.deltaTime);

        if (direcao != Vector3.zero)

        {

            Quaternion rotacaoAlvo = Quaternion.LookRotation(direcao);

            transform.rotation = Quaternion.RotateTowards(

                transform.rotation, rotacaoAlvo,

                velocidadeGiro * Time.deltaTime);

        }

        if (Controller.isGrounded)

        {

            if (velocidadeY < 0)

            {

                velocidadeY = -2f;

            }

            if (Input.GetKeyDown(KeyCode.Space))

            {

                velocidadeY = Mathf.Sqrt(alturaPulo * -2f * gravidade);

            }

        }

        velocidadeY += gravidade * Time.deltaTime;

        Vector3 movimento = direcao * velocidade;

        movimento.y = velocidadeY;

        Controller.Move(movimento * Time.deltaTime);

    }
    // UI e contador
public GameObject winTextObject;
public TextMeshProUGUI CountText;
private int count = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    //NOVO: atualiza o texto e verifica a vitória
    void SetCountText()
    {
        CountText.text = "Pontos: " + count.ToString();

        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }
}







