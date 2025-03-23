/**
Botón para regresar a Menu pricipal desde Créditos
Autor: Miguel Angel Argumedo
*/
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class RegresarCreditos : MonoBehaviour
{
    UIDocument uiRegresa;
    Button botonRegresa;
    void OnEnable()
    {
        uiRegresa = GetComponent<UIDocument>();
        var root = uiRegresa.rootVisualElement;
        
        botonRegresa = root.Q<Button>("Cerrar");
        
        // Callbacks
        botonRegresa.RegisterCallback<ClickEvent>(Regresar);
    }
    private void Regresar(ClickEvent evt)
    {
        SceneManager.LoadScene("EscenaMenu");
    }
}