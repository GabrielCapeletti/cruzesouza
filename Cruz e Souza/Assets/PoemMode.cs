using UnityEngine;
using Core;
using System.Collections;

public class PoemMode : MonoBehaviour {

    public Material targetMateria;

    public Color initialColor;

    [HideInInspector]
    public Color color;

    private Color[] colors = { Color.red, Color.yellow, Color.green, Color.blue };

    private GameManager manager;

    void Start()
    {
        this.targetMateria.color = initialColor;// new Color(1f,0.65f,0.21f);
        color = initialColor;
        manager = Singleton<GameManager>.Instance;
    }

    private Color targetColor = Color.red;
    private int counter = 0;
	void Update () {
        if (manager.poemMode)
        {
            color = Color.Lerp(color, targetColor, 0.05f);
            Vector3 color1 = new Vector3(color.r, color.g, color.b);
            Vector3 color2 = new Vector3(targetColor.r, targetColor.g, targetColor.b);

            if (Vector3.Distance(color1, color2) < 0.2f)
            {
                counter++;
                counter = counter % colors.Length;
                targetColor = colors[counter];
            }
            this.targetMateria.color = this.color;
        }
        else
        {
            this.targetMateria.color = initialColor;
        }
	}
}
