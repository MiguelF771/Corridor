using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public static class WebGLPlugins
{
    [DllImport("__Internal")]
    public static extern void SendJsonWeb(string text);
}
