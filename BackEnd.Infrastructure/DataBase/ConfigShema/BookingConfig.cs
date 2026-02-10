


using BackEnd.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Infrastructure.DataBase.ConfigShema;


public class BookingConfig : IEntityTypeConfiguration<BookingEntity>
{
    public void Configure(EntityTypeBuilder<BookingEntity> builder)
    {
        builder.ToTable("booking");

        builder.HasKey(x => x.BookingId);

        builder.Property(x => x.BookingId)
            .HasColumnName("booking_id")   // ojo: en tu CREATE TABLE la columna es booking_id, no "id"
            .HasColumnType("VARCHAR(64)")
            .IsRequired(true);

        builder.Property(x => x.Status)
            .HasColumnName("status")
            .HasColumnType("VARCHAR(16)")
            .IsRequired(false);

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("DATETIMEOFFSET")
            .IsRequired(true);

        builder.Property(x => x.StartAt)
            .HasColumnName("start_at")
            .HasColumnType("DATETIMEOFFSET")
            .IsRequired(true);

        builder.Property(x => x.Currency)
            .HasColumnName("currency")
            .HasColumnType("VARCHAR(3)")
            .HasDefaultValue("USD")
            .IsRequired(false);

        builder.Property(x => x.TotalAmount)
            .HasColumnName("total_amount")
            .HasColumnType("DECIMAL(18,2)")
            .IsRequired(true);

        builder.Property(x => x.PaidAmount)
            .HasColumnName("paid_amount")
            .HasColumnType("DECIMAL(18,2)")
            .IsRequired(true);

        builder.Property(x => x.SupplierId)
            .HasColumnName("supplier_id")
            .HasColumnType("VARCHAR(64)")
            .IsRequired(true);

        builder.Property(x => x.RatePlan)
            .HasColumnName("rate_plan")
            .HasColumnType("VARCHAR(16)")
            .IsRequired(true);

        builder.Property(x => x.PaymentMethod)
            .HasColumnName("payment_method")
            .HasColumnType("VARCHAR(16)")
            .IsRequired(true);

        builder.Property(x => x.CustomerEmail)
            .HasColumnName("customer_email")
            .HasColumnType("VARCHAR(128)")
            .IsRequired(true);



    }
}