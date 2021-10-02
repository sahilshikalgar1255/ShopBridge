using ShopBridgeApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeApi.Repositories.Interface
{
    public interface IProductService
    {
        Task<ResponseVM> AddProduct(ProductVM productmodel);
        Task<ResponseVM> GetAllProducts();
        Task<ResponseVM> GetProductByProductId(int ProductId);
        Task<ResponseVM> UpdateProduct(ProductVM ProductModel);
        Task<ResponseVM> DeleteProduct(int ProductId);
    }
}
