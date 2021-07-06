using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 更新弹窗显示信息
/// </summary>
public class ToastDataLoad : MonoBehaviour
{
    [SerializeField] private Text sortNumberText; //获取排行榜上的玩家序号
    [SerializeField] private Text userText; //弹窗显示玩家昵称信息
    [SerializeField] private Text rankText; //弹窗显示玩家排行信息
    private UserData userData; //接受Json数据
    
    //加载弹窗上的玩家信息
    public void LoadPlayerPInfo()
    {
        if (userData == null)
        {
            userData = JsonData.GetItem(); //获取Json数据
        }
        
        int index = int.Parse(sortNumberText.text); //获取玩家序号
        UserInfo info = userData.list[index - 1]; //获取玩家数据
        rankText.text = index.ToString(); //设置玩家排名序号
        userText.text = info.nickName; //设置昵称
    }
}
