using ReservationManagement.APIs.Common;
using ReservationManagement.APIs.Dtos;

namespace ReservationManagement.APIs;

public interface IPaymentsService
{
    /// <summary>
    /// Create one Payment
    /// </summary>
    public Task<Payment> CreatePayment(PaymentCreateInput payment);

    /// <summary>
    /// Delete one Payment
    /// </summary>
    public Task DeletePayment(PaymentWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Payments
    /// </summary>
    public Task<List<Payment>> Payments(PaymentFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Payment records
    /// </summary>
    public Task<MetadataDto> PaymentsMeta(PaymentFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Payment
    /// </summary>
    public Task<Payment> Payment(PaymentWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Payment
    /// </summary>
    public Task UpdatePayment(PaymentWhereUniqueInput uniqueId, PaymentUpdateInput updateDto);

    /// <summary>
    /// Get a Reservation record for Payment
    /// </summary>
    public Task<Reservation> GetReservation(PaymentWhereUniqueInput uniqueId);
}
