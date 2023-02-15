using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Migrations;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class ProductController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ImagesProvider imagesProvider;

        public ProductController(IProductsRepository productsRepository, ImagesProvider imagesProvider)
        {
            this.productsRepository = productsRepository;
            this.imagesProvider = imagesProvider;
        }

        public IActionResult Index()
        {
            return View();
        }     

        public IActionResult Get()
        {
            var productsDb = productsRepository.GetAll();

            var productsViewModels = new List<ProductViewModel>();
            foreach (var productDb in productsDb)
            {
                var productViewModel = new ProductViewModel
                {
                    Id = productDb.Id,
                    Name = productDb.Name,
                    Cost = productDb.Cost,
                    Description = productDb.Description,
                };
                productsViewModels.Add(productViewModel);
            }

            return View(productsViewModels);
        }
        
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddProductViewModel product)
        {            
            if (!ModelState.IsValid)
            {
                return View(product);               
            }

            var imagesPaths = imagesProvider.SafeFiles(product.UploadedFiles, ImageFolders.Products);

            productsRepository.Add(product.ToProduct(imagesPaths));
            return RedirectToAction("Get");


        }
        public IActionResult Remove(Guid id)
        {
            productsRepository.Remove(id);
            return RedirectToAction("Get");
        }

        public IActionResult Edit(Guid id)
        {
            var product = productsRepository.TryGetById(id);
            return View(product.ToEditProductViewModel());
        }

        [HttpPost]
        public IActionResult Edit(EditProductViewModel editedProduct)
        {
            if (!ModelState.IsValid)
            {
                return View(editedProduct);               
            }

            var imagesPaths = imagesProvider.SafeFiles(editedProduct.UploadedFiles, ImageFolders.Products);

            var productDb = editedProduct.ToProduct(imagesPaths);

            productsRepository.Edit(productDb);

            return RedirectToAction("Get");


        }
    }
}
