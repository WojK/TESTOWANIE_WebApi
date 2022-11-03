using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;
using TestowanieWebApi.Database;
using TestowanieWebApi.Models;
using TestowanieWebApi.Services;
using Xunit;

namespace Testowanie {
    public class CreateTests {


        [Theory, AutoData]
        public void When_AddClient_ReturnsClientWithProperProperties(string Name, string Surname,
            string Country, int Age, string Gender) {

            // arrange
            var clientsContextMock = new Mock<IClientContext>();
            ClientDTO newClient = new ClientDTO {
                Name = Name,
                Surname = Surname,
                Country = Country,
                Age = Age,
                Gender = Gender
            };

            IClientService clientService = new ClientService(clientsContextMock.Object);

            // act
            Client client = clientService.AddClient(newClient);


            // assert
            Assert.Equal(Name, newClient.Name);
            Assert.Equal(Surname, newClient.Surname);
            Assert.Equal(Country, newClient.Country);
            Assert.Equal(Gender, newClient.Gender);
            Assert.Equal(Age, newClient.Age);
        }


        [Fact]
        public void When_AddClient_WithIncorrectProperty_RaisesException() {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();
            ClientDTO newClient = new ClientDTO {
                Name = "Jan",
                Surname = "Kowalski",
                Country = "Poland",
                Age = -10,
                Gender = "Male"
            };

            IClientService clientService = new ClientService(clientsContextMock.Object);

            // act and assert
            Assert.Throws<ArgumentException>(
                () => { Client client = clientService.AddClient(newClient); });
        }





    }
}
