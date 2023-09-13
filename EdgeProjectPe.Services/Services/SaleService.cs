using AutoMapper;
using EdgeProjectPe.DB.Entities;
using EdgeProjectPe.DB.Repositories.Generic;
using EdgeProjectPe.Services.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EdgeProjectPe.Services.Services
{
    public interface ISaleService
    {

        Task CreateSaleAsync(SaleDTO sale);
        void UpdateSale(SaleDTO sale);
        Task DeleteSaleAsync(int id);
        Task<SaleDTO> GetByIdAsync(int id);
        List<SalesProductDTO> GetProductsSales(int idCompany, DateTime startDate, DateTime endDate, int pageSize, int pageNumber);

    }
    public class SaleService : ISaleService
    {
        private readonly IGenericRepository<Sale> _saleRepository;
        private readonly IMapper _mapper;

        public SaleService(IGenericRepository<Sale> saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper=mapper;
        }
        public async Task CreateSaleAsync(SaleDTO sale)
        {
            var saleObj = _mapper.Map<Sale>(sale);
            await _saleRepository.Insert(saleObj);
            _saleRepository.Save();
        }

        public async Task DeleteSaleAsync(int id)
        {
            var objSale = await _saleRepository.GetById(id);
            if (objSale != null)
            {
                await _saleRepository.Delete(objSale);
                _saleRepository.Save();
            }
        }

        public async Task<SaleDTO> GetByIdAsync(int id)
        {
            var objSale = await _saleRepository.GetById(id);
            return _mapper.Map<SaleDTO>(objSale);
        }

        public void UpdateSale(SaleDTO sale)
        {
            var saleObj = _mapper.Map<Sale>(sale);
            _saleRepository.Update(saleObj);
            _saleRepository.Save();
        }
        public List<SalesProductDTO> GetProductsSales(int idCompany, DateTime startDate, DateTime endDate,int pageSize, int pageNumber)
        {
            var result = (from s in _saleRepository.Context.Sales
                          join p in _saleRepository.Context.Products on s.ProductId equals p.Id
                          join si in _saleRepository.Context.Saleinvoices on s.Id equals si.SaleId
                          join u in _saleRepository.Context.Units on p.UnitId equals u.Id                          
                          where p.CompanyId == idCompany && si.SaleDate >= startDate && si.SaleDate <= endDate
                         select new
                         {
                             p.Id,
                             p.Description,
                             u.Name,
                             p.UnitPrice,
                             s.Quantity,
                             s.SubTotal
                         }).Skip((pageNumber - 1) * pageSize).Take(pageSize);


            return new List<SalesProductDTO>();

        }

    }
}
