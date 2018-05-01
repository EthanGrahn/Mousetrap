using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectProperties : MonoBehaviour {

    [SerializeField]
    StringStringDictionary m_stringStringDictionary;
    public IDictionary<string, string> StringStringDictionary
    {
        get { return m_stringStringDictionary; }
        set { m_stringStringDictionary.CopyFrom(value); }
    }

    /// <summary>
    /// Set (or add if not listed) the value of a custom property.
    /// </summary>
    /// <param name="pName">Property Name.</param>
    /// <param name="pValue">Property Value.</param>
    public void SetProperty(string pName, string pValue)
    {
        m_stringStringDictionary[pName] = pValue;
    }

    /// <summary>
    /// Get the value of the specified property as a boolean.
    /// </summary>
    /// <param name="pName">Property Name</param>
    /// <returns>If value is 0 it returns false. True is returned otherwise.</returns>
    public bool GetBoolProperty(string pName)
    {
        string outVal;
        if (m_stringStringDictionary.TryGetValue(pName, out outVal))
        {
            int result;
            if (Int32.TryParse(outVal, out result))
            {
                if (result == 0)
                    return true;
                else
                    return false;
            }
        }

        Debug.LogError("The dictionary attached to " + gameObject.name + "does not contain a boolean value for key: " + pName);
        return false;
    }

    /// <summary>
    /// Get the value of the specified property as a string.
    /// </summary>
    /// <param name="pName">Property Name.</param>
    /// <returns>Property value as a string.</returns>
    public string GetStringProperty(string pName)
    {
        string outVal;
        if (m_stringStringDictionary.TryGetValue(pName, out outVal))
        {
            return outVal;
        }

        Debug.LogError("The dictionary attached to " + gameObject.name + "does not contain a string value for key: " + pName);
        return String.Empty;
    }

    /// <summary>
    /// Get the value of the specified property as an integer.
    /// </summary>
    /// <param name="pName">Property Name.</param>
    /// <returns>Property value as an integer.</returns>
    public int GetIntProperty(string pName)
    {
        int result = 0;
        string outVal = String.Empty;
        if (m_stringStringDictionary.TryGetValue(pName, out outVal))
        {
            if (Int32.TryParse(outVal, out result))
                return result;
        }

        Debug.LogError("The dictionary attached to " + gameObject.name + "does not contain an integer value for key: " + pName);
        return 0;
    }
}
