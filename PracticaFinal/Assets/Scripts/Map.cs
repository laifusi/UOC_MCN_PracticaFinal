using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var character = collision.GetComponent<Inventory>();
        if (character != null)
        {
            character.CollectMap();
            Destroy(gameObject);
        }
    }
}
