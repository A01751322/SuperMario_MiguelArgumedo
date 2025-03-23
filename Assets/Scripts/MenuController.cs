/**
Cambia de escena cuando se le pica a los botones Jugar o Créditos
Autor: Miguel Angel Argumedo
*/
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private UIDocument menu;
    private Button botonJugar;
    private Button botonAyuda;
    private Button botonCreditos;

    void OnEnable()
    {
        menu = GetComponent<UIDocument>();
        var root = menu.rootVisualElement;

        botonJugar = root.Q<Button>("BotonJugar");
        botonCreditos = root.Q<Button>("BotonCreditos");

        botonJugar.RegisterCallback<ClickEvent>(IniciarJugar);
        botonCreditos.RegisterCallback<ClickEvent>(IniciarCreditos);

    }

    private void IniciarJugar(ClickEvent evt)
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    private void IniciarCreditos(ClickEvent evt)
    {
        SceneManager.LoadScene("Creditos");
    }
}
