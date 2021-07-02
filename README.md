# Game01

## 1.整体框架

使用Scroll Rect和Grid Layout Group实现排列页面和上下滑动的功能。滑动列表采用调整对象位置复用的方法优化。物品数据通过Json文件读取存储在一个类对象的List里面。

## 2.目录结构
```｜  
｜——Resources   
｜  ｜——JsonData  
｜     ｜——ranklist 			#Json文件  
｜
｜——Scripts   
｜  ｜——DataManagers  
｜  ｜  ｜——JsonData        		#读取Json数据    
｜  ｜  ｜——ObjectPool	    	        #对象池  
｜  ｜  
｜  ｜——InfoLoad  
｜  ｜  ｜——LeaderboardInfoLoad          #排行榜信息加载     
｜  ｜  ｜——PlayerInfoLoad		#玩家信息加载  
｜  ｜  ｜——ToastDataLoad		#弹窗信息加载  
｜  ｜   
｜  ｜——UIControl    
｜     ｜——CountDownUIControl 		#倒计时控制    
｜     ｜——EnterUIControl 		#进入主界面控制   
｜     ｜——ImageScrollShowControl 	#卡片滑动控制      
｜     ｜——LeaderBoardShowControl	#排行榜显示控制  
｜     ｜——ToastShowControl		#弹窗显示控制  
｜
```

## 3.代码逻辑分层

代码逻辑分为三层，分别是main、controller、model。 mian层负责读取和更新数据，controller控制UI界面的显示隐藏，model层显示界面具体信息。EnterUIControl负责控制主界面显示，CountDownUIControl负责倒计时显示，ImageScrollShowControl负责滑动时卡片物体的复用，LeaderBoardShowControl负责排行榜显示隐藏控制，ToastShowControl负责弹窗显示隐藏控制，LeaderboardInfoLoad负责排行榜信息加载，PlayerInfoLoad负责加载玩家卡片上的信息，ToastDataLoad负责加载弹窗上的信息。

## 4.存储设计

物品数据存储在一个类对象的List里面。 信息卡片做成预制体以供使用，弹窗作为预制体放在信息卡片预制体下。卡片物体通过对象池生成。

## 5.接口设计

物品数据通过Json文件读取存储在一个类对象的List里面，在其它类里可以通过此类提供的一个静态方法访问物品数据。

## 6.todo

后续优化：可以获取显示界面的长度动态设置卡片的长度。
