using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Momos.Tools.DebugLog
{
    /// <summary> 
    /// 'DebugLog'输出器基类,
    /// 实现的底层逻辑,
    /// 应用逻辑放置于子类<see cref="QueueDebugerComponent"/>。
    /// </summary>
    internal class DebugerComponent
    {
        internal DebugerConfigAsset debugerConfig;
        private Dictionary<E_LogMaskShiftAmount, LogMaskBody> maskDic;
        private LogMaskBody outputer;

        internal DebugerComponent()
        {
            if (new DebugerConfigLoader().TryLoad(ref debugerConfig))
                debugerConfig.GetMaskDic(out maskDic);
            else
                Debug.Log($"{nameof(Momos.Tools.DebugLog.DebugerComponent)}: 加载失败,输出将转向使用UnityEngine.Debug.Log");
        }

        /// <summary> 实现遮罩化Log的底层逻辑 </summary>
        internal virtual void Log(string message, E_LogMaskShiftAmount shiftAmountEnum)
        {
            Out(new LogMessageBody(shiftAmountEnum,message));
        }

        /// <summary> 通过遮罩验证是否输出 </summary>
        protected bool VerInput(LogMessageBody message,out LogMaskBody outer)
        {
            outer = null;
            if (debugerConfig == null)  // 未加载到Conifg 强制输出
            {
                return true;
            }
            else if ((debugerConfig.maskFlag & message.Mask) != 0) // 加载到Config 合法输出
            {
                outer = maskDic[message.shiftAmount];
                return true;
            }
            else // 不输出
            {
                return false;
            }
        }

        /// <summary> 输出消息 </summary>
        protected void Out(LogMessageBody outMessage)
        {
            if (VerInput(outMessage, out outputer))
            {
                Debug.Log(outMessage.ToString(outputer));
            }
        }
    }
}