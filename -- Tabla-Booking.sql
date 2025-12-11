-- Tabla Booking
CREATE TABLE booking (
    booking_id       VARCHAR(64) PRIMARY KEY,
    status           VARCHAR(16) CHECK (status IN ('CONFIRMED', 'CANCELLED')),
    created_at       DATETIMEOFFSET NOT NULL,
    start_at         DATETIMEOFFSET NOT NULL,
    currency         VARCHAR(3) DEFAULT 'USD',
    total_amount     DECIMAL(18,2) NOT NULL,
    paid_amount      DECIMAL(18,2) NOT NULL,
    supplier_id      VARCHAR(64) NOT NULL,
    rate_plan        VARCHAR(16) CHECK (rate_plan IN ('FLEX', 'SEMI_FLEX', 'NON_REFUNDABLE')),
    payment_method   VARCHAR(16) CHECK (payment_method IN ('CARD', 'TRANSFER')),
    customer_email   VARCHAR(128) NOT NULL
);

select *from booking
select *from audit_event

INSERT INTO booking (
    booking_id,
    status,
    created_at,
    start_at,
    currency,
    total_amount,
    paid_amount,
    supplier_id,
    rate_plan,
    payment_method,
    customer_email
)
VALUES
('BKG-1001', 'CONFIRMED', SYSDATETIMEOFFSET(), '2025-12-20T10:00:00Z', 'USD', 200, 200, 'SUP-01', 'FLEX', 'CARD', 'a@cliente.com'),
('BKG-1002', 'CONFIRMED', SYSDATETIMEOFFSET(), '2025-12-15T10:00:00Z', 'USD', 150, 150, 'SUP-02', 'SEMI_FLEX', 'CARD', 'b@cliente.com'),
('BKG-1003', 'CANCELLED', SYSDATETIMEOFFSET(), '2025-12-12T08:00:00Z', 'USD', 300, 300, 'SUP-03', 'NON_REFUNDABLE', 'CARD', 'c@cliente.com');

-- Tabla AuditEvent
CREATE TABLE audit_event (
    id                UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    booking_id        VARCHAR(64) NOT NULL,
    event_type        VARCHAR(32) CHECK (event_type = 'CANCELLATION_RECORDED'),
    occurred_at       DATETIMEOFFSET NOT NULL,
    cancel_at         DATETIMEOFFSET NOT NULL,
    penalty_percent   DECIMAL(5,2) NOT NULL,
    penalty_amount    DECIMAL(18,2) NOT NULL,
    refund_amount     DECIMAL(18,2) NOT NULL,
    supplier_notified BIT NOT NULL,
    notes             VARCHAR(MAX) NULL,
    actor             VARCHAR(64) NOT NULL,
    reason            VARCHAR(64) NOT NULL,
    CONSTRAINT FK_AuditEvent_Booking FOREIGN KEY (booking_id)
        REFERENCES Booking (booking_id)
);
select *from audit_event