using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public static class StringExtensions
{
    public static List<float> VectorStringToFloatList(string vector)
    {
        //if(Regex.IsMatch(vector, "[A-Z][a-z]!@#%&"))
        if (vector.StartsWith("(") && vector.EndsWith(")"))
        {
            vector = vector.Substring(1, vector.Length - 2);
        }
        else if (vector.StartsWith("("))
        {
            vector = vector.Substring(1, vector.Length - 1);
        }
        else if (vector.EndsWith(")"))
        {
            vector = vector.Substring(0, vector.Length - 2);
        }
        string[] vectorValues = vector.Split(',');

        List<float> result = new List<float>();
        for (int i = 0; i < vectorValues.Length; i++)
        {
            result.Add(float.Parse(vectorValues[i]));
        }
        return result;
    }

 //   private static string RemoveParenthesis(string input)
	//{
 //       in
	//}

    public static Vector3 VectorStringToVector3(string vector)
	{
        List<float> floatList = VectorStringToFloatList(vector);
        return new Vector3(floatList[0], floatList[1], floatList[2]);
	}

    public static string Vector3ToString(Vector3 vector)
	{
        string newVectorText = "(" + vector.x.ToString("0.0") + ", " + vector.y.ToString("0.0") + ", " + vector.z.ToString("0.0") + ")";
        return newVectorText;
    }
}
