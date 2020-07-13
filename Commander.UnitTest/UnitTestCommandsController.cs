using System.Collections.Generic;
using AutoMapper;
using Commander.Controllers;
using Commander.Data;
using Commander.Models;
using Commander.Profiles;
using Moq;
using Xunit;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Commander.Dtos;

namespace Commander.UnitTest
{
    public class UnitTestCommandsController
    {
        [Fact]
        public void Test_GetAllCommands()
        {
            //Arrange
            var mockRepo = new Mock<ICommanderRepo>();

            var commands = new List<Command>
            {
                new Command { HowTo = "Boil an egg", Id = 0, Line = "Boil water", Platform = "Kettle & pan" },
                new Command { HowTo = "Cut bread", Id = 1, Line = "Get a knife", Platform = "Knife & chopping board" },
                new Command { HowTo = "Make cup of tea", Id = 2, Line = "Place teabag in cup", Platform = "Kettle & cup" },
            };

            mockRepo.Setup(m => m.GetAllCommands()).Returns(value: commands);

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CommandsProfile());
            });
            var mapper = mockMapper.CreateMapper();

            var controller = new CommandsController(mockRepo.Object, mapper);

            //Act
            var result = controller.GetAllCommands();

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<CommandReadDto>>(okObjectResult.Value);

            if (returnValue.Count() > 0)
            {
                Assert.NotNull(returnValue);

                var expected = returnValue?.FirstOrDefault().HowTo;
                var actual = commands?.FirstOrDefault().HowTo;

                Assert.Equal(expected: expected, actual: actual);
            }
        }
    }
}
