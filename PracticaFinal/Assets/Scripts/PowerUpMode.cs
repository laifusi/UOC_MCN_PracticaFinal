using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMode : MonoBehaviour
{
    [SerializeField] private CharacterMode mode;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        switch (mode)
        {
            case CharacterMode.RubberBall:
                spriteRenderer.color = Color.red;
                break;
            case CharacterMode.CannonBall:
                spriteRenderer.color = Color.black;
                break;
            case CharacterMode.Cloud:
                spriteRenderer.color = Color.white;
                break;
            case CharacterMode.WaterDrop:
                spriteRenderer.color = Color.cyan;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var character = collision.GetComponent<Inventory>();
        if (character != null)
        {
            character.AddModePowerUp(mode);
            Destroy(gameObject);
        }
    }
}
