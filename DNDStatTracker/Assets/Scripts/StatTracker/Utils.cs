using UnityEngine;

public static class Utils
{
    public static Color StrengthColor = new Color(0.756f, 0.376f, 0.301f);
    public static Color DexterityColor = new Color(0.329f, 0.870f, 0.698f);
    public static Color ConstitutionColor = new Color(0.925f, 0.811f, 0.286f);
    public static Color IntelligenceColor = new Color(0.549f, 0.768f, 0.482f);
    public static Color WisdomColor = new Color(0.670f, 0.384f, 0.611f);
    public static Color CharismaColor = new Color(0.913f, 0.858f, 0.8f);
    
    public static int StatToMod(int stat)
    {
        return (int)Mathf.Floor((stat - 10) / 2f);
    }
    
    public static int ProficiencyBonus(int level)
    {
        switch (level)
        {
            case int n when (n >= 1 && n <= 4):
                return 2;
            case int n when (n >= 5 && n <= 8):
                return 3;
            case int n when (n >= 9 && n <= 12):
                return 4;
            case int n when (n >= 13 && n <= 16):
                return 5;
            case int n when (n >= 17 && n <= 20):
                return 6;
            default:
                return 0;
        }
    }

    public static int ExpToLvl(int exp)
    {
        switch (exp)
        {
            case int n when (n >= 0 && n <= 299):
                return 1;
            case int n when (n >= 300 && n <= 899):
                return 2;
            case int n when (n >= 900 && n <= 2699):
                return 3;
            case int n when (n >= 2700 && n <= 6499):
                return 4;
            case int n when (n >= 6500 && n <= 13999):
                return 5;
            case int n when (n >= 14000 && n <= 22999):
                return 6;
            case int n when (n >= 23000 && n <= 33999):
                return 7;
            case int n when (n >= 34000 && n <= 47999):
                return 8;
            case int n when (n >= 48000 && n <= 63999):
                return 9;
            case int n when (n >= 64000 && n <= 84999):
                return 10;
            case int n when (n >= 85000 && n <= 99999):
                return 11;
            case int n when (n >= 100000 && n <= 119999):
                return 12;
            case int n when (n >= 120000 && n <= 139999):
                return 13;
            case int n when (n >= 140000 && n <= 164999):
                return 14;
            case int n when (n >= 165000 && n <= 194999):
                return 15;
            case int n when (n >= 195000 && n <= 224999):
                return 16;
            case int n when (n >= 225000 && n <= 264999):
                return 17;
            case int n when (n >= 265000 && n <= 304999):
                return 18;
            case int n when (n >= 305000 && n <= 354999):
                return 19;
            case int n when (n >= 355000 && n <= 999999):
                return 20;
            default:
                return 0;
        }
    }

    public static int ExpNeededToLvl(int level)
    {
        switch (level)
        {
            case 1:
                return 0;
            case 2:
                return 300;
            case 3:
                return 900;
            case 4:
                return 2700;
            case 5:
                return 6500;
            case 6:
                return 14000;
            case 7:
                return 23000;
            case 8:
                return 34000;
            case 9:
                return 48000;
            case 10:
                return 64000;
            case 11:
                return 85000;
            case 12:
                return 100000;
            case 13:
                return 120000;
            case 14:
                return 140000;
            case 15:
                return 165000;
            case 16:
                return 195000;
            case 17:
                return 225000;
            case 18:
                return 265000;
            case 19:
                return 305000;
            case 20:
                return 355000;
            default:
                return 0;
        }
    }
}
