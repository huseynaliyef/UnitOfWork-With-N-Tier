using N_Tier.Data.DAL;
using N_Tier.BusinessLogic.Models.DTO.Catagory;
using N_Tier.BusinessLogic.UnitOFWordk;
using N_Tier.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.BusinessLogic.Logics
{
    public class CatagoryLogics
    {
        private readonly MyDataBaseDbContext _dataBase;
        private readonly IUnitOfWork _unitOfWork;
        public CatagoryLogics(MyDataBaseDbContext dataBase)
        {
            _dataBase = dataBase;
            _unitOfWork = new UnitOfWork(dataBase);
        }

        public async Task<bool> AddCatagory(AddCatagoryUIDTO catagory)
        {
            var existCatagory = await _unitOfWork._catagoryRepository.GetTableByExpresion(x=>x.CatagoryName == catagory.CatagoryName);
            if(existCatagory.Any())
            {
                var newCatagory = new Catagory { CatagoryName = catagory.CatagoryName };
                await _unitOfWork._catagoryRepository.Add(newCatagory);
                var result = await _unitOfWork.Commit();
                if(result != -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<bool> UpdateCatagory(UpdateCatagoryUIDTO catagory)
        {
            var existCatagory = await _unitOfWork._catagoryRepository.GetById(catagory.CatagoryId);
            if(existCatagory != null)
            {
                existCatagory.CatagoryName = catagory.CatagoryName;
                await _unitOfWork.Commit();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteCatagory(DeleteCatagoryUIDTO catagory)
        {
            var existCatagory = await _unitOfWork._catagoryRepository.GetById(catagory.CatagoryId);
            if (existCatagory != null)
            {
                _unitOfWork._catagoryRepository.Delete(existCatagory);
                await _unitOfWork.Commit();
                return true;
            }
            return false;
        }

        public async Task<List<Catagory>> CatagoryList()
        {
            var Catagories = await _unitOfWork._catagoryRepository.GetAll();
            return Catagories;
        }
    }
}
