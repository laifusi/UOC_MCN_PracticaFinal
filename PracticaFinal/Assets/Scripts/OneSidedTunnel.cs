using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneSidedTunnel : MonoBehaviour
{
    private bool characterOnTunnel;
    [SerializeField] private Side enterSide;
    [SerializeField] private Transform exitPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var character = collision.GetComponent<Inventory>();
        if (character != null)
        {
            characterOnTunnel = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var character = collision.GetComponent<CharacterMovement>();
        if (character != null)
        {
            switch(enterSide)
            {
                case Side.Bottom:
                    if (Input.GetAxis("VerticalMovement") > 0)
                        character.MoveTo(exitPoint);
                    break;
                case Side.Top:
                    if (Input.GetAxis("VerticalMovement") < 0)
                        character.MoveTo(exitPoint);
                    break;
                case Side.Left:
                    if (Input.GetAxis("HorizontalMovement") > 0)
                        character.MoveTo(exitPoint);
                    break;
                case Side.Right:
                    if (Input.GetAxis("HorizontalMovement") < 0)
                        character.MoveTo(exitPoint);
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var character = collision.GetComponent<Inventory>();
        if (character != null)
        {
            characterOnTunnel = false;
        }
    }
}
