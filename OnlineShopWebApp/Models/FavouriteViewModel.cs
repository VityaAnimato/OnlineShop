using System.Collections.Generic;
using System;

namespace OnlineShopWebApp.Models
{
    public class FavouriteViewModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public ProductViewModel ProductViewModel  { get; set; }

    }
}
