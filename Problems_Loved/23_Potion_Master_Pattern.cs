PotionType potion = PotionType.Water;

while(true)
{
    Console.WriteLine($"Current Potion: {potion}");

    Console.WriteLine("Do you want to add more ingredients? ");
    string? input = Console.ReadLine();
    if (input == "no") break;

    Console.WriteLine("Available ingredients: stardust, snake venom, dragon breath, shadow glass, eyeshine gem");

    Ingredients ingredient = Console.ReadLine() switch
    {
        "stardust" => Ingredients.Stardust,
        "snake venom" => Ingredients.SnakeVenom,
        "dragon breath" => Ingredients.DragonBreath,
        "shadow glass" => Ingredients.ShadowGlass,
        "eyeshine gem" => Ingredients.EyeshineGem
    };

    potion = (ingredient, potion) switch
    {
      (Ingredients.Stardust, PotionType.Water) => PotionType.Elixir,
      (Ingredients.SnakeVenom, PotionType.Elixir) => PotionType.Poison,
      (Ingredients.DragonBreath, PotionType.Elixir) => PotionType.Flying,
      (Ingredients.ShadowGlass, PotionType.Elixir) => PotionType.Invisiblity,
      (Ingredients.EyeshineGem, PotionType.Elixir) => PotionType.NightSight,
      (Ingredients.ShadowGlass, PotionType.NightSight) => PotionType.NightSight,
      (Ingredients.EyeshineGem, PotionType.Invisiblity) => PotionType.CloudyBrew,
      (Ingredients.Stardust, PotionType.CloudyBrew) => PotionType.Wraith,
      (_, _) => PotionType.Ruined, 
    };
    
    if (potion == PotionType.Ruined)
    {
        Console.WriteLine("Oh no! The potion is ruined! Lets start over.");
        potion = PotionType.Water;
    }
}

public enum Ingredients {Stardust, SnakeVenom, DragonBreath, ShadowGlass, EyeshineGem}
public enum PotionType {Water, Elixir, Poison, Flying, Invisiblity, NightSight, CloudyBrew, Wraith, Ruined}