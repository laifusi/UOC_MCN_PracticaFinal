using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCollectibles : MonoBehaviour
{
    [SerializeField] private int points;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var character = collision.GetComponent<Inventory>();
        if (character != null)
        {
            character.AddPoints(points);
            Destroy(gameObject);
        }
    }
}
