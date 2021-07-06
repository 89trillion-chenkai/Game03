using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 读取Json数据
/// </summary>
[Serializable]
public class UserInfo //数据模板类
{
    public string uid; //玩家id
    public string nickName; //玩家昵称
    public string avatar; //玩家头像id，全部设置为userhead.png
    public int trophy; //用户奖杯数量
    private string thirdAvatar; //忽略
}

public class UserData //数据接收类
{
    public string countDown; //倒计时
    public List<UserInfo> list; //玩家信息
}

public class JsonData : MonoBehaviour
{
    public static UserData data;
    
    private void Awake()
    {
        TextAsset itemText = Resources.Load<TextAsset>("JsonData/ranklist"); //从Resources加载Json数据
        string itemJson = itemText.text;
        data = JsonUtility.FromJson<UserData>(itemJson);
        
        //按奖杯数量对玩家信息进行从大到小的排序
        data.list.Sort((x, y) =>
        {
            return y.trophy - x.trophy;
        });
    }

    //供外界获取Json数据
    public static UserData GetItem()
    {
        return data;
    }
}