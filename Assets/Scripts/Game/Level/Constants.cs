using System;
using Type.Common;

public static class Constants
{
    public class Scenes
    {
        public const string Menu = "Menu";
        public const string Game = "Game";
    }
    public class Audio
    {
        public class WhereIsMyTail
        {
            public const string Cat     = "CAT_09";
            public const string Cow     = "COW_09";
            public const string Dog     = "DOG_09";
            public const string Horse   = "HORSE_09";
            public const string Mouse   = "MOUSE_09";
            public const string Pig     = "PIG_09";
            
            
            public static string GetClipByType(AnimalType animalType)
            {
                switch (animalType)
                {
                    case AnimalType.Cat:
                        return Cat;
                    case AnimalType.Cow:
                        return Cow;
                    case AnimalType.Dog:
                        return Dog;
                    case AnimalType.Horse:
                        return Horse;
                    case AnimalType.Mouse:
                        return Mouse;
                    case AnimalType.Pig:
                        return Pig;
                    default:
                        throw new ArgumentException($"There is no sound with type: {animalType}");
                }
            }
        }
    }
}