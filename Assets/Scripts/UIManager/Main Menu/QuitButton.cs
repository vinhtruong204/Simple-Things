using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_2017_1_OR_NEWER
using UnityEditor;
#endif

public class QuitButton : BaseButton
{
    protected override void OnClick()
    {
#if UNITY_2017_1_OR_NEWER
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
