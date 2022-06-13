using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidBlockingBlock : MonoBehaviour
{
    [SerializeField] private Collider2D collider2D;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var character = collision.GetComponent<CharacterMovement>();
        if (character.CharacterMode == CharacterMode.Cloud || character.CharacterMode == CharacterMode.WaterDrop)
        {
            collider2D.isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var character = collision.GetComponent<CharacterMovement>();
        if (character != null)
        {
            collider2D.isTrigger = false;
        }
    }
}
