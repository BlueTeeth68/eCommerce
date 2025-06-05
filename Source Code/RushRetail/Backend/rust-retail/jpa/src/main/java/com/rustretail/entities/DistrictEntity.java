package com.rustretail.entities;

import jakarta.persistence.Entity;
import jakarta.persistence.Table;
import lombok.*;

@Entity
@Table(name = "district")
@Getter
@Setter
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class DistrictEntity extends BaseAddressEntity {
}
