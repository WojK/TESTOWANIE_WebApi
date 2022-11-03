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
    public class DeleteTests {

        [Fact]
        public void When_DeleteClient_ReturnsClient() {
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

            // act

            Client result = clientService.DeleteClient(Id);

            // assert

            Assert.NotNull(result);
        }

        [Fact]
        public void When_DeleteClient_WithIncorrectID_RaisesException() {
            // arrange
            var clientsContextMock = new Mock<IClientContext>();

            clientsContextMock.Setup(x => x.Find(It.IsAny<int>())).Returns((Client)null);
            IClientService clientService = new ClientService(clientsContextMock.Object);


            int Id = 123;

            // act and assert
            Assert.Throws<Exception>(
                () => { Client client = clientService.DeleteClient(Id); });
        }
    }
}
