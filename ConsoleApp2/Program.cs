using System;

public class Personaje
{
    private int _vida;

    // Constructor
    public Personaje(string nombre, int fuerza, int inteligencia, int vida)
    {
        Nombre = nombre;
        Fuerza = fuerza;
        Inteligencia = inteligencia;
        Vida = vida; 
    }

    // Atributos / Propiedades públicas
    public string Nombre { get; set; }
    public int Fuerza { get; set; }
    public int Inteligencia { get; set; }

    // Encapsulamiento
    public int Vida
    {
        get => _vida;
        set => _vida = Math.Max(0, value);
    }

    // (polimorfismo)
    public virtual int Atacar()
    {
        return Fuerza;
    }
}

public class Guerrero : Personaje
{
    public Guerrero(string nombre, int fuerza, int inteligencia, int vida, int bonoArma)
        : base(nombre, fuerza, inteligencia, vida) // Llama al constructor de Personaje
    {
        BonoArma = bonoArma;
    }

    public int BonoArma { get; set; }

    // Polimorfismo: sobrescribe Atacar()
    public override int Atacar()
    {
        return Fuerza + BonoArma;
    }
}

public class Mago : Personaje
{
    public Mago(string nombre, int fuerza, int inteligencia, int vida, int poderGrimorio)
        : base(nombre, fuerza, inteligencia, vida)
    {
        PoderGrimorio = poderGrimorio;
    }

    public int PoderGrimorio { get; set; }

    // Polimorfismo: sobrescribe Atacar() usando inteligencia y grimorio
    public override int Atacar()
    {
        return (Inteligencia * 2) + PoderGrimorio;
    }
}

public class Programa
{
    public static void EjecutarTurnoAtaque(Personaje atacante, Personaje objetivo)
    {
        // Polimorfismo
        int danio = atacante.Atacar();
        objetivo.Vida -= danio;
        Console.WriteLine($"{atacante.Nombre} inflige {danio} de daño a {objetivo.Nombre} (vida restante: {objetivo.Vida})");
    }

    public static void Main()
    {
        // Instancias (objetos concretos)
        Personaje basePersonaje = new Personaje("Aldeano", fuerza: 5, inteligencia: 3, vida: 50);
        Personaje guerrero = new Guerrero("Thorgar", fuerza: 15, inteligencia: 4, vida: 120, bonoArma: 10);
        Personaje mago = new Mago("Lyra", fuerza: 4, inteligencia: 18, vida: 80, poderGrimorio: 12);

        EjecutarTurnoAtaque(guerrero, mago);
        EjecutarTurnoAtaque(mago, guerrero);
        EjecutarTurnoAtaque(basePersonaje, guerrero);
    }
}