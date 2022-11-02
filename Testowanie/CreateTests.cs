using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Moq;
using TestowanieWebApi.Database;
using TestowanieWebApi.Models;
using TestowanieWebApi.Services;
using Xunit;

namespace Testowanie
{
    public class CreateTests
    {


        [Theory, AutoData]
        public void When_AddClient_ReturnsClientWithProperProperties(string Name, string Surname,
            string Country, int Age, string Gender)
        {

            // arrange
            var clientsContextMock = new Mock<IClientContext>();
            ClientDTO newClient = new ClientDTO
            {
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
        public void When_AddClient_WithIncorrectProperty_RaisesException()
        {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();
            ClientDTO newClient = new ClientDTO
            {
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


        [Fact]
        public void When_EditClient_ReturnsClientWithEditedProperties()
        {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();

            Client client = new Client
            {
                Name = "Janek",
                Surname = "Kowal",
                Country = "England",
                Age = 12,
                Gender = "Male"
            };

            clientsContextMock.Setup(x => x.Find(It.IsAny<int>())).Returns(client);
            IClientService clientService = new ClientService(clientsContextMock.Object);


            int Id = 1;
            ClientDTO clientDTO = new ClientDTO
            {
                Name = "Jan",
                Surname = "Kowalski",
                Country = "Poland",
                Age = 10,
                Gender = "Male"
            };

            // act
            Client editedClient  = clientService.EditClient(Id, clientDTO);

            // assert
            Assert.Equal(editedClient.Name, clientDTO.Name);
            Assert.Equal(editedClient.Surname, clientDTO.Surname);
            Assert.Equal(editedClient.Country, clientDTO.Country);
            Assert.Equal(editedClient.Gender, clientDTO.Gender);
            Assert.Equal(editedClient.Age, clientDTO.Age);
        }

        [Fact]
        public void When_EditClient_WithIncorrectProperty_RaisesException()
        {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();

            Client client = new Client
            {
                Name = "Janek",
                Surname = "Kowal",
                Country = "England",
                Age = 12,
                Gender = "Male"
            };

            clientsContextMock.Setup(x => x.Find(It.IsAny<int>())).Returns(client);
            IClientService clientService = new ClientService(clientsContextMock.Object);


            int Id = 1;
            ClientDTO editedClient = new ClientDTO
            {
                Name = "Jan",
                Surname = "Kowalski",
                Country = "Poland",
                Age = -10,
                Gender = "Male"
            };

            // act and assert
            Assert.Throws<ArgumentException>(
                () => { Client client = clientService.EditClient(Id, editedClient); });
        }

        [Fact]
        public void When_EditClient_WithIncorrectID_RaisesException()
        {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();

            Client client = new Client
            {
                Name = "Janek",
                Surname = "Kowal",
                Country = "England",
                Age = 12,
                Gender = "Male"
            };

            clientsContextMock.Setup(x => x.Find(It.IsAny<int>())).Returns(null);
            IClientService clientService = new ClientService(clientsContextMock.Object);


            int Id = 123;
            ClientDTO editedClient = new ClientDTO
            {
                Name = "Jan",
                Surname = "Kowalski",
                Country = "Poland",
                Age = 10,
                Gender = "Male"
            };

            // act and assert
            Assert.Throws<Exception>(
                () => { Client client = clientService.EditClient(Id, editedClient); });
        }

        [Fact]
        public void When_DeleteClient_ReturnsClient()
        {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();

            Client client = new Client
            {
                Name = "Janek",
                Surname = "Kowal",
                Country = "England",
                Age = 12,
                Gender = "Male"
            };

            clientsContextMock.Setup(x => x.Find(It.IsAny<int>())).Returns(client);
            IClientService clientService = new ClientService(clientsContextMock.Object);


            int Id = 1;

            // act and assert
            //Assert.Throws<ArgumentException>(
            //    () => { Client client = clientService.EditClient(Id, editedClient); });
        }


    }
}
