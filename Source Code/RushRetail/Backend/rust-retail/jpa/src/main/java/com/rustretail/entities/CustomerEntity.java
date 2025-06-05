package com.rustretail.entities;

import com.ecommerce.rustretail.enums.Gender;
import jakarta.persistence.*;
import lombok.*;
import org.springframework.stereotype.Indexed;

import java.math.BigDecimal;
import java.time.Instant;
import java.util.Set;

@Entity
@Table(name = "customer",
        indexes = {},
        uniqueConstraints = {
                @UniqueConstraint(name = "unique_phone", columnNames = "phone")
        }
)
@Getter
@Setter
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class CustomerEntity extends BaseEntity {

    @Column(name = "first_name")
    private String firstName;
    @Column(name = "last_name")
    private String lastName;
    @Column(name = "email")
    private String email;
    @Column(name = "phone")
    private String phone;
    @Column(name = "tags")
    private String tags;
    @Column(name = "note")
    private String note;
    @Column(name = "gender")
    @Enumerated(EnumType.STRING)
    private Gender gender;
    @Column(name = "birthday")
    private Instant birthday;
    @Column(name = "last_order_date")
    private Instant lastOrderDate;
    @Column(name = "last_order_name")
    private String lastOrderName;
    @Column(name = "total_spent")
    private BigDecimal totalSpent;
    @Column(name = "total_paid")
    private BigDecimal totalPaid;
    @Column(name = "order_count")
    private int orderCount;

    @OneToMany(fetch = FetchType.LAZY, mappedBy = "customer", cascade = CascadeType.ALL, orphanRemoval = true)
    private Set<CustomerAddressEntity> addresses;
}
