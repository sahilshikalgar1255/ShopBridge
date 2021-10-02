using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBridgeApi.Repositories.Interface;
using ShopBridgeApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //Add New Product in product - Implemented Add and Update in one Method , and Managed by Product id
        [HttpPost("addproduct")]
        public async Task<IActionResult> AddProduct([FromBody] ProductVM ProductModel)
        {
            try
            {
                //Add And update break type condition 
                if (ProductModel.product_id == 0)
                {
                    return Ok(await _productService.AddProduct(ProductModel));
                }
                else
                {
                    return Ok(await _productService.UpdateProduct(ProductModel));
                }


            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get All Products from product
        [HttpGet("getallproducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                return Ok(await _productService.GetAllProducts());

            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get Product By product Id
        [HttpGet("getproductbyid")]
        public async Task<IActionResult> GetProductByProductId(int ProductId)
        {
            try
            {
                return Ok(await _productService.GetProductByProductId(ProductId));

            }
            catch (Exception)
            {
                throw;
            }
        }
    


            [HttpPost("updateproduct")]
            public async Task<IActionResult> UpdateProduct([FromBody] ProductVM ProductModel)
            {

                try
                {

                    return Ok(await _productService.UpdateProduct(ProductModel));

                }
                catch (Exception)
                {
                    throw;
                }
            }

        //Delete Product From Product
        [HttpGet("deleteproduct")]
        public async Task<IActionResult> DeleteProduct(int ProductId)
        {
            try
            {
                return Ok(await _productService.DeleteProduct(ProductId));

            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
