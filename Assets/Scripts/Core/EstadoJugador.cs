using UnityEngine;

public static class EstadoJugador
{
    private const string KEY_LEVEL = "CurrentLevel";
    private const string KEY_HIGHSCORE = "HighScoreNivel3";

    public static int ObtenerNivelGuardado()
    {
        return PlayerPrefs.GetInt(KEY_LEVEL, 1); // Por defecto empieza en Nivel 1
    }

    public static void GuardarNivel(int nivel)
    {
        int nivelMaximo = Mathf.Clamp(nivel, 1, 3);
        PlayerPrefs.SetInt(KEY_LEVEL, nivelMaximo);
        PlayerPrefs.Save();
    }

    public static int ObtenerHighScore()
    {
        return PlayerPrefs.GetInt(KEY_HIGHSCORE, 0);
    }

    public static bool IntentarGuardarHighScore(int nuevoPuntaje)
    {
        int recordActual = ObtenerHighScore();
        if (nuevoPuntaje > recordActual)
        {
            PlayerPrefs.SetInt(KEY_HIGHSCORE, nuevoPuntaje);
            PlayerPrefs.Save();
            return true; // Hubo nuevo récord
        }
        return false;
    }
}
