using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCharacter : PlayerCharacter
{
    private Bomb bomb;

    private void Start()
    {
        bomb = GetComponentInChildren<Bomb>(true);
    }
    public override void SpecialAbility()
    {
        if (!bomb.gameObject.activeSelf)
        {
            bomb.Reset(transform.position);
            bomb.gameObject.SetActive(true);
        }
    }
}
