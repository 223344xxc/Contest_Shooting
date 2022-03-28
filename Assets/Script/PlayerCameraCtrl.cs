using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraCtrl : MonoBehaviour
{
    [SerializeField] float moveSizeCamAngle;
    [SerializeField] float camRotSpeed;
    private float targetZAngle;

    void Start()
    {
        
    }

    void Update()
    {
        CameraAngleUpdate();
    }
    private void CameraAngleUpdate()
    {
        transform.eulerAngles =
            new Vector3(transform.eulerAngles.x, transform.eulerAngles.y,
            Mathf.LerpAngle(transform.eulerAngles.z, targetZAngle, Time.deltaTime * camRotSpeed));
    }
    public void SetSizeAngle(float angleNum)
    {
        if(angleNum > 0)
        {
            targetZAngle = -moveSizeCamAngle;
        }
        else if(angleNum < 0)
        {
            targetZAngle = moveSizeCamAngle;
        }
        else
        {
            targetZAngle = 0;
        }
    }
}
