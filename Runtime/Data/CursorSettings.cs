using System;
using UnityEngine;

namespace CopperDevs.Tools.CopperTools.Runtime.Data
{
    [Serializable]
    public class CursorSettings
    {
        public CursorLockMode lockMode;
        public bool visible;

        public void Set()
        {
            Cursor.lockState = lockMode;
            Cursor.visible = visible;
        }
    }
}