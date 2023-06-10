using AutoMapper;
using Microsoft.EntityFrameworkCore;
using N_Tier.Data.DAL;
using N_Tier.BusinessLogic.Abstractions;
using N_Tier.BusinessLogic.Models.DTO.Product;
using N_Tier.BusinessLogic.UnitOFWordk;
using N_Tier.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.BusinessLogic.Logics
{
    public class ProductsLogics
    {
        private readonly MyDataBaseDbContext _dataBase;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductsLogics(MyDataBaseDbContext dataBase, IMapper mapper)
        { 
            _dataBase = dataBase;
            _unitOfWork = new UnitOfWork(dataBase);
            _mapper = mapper;
        }
        public async Task<List<GetProductUIDTO>> ProductList()
        {
            List<GetProductUIDTO> p = new List<GetProductUIDTO>();
            List<Product> products = await _unitOfWork._productRepository.GetAll();
            foreach(var product in products)
            {
                p.Add(_mapper.Map<GetProductUIDTO>(product));
            }
            return p;
        }

        public async Task<bool> AddProduct(AddProductUIDTO p)
        {
            if(p != null)
            {
                var product = _mapper.Map<Product>(p);
                await _unitOfWork._productRepository.Add(product);
                int result = await _unitOfWork.Commit();
                if(result != -1)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateProduct(UpdateProductUIDTO p)
        {
            var product = await _unitOfWork._productRepository.GetById(p.Id);
            if(product != null)
            {
                _mapper.Map(p, product);
                int result = await _unitOfWork.Commit();
                if (result != -1)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        public async Task<Product> ProductById(int id)
        {
            var product = await _unitOfWork._productRepository.GetById(id);
            return product;
        }

        public async Task<bool> Deleteproduct(DeleteProductUIDTO p)
        {
            if(p != null)
            {
                var product = await _unitOfWork._productRepository.GetById(p.Id);
                if( product != null)
                {
                    _unitOfWork._productRepository.Delete(product);
                    int result = await _unitOfWork.Commit();
                if (result != -1)
                    return true;
                else
                    return false;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

    }
}
