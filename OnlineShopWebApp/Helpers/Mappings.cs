using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Helpers
{
    public static class Mappings
    {
        public static CartViewModel ToCartViewModel(this Cart cart)
        {
            if (cart == null)
                return null;

            return new CartViewModel()
            {
                UserId = cart.UserId,
                Id = cart.Id,
                Items = cart.Items.ToCartViewModelItems()
            };
        }

        public static Cart ToCart(this CartViewModel cartViewModel)
        {
            if (cartViewModel == null)
                return null;

            return new Cart()
            {
                UserId = cartViewModel.UserId,
                Id = cartViewModel.Id,
                Items = cartViewModel.Items.ToCartItems()
            };
        }

        public static List<CartItem> ToCartItems(this List<CartItemViewModel> cartItemsViewModel)
        {
            var cartItems = new List<CartItem>();
            if (cartItemsViewModel == null)
                return null;

            foreach (var item in cartItemsViewModel)
            {
                cartItems.Add(new CartItem()
                {
                    Id = item.Id,
                    Amount = item.Amount,
                    Product = item.Product.ToProduct(),
                });
            }
            return cartItems;
        }


        public static List<CartItemViewModel> ToCartViewModelItems(this List<CartItem> cartItems)
        {
            var cartItemsViewModel = new List<CartItemViewModel>();
            if (cartItems == null)
                return null;

            foreach (var item in cartItems)
            {
                cartItemsViewModel.Add(new CartItemViewModel()
                {
                    Id = item.Id,
                    Amount = item.Amount,
                    Product = item.Product.ToProductViewModel(),
                });
            }
            return cartItemsViewModel;
        }

        public static ProductViewModel ToProductViewModel(this Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImagesPaths = product.Images.Select(x => x.Url).ToList(),
            };
        }


        public static Product ToProduct(this ProductViewModel productViewModel)
        {
            return new Product
            {
                Id = productViewModel.Id,
                Name = productViewModel.Name,
                Cost = productViewModel.Cost,
                Description = productViewModel.Description,
                Images = ToImages(productViewModel.ImagesPaths),
            };
        }

        public static Product ToProduct(this AddProductViewModel addProductViewModel, List<string> imagesPaths)
        {
            return new Product
            {
                Name = addProductViewModel.Name,
                Cost = addProductViewModel.Cost,
                Description = addProductViewModel.Description,
                Images = ToImages(imagesPaths),
            };
        }

        public static Product ToProduct(this EditProductViewModel editProductViewModel, List<string> imagesPaths)
        {
            return new Product
            {
                Id = editProductViewModel.Id,
                Name = editProductViewModel.Name,
                Cost = editProductViewModel.Cost,
                Description = editProductViewModel.Description,
                Images = ToImages(imagesPaths),
            };
        }

        public static EditProductViewModel ToEditProductViewModel(this Product product)
        {
            return new EditProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImagesPaths = product.Images.ToPaths()
            };
        }

        public static List<Image> ToImages(this List<string> paths)
        {
            return paths?.Select(x => new Image { Url = x }).ToList();
        }

        public static List<string> ToPaths(this List<Image> images)
        {
            return images.Select(x => x.Url).ToList();
        }

        public static FavouriteViewModel ToFavouriteViewModel(this Favourite favourite)
        {
            if (favourite == null) return null;

            return new FavouriteViewModel
            {
                Id = favourite.Id,
                UserId = favourite.UserId,
                ProductViewModel = favourite.Product.ToProductViewModel(),
            };
        }

        public static List<ProductViewModel> ToProductsViewModel(this List<Product> products)
        {
            var productsViewModel = new List<ProductViewModel>();
            if (products == null)
                return null;

            foreach (var product in products)
            {
                productsViewModel.Add(product.ToProductViewModel());
            }
            return productsViewModel;
        }

        public static Order ToOrder(this OrderViewModel orderViewModel)
        {
            if (orderViewModel == null) return null;

            return new Order
            {
                Id = orderViewModel.Id,
                UserId = orderViewModel.UserId,
                OrderUserData = orderViewModel.OrderUserData.ToOrderUserData(),
                Status = orderViewModel.Status,
                DateTime = orderViewModel.DateTime,
                Items = orderViewModel.Items.ToCartItems(),
            };
        }

        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            if (order == null) return null;

            return new OrderViewModel
            {
                Id = order.Id,
                UserId = order.UserId,
                OrderUserData = order.OrderUserData.ToOrderUserDataViewModel(),
                Status = order.Status,
                DateTime = order.DateTime,
                Items = order.Items.ToCartViewModelItems(),
            };
        }

        public static OrderUserData ToOrderUserData(this OrderUserDataViewModel orderUserDataViewModel)
        {
            if (orderUserDataViewModel == null) return null;

            return new OrderUserData
            {
                FullName = orderUserDataViewModel.FullName,
                Address = orderUserDataViewModel.Address,
                Phone = orderUserDataViewModel.Phone,
            };
        }

        public static OrderUserDataViewModel ToOrderUserDataViewModel(this OrderUserData orderUserData)
        {
            if (orderUserData == null) return null;

            return new OrderUserDataViewModel
            {
                FullName = orderUserData.FullName,
                Address = orderUserData.Address,
                Phone = orderUserData.Phone,
            };
        }

        public static UserViewModel ToUserViewModel(this User user)
        {
            return new UserViewModel
            {
                UserName = user.UserName
            };
        }

        public static User ToUser(this UserViewModel userViewModel)
        {
            return new User
            {
                UserName = userViewModel.UserName
            };
        }

        public static Role ToRole(this IdentityRole identityRole)
        {
            return new Role { Name = identityRole.Name };
        }

        public static IdentityRole ToIdentityRole(this Role role)
        {
            return new IdentityRole { Name = role.Name };
        }

        public static List<Role> ToListRoles(this List<IdentityRole> identityRoles)
        {
            var list = new List<Role>();
            foreach (var identityRole in identityRoles)
            {
                list.Add(identityRole.ToRole());
            }

            return list;
        }
    }
}

