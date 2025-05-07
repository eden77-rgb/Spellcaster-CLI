public class PromptType
{
    public enum Type
    {
        Correction,
        TraductionUS,
        TraductionUK
    }

    public Dictionary<Type, string> Prompt()
    {
        return new Dictionary<Type, string>
        {
            { Type.Correction, "Corrige le texte suivant sans commentaire" },
            { Type.TraductionUS, "Traduis le texte suivant en Anglais (US)" },
            { Type.TraductionUK, "Traduis le texte suivant en Anglais (UK)" }
        };
    }
}