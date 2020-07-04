using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command { HowTo = "Boil an egg", Id = 0, Line = "Boil water", Platform = "Kettle & pan" },
                new Command { HowTo = "Cut bread", Id = 1, Line = "Get a knife", Platform = "Knife & chopping board" },
                new Command { HowTo = "Make cup of tea", Id = 2, Line = "Place teabag in cup", Platform = "Kettle & cup" },
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { HowTo = "Boil an egg", Id = 0, Line = "Boil water", Platform = "Kettle & Pan" };
        }
    }
}