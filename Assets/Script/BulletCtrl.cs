using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Vector3 moveDirection;

    private void Awake()
    {
        Destroy(gameObject, 10.0f);
    }

    void Start()
    {
        
    }

    void Update()
    {
        BulletMoveUpdate();
    }

    private void BulletMoveUpdate()
    {
        transform.position += moveDirection.normalized * Time.deltaTime * moveSpeed;
    }

    public void SetMoveDirection(Vector3 pos)
    {
        moveDirection = pos;
    }
}
