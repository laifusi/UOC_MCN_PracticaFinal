using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlock : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var character = collision.collider.GetComponent<CharacterMovement>();
        if(character.CharacterMode == CharacterMode.CannonBall)
        {
            Destroy(gameObject);
        }     
    }
}
