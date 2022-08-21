using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
public class Textutil : MonoBehaviour
{
    public static bool IsUpperAlpha (char c)
    {
        return c >= 'A' && c<= 'Z';
    }
    public static bool IsLowerAlpha(char c)
    {
        return c >= 'a' && c <= 'z';
    }
    public static bool IsAlpha(char c)
    {
        return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
    }

}
}