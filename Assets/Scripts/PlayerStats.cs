using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public string gameClass { get; set;}
	public string userName { get; set; }
    public int lifeLeft { get; set; }
    private float DamageMultiplier = 1; // All the floats are in precent, between 0.00 and 1.00
    private float DamageReducer = 1; // Float in precentage f.eks 3x damage = 3.00
    private float MissChance;

	// Use this for initialization
	void Start () {
        UnityEngine.Object.DontDestroyOnLoad(this);
        lifeLeft = 100;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetDamageMultiplier (float multiplier)
    {
        DamageMultiplier = multiplier;
    }

    public void SetDamageReducer (float mutiplier)
    {
        DamageReducer = mutiplier;
    }

    //returns if attack was succes or not!
    public void GiveDamage(int damage)
    {
        if (HitOrMiss())
        {
            damage = ApplyDamageModifiyers(damage);
            lifeLeft -= damage;
        }
        else
        {

        }
    }

    private int ApplyDamageModifiyers(int damage)
    {
        float tempResult = damage * DamageMultiplier * DamageReducer;
        int rounded = Convert.ToInt32(tempResult);
        return rounded;
    }

    // this method should calculate wheater there is a hit or not
    // up to Grønbjerg to complete. Hit => true
    private bool HitOrMiss()
    {
        return true;
    }
}
