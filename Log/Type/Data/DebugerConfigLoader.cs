using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Momos.Tools.DebugLog
{
    public class DebugerConfigLoader
    {
        public string resourcePath = "Tools/Config/DebugerConfig";
        public string LocalFullPath => $"{nameof(Resources)}/{resourcePath}.asset";

        public bool TryLoad(ref DebugerConfigAsset configAsset)
        {
            DebugerConfigAsset ca = Get();
            if (ca != null)
            {
                configAsset = ca;
                return true;
            }
            return false;
        }

        /// <param name="path"> 路径从Assets开始 </param>
        public bool IsUsablePath(string path)
        { 
            int resIndex = path.IndexOf(nameof(Resources));
            if (resIndex != -1)
            {
                string suffixPath = path.Substring(resIndex, path.Length - resIndex);
                return suffixPath == LocalFullPath;
            }
            return false;
        }

        private DebugerConfigAsset Get()
        { 
            return Resources.Load<DebugerConfigAsset>(resourcePath);
        }
    }
}