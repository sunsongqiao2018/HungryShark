using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFish : MonoBehaviour
{
    public static event EventHandler<GameObject> OnPlayerEatFish;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject fishEaten = collision.gameObject;
        //we ate fish
        if (fishEaten.tag == "Fish")
        {
            OnPlayerEatFish.Invoke(this, fishEaten);
        }
    }
}
