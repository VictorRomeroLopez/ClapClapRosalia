using System.Collections;
public class Player
{
    public float TapDamage { get; set; }
    public float PasiveDamate { get; set; }
    public float NailDamageModifier { get; set; }
    public float JaquetTimeModifier { get; set; }
    public float Coins { get; set; }
    public float Fans { get; set; }

    public Player()
    {
        TapDamage = 1;
        PasiveDamate = 0;
        NailDamageModifier = 0;
        JaquetTimeModifier = 0;
        Coins = 0;
        Fans = 0;
    }
}
