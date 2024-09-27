using UnityEngine;

public static class RichTextExtensions {
    public static string RichColor(this string text, string color) => $"<color={color}>{text}</color>";
    public static string RichColor(this string text, Color color) => $"<color=#{ColorUtility.ToHtmlStringRGBA(color)}>{text}</color>";
    
    public static string RichBold(this string text) => $"<b>{text}</b>";
    public static string RichItalic(this string text) => $"<i>{text}</i>";
    public static string RichSize(this string text, int size) => $"<size={size}>{text}</size>";
}