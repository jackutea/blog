#git

# PART 0 提交
【原则】  
每次提交只处理一件事。  

【格式】  
提交格式为：  
	标题 + 标题内容  
	描述(可选)  

举例：  
\<feature\> 新增: 角色跳跃  
物理组件为 Character Controller  

以例子来看，  
	标题：”\<feature\>”  
	标题内容：”新增: 角色跳跃”  
	描述：”物理组件为 Character Controller”  

# PART 1 分支协作  
【原则】  
分支不共用。  
  
【固定分支】  
main：稳定可运行的分支。一般情况下，从这个分支发布稳定版本。  
develop：处于开发状态的分支。一般情况下，从这个分支创建出其他分支  

【分支命名规范】  
分支名：分支前缀 + / + 分支用途描述 + @分支归属者  
举例：feature/camera@jackwithtea  

【创建分支步骤】  
1、默认情况下，从develop创建分支：  
可从网页上直接创建  
可用git客户端创建  

2、推送分支到仓库  
【合并分支步骤】  
1、提交内容到本分支（自己的分支）  
2、在gitlab网页上提交merge request，将本分支合并到目标分支  
3、如有冲突：  
程序员：与目标分支归属者共同处理变基或合并  
非程序员：喊程序员来帮忙  

4、@管理员，通知合并已提交  