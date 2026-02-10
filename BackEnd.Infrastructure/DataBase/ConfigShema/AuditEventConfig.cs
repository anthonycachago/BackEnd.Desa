

using BackEnd.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Infrastructure.DataBase.ConfigShema;


public class AuditEventConfig : IEntityTypeConfiguration<AuditEventEntity>
{
    public void Configure(EntityTypeBuilder<AuditEventEntity> builder)
    {
        builder.ToTable("audit_event");

       
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("UNIQUEIDENTIFIER")
            .HasDefaultValueSql("NEWID()");

        builder.Property(x => x.BookingId)
            .HasColumnName("booking_id")
            .HasColumnType("VARCHAR(64)")
            .IsRequired();

        builder.Property(x => x.EventType)
            .HasColumnName("event_type")
            .HasColumnType("VARCHAR(32)")
           
            .IsRequired();

        builder.Property(x => x.OccurredAt)
            .HasColumnName("occurred_at")
            .HasColumnType("DATETIMEOFFSET")
            .IsRequired();

        builder.Property(x => x.CancelAt)
            .HasColumnName("cancel_at")
            .HasColumnType("DATETIMEOFFSET")
            .IsRequired();

        builder.Property(x => x.PenaltyPercent)
            .HasColumnName("penalty_percent")
            .HasColumnType("DECIMAL(5,2)")
            .IsRequired();

        builder.Property(x => x.PenaltyAmount)
            .HasColumnName("penalty_amount")
            .HasColumnType("DECIMAL(18,2)")
            .IsRequired();

        builder.Property(x => x.RefundAmount)
            .HasColumnName("refund_amount")
            .HasColumnType("DECIMAL(18,2)")
            .IsRequired();

        builder.Property(x => x.SupplierNotified)
            .HasColumnName("supplier_notified")
            .HasColumnType("BIT")
            .IsRequired();

        builder.Property(x => x.Notes)
            .HasColumnName("notes")
            .HasColumnType("VARCHAR(MAX)")
            .IsRequired(false);

        builder.Property(x => x.Actor)
            .HasColumnName("actor")
            .HasColumnType("VARCHAR(64)")
            .IsRequired();

        builder.Property(x => x.Reason)
            .HasColumnName("reason")
            .HasColumnType("VARCHAR(64)")
            .IsRequired();

        // FK con Booking
        builder.HasOne<BookingEntity>()
            .WithMany()
            .HasForeignKey(x => x.BookingId)
            .HasConstraintName("FK_AuditEvent_Booking");



    }
}