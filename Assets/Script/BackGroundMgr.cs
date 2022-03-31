using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMgr : MonoBehaviour
{
    public static BackGroundMgr instance;


    [SerializeField] private GameObject backGroundPrefab;
    [SerializeField] private float backGroundScrollSpeed;
    [SerializeField] private float backGroundPrefabSize;
    [SerializeField] private int maxBackGroundCount;
    [SerializeField] private Vector3 originPosition;


    private List<BackGroundObject> backGroundList;

    private void Awake()
    {
        InitBackGroundMgr();
    }

    private void InitBackGroundMgr()
    {
        instance = this;

        backGroundList = new List<BackGroundObject>();

        for(int i = 0; i < maxBackGroundCount; i++)
        {
            BackGroundObject bgo = Instantiate(backGroundPrefab).GetComponent<BackGroundObject>();
            bgo.transform.position = originPosition + new Vector3(0, 0, i * backGroundPrefabSize);
            bgo.SetIndex(i);
            backGroundList.Add(bgo);   
            
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        BackGroundMoveUpdate();   
    }

    private void BackGroundMoveUpdate()
    {
        foreach(var bgo in backGroundList)
        {
            bgo.BackGroundScroll(backGroundScrollSpeed);
        }
    }

    public void ResetGround(BackGroundObject bgo)
    {
        int idx;
        idx = bgo.GetIndex() - 1;
        idx = idx < 0 ? backGroundList.Count - 1 : idx;
        idx.Log();

        bgo.transform.position = backGroundList[idx].transform.position += new Vector3(0, 0, backGroundPrefabSize);
        bgo.transform.position -= new Vector3(0, 0, backGroundScrollSpeed * Time.deltaTime);
    }

    public float GetBackGroundObjectSize()
    {
        return backGroundPrefabSize;
    }
}
