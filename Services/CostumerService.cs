using Dws.Note_one.Api.Domain.Models;
using Dws.Note_one.Api.Services.IServices;
using Dws.Note_one.Api.Persistence.Repositories.IRepositories;
using Dws.Note_one.Api.Services.Communication;

namespace Dws.Note_one.Api.Services
{
    public class CostumerService : ICostumerService
    {
        private readonly ICostumerRepository _costumerRepository;
        private readonly IUnitOfWork _unitOfWork;


        public CostumerService(ICostumerRepository costumerRepository, IUnitOfWork unitOfWork)
        {
            _costumerRepository = costumerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Costumer>> ListAsync()
        {
            return await _costumerRepository.ListAsync();
        }

        public async Task<CostumerResponse> FindByIdAsync(int id)
        {
            var existingCostumer = await _costumerRepository.FindByIdAsync(id);

            if (existingCostumer == null)
            {
                return new CostumerResponse("Costumer not found.");
            }
            else 
            {
                return new CostumerResponse(existingCostumer);
            }
        }
        public async Task<CostumerResponse> FindByNameAsync(string name)
        {
            var existingCostumer = await _costumerRepository.FindByNameAsync(name);

            if (existingCostumer == null)
            {
                return new CostumerResponse("Costumer not found.");
            }
            else 
            {
                return new CostumerResponse(existingCostumer);
            }
            
        }

        public async Task<IEnumerable<Costumer>> ListByPositiveCreditAsync()
        {
            return await _costumerRepository.ListByPositiveCreditAsync();
        }

        public async Task<IEnumerable<Costumer>> ListByNegativeCreditAsync()
        {
            return await _costumerRepository.ListByNegativeCreditAsync();
        }
        public async Task<CostumerResponse> SaveAsync(Costumer costumer)
        {
            try
            {
                await _costumerRepository.AddAsync(costumer);
                await _unitOfWork.CompleteAsync();

                return new CostumerResponse(costumer);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CostumerResponse($"An error occurred when saving the Costumer: {ex.Message}");
            }
        }

        public async Task<CostumerResponse> UpdateAsync(int id, Costumer costumer)
        {

            var existingCostumer = await _costumerRepository.FindByIdAsync(id);

            if (existingCostumer == null)
                return new CostumerResponse("Costumer not found.");

            existingCostumer.Name = costumer.Name;
            existingCostumer.Email = costumer.Email;
            existingCostumer.PhoneNumber = costumer.PhoneNumber;
            existingCostumer.Credit = costumer.Credit;

            try
            {
                _costumerRepository.Update(existingCostumer);
                await _unitOfWork.CompleteAsync();

                return new CostumerResponse(existingCostumer);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CostumerResponse($"An error occurred when updating the Costumer: {ex.Message}");
            }
        }

        public async Task<CostumerResponse> DeleteAsync(int id)
        {
            var existingCostumer = await _costumerRepository.FindByIdAsync(id);

            if (existingCostumer == null)
                return new CostumerResponse("Costumer not found.");

            try
            {
                _costumerRepository.Remove(existingCostumer);
                await _unitOfWork.CompleteAsync();

                return new CostumerResponse(existingCostumer);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CostumerResponse($"An error occurred when deleting the Costumer: {ex.Message}");
            }
        }
    }
}