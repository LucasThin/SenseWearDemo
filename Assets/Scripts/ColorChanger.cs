using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField]private Material material;
    private Color originalColor = new Color(0, 126 / 255f, 255 / 255f);
    private Color alertColor = new Color(255 / 255f, 151 / 255f, 0);


    public void ChangeToAlertColor()
    {
        material.SetColor("_BaseColor", alertColor);
    }

    public void ChangeToOriginalColor()
    {
        material.SetColor("_BaseColor", originalColor);
    }
}