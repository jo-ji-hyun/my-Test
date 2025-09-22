using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    private Vector2 _moveDirection;

    private void OnMove(InputValue input)
    {
        _moveDirection = input.Get<Vector2>();
    }

    void FixedUpdate()
    {
        transform.position += moveSpeed * Time.fixedDeltaTime * (Vector3)_moveDirection;
    }
}
