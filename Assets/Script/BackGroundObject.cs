using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundObject : MonoBehaviour
{
    private int backGroundIndexNumber;

    public void BackGroundScroll(float distance)
    {
        transform.position -= new Vector3(0, 0, distance * Time.deltaTime);
        if(transform.position.z < -BackGroundMgr.instance.GetBackGroundObjectSize())
        {
            BackGroundMgr.instance.ResetGround(this);
        }
    }
    
    public void SetIndex(int idx)
    {
        backGroundIndexNumber = idx;
    }

    public int GetIndex()
    {
        return backGroundIndexNumber;
    }
}
