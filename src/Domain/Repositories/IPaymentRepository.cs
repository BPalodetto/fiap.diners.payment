using Domain.Entities.PaymentAggregate;

namespace Domain.Repositories;

public interface IPaymentRepository
{
    Task<Payment> CreateAsync(Payment order, CancellationToken cancellationToken);
    Task UpdateAsync(Payment order, CancellationToken cancellationToken);
}
