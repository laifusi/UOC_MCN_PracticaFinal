using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int totalPoints;
    private CharacterMovement characterLogic;
    private bool cogCollected, mapCollected, keyCollected;

    [SerializeField] private int bluePowerUps, redPowerUps, blackPowerUps, whitePowerUps;
    [SerializeField] private GameObject mapIcon, cogIcon, keyIcon;

    public Action<int> OnChangedBluePU, OnChangedRedPU, OnChangedBlackPU, OnChangedWhitePU;
    public Action<int> OnChangedPoints;

    private void Start()
    {
        characterLogic = GetComponent<CharacterMovement>();
    }

    public void AddPoints(int points)
    {
        totalPoints += points;
        OnChangedPoints?.Invoke(totalPoints);
    }

    public void AddModePowerUp(CharacterMode mode)
    {
        switch(mode)
        {
            case CharacterMode.CannonBall:
                blackPowerUps++;
                OnChangedBlackPU?.Invoke(blackPowerUps);
                break;
            case CharacterMode.Cloud:
                whitePowerUps++;
                OnChangedWhitePU?.Invoke(whitePowerUps);
                break;
            case CharacterMode.RubberBall:
                redPowerUps++;
                OnChangedRedPU?.Invoke(redPowerUps);
                break;
            case CharacterMode.WaterDrop:
                bluePowerUps++;
                OnChangedBluePU?.Invoke(bluePowerUps);
                break;
        }
    }

    public void UseModePowerUp(CharacterMode mode)
    {
        switch (mode)
        {
            case CharacterMode.CannonBall:
                if(blackPowerUps == 0)
                {
                    characterLogic.Die();
                    return;
                }
                blackPowerUps--;
                OnChangedBlackPU?.Invoke(blackPowerUps);
                break;
            case CharacterMode.Cloud:
                if (whitePowerUps == 0)
                {
                    characterLogic.Die();
                    return;
                }
                whitePowerUps--;
                OnChangedWhitePU?.Invoke(whitePowerUps);
                break;
            case CharacterMode.RubberBall:
                if (redPowerUps == 0)
                {
                    characterLogic.Die();
                    return;
                }
                redPowerUps--;
                OnChangedRedPU?.Invoke(redPowerUps);
                break;
            case CharacterMode.WaterDrop:
                if (bluePowerUps == 0)
                {
                    characterLogic.Die();
                    return;
                }
                bluePowerUps--;
                OnChangedBluePU?.Invoke(bluePowerUps);
                break;
        }
    }

    public void CollectMap()
    {
        mapCollected = true;
        mapIcon.SetActive(true);
    }

    public void CollectCog()
    {
        cogCollected = true;
        cogIcon.SetActive(true);
    }

    public void CollectKey()
    {
        keyCollected = true;
        keyIcon.SetActive(true);
    }

    public bool HasKey()
    {
        return keyCollected;
    }

    public bool HasCog()
    {
        return cogCollected;
    }
}
