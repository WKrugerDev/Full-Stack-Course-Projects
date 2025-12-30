using System.Collections.Generic;

namespace AdvancedBlazorComponents.Services
{
    public class DataService
    {
        public List<string> GetData()
        {
            // return some mock data
            return new List<string>
            {
                "Item 1",
                "Item 2",
                "Item 3"
            };
        }
    }
}