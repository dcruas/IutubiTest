using IutubiRestfulAPI.Interfaces;
using IutubiRestfulAPI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IutubiTest.MockRepositories
{
    public class MockYoutubeItemDB : IYoutubeItemDB
    {
        public List<YoutubeItem> YoutubeItems { get; set; }

        public MockYoutubeItemDB()
        {
            YoutubeItems = new List<YoutubeItem>();
        }

        public async Task<List<YoutubeItem>> Get()
        {
            return YoutubeItems;
        }

        public async Task<bool> Insert(List<YoutubeItem> resultList)
        {
            try
            {
                YoutubeItems.AddRange(resultList);
            }
            catch (Exception)
            {
                return false;
            }
           

            return true;
        }
    }
}
