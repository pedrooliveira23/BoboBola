using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    private float velocity;
    private bool canCreateSpringBox;

    public float Velocity { get => velocity; set => velocity = value; }
    public bool CanCreateSpringBox { get => canCreateSpringBox; set => canCreateSpringBox = value; }
}
