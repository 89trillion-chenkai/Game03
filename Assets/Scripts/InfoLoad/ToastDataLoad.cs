using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 更新弹窗显示信息
/// </summary>
public class ToastDataLoad : MonoBehaviour
{
    [SerializeField] private Text txtSortNumber; //获取排行榜上的玩家序号
    [SerializeField] private Text txtUserName; //弹窗显示玩家昵称信息
    [SerializeField] private Text txtRank; //弹窗显示玩家排行信息
    private UserData userData; //接受Json数据
    
    //加载弹窗上的玩家信息
    public void LoadPlayerPInfo()
    {
        if (userData == null)
        {
            userData = JsonData.GetItem(); //获取Json数据
        }
        
        int index = int.Parse(txtSortNumber.text); //获取玩家在排行榜上的名次序号
        UserInfo info = userData.list[index - 1]; //获取玩家数据
        txtRank.text = index.ToString(); //设置玩家排名序号
        txtUserName.text = info.nickName; //设置昵称
    }
}
