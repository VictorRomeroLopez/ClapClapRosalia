using System.Collections;
public class Player
{
    public float TapPoints { get; set; }
    public float PasivePoints { get; set; }
    public float NailPointsModifier { get; set; }
    public float JaquetTimeModifier { get; set; }
    public float Coins { get; set; }
    public int Fans { get; set; }
    public int NailsLevel { get; set; }
    public int JaquetLevel { get; set; }

    public Player()
    {
        TapPoints = 1;
        PasivePoints = 0;
        NailPointsModifier = 1;
        JaquetTimeModifier = 1;
        Coins = 0;
        Fans = 0;
        NailsLevel = 0;
        JaquetLevel = 0;
    }
}
