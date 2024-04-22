using System;
using UnityEngine;

namespace CopperTools.Data
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