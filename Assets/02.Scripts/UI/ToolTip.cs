using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    public Text name;
    public Text description;

    public void SetUpToolTip(string _name, string _des)
    {
        name.text = _name;
        description.text = _des;
    }
}
