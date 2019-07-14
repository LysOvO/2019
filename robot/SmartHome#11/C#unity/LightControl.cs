using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 灯光报警的控制
/// 类名要和文件名保持一致，不然会出错
/// </summary>
public class LightControl : Singleton<LightControl>//相当于直接把这个类暴露在公共空间里
{


    /// <summary>
    /// 控制警报触发，是否开启了警报
    /// </summary>
	public bool m_onAlarm = false;

    /// <summary>
    /// 切换灯光的速度
    /// </summary>
    private float m_trunSpeed = 4.0f;

    /// <summary>
    /// 高强光
    /// </summary>
    private float m_highIntensity = 4.0f;

    /// <summary>
    /// 低强光
    /// </summary>
    private float m_lowIntensity = 0f;

    /// <summary>
    /// 目标光强度
    /// </summary>
    private float m_targetIntensity = 0f;

    /// <summary>
    /// 警报灯光组件
    /// </summary>
    private Light m_alarmLight;

    void Start()
    {
        // 初始化灯光
        m_alarmLight = GetComponent<Light>();
        // 初始化灯光强度
        m_targetIntensity = m_highIntensity;
    }


    void Update()
    {
		m_onAlarm = UdpServer.Instance.onFire;
        // 如果警报打开
        if (m_onAlarm)
        {
            // 灯光逐渐变化为目标灯光强度
            m_alarmLight.intensity = 
                Mathf.Lerp(m_alarmLight.intensity, m_targetIntensity, Time.deltaTime * m_trunSpeed);
            // 如果当前灯光强度和目标强度之间小于0.01f
            if (Mathf.Abs(m_alarmLight.intensity - m_targetIntensity) < 0.01f)
            {
                // 如果当前灯光是最大强度光，让它等于最低光
                if (m_targetIntensity == m_highIntensity)
                {
                    m_targetIntensity = m_lowIntensity;
                }
                else
                {
                    // 如果当前是最低，那么让它等于最高
                    m_targetIntensity = m_highIntensity;
                }
            }
        }
        else
        {
            // 如果灯光关闭了，让灯光强度逐渐减小为0
            m_alarmLight.intensity = Mathf.Lerp(m_alarmLight.intensity, m_lowIntensity, Time.deltaTime * m_trunSpeed);
            // 如果警报灯光强度小于0.05f
            if (m_alarmLight.intensity < 0.05f)
            {
                m_alarmLight.intensity = 0f;
            }
        }
    }

}