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

Monster RottenTeeth = new Monster("Rotten Teeth", 8, 5, 50);
Game.Monster = RottenTeeth;


Console.WriteLine("Hi, please enter player name");
string playerName = Console.ReadLine();
Console.WriteLine($"Welcome {playerName}");
Console.WriteLine("Main Menu");
Console.WriteLine("To display Game Statistic enter 'a' \nTo display Inventory enter 'b' \nTo Fight press 'c'");

char initiateGameCommand = Console.ReadKey().KeyChar;
Console.WriteLine("Choose your Weapon");

Console.WriteLine("For Battle Axe press 'a' \nFor AK-47 press 'b' \nFor Shotgun press 'c'");
char weaponChoice = Console.ReadKey().KeyChar;

Console.WriteLine("Choose your Armour");
Console.WriteLine("For VooDoo press 'a' \nFor Body Armour press 'b' \nTo try and evade press 'c'");


char armourChoice = Console.ReadKey().KeyChar;

Hero Hero = new Hero($"{playerName}", 4, 3, 30); 

if (weaponChoice == 'a')
{
    Hero.EquippedWeapon = BattleAxe;

}
else if (weaponChoice == 'b')
{
    Hero.EquippedWeapon = AK47;

}
else if (weaponChoice == 'c')
{
    Hero.EquippedWeapon = Shotgun;

}

if (armourChoice == 'a')
{
    Hero.EquippedArmour = Voodoo;
}
else if (armourChoice == 'b')
{
    Hero.EquippedArmour = BodyArmour;

}
else if (armourChoice == 'c')
{
    Hero.EquippedArmour = RunAway;

}

Game.Hero = Hero;

if (initiateGameCommand == 'c')
{
    Game.PlayGame();
}






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
    public Hero Hero { get; set; }
    public Monster Monster { get; set; }
    public bool Win { get; set; } = false;
    public bool Lose { get; set; } = false;

}

static class Game
{
    public  static Hero Hero { get; set; }
    public static Monster Monster { get; set; }
    public static Fight Fight = new Fight();

    public static void PlayGame()
    {
        int heroAttack;
        int heroDefense;
        int heroHealth;

        heroAttack = Hero.BaseStrength + Hero.EquippedWeapon.Power;
        heroDefense = Hero.BaseDefense + Hero.EquippedArmour.Power;
        heroHealth = Hero.CurrentHealth;

        int monsterAttack;
        int monsterDefense;
        int monsterHealth;

        monsterAttack = Monster.Strength;
        monsterDefense = Monster.Defense;
        monsterHealth = Monster.CurrentHealth;


        // to review this to fix endless loop bug
        while (Fight.Win != true|| Fight.Lose != true)
        {
            monsterHealth = - (heroAttack - monsterDefense);
            Console.WriteLine($"{Hero.Name} attacks {Monster.Name}");
            if (monsterHealth <= 0)
            {
                Fight.Win = true;
            }

            heroHealth =- (monsterAttack - heroDefense);
            Console.WriteLine($"{Monster.Name} attacks {Hero.Name}");
            if (heroHealth <= 0)
            {
                Fight.Lose = true;
            }



        }

        if (Fight.Win)
        {
            Console.WriteLine($"{Hero.Name} wins");
        }
        else if (Fight.Lose)
        {
            Console.WriteLine($"{Hero.Name} loses");
        }

            
    }


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