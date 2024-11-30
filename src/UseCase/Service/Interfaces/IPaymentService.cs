using UseCase.Dtos;

namespace UseCase.Service.Interfaces;

public interface IPaymentService
{
    Task CreatePaymentAsync(CreatePaymentDto createPaymentDto, CancellationToken cancellationToken);
}
