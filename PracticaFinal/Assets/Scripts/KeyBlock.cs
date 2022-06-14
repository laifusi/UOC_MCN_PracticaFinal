using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBlock : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var character = collision.collider.GetComponent<Inventory>();
        if (character != null)
        {
            if (character.HasKey())
                Destroy(gameObject);
        }
    }
}
