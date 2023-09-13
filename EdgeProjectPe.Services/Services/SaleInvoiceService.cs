using AutoMapper;
using EdgeProjectPe.DB.Entities;
using EdgeProjectPe.DB.Repositories.Generic;
using EdgeProjectPe.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeProjectPe.Services.Services
{
    public interface ISaleInvoiceService
    {

        Task CreateSaleInvoiceAsync(SaleInvoiceDTO saleInv);
        void UpdateSaleInvoice(SaleInvoiceDTO saleInv);
        Task DeleteSaleInvoiceAsync(int id);
        Task<SaleInvoiceDTO> GetByIdAsync(int id);

    }
    public class SaleInvoiceService : ISaleInvoiceService
    {
        private readonly IGenericRepository<Saleinvoice> _saleInvRepository;
        private readonly IMapper _mapper;

        public SaleInvoiceService(IGenericRepository<Saleinvoice> saleInvRepository, IMapper mapper)
        {
            _saleInvRepository = saleInvRepository;
            _mapper=mapper;
        }
        public async Task CreateSaleInvoiceAsync(SaleInvoiceDTO saleInv)
        {
            var saleInvObj = _mapper.Map<Saleinvoice>(saleInv);
            await _saleInvRepository.Insert(saleInvObj);
            _saleInvRepository.Save();
        }

        public async Task DeleteSaleInvoiceAsync(int id)
        {
            var objSaleInv = await _saleInvRepository.GetById(id);
            if (objSaleInv != null)
            {
                await _saleInvRepository.Delete(objSaleInv);
                _saleInvRepository.Save();
            }
        }

        public async Task<SaleInvoiceDTO> GetByIdAsync(int id)
        {
            var objSale = await _saleInvRepository.GetById(id);
            return _mapper.Map<SaleInvoiceDTO>(objSale);
        }

        public void UpdateSaleInvoice(SaleInvoiceDTO saleInv)
        {
            var saleInvObj = _mapper.Map<Saleinvoice>(saleInv);
            _saleInvRepository.Update(saleInvObj);
            _saleInvRepository.Save();
        }
    }
}
