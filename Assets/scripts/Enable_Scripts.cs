using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable_Scripts : MonoBehaviour
{
    public static charactercontrool my_char_begine_Script;
    public static speed my_char_speed_Script;
    public static bool count_begin;
    // Start is called before the first frame update
    void Start()
    {
        my_char_begine_Script = GetComponent<charactercontrool>();
        my_char_speed_Script = GetComponent<speed>();
        count_begin = false;
    }

    public static void enable_scripte()
    {
        my_char_begine_Script.enabled = !my_char_begine_Script.enabled;
        my_char_speed_Script.enabled = !my_char_speed_Script.enabled;
        count_begin = true;
    }
}
