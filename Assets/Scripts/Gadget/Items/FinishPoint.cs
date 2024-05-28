using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishPoint : Item
{
    public float finishSec;
    public int finishMin;
    public GameObject finishPanel;
    public TextMeshProUGUI finishText;

    private void Update()
    {
        finishSec += Time.deltaTime;
        if(finishSec >= 60f) 
        {
            finishMin += 1;
            finishSec = 0;
        }
    }

    public override void UseItem()
    {
        base.UseItem();
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        finishPanel.SetActive(true);
        finishText.text = string.Format("{0}�� {1:D2}�� ���� �����ҿ� �����߽��ϴ�!", finishMin, (int)finishSec);
        
    }
}
