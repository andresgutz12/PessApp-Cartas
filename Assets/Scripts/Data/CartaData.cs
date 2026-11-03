using UnityEngine;

[CreateAssetMenu(fileName = "Carta_", menuName = "Juego/Carta Gramatical")]
public class CardData : ScriptableObject
{
    public string palabra; // Escribirla con tilde normal, ej: "Pájaro" o "Árbol"
    public Sprite figura;  // Indispensable para el Nivel 2 y Nivel 3
    public CategoriaGramatical categoria;
    public Sprite fondoCarta;
    [TextArea(2, 4)]
    public string explicacion;
}