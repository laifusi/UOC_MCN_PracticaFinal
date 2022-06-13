using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterMode characterMode;
    private SpriteRenderer spriteRenderer;

    [SerializeField] CharacterMode initialMode;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeMode(initialMode);
    }

    private void Update()
    {
        if(Input.GetAxis("Vertical") > 0)
        {
            ChangeMode(Side.Top);
        }
        else if(Input.GetAxis("Vertical") < 0)
        {
            ChangeMode(Side.Bottom);
        }
        else if(Input.GetAxis("Horizontal") > 0)
        {
            ChangeMode(Side.Right);
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            ChangeMode(Side.Left);
        }
    }

    public void ChangeMode(Side side)
    {
        switch(side)
        {
            case Side.Top:
                ChangeMode(CharacterMode.Cloud);
                break;
            case Side.Right:
                ChangeMode(CharacterMode.RubberBall);
                break;
            case Side.Left:
                ChangeMode(CharacterMode.WaterDrop);
                break;
            case Side.Bottom:
                ChangeMode(CharacterMode.CannonBall);
                break;
        }
    }

    private void ChangeMode(CharacterMode mode)
    {
        characterMode = mode;
        switch(mode)
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
}

public enum Side
{
    Top, Bottom, Left, Right
}

public enum CharacterMode
{
    RubberBall, CannonBall, WaterDrop, Cloud
}
