using FluentAssertions;
using IutubiProject.Service;
using IutubiTest.MockRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Xunit;


namespace IutubiTest
{
    public class YoutubeServiceTest
    {
        private YoutubeService _youtubeService;
        private MockYoutubeItemDB _mockYoutubeItemDB = new MockYoutubeItemDB();

        public YoutubeServiceTest()
        {
            _youtubeService = new YoutubeService(_mockYoutubeItemDB);
        }
        
        [Fact]
        public async void DadoResultadoInexistente_QuandoImportar_EntaoRetornarNada()
        {
            var result = await _youtubeService.Import("DSHDAHUDSUHADASFUHADHSADAD CONSLE.WRTRILEN");

            Assert.Equal(200, ((OkObjectResult) result).StatusCode);
        }

        [Fact]
        public async void DadoTituloIexistente_QuandoImportar_EntaoRetornarItems()
        {
            // Dado
            var filtro = "Tales of arise";
            
            // Quando
            var result = await _youtubeService.Import(filtro);

            // Ent�o
            _mockYoutubeItemDB.YoutubeItems.Any().Should().Be(true);
            Assert.Equal(200, ((OkObjectResult)result).StatusCode);

        }



    }
}
