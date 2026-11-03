using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComentariosManager : MonoBehaviour
{
    [SerializeField] private GameObject panelDialogo;
    [SerializeField] private Image imgPersonaje;
    [SerializeField] private TextMeshProUGUI txtExplicacion;
    [SerializeField] private Sprite spriteAcierto;
    [SerializeField] private Sprite spriteFallo;

    public void MostrarDialogo(bool esCorrecto, string explicacion)
    {
        panelDialogo.SetActive(true);
        imgPersonaje.sprite = esCorrecto ? spriteAcierto : spriteFallo;
        string prefijo = esCorrecto ? "<color=green>¡Correcto!</color> " : "<color=red>¡Incorrecto!</color> ";
        txtExplicacion.text = prefijo + explicacion;
    }

    public void OcultarDialogo()
    {
        panelDialogo.SetActive(false);
    }
}
