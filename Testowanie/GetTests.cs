using AutoFixture.Xunit2;
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
    public class GetTests {

        [Fact]
        public void When_GetClient_ReturnsClientWithProperProperties() {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();
            ClientDTO newClientDTO = new ClientDTO {
                Name = "Jan",
                Surname = "Kowalski",
                Country = "Poland",
                Age = 10,
                Gender = "Male",
                Email = "email@gmail.com"
            };
            Client newClient = new Client {
                Id = 1,
                Name = newClientDTO.Name,
                Surname = newClientDTO.Surname,
                Country = newClientDTO.Country,
                Age = newClientDTO.Age,
                Gender = newClientDTO.Gender,
                Email = newClientDTO.Email
            };

            IClientService clientService = new ClientService(clientsContextMock.Object);
            Client client = clientService.AddClient(newClientDTO);

            clientsContextMock.Setup(x => x.Find(It.IsAny<int>())).Returns(newClient);
            // act
            Client result = clientService.GetClient(client.Id);

            // assert
            Assert.Equal(result, newClient);

        }

        [Fact]
        public void When_GetClientWithNoExistedId_ReturnsException() {
            //arrange
            var clientsContextMock = new Mock<IClientContext>();
            IClientService clientService = new ClientService(clientsContextMock.Object);
            clientsContextMock.Setup(x => x.Find(It.IsAny<int>())).Returns((Client)null);

            //act and assert
            Assert.Throws<Exception>(
                () => { Client client = clientService.GetClient(123); });

        }

        [Theory, AutoData]
        public void When_GetClients_ReturnsProperClients(ClientDTO client1, ClientDTO client2) {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();
            client1.Age = 10;
            client2.Age = 20;
            client1.Gender = "Male";
            client2.Gender = "Male";
            client1.Email = "string@gmail.com";
            client2.Email = "string@gmail.com";
            Client c1 = new Client {
                Id = 1,
                Name = client1.Name,
                Surname = client1.Surname,
                Country = client1.Country,
                Age = client1.Age,
                Gender = client1.Gender,
                Email = client1.Email
            };
            Client c2 = new Client {
                Id = 2,
                Name = client2.Name,
                Surname = client2.Surname,
                Country = client2.Country,
                Age = client2.Age,
                Gender = client2.Gender,
                Email = client2.Email
            };
            var addedClients = new[] { c1, c2 };

            IClientService clientService = new ClientService(clientsContextMock.Object);
            clientsContextMock.Setup(x => x.Set<Client>()).Returns(addedClients);

            // act

            clientService.AddClient(client1);
            clientService.AddClient(client2);

            IEnumerable<Client> result = clientService.GetClients();

            // assert
            Assert.Equal(result, addedClients);
        }

        [Theory, AutoData]
        public void When_GetManyClients_ReturnsProperClients(ClientDTO client1)
        {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();
            List<Client> addedClients = new List<Client>();
            for (int i = 0; i < 100; i++)
            {
                Client c = new Client
                {
                    Id = i,
                    Name = client1.Name,
                    Surname = client1.Surname,
                    Country = client1.Country,
                    Age = i,
                    Gender = client1.Gender,
                    Email = client1.Email

                };
                addedClients.Add(c);
            }

            IClientService clientService = new ClientService(clientsContextMock.Object);
            clientsContextMock.Setup(x => x.Set<Client>()).Returns(addedClients);

            // act
            IEnumerable<Client> result = clientService.GetClients();

            // assert
            Assert.Equal(result.Count(), addedClients.Count());
        }

        [Fact]
        public void When_GetClients_ReturnsEmptyList() {
            //arrange
            var clientsContextMock = new Mock<IClientContext>();
            IClientService clientService = new ClientService(clientsContextMock.Object);
            clientsContextMock.Setup(x => x.Set<Client>()).Returns((IEnumerable<Client>)null);

            //act
            var result = clientService.GetClients();

            //assert
            Assert.Equal(result, (IEnumerable<Client>)null);

        }

        [Fact]
        public void When_GetClients_ReturnsNotEmptyList()
        {
            //arrange
            var clientsContextMock = new Mock<IClientContext>();
            IClientService clientService = new ClientService(clientsContextMock.Object);

            Client FirstClinet = new Client
            {
                Id = 1,
                Name = "Jan",
                Surname = "Kowalski",
                Country = "Poland",
                Age = 10,
                Gender = "Male"
            };

            Client SecondClinet = new Client
            {
                Id = 2,
                Name = "Jan",
                Surname = "Kowalski",
                Country = "Poland",
                Age = 10,
                Gender = "Male"
            };

            Client ThirdClinet = new Client
            {
                Id = 3,
                Name = "Jan",
                Surname = "Kowalski",
                Country = "Poland",
                Age = 10,
                Gender = "Male"
            };

            IEnumerable<Client> set = new HashSet<Client>();
            set.Append<Client>(FirstClinet);
            set.Append<Client>(SecondClinet);
            set.Append<Client>(ThirdClinet);
            clientsContextMock.Setup(x => x.Set<Client>()).Returns(set);

            //act
            var result = clientService.GetClients();

            //assert
            Assert.Equal(set, result);

        }
    }
}

