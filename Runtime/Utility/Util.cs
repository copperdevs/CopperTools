using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

namespace CopperDevs.Tools.Utility
{
    public static class Util
    {
        private static readonly List<string> Names = new()
        {
            "Curt Perez",
            "Myrtle Groves",
            "Leslie Meyers",
            "Johanna Russell",
            "Michele Combs",
            "Jody Dodson",
            "Shelby Jacobs",
            "Natalie Maxwell",
            "Bessie Knight",
            "David Turner",
            "Kenny Short",
            "Christine Dickinson",
            "Kim Stokes",
            "Dwight Lamb",
            "Alexandra Moody",
            "Bethany Hanson",
            "Greg Dugan",
            "Jeanne Bean",
            "Brandy Gamble",
            "Jean Ott",
            "Rosalie Neff",
            "Philip Dodd",
            "Garrett Owens",
            "Jeannette Valentine",
            "Shirley Walker",
            "Patrice Frazier",
            "Misty Christensen",
            "Darin Hayden",
            "Mario Barlow",
            "Cecelia Choi",
            "Nell Newman",
            "Ramona Wolfe",
            "Corinne Cassidy",
            "Janice Montgomery",
            "Steven Suarez",
            "Vicki Barrett",
            "Dorothy Sargent",
            "Jill Velez",
            "Candice Shepherd",
            "Lawrence Boyer",
            "Joni Harris",
            "Katie Mahoney",
            "Jessie Hines",
            "Victor McCarty",
            "Sammy Carlson",
            "Tammy Ford",
            "Alberto Rhodes",
            "Marissa Forbes",
            "Angelo Lowe",
            "Sonja Chung"
        };

        public static void CopyToClipboard(string textToCopy)
        {
            GUIUtility.systemCopyBuffer = textToCopy;
        }

        public static string GetRandomName()
        {
            return Names[Random.Range(0, Names.Count - 1)];
        }
        
        public static string ConvertToTitleCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            
            var result = Regex.Replace(input, "(\\B[A-Z])", " $1");
            
            result = char.ToUpper(result[0]) + result[1..].ToLower();
            return result;
        }
    }
}