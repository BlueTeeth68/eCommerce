package com.rustretail.entities;

import jakarta.persistence.Entity;
import jakarta.persistence.Table;
import lombok.*;

@Entity
@Table(name = "ward")
@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
@Builder
public class WardEntity extends BaseAddressEntity {
}
