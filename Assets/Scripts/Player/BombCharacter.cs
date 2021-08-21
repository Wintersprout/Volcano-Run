using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCharacter : PlayerCharacter
{
    private Bomb bomb;

    protected override void Awake()
    {
        base.Awake();
        runSpeed = 16;
        bomb = GetComponentInChildren<Bomb>(true);
    }
    public override void SpecialAbility()
    {
        if (!bomb.gameObject.activeSelf)
        {
            if (playerAudio != null)
                playerAudio.Play();
            bomb.Reset();
            bomb.gameObject.SetActive(true);
        }
    }
}
