using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Vector3 targetPos;

    void Start()
    {
        
    }

    void Update()
    {
        BulletMoveUpdate();
    }

    private void BulletMoveUpdate()
    {
        transform.position += (targetPos - transform.position).normalized * Time.deltaTime * moveSpeed;
    }

    public void SetTargetPos(Vector3 pos)
    {
        targetPos = pos;
    }
}
