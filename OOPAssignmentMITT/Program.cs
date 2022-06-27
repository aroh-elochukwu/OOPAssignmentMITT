Console.WriteLine("Hi, please enter player name");
string playerName = Console.ReadLine();
Console.WriteLine($"Welcome {playerName}");
Console.WriteLine("Main Menu");
Console.WriteLine("To display Game Statistic enter 'a' \nTo display Inventory enter 'b' \nTo Fight press 'c'");

char userFirstCommand = Console.ReadKey().KeyChar;

//if (userFirstCommand == 'a')



Armour Voodoo = new Armour("Voodoo", 5);
Armour RunAway = new Armour("Run Away", 9);
Armour BodyArmour = new Armour("Body Armour", 6);

ArmourList.Armours.Add(Voodoo);
ArmourList.Armours.Add(BodyArmour);
ArmourList.Armours.Add(RunAway);

Weapon BattleAxe = new Weapon("Battle Axe", 4);
Weapon AK47 = new Weapon("AK-47", 10);
Weapon Shotgun = new Weapon("ShotGun", 7);

WeaponList.Weapons.Add(BattleAxe);
WeaponList.Weapons.Add(AK47);
WeaponList.Weapons.Add(Shotgun);


class Hero
{
    public string Name { get; set; }
    public int BaseStrength { get; set; }
    public int BaseDefense { get; set; }
    public int OriginalHealth { get; set; }
    public int CurrentHealth { get; set; }
    public Weapon EquippedWeapon { get; set; }
    public Armour EquippedArmour { get; set; }

    public Hero(string name, int baseStrength, int baseDefense, int originalHealth)
    {
        Name = name;
        BaseStrength = baseStrength;
        BaseDefense = baseDefense;
        OriginalHealth = originalHealth;
        CurrentHealth = originalHealth;            
    }

}

class Monster
{
    public string Name { get; set; }
    public int Strength { get; set; }
    public int Defense  { get; set; }
    public int OriginalHealth { get; set; }
    public int CurrentHealth { get; set; }

    public Monster(string name, int strength, int defense, int originalHealth)
    {
        Name = name;
        Strength = strength;
        Defense = defense;
        OriginalHealth = originalHealth;
        CurrentHealth = originalHealth;
    }
}

class Weapon
{
    public string Name { get; set; }    
    public int Power { get; set; }
    public Weapon(string name, int power)
    {
        Name = name;
        Power = power;
    }
}

class Armour
{
    public string Name { get; set; }
    public int Power { get; set; } 

    public Armour(string name, int power)
    {
        Name = name;
        Power = power;
    }
}

static class WeaponList
{
    public static List<Weapon> Weapons = new List<Weapon>();     
}

static class ArmourList
{
    public static List<Armour> Armours = new List<Armour>();

}
class Fight
{
    public Hero FightHero { get; set; }
    public Monster FightMonster { get; set; }
    public bool Win { get; set; } = false;
    public bool lose { get; set; } = false;

}

class Game
{

}


/*
enum WeaponOptions
{
    AK_47 = 6,
    BattleAxe = 2,
    Sniper = 7,
    BowNArrow = 3,
    Shotgun = 4
}

enum ArmourOptions
{
    runAway = 8,
    Voodoo = 5,
    Helmet = 2,
    BodyArmour = 6,
    HandShield = 1
}

*/