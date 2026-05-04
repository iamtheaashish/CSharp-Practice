/*Idea was given by a discord user named Cosmic Sloth on Server for book "The C# Player's Guide" as a challenge/thought to modify the solution.*/
using static System.Console;
// Discount Inventory

Console.Clear();

WriteLine("The following items are available: ");
WriteLine("1. Rope \n2. Torches \n3. Climbing Equipment \n4. Clean Water \n5. Machete \n6. Canoe \n7. Food Supplies");

// Input the name
Write("Before you shop, enter your name: ");
string? nameStr = ReadLine();

Write("What number do you want to see the price of? ");
string? numStr = ReadLine();
int num = int.Parse(numStr);

int ropeCost = 10;
int torchCost = 15;
int climbEquipmentCost = 25;
int cleanWaterCost = 1;
int macheteCost = 20;
int canoeCost = 200;
int foodSupplies = 1;
float discount;

// for 23% Discount
if (nameStr == "Aashish")
{
    discount = 0.23F;
    switch (num)
    {
        case 1:
        WriteLine($"The Rope cost {ropeCost - (ropeCost * discount)} gold.");
        break;
        case 2:
        WriteLine($"The Torch cost {torchCost - (torchCost * discount)} gold.");
        break;
        case 3:
        WriteLine($"The Climbing Equipment cost {climbEquipmentCost - (climbEquipmentCost * discount)} gold.");
        break;
        case 4:
        WriteLine($"The Clean Water cost {cleanWaterCost - (cleanWaterCost * discount)} gold.");
        break;
        case 5:
        WriteLine($"The Machete cost {macheteCost - (macheteCost * discount)} gold.");
        break;
        case 6:
        WriteLine($"The Canoe cost {canoeCost - (canoeCost * discount)} gold.");
        break;
        case 7:
        WriteLine($"The Food Supplies cost {foodSupplies - (foodSupplies * discount)} gold.");
        break;
        default:
        WriteLine("Item not in shop, or you have gone insane.");
        break;
    }
}
else
{

    switch (num)
    {
        case 1:
        WriteLine($"The Rope cost {ropeCost} gold.");
        break;
        case 2:
        WriteLine($"The Torch cost {torchCost} gold.");
        break;
        case 3:
        WriteLine($"The Climbing Equipment cost {climbEquipmentCost} gold.");
        break;
        case 4:
        WriteLine($"The Clean Water cost {cleanWaterCost} gold.");
        break;
        case 5:
        WriteLine($"The Machete cost {macheteCost} gold.");
        break;
        case 6:
        WriteLine($"The Canoe cost {canoeCost} gold.");
        break;
        case 7:
        WriteLine($"The Food Supplies cost {foodSupplies} gold.");
        break;
        default:
        WriteLine("Item not in shop, or you have gone insane.");
        break;
    }
}
