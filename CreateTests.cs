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
            string Country) {

            // arrange
            var clientsContextMock = new Mock<IClientContext>();
            ClientDTO client = new ClientDTO {
                Name = Name,
                Surname = Surname,
                Country = Country,
                Age = 10,
                Gender = "Female",
                Email = "string@gmail.com"
            };

            IClientService clientService = new ClientService(clientsContextMock.Object);

            // act
            Client newClient = clientService.AddClient(client);


            // assert
            Assert.Equal(Name, newClient.Name);
            Assert.Equal(Surname, newClient.Surname);
            Assert.Equal(Country, newClient.Country);
            Assert.Equal(client.Gender, newClient.Gender);
            Assert.Equal(client.Age, newClient.Age);
            Assert.Equal(client.Email, newClient.Email);

        }


        [Fact]
        public void When_AddClient_WithIncorrectAge_RaisesException() {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();
            ClientDTO newClient = new ClientDTO {
                Name = "Jan",
                Surname = "Kowalski",
                Country = "Poland",
                Age = -10,
                Gender = "Male",
                Email = "string@gmail.com"
            };

            IClientService clientService = new ClientService(clientsContextMock.Object);

            // act and assert
            Assert.Throws<ArgumentException>(
                () => { Client client = clientService.AddClient(newClient); });
        }

        [Fact]
        public void When_AddClient_WithNullName_RaisesException()
        {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();
            ClientDTO newClient = new ClientDTO
            {
                Surname = "Kowalski",
                Country = "Poland",
                Age = 10,
                Gender = "Male",
                Email = "string@gmail.com"
            };

            IClientService clientService = new ClientService(clientsContextMock.Object);

            // act and assert
            Assert.Throws<ArgumentException>(
                () => { Client client = clientService.AddClient(newClient); });
        }

        [Fact]
        public void When_AddClient_WithNullSurname_RaisesException()
        {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();
            ClientDTO newClient = new ClientDTO
            {
                Name = "Jan",
                Country = "Poland",
                Age = 10,
                Gender = "Male",
                Email = "string@gmail.com"
            };

            IClientService clientService = new ClientService(clientsContextMock.Object);

            // act and assert
            Assert.Throws<ArgumentException>(
                () => { Client client = clientService.AddClient(newClient); });
        }

        [Fact]
        public void When_AddClient_WithNullCountry_RaisesException()
        {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();
            ClientDTO newClient = new ClientDTO
            {
                Name = "Jan",
                Surname = "Kowalski",
                Age = 10,
                Gender = "Male",
                Email = "string@gmail.com"
            };

            IClientService clientService = new ClientService(clientsContextMock.Object);

            // act and assert
            Assert.Throws<ArgumentException>(
                () => { Client client = clientService.AddClient(newClient); });
        }

        [Fact]
        public void When_AddClient_WithNullEmail_RaisesException()
        {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();
            ClientDTO newClient = new ClientDTO
            {
                Name = "Jan",
                Surname = "Kowalski",
                Age = 10,
                Gender = "Male",
                Country = "Poland",
            };

            IClientService clientService = new ClientService(clientsContextMock.Object);

            // act and assert
            Assert.Throws<ArgumentException>(
                () => { Client client = clientService.AddClient(newClient); });
        }

        [Fact]
        public void When_AddClient_WithNullGender_RaisesException()
        {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();
            ClientDTO newClient = new ClientDTO
            {
                Name = "Jan",
                Surname = "Kowalski",
                Age = 10,
                Country = "Poland",
                Email = "string@gmail.com"

            };

            IClientService clientService = new ClientService(clientsContextMock.Object);

            // act and assert
            Assert.Throws<ArgumentException>(
                () => { Client client = clientService.AddClient(newClient); });
        }

        [Fact]
        public void When_AddClient_WithIncorrectGender_RaisesException()
        {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();
            ClientDTO newClient = new ClientDTO {
                Name = "Jan",
                Surname = "Kowalski",
                Age = 10,
                Country = "Poland",
                Gender = "Unknown",
                Email = "string@gmail.com"
            };

            IClientService clientService = new ClientService(clientsContextMock.Object);

            // act and assert
            Assert.Throws<ArgumentException>(
                () => { Client client = clientService.AddClient(newClient); });
        }

        [Fact]
        public void When_AddClient_WithIncorrectEmail_RaisesException()
        {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();
            ClientDTO newClient = new ClientDTO
            {
                Name = "Jan",
                Surname = "Kowalski",
                Age = 10,
                Country = "Poland",
                Gender = "Female",
                Email = "someemail.123"
            };

            IClientService clientService = new ClientService(clientsContextMock.Object);

            // act and assert
            Assert.Throws<ArgumentException>(
                () => { Client client = clientService.AddClient(newClient); });
        }

        [Fact]
        public void When_AddNullValue_RaisesException()
        {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();
            ClientDTO? newClientNull = null;

            IClientService clientService = new ClientService(clientsContextMock.Object);

<<<<<<< HEAD
            // act and assert
            Assert.Throws<ArgumentException>(
                () => { Client client = clientService.AddClient(newClientNull); });
        }
=======

>>>>>>> 90401444eb41d083f086c0416ae15225515b272e
    }
}
