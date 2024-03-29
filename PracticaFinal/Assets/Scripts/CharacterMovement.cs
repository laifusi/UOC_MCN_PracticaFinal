using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterMode characterMode;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2D;
    private Inventory inventory;
    private float horizontalMovement;
    private float verticalMovement;
    private float upSpeed, downSpeed, sideSpeed;

    [SerializeField] CharacterMode initialMode;
    [SerializeField] Transform spawnPosition;

    public CharacterMode CharacterMode => characterMode;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        inventory = GetComponent<Inventory>();
        sideSpeed = 10;
        InitializeCharacter();
    }

    private void InitializeCharacter()
    {
        ChangeMode(initialMode);
        inventory.AddModePowerUp(initialMode);
        transform.position = spawnPosition.position;
    }

    private void Update()
    {
        if(Input.GetButtonDown("UpMode"))
        {
            ChangeMode(Side.Top);
        }
        else if(Input.GetButtonDown("DownMode"))
        {
            ChangeMode(Side.Bottom);
        }
        else if(Input.GetButtonDown("RightMode"))
        {
            ChangeMode(Side.Right);
        }
        else if(Input.GetButtonDown("LeftMode"))
        {
            ChangeMode(Side.Left);
        }

        horizontalMovement = Input.GetAxis("HorizontalMovement");
        verticalMovement = Input.GetAxis("VerticalMovement");

        if(verticalMovement != 0)
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, verticalMovement > 0 ? verticalMovement*upSpeed : verticalMovement*downSpeed);
        
        rigidbody2D.velocity = new Vector2(horizontalMovement*sideSpeed, rigidbody2D.velocity.y);
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

    public void ChangeMode(CharacterMode mode)
    {
        characterMode = mode;
        inventory.UseModePowerUp(mode);
        switch (mode)
        {
            case CharacterMode.RubberBall:
                spriteRenderer.color = Color.red;
                rigidbody2D.gravityScale = 1;
                upSpeed = 10;
                downSpeed = 1;
                break;
            case CharacterMode.CannonBall:
                spriteRenderer.color = Color.black;
                rigidbody2D.gravityScale = 2;
                upSpeed = 0;
                downSpeed = 1;
                break;
            case CharacterMode.Cloud:
                spriteRenderer.color = Color.white;
                rigidbody2D.gravityScale = -0.1f;
                upSpeed = 10;
                downSpeed = 0.075f;
                break;
            case CharacterMode.WaterDrop:
                spriteRenderer.color = Color.cyan;
                rigidbody2D.gravityScale = 1;
                upSpeed = 0;
                downSpeed = 1;
                break;
        }
    }

    public void MoveTo(Transform point)
    {
        transform.position = point.position;
    }

    public void Die()
    {
        Debug.Log("Game lost");
        InitializeCharacter();
    }

    public void EndGame()
    {
        if(inventory.HasCog())
        {
            Debug.Log("Game won!");
        }
        else
        {
            Debug.Log("Game incomplete");
        }

        InitializeCharacter();
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
