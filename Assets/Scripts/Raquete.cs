using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raquete : MonoBehaviour
{
    public bool choice;     //usei essa bool para diferenciar as teclas de mover cada raquete
    public float speed;     //controla a velociodade que as raquetes se movem conforme as teclas
    public float escala = 0.00008f; //variavel que altera a escala das raquetes conforme o tempo
    public float controler2 = 10; //controlador principal de tempo para fazer as raquetes diminuirem conforme esse periodo de tempo passa
    public GameObject raquete1; //o gameobject da raquete em si 
    private Vector3 scale;  //o vetor de escala para alterarmos o scale da nossa raquete
    private float cronom;   //declaramos a variavel que é o nosso cronometro
    public Rigidbody2D body; //o jogo tava com um probleminha e pra resolver tive que pegar o rigidbody da raquete
    // Update is called once per frame
    void Update()
    {
        fixproblem();
        raquetemov();
        if(raquete1.transform.localScale.y > raquete1.transform.localScale.x){ //fiz isso para limitar o tamanho da raquete fazendo ela ficar um pouco menor que o eixo x da escala dela
        cronometrador();
        }
    }

    void raquetemov() 
    {
        if (choice == true) 
        {
            float vertical = Input.GetAxis("Vertical");             //faz com que o y seja 1 ou -1 de acordo com a tecla apertada
            transform.Translate(Vector2.up * vertical * speed * Time.deltaTime); //move as raquetes
        } else {
            float vertical = Input.GetAxis("Vertical1");            //faz com que o y seja 1 ou -1 de acordo com a tecla apertada(so que esse é de setinhas)
            transform.Translate(Vector2.up * vertical * speed * Time.deltaTime); //move as raquetes
        }
    }

    void cronometrador() 
    {
        cronom = cronom + Time.deltaTime; //cronometro para diminuir o tamanho das raquetes conforme o tempo
        if (cronom > controler2) {   //comparamos o tempo no cronometro com o tempo do controlador para sempre que isso ocorrer diminuirmos o tamanho da raquete
            scale = new Vector3(0f, -escala, 0f); //essas 2 linhas são para diminuir o tamanho da raquete 
            raquete1.transform.localScale += scale; //muda o tamanho da raquete
        }
    }

    void fixproblem() //essa script é pra resolver um probleminha que é basicamente as raquetes tomando knockback 
    {                 //da bolinha(elas acabam se movendo no eixo Y por causa desse knockback contra a vontade do jogar e isso atrapalha)
        body = GetComponent<Rigidbody2D>(); //aqui pegamoso componente do rigidbody da bolinha
        body.velocity = Vector3.zero; //e aqui zeramos qualquer força de rigidbody que possa movar a raquete(a raquete se move com transform logo isso nao afeta o movimento dela)
    } 
}
