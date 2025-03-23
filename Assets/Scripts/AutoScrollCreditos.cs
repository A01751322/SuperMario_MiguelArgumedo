/**
Scrollea el texto de los créditos
Autor: Miguel Angel Argumedo
*/
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

public class AutoScrollCreditos : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 50f;
    [SerializeField] private bool enableLoop = true;
    [SerializeField] private float startDelay = 0f; 
    [SerializeField] private float initialOffset = 200f; 
    [SerializeField] private float maxScrollReduction = 150f;

    private UIDocument document;
    private ScrollView scrollView;
    private VisualElement contentContainer;
    private VisualElement creditosElem;
    private VisualElement duplicadoElem;
    private float creditosHeight = 0f;
    private float viewportHeight = 0f;
    private float currentPosition = 0f;
    private bool setupComplete = false;
    private bool duplicateCreated = false;
    private float resetPauseTimer = 0f;
    private float resetPauseDuration = 0f; // segundos de espera antes de reiniciar
    private bool isPaused = false;

    private void OnEnable()
    {
        document = GetComponent<UIDocument>();
        if (document == null) return;

        var root = document.rootVisualElement;
        scrollView = root.Q<ScrollView>("scrollTexto");

        if (scrollView != null)
        {
            contentContainer = scrollView.Q("unity-content-container");
            scrollView.verticalScrollerVisibility = ScrollerVisibility.Hidden;

            StartCoroutine(DelayedSetup());
        }
    }
        private IEnumerator DelayedSetup()
        {
            yield return new WaitForSeconds(startDelay);

            creditosElem = contentContainer.Q("creditos");

            // Esperar un frame adicional para asegurar que el layout se calcule
            yield return null;

            if (creditosElem != null)
            {
                creditosHeight = creditosElem.resolvedStyle.height;
                viewportHeight = scrollView.resolvedStyle.height;

                currentPosition = initialOffset;
                scrollView.scrollOffset = new Vector2(0, currentPosition);

                if (enableLoop && !duplicateCreated)
                {
                    CreateDuplicate();
                }

                setupComplete = true;
            }
        }

    private void CreateDuplicate()
    {
        if (duplicateCreated) return;

        if (creditosElem is Label creditosLabel)
        {
            var duplicadoLabel = new Label
            {
                name = "creditosDuplicado",
                text = creditosLabel.text
            };
            duplicadoLabel.AddToClassList("creditosStyle");
            duplicadoLabel.style.position = Position.Relative;

            //Ocultamos el duplicado hasta que sea necesario
            duplicadoLabel.style.display = DisplayStyle.None;

            contentContainer.Add(duplicadoLabel);
            duplicadoElem = duplicadoLabel;
        }
        else
        {
            Debug.LogWarning("El elemento 'creditos' no es un Label.");
        }

        duplicateCreated = true;
    }

    private void Update()
    {
        if (!setupComplete || scrollView == null) return;

        if (isPaused)
        {
            resetPauseTimer += Time.deltaTime;
            if (resetPauseTimer >= resetPauseDuration)
            {
                // Reiniciar scroll
                currentPosition = -viewportHeight;
                scrollView.scrollOffset = new Vector2(0, currentPosition);
                resetPauseTimer = 0f;
                isPaused = false;
            }
            return;
        }

        currentPosition += scrollSpeed * Time.deltaTime;

        float resetPoint = creditosHeight + viewportHeight;

        if (currentPosition >= resetPoint)
        {
            isPaused = true;
            return;
        }

        scrollView.scrollOffset = new Vector2(0, currentPosition);
    }
}