using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour
{
    private Inventory inventory;
    private Text text;

    [SerializeField] private TypeOfCollectible collectibleType;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        text = GetComponent<Text>();

        switch(collectibleType)
        {
            case TypeOfCollectible.Points:
                inventory.OnChangedPoints += UpdateText;
                break;
            case TypeOfCollectible.WhitePU:
                inventory.OnChangedWhitePU += UpdateText;
                break;
            case TypeOfCollectible.RedPU:
                inventory.OnChangedRedPU += UpdateText;
                break;
            case TypeOfCollectible.BluePU:
                inventory.OnChangedBluePU += UpdateText;
                break;
            case TypeOfCollectible.BlackPU:
                inventory.OnChangedBlackPU += UpdateText;
                break;
        }
    }

    private void UpdateText(int number)
    {
        text.text = number.ToString();
    }

    private void OnDestroy()
    {
        switch (collectibleType)
        {
            case TypeOfCollectible.Points:
                inventory.OnChangedPoints -= UpdateText;
                break;
            case TypeOfCollectible.WhitePU:
                inventory.OnChangedWhitePU -= UpdateText;
                break;
            case TypeOfCollectible.RedPU:
                inventory.OnChangedRedPU -= UpdateText;
                break;
            case TypeOfCollectible.BluePU:
                inventory.OnChangedBluePU -= UpdateText;
                break;
            case TypeOfCollectible.BlackPU:
                inventory.OnChangedBlackPU -= UpdateText;
                break;
        }
    }
}

public enum TypeOfCollectible
{
    Points, BluePU, RedPU, WhitePU, BlackPU
}
