using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject bulletPrefab;

    private PlayerCameraCtrl camCtrl;
    private Vector3 moveVector = Vector3.zero;
    private bool onClick;
    
    private void Awake()
    {
        InitPlayerCtrl();
    }

    private void InitPlayerCtrl()
    {
        camCtrl = GameObject.Find("Main Camera").GetComponent<PlayerCameraCtrl>();
    }

    private void Start()
    {
    }

    private void Update()
    {
        PlayerInputUpdate();
        PlayerMoveUpdate();
        PlayerRayUpdate();
    }

    private void PlayerInputUpdate()
    {
        onClick = Input.GetMouseButton(0);

        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = Input.GetAxisRaw("Vertical");
    }

    private void PlayerMoveUpdate()
    {
        transform.position += moveVector.normalized * Time.deltaTime * moveSpeed;
        camCtrl.SetSizeAngle(moveVector.x);
    }

    private void PlayerRayUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("RayHit")))
        {
            "hit".Log();
            if (onClick)
            {
                BulletCtrl bc = Instantiate(bulletPrefab).GetComponent<BulletCtrl>();
                bc.transform.position = transform.position;
                bc.SetTargetPos(hit.point);
            }
        }
    }
}
