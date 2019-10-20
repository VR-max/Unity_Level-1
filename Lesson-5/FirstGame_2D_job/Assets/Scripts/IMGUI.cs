using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMGUI : MonoBehaviour
{
    [SerializeField] private Hero _hero;

    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 100, 30), "");
        //GUI.Label(new Rect(20, 10, 50, 30), _hero.GetHP().ToString());
    }
}
