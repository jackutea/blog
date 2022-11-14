## >> 创建项目 <<
Step 1 - Create MySolution
	IDE: VS 2019
	Project Name: 自定义，我的叫dxengine

Step 2 - Import Solution From DirectXTK
	https://github.com/microsoft/DirectXTK

Step 3 - Generate XTK Includes&Libraries
	Gen x86 Debug&Release
	Gen x64 Debug&Release

Step 4 - Copy XTK Includes&Libraries To dxengine
	dxengine/Includes
	dxengine/Libs/x86/Debug ⇒ xtk.lib
	dxengine/Libs/x64/Release ⇒ xtk.lib
	dxengine/Libs/x86/Debug ⇒ xtk.lib
	dxengine/Libs/x64/Release ⇒ xtk.lib

Step 4 - Setting Project Properties
	Set Libraries
	Set Includes

Step 5 - Entry Code

## **>> PART 0 概念 <<**
WND = Window
Primitive = 原始图形
LH = Left-Hand 左手坐标系
IA = Input Assembler 输入收集器，向流水线提供顶点、直线或三角形数据
VS = Vertex Shader 顶点着色器
Tessellation = 曲面细分，描述一个曲面所需的三角形数
GS = Geometry Shader 几何着色器
RS = Rasterizer 光栅化
PS = Pixel Shader 像素着色器。处理 Color 与 Depth，通常是最耗时的阶段。
OM = Output-Merger 输出合并。Depth Test / Stencil Test / Color Blending
Texcoord = 贴图
Constant Buffer = 单次DrawCall时始终不变的缓存
Buffer 只是字节流，不需要类型，而是以 bytewidth 对齐
Camera 相机实际上并不移动，移动相机时，是整个世界偏移了。
Eye Position
Look At Position
Up Vector 只能XYZ其中一个有值
Projection = 投影
RGB = RGB * A

【Blend】
SA = Source Alpha
SBF = Source Blend Factor
DA = Destination Alpha
DBF = Destination Blend Factor
BO = Blend Operation
FA = Final Alpha
FA = mul(SA, SBF) + mul(DA, DBF)

## **>> PART 1 常用类型 <<**
【Windows窗口相关】
WNDCLASSEX
HWND
HINSTANCE
WNDPROC

【DX11相关】
IDXGIFactory 显示类工厂
EnumAdapters 获取所有显示设备适配器
ID3D11Device 显示设备
CreateRenderTargetView
ID3D11DeviceContext 显示设备上下文
OMSetRenderTarget
ID3D11RenderTargetView 渲染视图
IDXGISwapChain 交换链
DXGI_SWAP_CHAIN_DESC 交换链描述信息
DXGI_MODE_DESC
DXGI_SAMPLE_DESC
DXGI_USAGE
DXGI_SWAP_EFFECT
IDXGIAdapter 显示设备
ID3D11VertexShader 顶点着色器
ID3D10Blob 顶点数据二进制缓存
ID3D11InputLayout
D3D11_VIEWPORT
ID3D11Texture2D 贴图
D3D11_INPUT_ELEMENT_DESC

## **>> PART 2 常用接口 <<**
【Window】
WNDPROC OnWindowProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
这个接口主要处理三件事：
	第一层：根据msg判断事件的主要类型，比如WM_CLOSE是关闭窗口
	第二层：wParam是msg下的子消息参数
	第三层：lParam是wParam下的子消息参数
具体见：
[Window Messages (Get Started with Win32 and C++) - Win32 apps](https://docs.microsoft.com/en-us/windows/win32/learnwin32/window-messages)

【DX11】
D3D11CreateDeviceAndSwapChain 创建显示设备和交换链

## >> PART 3 执行流程 <<
### **Step1 Initialize**
InitializeWindow
	声明窗口信息：WNDCLASSEX wc
	
	注册窗口：RegisterClassEx
	In:
		HINSTANCE
	Out:
		WNDPROC
	
	创建窗口：CreateWindowEx
	In:
		HINSTANCE
		LPVOID 作为WM_CREATE消息传入的指针，可调用reinterpret_cast<CREATESTRUCTW*>通过lParam取出CREATESTRUCTW*，再对应转换成自定义的实例
	Out:
		HWND
	
	显示窗口：ShowWindow
	
	弹出窗口：SetForegroundWindow
	
	聚焦窗口：SetFocus
	
	监听键盘/鼠标事件：WNDPROC OnWindowProc;

InitializeDirectX
	获取设备信息：GetAdapters

	设置交换链信息：DXGI_SWAP_CHAIN_DESC scd;
	关键Param:
		scd.OutputWindow = hwnd

	创建设备和交换链：D3D11CreateDeviceAndSwapChain
	In:
		IDXGIAdapter 实例
		DXGI_SWAP_CHAIN_DESC 实例
	Out:
		ID3D11Device 实例
		ID3D11DeviceContext 实例
		IDXGISwapChain 实例
		
	获取交换链信息：IDXGISwapChain::GetBuffer
	In:
		ID3D11Texture2D*
	Out:
		ID3D11Texture2D*
	
	创建视图：ID3D11Device::CreateRenderTargetView
	In:
		ID3D11Texture2D*
		ID3D11RenderTargetView*
	Out:
		ID3D11RenderTargetView*
	
	渲染融合视图：ID3D11DeviceContext::OMSetRenderTargets
	In:
		ID3D11RenderTargetView*

InitializeShaders
	配置图层信息：D3D11_INPUT_ELEMENT_DESC layoutDesc[];
	
	读取Shader至内存：D3DReadFileToBlob
	In:
		ID3D10Blob*
	Out:
		ID3D10Blob*
	
	创建顶点Shader：ID3D11Device::CreateVertexShader
	In:
		LPVOID → Shader Buffer 指针
		SIZE_T → Shader Buffer 大小
		ID3D11VertexShader*
	Out:
		ID3D11VertexShader*
	
	创建图层：ID3D11Device::CreateInputLayout
	In:
		SIZE_T → Shader Buffer 大小

==== ProcessInput ====
ProcessMessages
	获取最新事件消息：PeekMessage
	In:
		MSG*
	Out:
		MSG*
	
	翻译消息：TranslateMessage
	In:
		MSG*
	Out:
		MSG*
	
	分发消息：DispatchMessage
	In:
		MSG*
	Out:
		MSG*

(Invoke WNDPROC)

==== Update ====

==== RenderFrame ====

## >> PART 4 绘制说明 <<

【渲染管线】
[Graphics pipeline - Win32 apps](https://docs.microsoft.com/en-us/windows/win32/direct3d11/overviews-direct3d-11-graphics-pipeline)
![[IMG_DX11Pipeline.png]]

Topology 决定绘点、线、三角
当绘制三角时，只能顺时针，否则什么也画不出
矩阵变换时，Rotate和Scale放前，Translate应放后
DX数学库与Shader存储矩阵的方向不同，前者以行为主，后者以列为主。Shader可通过row_major声明处理，DX亦可通过XMMatrixTranspose