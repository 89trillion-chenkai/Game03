using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 更新弹窗显示信息
/// </summary>
public class ToastDataLoad : MonoBehaviour
{
    public Text sortNumberText; //排行榜上的玩家序号
    public Text userText; //弹窗玩家信息
    public Text rankText; //弹窗玩家段位信息
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
        int rank = info.trophy / 1000 + 1; //计算玩家段位
        rankText.text = rank.ToString(); //设置段位
        userText.text = info.nickName; //设置昵称
    }
}
