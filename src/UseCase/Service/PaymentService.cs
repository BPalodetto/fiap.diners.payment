using Domain.Entities.PaymentAggregate;
using Domain.Gateways;
using Domain.Repositories;
using UseCase.Dtos;
using UseCase.Service.Interfaces;

namespace UseCase.Service;

public class PaymentService : IPaymentService
{
    private readonly IPaymentGateway _paymentGateway;
    private readonly IPaymentRepository _paymentRepository;
    public PaymentService(IPaymentGateway paymentGateway, IPaymentRepository paymentRepository)
    {
        _paymentGateway = paymentGateway;
        _paymentRepository = paymentRepository;
    }
    public async Task CreatePaymentAsync(CreatePaymentDto createPaymentDto, CancellationToken cancellationToken)
    {
        Payment payment = new Payment()
        {
            ExternalId = createPaymentDto.ExternalId,
            PaymentMethod = createPaymentDto.PaymentMethod,
            Amount = createPaymentDto.Price
        };

        payment = await _paymentRepository.CreateAsync(payment, cancellationToken);

        await _paymentGateway.CreatePayment(payment, cancellationToken);

        await _paymentRepository.UpdateAsync(payment, cancellationToken);
    }
}
