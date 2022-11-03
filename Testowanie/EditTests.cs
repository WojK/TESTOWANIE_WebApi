using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestowanieWebApi.Database;
using TestowanieWebApi.Models;
using TestowanieWebApi.Services;

namespace Testowanie {
    public class EditTests {

        [Fact]
        public void When_EditClient_ReturnsClientWithEditedProperties() {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();

            Client client = new Client {
                Name = "Janek",
                Surname = "Kowal",
                Country = "England",
                Age = 12,
                Gender = "Male",
                Email = "string@gmail.com"
            };

            clientsContextMock.Setup(x => x.Find(It.IsAny<int>())).Returns(client);
            IClientService clientService = new ClientService(clientsContextMock.Object);


            int Id = 1;
            ClientDTO clientDTO = new ClientDTO {
                Name = "Jan",
                Surname = "Kowalski",
                Country = "Poland",
                Age = 10,
                Gender = "Male",
                Email = "string@gmail.com"
            };

            // act
            Client editedClient = clientService.EditClient(Id, clientDTO);

            // assert
            Assert.Equal(editedClient.Name, clientDTO.Name);
            Assert.Equal(editedClient.Surname, clientDTO.Surname);
            Assert.Equal(editedClient.Country, clientDTO.Country);
            Assert.Equal(editedClient.Gender, clientDTO.Gender);
            Assert.Equal(editedClient.Age, clientDTO.Age);
        }

        [Fact]
        public void When_EditClient_WithIncorrectAgeProperty_RaisesException() {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();

            Client client = new Client {
                Name = "Janek",
                Surname = "Kowal",
                Country = "England",
                Age = 12,
                Gender = "Male",
                Email = "string@gmail.com"
            };

            clientsContextMock.Setup(x => x.Find(It.IsAny<int>())).Returns(client);
            IClientService clientService = new ClientService(clientsContextMock.Object);


            int Id = 1;
            ClientDTO editedClient = new ClientDTO {
                Name = "Jan",
                Surname = "Kowalski",
                Country = "Poland",
                Age = -10,
                Gender = "Male",
                Email = "string@gmail.com"
            };

            // act and assert
            Assert.Throws<ArgumentException>(
                () => { Client client = clientService.EditClient(Id, editedClient); });
        }

        [Fact]
        public void When_EditClient_WithIncorrectID_RaisesException() {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();

            clientsContextMock.Setup(x => x.Find(It.IsAny<int>())).Returns((Client)null);
            IClientService clientService = new ClientService(clientsContextMock.Object);


            int Id = 123;
            ClientDTO editedClient = new ClientDTO {
                Name = "Jan",
                Surname = "Kowalski",
                Country = "Poland",
                Age = 10,
                Gender = "Male",
                Email = "string@gmail.com"
            };

            // act and assert
            Assert.Throws<Exception>(
                () => { Client client = clientService.EditClient(Id, editedClient); });
        }

        [Fact]
        public void When_EditClient_WithNullName_RaisesException(){
            // arrange
            var clientsContextMock = new Mock<IClientContext>();

            clientsContextMock.Setup(x => x.Find(It.IsAny<int>())).Returns((Client)null);
            IClientService clientService = new ClientService(clientsContextMock.Object);


            int Id = 123;
            ClientDTO editedClient = new ClientDTO
            {
                Name = null,
                Surname = "Kowalski",
                Country = "Poland",
                Age = 10,
                Gender = "Male",
                Email = "string@gmail.com"
            };

            // act and assert
            Assert.Throws<Exception>(
                () => { Client client = clientService.EditClient(Id, editedClient); });
        }

        [Fact]
        public void When_EditClient_WithNullSurname_RaisesException() {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();

            clientsContextMock.Setup(x => x.Find(It.IsAny<int>())).Returns((Client)null);
            IClientService clientService = new ClientService(clientsContextMock.Object);


            int Id = 123;
            ClientDTO editedClient = new ClientDTO {
                Name = "Jan",
                Surname = null,
                Country = "Poland",
                Age = 10,
                Gender = "Male",
                Email = "string@gmail.com"
            };

            // act and assert
            Assert.Throws<Exception>(
                () => { Client client = clientService.EditClient(Id, editedClient); });
        }

        [Fact]
        public void When_EditClient_WithNullCountry_RaisesException() {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();

            clientsContextMock.Setup(x => x.Find(It.IsAny<int>())).Returns((Client)null);
            IClientService clientService = new ClientService(clientsContextMock.Object);


            int Id = 123;
            ClientDTO editedClient = new ClientDTO {
                Name = "Jan",
                Surname = "Kowalski",
                Country = null,
                Age = 10,
                Gender = "Male",
                Email = "string@gmail.com"
            };

            // act and assert
            Assert.Throws<Exception>(
                () => { Client client = clientService.EditClient(Id, editedClient); });
        }
        [Fact]
        public void When_EditClient_WithNullGender_RaisesException()
        {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();

            clientsContextMock.Setup(x => x.Find(It.IsAny<int>())).Returns((Client)null);
            IClientService clientService = new ClientService(clientsContextMock.Object);


            int Id = 123;
            ClientDTO editedClient = new ClientDTO
            {
                Name = "Jan",
                Surname = "Kowalski",
                Country = "Poland",
                Age = 10,
                Gender = null,
                Email = "string@gmail.com"
            };

            // act and assert
            Assert.Throws<Exception>(
                () => { Client client = clientService.EditClient(Id, editedClient); });
        }

        [Fact]
        public void When_EditClient_WithNullEmail_RaisesException() {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();

            clientsContextMock.Setup(x => x.Find(It.IsAny<int>())).Returns((Client)null);
            IClientService clientService = new ClientService(clientsContextMock.Object);


            int Id = 123;
            ClientDTO editedClient = new ClientDTO {
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
        public void When_EditClient_WithIncorrectEmail_RaisesException()
        {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();

            clientsContextMock.Setup(x => x.Find(It.IsAny<int>())).Returns((Client)null);
            IClientService clientService = new ClientService(clientsContextMock.Object);


            int Id = 123;
            ClientDTO editedClient = new ClientDTO
            {
                Name = "Jan",
                Surname = "Kowalski",
                Country = "Poland",
                Age = 10,
                Gender = "Female",
                Email = "someemail.21"
            };

            // act and assert
            Assert.Throws<Exception>(
                () => { Client client = clientService.EditClient(Id, editedClient); });
        }

        [Fact]
        public void When_EditClient_WithIncorrectGender_RaisesException() {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();

            clientsContextMock.Setup(x => x.Find(It.IsAny<int>())).Returns((Client)null);
            IClientService clientService = new ClientService(clientsContextMock.Object);


            int Id = 123;
            ClientDTO editedClient = new ClientDTO {
                Name = "Jan",
                Surname = "Kowalski",
                Country = "Poland",
                Age = 10,
                Gender = "Unknown",
                Email = "string@gmail.com"
            };

            // act and assert
            Assert.Throws<Exception>(
                () => { Client client = clientService.EditClient(Id, editedClient); });
        }

        [Fact]
        public void When_EditClient_WithNullClientButCorrectID_RaisesException()
        {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();

            clientsContextMock.Setup(x => x.Find(It.IsAny<int>())).Returns((Client)null);
            IClientService clientService = new ClientService(clientsContextMock.Object);


            int Id = 10;
            ClientDTO editedClient = new ClientDTO
            {
                Name = "Jan",
                Surname = "Kowalski",
                Country = "Poland",
                Age = 10,
                Gender = "Male",
                Email = "string@gmail.com"
            };

            // act and assert
            Assert.Throws<Exception>(
                () => { Client client = clientService.EditClient(Id, (ClientDTO)null); });
        }


    }
}
