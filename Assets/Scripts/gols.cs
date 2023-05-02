using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //outra biblioteca pra mexer nos texto
using TMPro;            //as biblioteca de texto tbm

public class gols : MonoBehaviour
{
    public int rightgols = 0;       //variavel que conta o gol da direita
    public int leftgols = 0;        //variavel que conta gol da esquerda
    public bool side;               //variavel que dizer qual lado é(pra eu nao fazer 2 scripts so 1)
    public static bool side2 = true;//essa bool vai ser chamada na script de ball mov para trocar o lado da bola
    public TextMeshProUGUI right;   //texto da direita
    public TextMeshProUGUI left;    //texto da esquerda

    

    void OnTriggerEnter2D(Collider2D b) //quando tiver colisao no collider dos bagui
    {
        if(side == true) {  //se for na direita
            side2 = true;   //vamos usar essa bool para (no ballmov) mudarmos a direçao que a bola via no gol
            rightgols++;    //vai aumentar os gol da direita em 1(no caso vai aparecer no lado da esquerda ja que o jogador da esquerda que pontua)
            right.text = rightgols.ToString(); //atualiza o valor do texto
        } else {            //senao for na direita vai ser na esquerda
            side2 = false;  //vamos usar essa bool para (no ballmov) mudarmos a direçao que a bola via no gol
            leftgols++;     //faz a mesma coisa que o rightgols++ so que da esquerda
            left.text = leftgols.ToString(); //mesma coisa do outro so que da esquerda tbm
        }
    }
}

