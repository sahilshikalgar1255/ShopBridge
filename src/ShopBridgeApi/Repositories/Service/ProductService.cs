using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ShopBridgeApi.Data;
using ShopBridgeApi.Helpers;
using ShopBridgeApi.Models;
using ShopBridgeApi.Repositories.Interface;
using ShopBridgeApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopBridgeApi.Repositories.Service
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public ProductService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;

        }
        //Add New Product
        public async Task<ResponseVM> AddProduct(ProductVM ProductModel)
        {
            try
            {
                Product p = new Product();

                if (_dataContext.Product.Any(x => x.product_name.ToLower().Trim() == ProductModel.product_name.ToLower().Trim() || x.product_desc.ToLower().Trim() == ProductModel.product_desc.ToLower().Trim()))
                {
                    return new ResponseVM(0, ResponseMessage.Exist, true, StatusCodes.Status400BadRequest);
                }
                else
                {

                    p.product_name = ProductModel.product_name;
                    p.product_desc = ProductModel.product_desc;
                    p.price = ProductModel.price;
                    p.modify_ts = DateTime.Now;
                    p.create_user = 1; //Hard Code
                    p.modify_user = 1; //Hard Code
                    p.create_ts = DateTime.Now;
                    p.is_active = true;
                    _dataContext.Product.Add(p);
                    await _dataContext.SaveChangesAsync();

                    return new ResponseVM(p, ResponseMessage.Success, true, StatusCodes.Status200OK);

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }

        }

        // Get All Products from Products
        public async Task<ResponseVM> GetAllProducts()
        {
            try
            {

                List<Product> ProductList = await _dataContext.Product.Where(x => x.is_active == true).OrderByDescending(x => x.create_ts).ToListAsync();
                List<ProductVM> NewProductList = _mapper.Map<List<ProductVM>>(ProductList);
                return new ResponseVM(JsonSerializer.Serialize(NewProductList), ResponseMessage.Success, true, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
               
            }
        }

        // Get Product by Product Id
        public async Task<ResponseVM> GetProductByProductId(int ProductId)
        {
            try
            {

                Product p = await _dataContext.Product.Where(x => x.product_id == ProductId && x.is_active == true).FirstOrDefaultAsync();
                ProductVM ProductData = _mapper.Map<ProductVM>(p);
                return new ResponseVM(JsonSerializer.Serialize(ProductData), ResponseMessage.Success, true, StatusCodes.Status200OK);

            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }

        }

        // Update Record in Product
        public async Task<ResponseVM> UpdateProduct(ProductVM ProductModel)
        {

            try
            {
                var Result = _dataContext.Product.Where(x => x.product_id == ProductModel.product_id && x.is_active == true).FirstOrDefault();
                if (Result != null)
                {
                    if (_dataContext.Product.Any(x => x.product_name.ToLower().Trim() == ProductModel.product_name.ToLower().Trim() && x.product_id != ProductModel.product_id && x.is_active == true))
                    {
                        return new ResponseVM(0, ResponseMessage.Exist, true, StatusCodes.Status400BadRequest);
                    }

                    Result.product_name = ProductModel.product_name;

                    Result.product_desc = ProductModel.product_desc;
                    Result.price = ProductModel.price;

                    Result.modify_ts = DateTime.Now;
                    Result.modify_user = 1; //Hard Code


                    _dataContext.Entry(Result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    await _dataContext.SaveChangesAsync();

                    return new ResponseVM(JsonSerializer.Serialize(Result), ResponseMessage.Success, true, StatusCodes.Status200OK);
                }
                else
                {

                    return new ResponseVM(0, ResponseMessage.Error, true, StatusCodes.Status204NoContent);
                }

            }

            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }

        }

        //Delete Record from Product - Implemented Soft Delete by Is Active Status
        public async Task<ResponseVM> DeleteProduct(int ProductId)
        {
            try
            {

                var Result = _dataContext.Product.Where(x => x.product_id == ProductId && x.is_active == true).FirstOrDefault();

                Result.is_active = false;
                _dataContext.Entry(Result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _dataContext.SaveChangesAsync();

                return new ResponseVM(JsonSerializer.Serialize(Result), ResponseMessage.Success, true, StatusCodes.Status200OK);

            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }
        }

    }
}
