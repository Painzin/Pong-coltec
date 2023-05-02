using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballmov : MonoBehaviour
{
    public float streng = 12f;  //var para controlar a força aplicada na bola
    private Rigidbody2D baller; //var que pega o rigidbody  
    private Vector2 power;      //Esse é o vetor que vai ser responsavel para aplicarmos uma força na bola para que ela se mova
    private bool start10 = false;   //para fazer a bola trocar de lado precisamos de um "cooldown" sempre que marca um ponto esse cara vai nos ajudar nisso
    public float temporizator;      //esse vai ser o temporiador do cooldown

    // Start is called before the first frame update
    void Start()
    {
        baller = GetComponent<Rigidbody2D>(); //peguei o rigidbody e chamei de baller
        impulse();
    }

    void Update()
    {
        if (start10 == true) {  
            temporizator = temporizator + Time.deltaTime; //vamos começar o cooldown quando esse cara for true
            if (temporizator >= 0.1) { //assim que o cooldown acabar executamnos o impulse
                impulse();
                temporizator = 0f; //voltamos o cooldown pra zero para prepararmos pra proxima vez
            }
        }
    }

    void OnTriggerEnter2D(Collider2D b)
    {
        start10 = true; //esse carinha vai ser true quando a colisão ocorrer
        transform.position = Vector3.zero; //essa linha é essencial para a bola voltar ao 0 0 depois de marcamos um gol
        baller.velocity = Vector3.zero; //essa linha faz a bola perder as forças que tem nela para que possamos inverter a direçao que ela vai
    }

    void impulse() 
    {
        if(gols.side2 == true) { //esse cara nos diz qual lado a bolinha vai ir sendo true = direita false = esquerda
            power = new Vector2(10f, Random.Range(-3f, 3f))* streng;
        } else {
            power = new Vector2(-10f, Random.Range(-3f, 3f))* streng;   //responsavel por mover a bola no começo do jogo ou depois de um gol
        }
        if (power.y > 15f || power.y < -15f ) { //impede que a bolinha siga por uma direçao muito reta
            start10 = false; //fazemos esse carinha virar falso pra proxima colisão 
            baller.AddForce(power); //impulsiona a bolinha
        } else {
            impulse();
        }
    }
}
