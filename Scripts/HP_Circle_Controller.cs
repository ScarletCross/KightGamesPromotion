using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Circle_Controller : MonoBehaviour
{
    public PlayerController Player;

    public Image HP_Circle;

    private float countTime = 5.0f;

    private int player_damage = PlayerController.damage;

    private bool DamageFlag = false;

    // Start is called before the first frame update
    void Start()
    {
       // this.GameObject = GameObject.Find("HP_Circle");
        this.HP_Circle = GetComponent<Image>();

        GameObject playerObj = GameObject.Find("M05");

        this.Player = playerObj.GetComponent<PlayerController>();
        
    }

    

    public void DamageTrriger(float wariaiHP)
    {
        DamageFlag = true;
       // this.Player.TakeDamage(damage);

        HP_Circle.fillAmount = wariaiHP;
        
    }

}
