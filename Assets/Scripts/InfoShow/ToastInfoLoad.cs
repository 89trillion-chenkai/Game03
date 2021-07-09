using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Toast信息加载
/// </summary>
public class ToastInfoLoad : MonoBehaviour
{
    [SerializeField] private Text txtSortNumber; //获取排行榜上的玩家序号
    [SerializeField] private Text txtUsername; //获取玩家昵称
    
    //加载弹窗上的玩家信息
    public void LoadPlayerPInfo(RectTransform toast)
    {
        toast.GetChild(3).GetComponent<Text>().text = txtSortNumber.text; //设置玩家排名序号
        toast.GetChild(1).GetComponent<Text>().text = txtUsername.text; //设置昵称
    }
}
