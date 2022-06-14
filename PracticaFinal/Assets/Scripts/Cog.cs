using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cog : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var character = collision.GetComponent<Inventory>();
        if (character != null)
        {
            character.CollectCog();
            Destroy(gameObject);
        }
    }
}
