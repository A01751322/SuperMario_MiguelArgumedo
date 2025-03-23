/**
Boton para regresar a Menu principal desde el Juego
Autor: Miguel Angel Argumedo
*/
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class RegresaController : MonoBehaviour 
{
    UIDocument uiRegresa;
    Button botonRegresa;
    void OnEnable()
    {
        uiRegresa = GetComponent<UIDocument>();
        var root = uiRegresa.rootVisualElement;
        
        botonRegresa = root.Q<Button>("BotonRegresa");
        
        // Callbacks
        botonRegresa.RegisterCallback<ClickEvent>(Regresar);
    }
    private void Regresar(ClickEvent evt)
    {
        SceneManager.LoadScene("EscenaMenu");
    }
}