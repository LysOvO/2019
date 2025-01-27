using UnityEngine;
using System.Collections;
//引入库
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System;



public class UdpServer: Singleton <UdpServer>//相当于直接把这个类暴露在公共空间里
{
	
	//以下默认都是私有的成员
	Socket socket; //目标socket
	EndPoint clientEnd; //客户端
	IPEndPoint ipEnd; //侦听端口
	string recvStr; //接收的字符串
	string sendStr; //发送的字符串
	byte[] recvData=new byte[16]; //接收的数据，必须为字节
	byte[] sendData=new byte[16]; //发送的数据，必须为字节
	int recvLen; //接收的数据长度
	Thread connectThread; //连接线程
	public int LightValue;//定义全局光强
	public int temperature;//定义温度
	public int WaterValue;//定义湿度
	public bool onFire = false;//定义是否着火
	public int Fan = 1;
	public int Beep = 4;

	//初始化
	void InitSocket()
	{
		//定义侦听端口,侦听任何IP
		ipEnd=new IPEndPoint(IPAddress.Any,8080);

		//定义套接字类型,在主线程中定义
		socket=new Socket(AddressFamily.InterNetwork,SocketType.Dgram,ProtocolType.Udp);
		//服务端需要绑定ip
		socket.Bind(ipEnd);
		//定义客户端
		IPEndPoint sender=new IPEndPoint(IPAddress.Any,20000);
		clientEnd=(EndPoint)sender;
		print("Waiting for UDP dgram");

		//开启一个线程连接，必须的，否则主线程卡死
		connectThread=new Thread(new ThreadStart(SocketReceive));
		connectThread.Start();
	}

	void SocketSend(string sendStr)
	{
		//清空发送缓存
		sendData=new byte[16];
		//数据类型转换
		sendData=Encoding.ASCII.GetBytes(sendStr);
		//发送给指定客户端
		//socket.SendTo(sendData,sendData.Length,SocketFlags.None,clientEnd);
		socket.SendTo (sendData, clientEnd);
	}

	//服务器接收
	void SocketReceive()
	{
		//进入接收循环
		while(true)
		{
			//对data清零
			recvData=new byte[16]; //接收过来的16进制的字符串
			recvLen=socket.ReceiveFrom(recvData,ref clientEnd);
			//print("message from: "+clientEnd.ToString()); //打印客户端信息
			//输出接收到的数据
			recvStr=Encoding.ASCII.GetString(recvData,0,recvLen);
			//print ("转换成string："+recvStr);
			string n1 = "192.168.137.124:20000"; //光敏传感器的ip
			string n2 = "192.168.137.207:20000";//温湿传感器的ip
			string n3 = "192.168.137.121:20000"; //火焰传感器模块ip

			string n4 = "192.168.137.139:20000"; //风扇传感器ip
		    string n5 = "192.168.137.177:20000"; //蜂鸣器传感器ip
         

            string nn = clientEnd.ToString ();
			//string n1 = "192.168.43.18:20000"; //光敏传感器的ip
			//string n2 = "192.168.43.38:20000"; //温湿传感器的ip
			//string n3 = "192.168.43.94:20000"; //火焰传感器模块ip
			//string n4 = "192.168.43.199:20000"; //风扇传感器ip
			//string n5 = "192.168.43.104:20000"; //蜂鸣器传感器ip
			//print ("转换成数字"+int.Parse (recvStr));
			/*
			if (nn.Equals (n1, StringComparison.OrdinalIgnoreCase)) //识别光敏传感器
				LightValue = int.Parse (recvStr);
			else if (nn.Equals (n2, StringComparison.OrdinalIgnoreCase)) { //识别温湿传感器
				if (int.Parse (recvStr) < 50) //区分温度湿度
					temperature = int.Parse (recvStr);
				else if (int.Parse (recvStr) > 50)
					WaterValue = int.Parse (recvStr);
			} else if (nn.Equals (n3, StringComparison.OrdinalIgnoreCase)) { //识别火焰传感器
				if (int.Parse (recvStr) > 100) { //看下火焰
					onFire = true;
				} else if (int.Parse (recvStr) < 100) {
					onFire = false;
				}
			}
			//print ("温湿:" + temperature + " " + WaterValue);
			else if (nn.Equals (n4, StringComparison.OrdinalIgnoreCase)) { //识别风扇传感器
				if(Fan == 2)
					recvStr = "2";
				else if(Fan == 1)
					recvStr = "1";
			} else if (nn.Equals (n5, StringComparison.OrdinalIgnoreCase)) { //蜂鸣器传感器
				if(onFire == true) recvStr = "3";
				else recvStr = "4";
			}
			*/
			if (nn.Equals (n1, StringComparison.OrdinalIgnoreCase)) //识别光敏传感器
				LightValue = int.Parse (recvStr);
			if (nn.Equals (n2, StringComparison.OrdinalIgnoreCase)) { //识别温湿传感器
				if (int.Parse (recvStr) < 50) //区分温度湿度
					temperature = int.Parse (recvStr);
				else if (int.Parse (recvStr) > 50)
					WaterValue = int.Parse (recvStr);
			}
			if (nn.Equals (n3, StringComparison.OrdinalIgnoreCase)) { //识别火焰传感器
				if (int.Parse (recvStr) > 100) { //看下火焰
					onFire = true;
				} else if (int.Parse (recvStr) < 100) {
					onFire = false;
				}
			}
			//print ("温湿:" + temperature + " " + WaterValue);
			if (nn.Equals (n4, StringComparison.OrdinalIgnoreCase)) { //识别风扇传感器
				if (Fan == 2) {
					recvStr = "2";
				}else if(Fan == 1)
					recvStr = "1";
			}
			if (nn.Equals (n5, StringComparison.OrdinalIgnoreCase)) { //蜂鸣器传感器
				//LightValue = int.Parse ("123");
				if(onFire == true) recvStr = "3";
				else recvStr = "4";
			}
           
            sendStr =recvStr;
			SocketSend(sendStr);
		}
	}


	//连接关闭
	void SocketQuit()
	{
		//关闭线程
		if(connectThread!=null)
		{
			connectThread.Interrupt();
			connectThread.Abort();
		}
		//最后关闭socket
		if(socket!=null)
			socket.Close();
		print("disconnect");
	}

	// Use this for initialization
	void Start()
	{
		InitSocket(); //在这里初始化server
	}
	//string editString="text"; //编辑框文字

	// Update is called once per frame
	void Update()
	{

	}

	void OnApplicationQuit()
	{
		SocketQuit();
	}
}
