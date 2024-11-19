using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Momos.Tools.DebugLog.Demo
{
    internal class DebugerDemo : MonoBehaviour
    {
        //private E_LogMaskShiftAmount[] shiftAmountEnums;
        //private E_LogMaskShiftAmount[] ShiftAmountEnums
        //{
        //    get
        //    { 
        //        if(shiftAmountEnums == null)
        //            shiftAmountEnums = (E_LogMaskShiftAmount[])Enum.GetValues(typeof(E_LogMaskShiftAmount));
        //        return shiftAmountEnums;
        //    }
        //}

        private void OnGUI()
        {
            //foreach (E_LogMaskShiftAmount shift in ShiftAmountEnums)
            //{ 
            //    if (GUILayout.Button($"从{shift.ToString()}输出"))
            //    {
            //            Debuger.Log($"{(int)shift}", shift);
            //    }
            //}

            if (GUI.Button(new Rect(0,0,200,100), $"从{E_LogMaskShiftAmount.Global.ToString()}输出"))
            {
                    Debuger.Log($"{(int)E_LogMaskShiftAmount.Global}", E_LogMaskShiftAmount.Global);
            }
            
            if (GUI.Button(new Rect(200, 0,200,100), $"从{E_LogMaskShiftAmount.Amount1.ToString()}输出"))
            {
                    Debuger.Log($"{(int)E_LogMaskShiftAmount.Amount1}", E_LogMaskShiftAmount.Amount1);
            }
            
            if (GUI.Button(new Rect(400, 0,200,100), $"从{E_LogMaskShiftAmount.Amount2.ToString()}输出"))
            {
                    Debuger.Log($"{(int)E_LogMaskShiftAmount.Amount2}", E_LogMaskShiftAmount.Amount2);
            }
            
            if (GUI.Button(new Rect(600, 0,200,100), $"从{E_LogMaskShiftAmount.Amount3.ToString()}输出"))
            {
                    Debuger.Log($"{(int)E_LogMaskShiftAmount.Amount3}", E_LogMaskShiftAmount.Amount3);
            }
            if (GUI.Button(new Rect(800, 0,200,100), $"从{E_LogMaskShiftAmount.Amount4.ToString()}输出"))
            {
                    Debuger.Log($"{(int)E_LogMaskShiftAmount.Amount4}", E_LogMaskShiftAmount.Amount4);
            }
        }
    }
}