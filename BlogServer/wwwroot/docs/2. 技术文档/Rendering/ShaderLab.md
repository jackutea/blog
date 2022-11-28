#shader #unity

### Properties
1.  类型  
--Int  
--Float  
--Vector  
--Range  
--Color  
--2D  
--CUBE  
1.  声明方式  
--_C("ColorA", Color) = (1, 0, 0, 1)  
----_C 是变量名  
----“ColorA” 是显示在面板上的名字  
----Color 是类型  
----(1, 0, 0, 1) 是初始值  

### 语义
1.  SV_TARGET 相当于 COLOR
2.  SV_POSITION 相当于 Object Space Position  
3.  POSITION 即位置  
--WS 世界坐标  
--OS 模型坐标  
--CS 裁剪坐标  
1.  TEXCOORD 纹理
--TEXCOORD0 表面纹理  
--1 ~ 7，凹凸纹理、法线纹理  

### 内置类型
1.  32位 float
2.  16位 half：-60000 ~ 60000
3.  11位 fixed：-2.0 ~ 2.0
4.  sampler2D，用于表示Texture2D

### 规则
1. fragment 返回值一定是**色彩**
2.  fragment 就是**逐像素上色**
3.  UV 左下角是(0, 0)

### 内置变量
1.  float4 _Time 自游戏开始以来的时间(秒)
--(t/20, t, t_2, t_3)  
2.  float4 UNITY_LIGHTMODEL_AMBIENT 环境光

### 内置函数
1.  CG 标准函数：(https://www.jianshu.com/p/da4950db9a00)
2.  CG 标准库：(https://developer.download.nvidia.cn/cg/index_stdlib.html)
3.  lerp(a, b, percent) 过渡
4.  saturate(float3) 饱和度
5.  step(edge, n) 返回0 1