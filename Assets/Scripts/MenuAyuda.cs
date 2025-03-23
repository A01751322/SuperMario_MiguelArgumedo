/**
Modifica el estado de los contenedores cuando se da click en botón ayuda
Autor: Miguel Angel Argumedo
*/
using UnityEngine;
using UnityEngine.UIElements;

public class MenuAyuda : MonoBehaviour
{
    private VisualElement conAyuda;
    private VisualElement botones;

    private Button botonAyuda;
    private Button botonClose;

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Obtener referencias
        conAyuda = root.Q<VisualElement>("conAyuda");
        botones = root.Q<VisualElement>("Botones");

        botonAyuda = root.Q<Button>("BotonAyuda");
        botonClose = root.Q<Button>("closeAyuda");

        // Mostrar ayuda y ocultar menú
        botonAyuda.clicked += () =>
        {
            conAyuda.style.display = DisplayStyle.Flex;
            botones.style.display = DisplayStyle.None;
        };

        // Ocultar ayuda y volver a mostrar menú
        botonClose.clicked += () =>
        {
            conAyuda.style.display = DisplayStyle.None;
            botones.style.display = DisplayStyle.Flex;
        };
    }
}