using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] TypeOfTrap typeOfTrap;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var character = collision.GetComponent<CharacterMovement>();
        CharacterMode characterMode = character.CharacterMode;

        switch(typeOfTrap)
        {
            case TypeOfTrap.Fan:
                if(characterMode == CharacterMode.Cloud)
                    character.Die();
                break;
            case TypeOfTrap.Fire:
                if (characterMode == CharacterMode.RubberBall)
                    character.Die();
                else if (characterMode == CharacterMode.WaterDrop)
                    DisableTrap();
                break;
            case TypeOfTrap.Water:
                if (characterMode == CharacterMode.WaterDrop || characterMode == CharacterMode.CannonBall)
                    character.Die();
                break;
        }
    }

    private void DisableTrap()
    {
        Destroy(gameObject);
    }
}

public enum TypeOfTrap
{
    Fire, Water, Fan
}
