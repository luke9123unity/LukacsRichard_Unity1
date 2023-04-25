using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialog", menuName = "Roleplay/Dialog", order = 0)]
public class Dialog : ScriptableObject
{
    [SerializeField] string text = "Default text";

    [SerializeField] string[] answers;

    public string GetText()
    {
        return text;
    }

}

[Serializable]
class Answer
{
    public string text;
    public Dialog dialog;
}
