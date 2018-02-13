using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityStringEvent : UnityEvent<string>
{
}

[System.Serializable]
public class UnityIntEvent : UnityEvent<int>
{
}

[System.Serializable]
public class UnityBoolEvent : UnityEvent<bool>
{
}